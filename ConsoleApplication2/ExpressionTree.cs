using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCareerQuestionsSearch
{
	public class ExpressionTree
	{

	}


	public class Node<T>
	{
		private T data;
		private T initialVal;
		private NodeList<T> neighbors = null;
		public Node()
		{

		}

		public Node(T data, T val) : this(data,null, val){}
		public Node(T data, NodeList<T> neighbors, T val)
		{
			this.data = data;
			this.neighbors = neighbors;
			this.initialVal = val;
		}

		public T Value
		{
			get
			{
				return data;
			}
			set
			{
				data = value;
			}
		}

		public T InitialValue
		{
			get
			{
				return initialVal;
			}
			set
			{
				initialVal = value;
			}
		}

		protected NodeList<T> Neighbors
		{
			get
			{
				return neighbors;
			}
			set
			{
				neighbors = value;
			}
		}

	}

	public class NodeList<T> : Collection<Node<T>>
	{
		public NodeList() : base() { }

		public NodeList(int initialSize)
		{
			// Add the specified number of items
			for (int i = 0; i < initialSize; i++)
				base.Items.Add(default(Node<T>));
		}

		public Node<T> FindByValue(T value)
		{
			// search the list for the value
			foreach (Node<T> node in Items)
				if (node.Value.Equals(value))
					return node;

			// if we reached here, we didn't find a matching node
			return null;
		}
	}

	public class BinaryTree<T>
	{
		private BinaryTreeNode<T> root;

		public BinaryTree()
		{
			root = null;
		}

		public virtual void Clear()
		{
			root = null;
		}

		public BinaryTreeNode<T> Root
		{
			get
			{
				return root;
			}
			set
			{
				root = value;
			}
		}
	}

	public class BinaryTreeNode<T> : Node<T>
	{
		public BinaryTreeNode() : base() { }
		public BinaryTreeNode(T data, T underlyingValue) : base(data, null, underlyingValue) { }
		public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
		{
			base.Value = data;
			NodeList<T> children = new NodeList<T>(2);
			children[0] = left;
			children[1] = right;
			base.Neighbors = children;
		}

		public BinaryTreeNode<T> Left
		{
			get
			{
				if (base.Neighbors == null)
					return null;
				else
					return (BinaryTreeNode<T>)base.Neighbors[0];
			}
			set
			{
				if (base.Neighbors == null)
					base.Neighbors = new NodeList<T>(2);

				base.Neighbors[0] = value;
			}
		}

		public BinaryTreeNode<T> Right
		{
			get
			{
				if (base.Neighbors == null)
					return null;
				else
					return (BinaryTreeNode<T>)base.Neighbors[1];
			}
			set
			{
				if (base.Neighbors == null)
					base.Neighbors = new NodeList<T>(2);

				base.Neighbors[1] = value;
			}
		}
	}

}
