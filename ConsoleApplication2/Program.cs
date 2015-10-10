using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCareerQuestionsSearch
{
	class Program
	{
		public static Stack<string> CalcStack = new Stack<string>();
		static void Main(string[] args)
		{
			//Format: Each integer is separated by a space. The value we're looking for is the last entry in the string
			var testInput = "4 5 6 7 8 30";
			var inputSplit = testInput.Split(' ').Select(p => int.Parse(p));
			BinaryTree<int> tree = new BinaryTree<int>();
			tree.Root = new BinaryTreeNode<int>(inputSplit.First(), inputSplit.First());
			AddNodes(tree.Root, inputSplit.Skip(1).Take(inputSplit.Count() - 1));
			var res = FindNode(tree.Root, inputSplit.Last());
			if (res != null)
			{
				Console.WriteLine("Found it!");
				while (CalcStack.Count > 0)
				{
					Console.Write(CalcStack.Pop());
				}
				Console.Write("=" + inputSplit.Last());
			}
			else
			{
				Console.WriteLine("Nope");
			}
			Console.Read();
		}

		public static void AddNodes(BinaryTreeNode<int> node, IEnumerable<int> nodes)
		{
			if (nodes.Any())
			{
				var multiplied = node.Value * nodes.First();
				var added = node.Value + nodes.First();
				
				node.Left = new BinaryTreeNode<int>(added, nodes.FirstOrDefault());
				node.Right = new BinaryTreeNode<int>(multiplied, nodes.FirstOrDefault());
				nodes = nodes.Skip(1);
				AddNodes(node.Left, nodes);
				AddNodes(node.Right, nodes);
			}
		}

		public static BinaryTreeNode<int> FindNode(BinaryTreeNode<int> node, int searchValue)
		{
			if (node != null)
			{
				if (node.Value == searchValue)
				{
					CalcStack.Push(node.InitialValue.ToString());
					return node;
				}
				else
				{
					var right = FindNode(node.Right, searchValue);
					if (right != null)
					{
						CalcStack.Push("*");
						CalcStack.Push(node.InitialValue.ToString());
						return right;
					}
					else
					{
						var left = FindNode(node.Left, searchValue);
						if (left != null)
						{
							CalcStack.Push("+");
							CalcStack.Push(node.InitialValue.ToString());
							return left;
						}
					}
				}
			}
			return null;
		}
	}
}
