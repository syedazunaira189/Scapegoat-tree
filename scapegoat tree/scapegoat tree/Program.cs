using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17b_103_se_17b_101_se
{
    class Program
    {
        static void Main(string[] args)
        {

            ScapegoatTree s = new ScapegoatTree();
            Console.WriteLine("SCAPE GOAT TREE");
            Console.WriteLine("INSERTED ELEMENTS");
            s.Add(3);
            s.Add(4);
            s.Add(5);
            s.Add(6);
            s.Add(7);
            s.Add(0);
            Console.WriteLine("Inorder");
            s.InOrder();
            Console.WriteLine("Postorder");
            s.PostOrder();
            Console.WriteLine("preorder");
            s.PreOrder();
            Console.WriteLine("DELETE ELEMENT");
            s.Delete(6);
            Console.WriteLine("Inorder");
            s.InOrder();
            Console.WriteLine("Postorder");
            s.PostOrder();
            Console.WriteLine("preorder");
            s.PreOrder();
        }
    }

    public class SNode
    {
        public int data;
        public SNode left;
        public SNode right;
        public SNode parent;
        public SNode siblings;
        public SNode()
        {
            Initialize();
        }

        public SNode(int e)
        {
            this.data = e;
            Initialize();
        }

        private void Initialize()
        {
            siblings = null;
            parent = null;
            left = null;
            right = null;

        }

    }
    public class ScapegoatTree
    {
        private SNode root;
        public ScapegoatTree()
        {
            initialize();
        }
        private void initialize()
        {
            this.root = null;
        }
        public void InOrder()
        {
            InOrder(root);
        }

        public void PreOrder()
        {
            PreOder(root);
        }

        public void PostOrder()
        {
            PostOder(root);
        }

        private void InOrder(SNode node)
        {
            if (node == null)
                return;
            InOrder(node.left);
            Console.WriteLine(node.data);
            InOrder(node.right);
        }

        private void PreOder(SNode node)
        {
            if (node == null)
                return;

            Console.WriteLine(node.data);
            PreOder(node.left);
            PreOder(node.right);
        }

        private void PostOder(SNode node)
        {
            if (node == null)
                return;

            PostOder(node.left);
            PostOder(node.right);
            Console.WriteLine(node.data);
        }
        //function for calculating height of Node or Tree
        public int Height()
        {
            return Height(root);
        }

        public int Height(SNode node)
        {
            if (node == null)  //case 1 : if root is null then height don't exist 
                return -1;

            int l = Height(node.left);
            int r = Height(node.right);

            if (l > r)         //case 2 : if height of left subtree > right subtree 
                return l + 1;  // adding 1 (height of node root) in height of left subtree
            else               //case 2 : if height of left subtree < right subtree 
                return r + 1;  // adding 1 (height of node root) in height of right subtree
        }
        //function for calculating size of any node
        public int Size()
        {
            return Size(root);
        }

        public int Size(SNode node)
        {
            if (node == null)
                return 0;
            ///return total size
            return 1 + Size(node.left) + Size(node.right);
        }
        public SNode Successor(SNode node)
        {
            if (node == null)
                return null;

            return Minimum(node.right);
        }

        public SNode Predecessor(SNode node)
        {
            if (node == null)
                return null;

            return Maximum(node.left);
        }

        public SNode Minimum(SNode node)
        {
            if (node == null)
                return null;

            if (node.left == null)
                return node;
            else
                return Minimum(node.left);
        }

        public SNode Maximum(SNode node)
        {
            if (node == null)
                return null;

            if (node.right == null)
                return node;
            else
                return Maximum(node.right);
        }

        public void Delete(int e)
        {
            SNode n = new SNode(e);
            root = Delete(root, e);
            int height = 0;
            height = Height(n);
            //checking the height of Node 
            //then finding scapegoat Node  
            if (height > (log32(height)))
            {
                find_scapegoat(n);
            }
        }

        public SNode Delete(SNode node, int e)
        {
            if (node == null)
                return null;

            if (node.data == e)
            {
                // case 1 - left and right child both are empty - return null
                if (node.left == null && node.right == null)
                    return null;
                // case 2 - left child is not empty - connect parent with left child
                if (node.left != null && node.right == null)
                    return node.left;
                // case 2 - right child is not empty - connect parent with right child
                if (node.right != null && node.left == null)
                    return node.right;
                // nothing like above then
                // both children are not empty
                if (node.right != null)
                {
                    SNode succ = Successor(node);
                    node.data = succ.data;
                    node.right = Delete(node.right, succ.data);
                }
                else
                {
                    SNode pred = Predecessor(node);
                    node.data = pred.data;
                    node.left = Delete(node.left, pred.data);
                }

                return node;
            }

            if (e < node.data)
                node.left = Delete(node.left, e);
            else
                node.right = Delete(node.right, e);


            int h;
            h = Height();
            return node;
        }
        // function for inserting a new Node
        public void Add(int e)
        {
            SNode n = new SNode(e); //creating new Node
            root = Add(root, e); //calling another function for different conditions
            int height = 0;
            height = Height(n);
            //checking the height of Node 
            //then finding scapegoat Node
            if (height > (log32(height)))
            {
                find_scapegoat(n);
            }
        }
        private SNode Add(SNode node, int e)
        { //case 1- if root is null then set inserted value as root 
            if (node == null)
            {
                node = new SNode(e);
                return node;
            }
            //case2 - if value is less than root adding it as left sub tree
            if (e < node.data)
                node.left = Add(node.left, e);
            // case 3 - if value is greater than root adding it as right sub tree
            else
                node.right = Add(node.right, e);
            //returning root 
            return node;
        }
        // function to finding a scapegoat node
        public void find_scapegoat(SNode n)
        {
            SNode N = n.parent;

            int totalsize = Size(n);// size() is argumented function for finding totalsize of any node


            //  value of alpha is 0.6 or (2/3)
            // checking whether the ratio of sizes of inserted_node.parent and inserted_node.parent.parent is > alpha
            // using this as --- 3 * Size(N) <= 2 * Size(N.parent)
            while (3 * Size(N) <= 2 * Size(N.parent))
            {
                N = N.parent;
            }
            Rebuild_Tree(N.parent);//here N.parent is scapegoat node
        }

        // this function will return the tree rooted at scapegoat node
        public void Rebuild_Tree(SNode u)
        {
            int size = Size(u);
            SNode p = u.parent;
            SNode[] array = new SNode[size];
            packIntoArray(u, array, 0);
            if (p == null) //case 1 : if parent of scapeoat node is null
            {
                root = Build_Balanced_Tree(array, 0, size);
                root.parent = null;
            }
            else if (p.right == u)
            {
                p.right = Build_Balanced_Tree(array, 0, size);
                p.right.parent = p;
            }
            else
            {
                p.left = Build_Balanced_Tree(array, 0, size);
                p.left.parent = p;
            }
        }
        //packing  nodes in a an array
        //this function will return index of array of nodes  
        public int packIntoArray(SNode u, SNode[] a, int i)
        {
            if (u == null)
            {
                return i;
            }
            i = packIntoArray(u.left, a, i);
            a[i++] = u;
            return packIntoArray(u.right, a, i);
        }
        // this function willl return balanced tree
        public SNode Build_Balanced_Tree(SNode[] array, int i, int nsize)
        {
            if (nsize == 0)
            {
                return null;
            }
            int m = nsize / 2;
            array[i + m].left = Build_Balanced_Tree(array, i, m);
            if (array[i + m].left != null)
            {
                array[i + m].left.parent = array[i + m];
            }
            array[i + m].right = Build_Balanced_Tree(array, i + m + 1, nsize - m - 1);
            if (array[i + m].right != null)
            {
                array[i + m].right.parent = array[i + m];
            }
            return array[i + m];
        }

        //this function will return the value of log 
        public static double log32(int q)
        {
            double x = Math.Log(q, 0.6);
            return x;


        }


    }
}



