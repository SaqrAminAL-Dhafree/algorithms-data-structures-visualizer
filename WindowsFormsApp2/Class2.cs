using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class BinaryTree
    { 
            public Node Root;

            public BinaryTree()
            {
                Root = null;
            }

            public void BuildTree(int nodeCount)
            {
                if (nodeCount <= 0) return;

                Queue<Node> queue = new Queue<Node>();
                Root = new Node(1); // الجذر يبدأ دائمًا من 1
                queue.Enqueue(Root);

                int currentValue = 2; // القيمة التالية لكل عقدة
                while (currentValue <= nodeCount)
                {
                    Node current = queue.Dequeue();

                    // إضافة العقدة اليسرى إذا كان هناك عدد كافٍ من العقد
                    if (currentValue <= nodeCount)
                    {
                        current.Left = new Node(currentValue++);
                        queue.Enqueue(current.Left);
                    }

                    // إضافة العقدة اليمنى إذا كان هناك عدد كافٍ من العقد
                    if (currentValue <= nodeCount)
                    {
                        current.Right = new Node(currentValue++);
                        queue.Enqueue(current.Right);
                    }
                }
            }


            public List<string> PreOrderTraversal(Node node, List<string> steps)
            {
                if (node == null) return steps;

                steps.Add($"Visit: {node.Value}");
                PreOrderTraversal(node.Left, steps);
                PreOrderTraversal(node.Right, steps);

                return steps;
            }

            public List<string> InOrderTraversal(Node node, List<string> steps)
            {
                if (node == null) return steps;

                InOrderTraversal(node.Left, steps);
                steps.Add($"Visit: {node.Value}");
                InOrderTraversal(node.Right, steps);

                return steps;
            }

            public List<string> PostOrderTraversal(Node node, List<string> steps)
            {
                if (node == null) return steps;

                PostOrderTraversal(node.Left, steps);
                PostOrderTraversal(node.Right, steps);
                steps.Add($"Visit: {node.Value}");

                return steps;
            }

            public int GetHeight(Node node)
            {
                if (node == null) return 0;

                int leftHeight = GetHeight(node.Left);
                int rightHeight = GetHeight(node.Right);

                return Math.Max(leftHeight, rightHeight) + 1;
            }
        
    }
}
