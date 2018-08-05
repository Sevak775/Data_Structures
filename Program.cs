using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_Tree
{
   public class Node
    {
        public int data;
        public Node left;
        public Node right;
        public int height;

        public Node(int data)
        {
            this.data = data;
            height = 1;
        }
    }


    public class AVLTree
    {
       
        public int Get_Balance(Node n)
        {
            if (n != null)
            {
                return (Get_Height(n.left) - Get_Height(n.right));
            }
            return 0;
        }

        public int Get_Height(Node n)
        {
            if (n != null)
            {
                return n.height;
            }
            return 0;
        }

        public Node Right_rotate(Node y)
        {
            Node x = y.left;
            Node T2 = x.right;

            // Rotation
            x.right = y;
            y.left = T2;

            // update their heights
            x.height = Math.Max(Get_Height(x.left), Get_Height(x.right)) + 1;
            y.height = Math.Max(Get_Height(y.left), Get_Height(y.right)) + 1;

            return x;
        }

        public Node Left_Rotate(Node x)
        {
            Node y = x.right;
            Node T2 = y.left;

            // Rotation
            y.left = x;
            x.right = T2;

            // update their heights
            x.height = Math.Max(Get_Height(x.left), Get_Height(x.right)) + 1;
            y.height = Math.Max(Get_Height(y.left), Get_Height(y.right)) + 1;

            return y;
        }

        public Node Insert(Node node, int data)
        {
            if (node == null)
            {
                return (new Node(data));
            }
            if (node.data > data)
            {
                node.left = Insert(node.left, data);
            }
            else
            {
                node.right = Insert(node.right, data);
            }
            // update the node height
            node.height = Math.Max(Get_Height(node.left), Get_Height(node.right)) + 1;

            int balDiff = Get_Balance(node);

            // Left Rotate
            if (balDiff > 1 && data < node.left.data)
            {
                return Right_rotate(node);
            }

            // Right Rotate
            if (balDiff < -1 && data > node.right.data)
            {
                return Left_Rotate(node);
            }

            // Left Right Rotate
            if (balDiff > 1 && data > node.left.data)
            {
                node.left = Left_Rotate(node.left);
                return Right_rotate(node);
            }

            // Right Left Rotate
            if (balDiff < -1 && data < node.right.data)
            {
                node.right = Right_rotate(node.right);
                return Left_Rotate(node);
            }

            return node;
        }

      
    }

    class Program
    {
        static void Main(string[] args)
        {
            Node root = null;
            AVLTree i = new AVLTree();
            root = i.Insert(root, 4);
            root = i.Insert(root, 2);
            root = i.Insert(root, 3);
            root = i.Insert(root, 8);
            root = i.Insert(root, 6);
            root = i.Insert(root, 15);                          
           
        }
    }
}
