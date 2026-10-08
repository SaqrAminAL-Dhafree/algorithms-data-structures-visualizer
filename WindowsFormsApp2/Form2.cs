using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        private BinaryTree tree;
        private List<string> traversalSteps ; // قائمة لتخزين خطوات الاجتياز
        private int currentStepIndex;
        private TextBox[,] adjacencyMatrixInputs;
        private TextBox[,] weightMatrixInputs;
        private int[,] adjacencyMatrix;
        private int[,] weightMatrix;
        private int matrixSize = 6;
        private string[] vertexNames;
        private bool adjacencySaved = false;
        private int currentStep = 0; // عداد الخطوة الحالية
        private List<Action> stepsQueue = new List<Action>(); // قائمة الخطوات

        private List<Edge> primEdges = new List<Edge>();
       

       
        public Form2()
        {


            //InitializeComponent();
            InitializeTree();
            tree = new BinaryTree();
            InitializeComponent();
            this.Text = "Graph Visualization";
            adjacencyMatrix = new int[matrixSize, matrixSize];
            weightMatrix = new int[matrixSize, matrixSize];
            update_weight.Enabled = false;
            delete_weightt.Enabled = false;
            update_adjacency.Enabled = false;
            delete_adjacency.Enabled = false;
            if_tree.Enabled = false;
            if_graph.Enabled = false;
            undirect_graph.Enabled = false; 
            direct_graph.Enabled = false;
            unweighted_graph.Enabled = false;
            weighted_graph.Enabled = false;
            save_adjacency.Enabled = false;
            save_weight.Enabled=false;

            labels_points.Enabled = false;
            undirect_graph.Checked = true;
            weighted_graph.Checked = true;
            number_points.TextChanged += (s, e) => EnableLabelsPoints();
            labels_points.TextChanged += (s, e) => ApplyLabels();

          //  save_adjacency.Click += SaveAdjacency_Click;
            update_weight.Click += UpdateAdjacency_Click;
            delete_weightt.Click += DeleteAdjacency_Click;
            update_weight.Enabled = false;

            panelGraph.Paint += PanelGraph_Paint;
            direct_graph.CheckedChanged += DirectGraph_CheckedChanged;
            if_tree.CheckedChanged += If_tree_CheckedChanged;
            if_graph.CheckedChanged += If_graph_CheckedChanged;
           
            button2.Visible = false;

            comboBox1.Items.AddRange(new string[] { "  " });
            comboBox2.Items.AddRange(new string[] { "", "" });
            comboBox3.Items.AddRange(new string[] { "", "" });
        }
        private void InitializeTree()
        {

        }
        private void DrawTreeWithSteps(Graphics g, Node node, int x, int y, int offsetX, int offsetY, int stepIndex)
        {
            if (node == null) return;

            // تلوين العقدة الحالية إذا كانت في الخطوة المحددة
            if (stepIndex >= 0 && traversalSteps[stepIndex].Contains($"Visit: {node.Value}"))
            {
                g.FillEllipse(Brushes.Yellow, x - 15, y - 15, 30, 30);
            }
            else
            {
                g.FillEllipse(Brushes.LightBlue, x - 15, y - 15, 30, 30);
            }

            g.DrawString(node.Value.ToString(), new Font("Arial", 10), Brushes.Black, x - 10, y - 10);

            // رسم العقد الفرعية
            if (node.Left != null)
            {
                g.DrawLine(Pens.Black, x, y, x - offsetX, y + offsetY);
                DrawTreeWithSteps(g, node.Left, x - offsetX, y + offsetY, offsetX / 2, offsetY, stepIndex);
            }

            if (node.Right != null)
            {
                g.DrawLine(Pens.Black, x, y, x + offsetX, y + offsetY);
                DrawTreeWithSteps(g, node.Right, x + offsetX, y + offsetY, offsetX / 2, offsetY, stepIndex);
            }
        }
         
        private void DrawTree(Graphics g, Node node, int x, int y, int offsetX, int offsetY)
        {
            if (node == null) return;

            // رسم العقدة
            g.FillEllipse(Brushes.LightBlue, x - 15, y - 15, 30, 30);
            g.DrawString(node.Value.ToString(), new Font("Arial", 10), Brushes.Black, x - 10, y - 10);

            // رسم الفروع والعقد الفرعية
            if (node.Left != null)
            {
                g.DrawLine(Pens.Black, x, y, x - offsetX, y + offsetY);
                DrawTree(g, node.Left, x - offsetX, y + offsetY, offsetX / 2, offsetY);
            }

            if (node.Right != null)
            {
                g.DrawLine(Pens.Black, x, y, x + offsetX, y + offsetY);
                DrawTree(g, node.Right, x + offsetX, y + offsetY, offsetX / 2, offsetY);
            }
        }


        public static void  pane(Panel panelGraph ,ComboBox comboBox1,Label label1) 
        {

        }   
      
        private void EnableLabelsPoints()
        {
            if (int.TryParse(number_points.Text, out int parsedMatrixSize) && parsedMatrixSize > 0)
            {
                matrixSize = parsedMatrixSize;
                labels_points.Enabled = true;
                if_graph.Enabled = true;
                if_tree.Enabled = true;
                weighted_graph.Enabled = true;
                unweighted_graph.Enabled = true;
                direct_graph.Enabled = true;
                undirect_graph.Enabled = true;
                InitializeMatrixInputs();
            }
            else
            {
                labels_points.Enabled = false;
                panelGraph.Invalidate();
            }
        }

        private void InitializeMatrixInputs()
        {
           
            adjacencyMatrix = new int[matrixSize, matrixSize];
            weightMatrix = new int[matrixSize, matrixSize];
            vertexNames = new string[matrixSize];
            adjacencyMatrixInputs = new TextBox[matrixSize, matrixSize];
            weightMatrixInputs = new TextBox[matrixSize, matrixSize];
            int cellSize = 30;

            panelAdjacencyMatrix.Controls.Clear();
            panelWeightMatrix.Controls.Clear();

            for (int i = 0; i <= matrixSize; i++)
            {
                for (int j = 0; j <= matrixSize; j++)
                {
                    if (i > 0 && j > 0)
                    {
                        TextBox adjacencyTextBox = new TextBox
                        {
                            Width = cellSize,
                            Height = cellSize,
                            Location = new Point(10 + j * cellSize, 10 + i * cellSize),
                            TextAlign = HorizontalAlignment.Center
                        };
                        adjacencyTextBox.KeyPress += AdjacencyTextBox_KeyPress; // التحقق من الإدخال
                        adjacencyTextBox.TextChanged += AdjacencyMatrixInput_TextChanged; // تفعيل زر الحفظ
                        adjacencyTextBox.TextChanged += (s, e) => UpdateGraph();
                        panelAdjacencyMatrix.Controls.Add(adjacencyTextBox);
                        adjacencyMatrixInputs[i - 1, j - 1] = adjacencyTextBox;

                        TextBox weightTextBox = new TextBox
                        {
                            Width = cellSize,
                            Height = cellSize,
                            Location = new Point(10 + j * cellSize, 10 + i * cellSize),
                            TextAlign = HorizontalAlignment.Center,
                            Enabled = false
                        };
                        weightTextBox.KeyPress += WeightTextBox_KeyPress; // التحقق من الإدخال
                        panelWeightMatrix.Controls.Add(weightTextBox);
                        weightMatrixInputs[i - 1, j - 1] = weightTextBox;
                    }
                }
            }

            panelAdjacencyMatrix.Size = new Size((matrixSize + 1) * cellSize + 20, (matrixSize + 1) * cellSize + 20);
            panelWeightMatrix.Size = new Size((matrixSize + 1) * cellSize + 20, (matrixSize + 1) * cellSize + 20);

            panelGraph.Invalidate();
           
        }
        private void AdjacencyMatrixInput_TextChanged(object sender, EventArgs e)
        {
            save_adjacency.Enabled = true; // تفعيل زر الحفظ عند إدخال نص
        }
        // التحقق من أن المدخلات في مصفوفة الجوار تقبل الرقم 1 فقط
        private void AdjacencyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // السماح بالرقم 1 فقط أو مسح النص (Backspace)
            if (e.KeyChar != '1' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // منع الإدخال
            }
        }

        // التحقق من أن المدخلات في مصفوفة الأوزان تقبل أرقام فقط
        private void WeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // السماح بالأرقام فقط أو مسح النص (Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // منع الإدخال
            }
        }


        private void ApplyLabels()
        {
            string labelInput = labels_points.Text;
            if (vertexNames == null || vertexNames.Length < matrixSize)
                return;

            if (int.TryParse(labelInput, out int startNumber))
            {
                for (int i = 0; i < matrixSize; i++)
                {
                    vertexNames[i] = (startNumber + i).ToString();
                }
            }
            else if (!string.IsNullOrEmpty(labelInput) && char.IsLetter(labelInput[0]))
            {
                char startChar = char.ToUpper(labelInput[0]);
                for (int i = 0; i < matrixSize; i++)
                {
                    vertexNames[i] = ((char)(startChar + i)).ToString();
                }
            }
            else
            {
                MessageBox.Show("الرجاء إدخال حرف أو رقم صحيح لبدء التسمية.");
                return;
            }

            UpdateMatrixLabels(panelAdjacencyMatrix, vertexNames);
            UpdateMatrixLabels(panelWeightMatrix, vertexNames);

            panelGraph.Invalidate();
        }

        private void UpdateMatrixLabels(Panel matrixPanel, string[] labels)
        {
            int cellSize = 30;

            for (int j = 1; j <= matrixSize; j++)
            {
                Label label = new Label
                {
                    Text = labels[j - 1],
                    Width = cellSize,
                    Height = cellSize,
                    Location = new Point(10 + j * cellSize, 10),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                matrixPanel.Controls.Add(label);
            }

            for (int i = 1; i <= matrixSize; i++)
            {
                Label label = new Label
                {
                    Text = labels[i - 1],
                    Width = cellSize,
                    Height = cellSize,
                    Location = new Point(10, 10 + i * cellSize),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                matrixPanel.Controls.Add(label);
            }
        }


        private void UpdateAdjacency_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (int.TryParse(adjacencyMatrixInputs[i, j].Text, out int value))
                    {
                        adjacencyMatrix[i, j] = value;
                        weightMatrixInputs[i, j].Enabled = value == 1;
                    }
                }
            }

            UpdateGraph();
        }

        private void DeleteAdjacency_Click(object sender, EventArgs e)
        {
            adjacencySaved = false;
            update_weight.Enabled = false;

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    adjacencyMatrix[i, j] = 0;
                    weightMatrix[i, j] = 0;
                    adjacencyMatrixInputs[i, j].Text = "";
                    weightMatrixInputs[i, j].Text = "";
                    weightMatrixInputs[i, j].Enabled = false;
                }
            }

            UpdateGraph();
        }

        private void UpdateGraph()
        {
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (int.TryParse(adjacencyMatrixInputs[i, j].Text, out int adjacencyValue))
                        adjacencyMatrix[i, j] = adjacencyValue;

                    if (if_tree.Checked)
                    {
                        weightMatrix[i, j] = 0;
                    }
                    else if (int.TryParse(weightMatrixInputs[i, j].Text, out int weightValue))
                    {
                        weightMatrix[i, j] = weightValue;
                    }
                }
            }

            panelGraph.Invalidate();
        }

        private void PanelGraph_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int panelWidth = panelGraph.Width;
            int panelHeight = panelGraph.Height;

            if (vertexNames == null || vertexNames.Length < matrixSize)
                return;

            //رسم الشحرة 
            if (if_tree.Checked)
            {
                DrawBinaryTree(g, panelWidth, panelHeight, vertexNames, matrixSize);
            }
            else
            {
                DrawGraph(g, panelWidth, panelHeight);
            }
        }

        private void DrawBinaryTree(Graphics g, int width, int height, string[] labels, int nodeCount)
        {
            //int nodeRadius = 15;
            //int verticalSpacing = 80;
            //int horizontalSpacing = 100;

            //Point[] positions = new Point[nodeCount];
            //int level = 0;
            //int nodesInLevel = 1;
            //int currentNode = 0;

            //while (currentNode < nodeCount)
            //{
            //    int levelWidth = (int)(nodesInLevel * horizontalSpacing);
            //    int startX = (width - levelWidth) / 2;

            //    for (int i = 0; i < nodesInLevel && currentNode < nodeCount; i++)
            //    {
            //        positions[currentNode] = new Point(startX + i * horizontalSpacing + horizontalSpacing / 2, level * verticalSpacing + 30);
            //        currentNode++;
            //    }

            //    level++;
            //    nodesInLevel *= 2;
            //}

            //for (int i = 0; i < nodeCount; i++)
            //{
            //    int x = positions[i].X;
            //    int y = positions[i].Y;

            //    g.FillEllipse(Brushes.White, x - nodeRadius, y - nodeRadius, nodeRadius * 2, nodeRadius * 2);
            //    g.DrawEllipse(Pens.Black, x - nodeRadius, y - nodeRadius, nodeRadius * 2, nodeRadius * 2);
            //    g.DrawString(labels[i], new Font("Arial", 12), Brushes.Black, x - 10, y - 10);
            //}

            //for (int i = 0; i < nodeCount; i++)
            //{
            //    for (int j = 0; j < nodeCount; j++)
            //    {
            //        if (adjacencyMatrix[i, j] == 1 && GetLevel(i) != GetLevel(j))
            //        {
            //            g.DrawLine(Pens.Black, positions[i], positions[j]);
            //            if (weightMatrix[i, j] > 0)
            //            {
            //                int midX = (positions[i].X + positions[j].X) / 2;
            //                int midY = (positions[i].Y + positions[j].Y) / 2;
            //                g.DrawString(weightMatrix[i, j].ToString(), new Font("Arial", 10), Brushes.Red, midX, midY);
            //            }
            //        }
            //    }
            //}
        }

        private void DrawGraph(Graphics g, int width, int height)
        {
            Point[] points = GenerateCircularPoints(width, height);

            for (int i = 0; i < points.Length; i++)
            {
                g.FillEllipse(Brushes.White, points[i].X - 15, points[i].Y - 15, 30, 30);
                g.DrawEllipse(Pens.Black, points[i].X - 15, points[i].Y - 15, 30, 30);
                g.DrawString(vertexNames[i], new Font("Arial", 12), Brushes.Black, points[i].X - 10, points[i].Y - 10);
            }

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (adjacencyMatrix[i, j] == 1)
                    {
                        Point startPoint = points[i];
                        Point endPoint = points[j];
                        g.DrawLine(Pens.Black, startPoint, endPoint);

                        if (direct_graph.Checked)
                        {
                            DrawArrow(g, startPoint, endPoint);
                        }

                        if (weightMatrix[i, j] > 0)
                        {
                            int midX = (startPoint.X + endPoint.X) / 2;
                            int midY = (startPoint.Y + endPoint.Y) / 2;
                            g.DrawString(weightMatrix[i, j].ToString(), new Font("Arial", 10), Brushes.Red, midX, midY);
                        }
                    }
                }
            }
        }

        private void DrawArrow(Graphics g, Point start, Point end)
        {
            float arrowLength = 10;
            float arrowAngle = 0.4f;

            float dx = end.X - start.X;
            float dy = end.Y - start.Y;
            float angle = (float)Math.Atan2(dy, dx);

            PointF arrowPoint1 = new PointF(end.X - arrowLength * (float)Math.Cos(angle - arrowAngle),
                                             end.Y - arrowLength * (float)Math.Sin(angle - arrowAngle));
            PointF arrowPoint2 = new PointF(end.X - arrowLength * (float)Math.Cos(angle + arrowAngle),
                                             end.Y - arrowLength * (float)Math.Sin(angle + arrowAngle));
            g.DrawLine(Pens.Black, end, arrowPoint1);
            g.DrawLine(Pens.Black, end, arrowPoint2);
        }

        private Point[] GenerateCircularPoints(int width, int height)
        {
            Point[] points = new Point[matrixSize];
            int radius = Math.Min(width, height) / 3;
            Point center = new Point(width / 2, height / 2);

            double angleOffset = -Math.PI / 2;

            for (int i = 0; i < matrixSize; i++)
            {
                double angle = angleOffset + i * 2 * Math.PI / matrixSize;
                int x = center.X + (int)(radius * Math.Cos(angle));
                int y = center.Y + (int)(radius * Math.Sin(angle));
                points[i] = new Point(x, y);
            }

            return points;
        }

        private int GetLevel(int node)
        {
            int level = 0;
            while (node > 0)
            {
                node = (node - 1) / 2;
                level++;
            }
            return level;
        }

        private void If_tree_CheckedChanged(object sender, EventArgs e)
        {
            unweighted_graph.Checked = true;
            weighted_graph.Enabled = false;
            unweighted_graph.Enabled = false;
            direct_graph.Enabled = false;
            undirect_graph.Enabled = false;
            if (if_tree.Checked)
            {
                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j < matrixSize; j++)
                    {
                        weightMatrixInputs[i, j].Enabled = false;
                    }
                }
               //UpdateCombos("شجرة");
                panelGraph.Invalidate();
            }
        }

        private void If_graph_CheckedChanged(object sender, EventArgs e)
        {
            weighted_graph.Enabled = true;
            unweighted_graph.Enabled = true;
            direct_graph.Enabled = true;
            undirect_graph.Enabled = true;
            if (if_graph.Checked)
            {
                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j < matrixSize; j++)
                    {
                        weightMatrixInputs[i, j].Enabled = adjacencyMatrix[i, j] == 1;
                    }
                }
                //UpdateCombos("مخطط");
                panelGraph.Invalidate();

            }

        }
       

        private void DirectGraph_CheckedChanged(object sender, EventArgs e)
        {
            if (direct_graph.Checked)
            {
                panelGraph.Invalidate();
            }
        }

        private void Unweighted_graph_CheckedChanged(object sender, EventArgs e)
        {
            panelWeightMatrix.Enabled = false;
        }

        private void Weighted_graph_CheckedChanged(object sender, EventArgs e)
        {
            if (weighted_graph.Checked)
            {
                panelWeightMatrix.Enabled = true;

            }
            else
            {
                panelWeightMatrix.Enabled = false;


            }

        }
        public Panel GetGraphPanel()
        {
            return panelGraph;
        }
        public class Edge
        {
            public int Start { get; }
            public int End { get; }

            public Edge(int start, int end)
            {
                Start = start;
                End = end;
            }
        }
        private void if_tree_CheckedChanged_1(object sender, EventArgs e)
        {// عند تغيير الخيار إلى شجرة ثنائية
            if (if_tree.Checked)
            {
                // تعطيل إدخال الأوزان
                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j < matrixSize; j++)
                    {
                        weightMatrixInputs[i, j].Enabled = false; // تعطيل إدخال الوزن
                    }
                }
                UpdateCombos("شجرة");

                /*panelGraph.Invalidate();*/ // إعادة رسم اللوحة
            }
        }

        private void if_graph_CheckedChanged_1(object sender, EventArgs e)
        {
            // عند تغيير الخيار إلى رسم عادي
            if (if_graph.Checked)
            {
                // تمكين إدخال الأوزان
                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j < matrixSize; j++)
                    {
                        weightMatrixInputs[i, j].Enabled = adjacencyMatrix[i, j] == 1; // تمكين إدخال الوزن إذا كان الاتصال موجودًا
                    }
                }
                panelGraph.Invalidate();// إعادة رسم اللوحة
                UpdateCombos("مخطط");
            }
        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            if (comboBox1.SelectedItem.ToString() == "اجتياز الشجرة الثنائية")
            {
                comboBox2.Items.Add("اجتياز الشجرة الثنائية");
                comboBox3.Items.Add("اجتياز بالترتيب السابق");
                comboBox3.Items.Add("اجتياز بالترتيب الداخل");
                comboBox3.Items.Add("اجتياز بالترتيب اللاحق");
            }
            else if (comboBox1.SelectedItem.ToString() == "ايجاد ارتفاع الشجرة")
            {
                comboBox2.Items.Add("ايجاد ارتفاع الشجرة");
                comboBox3.Items.Add("خوارزيمة ايجاد ارتفاع الشجره ");
            }
            else if (comboBox1.SelectedItem.ToString() == "المسار الاقصر")
            {
                comboBox2.Items.Add("إجتياز اقصر مسار ");
                comboBox3.Items.Add("خوارزمية القوة الغاشمة");
                comboBox3.Items.Add("خوارزمية  فلويد");
                comboBox3.Items.Add("خوارزمية ديجسترا");
                comboBox3.Items.Add("خوارزمية بليمان");

            }
            else if (comboBox1.SelectedItem.ToString() == " احتياز الرسم البياني")
            {
                comboBox2.Items.Add("الاجتياز الاقل كلفة للشجرة");
                comboBox2.Items.Add("بحث العرض اولا");
                comboBox2.Items.Add("بحث العمق اولا");
            }

            else if (comboBox2.SelectedItem.ToString() == "بحث العمق اولا")
            {

                comboBox3.Items.Add(" خوارزمية البحث بالعمق اولا");
                comboBox3.Items.Add("خوارزمية  البحث بالعمق مع التلوين");
            }
            else if (comboBox2.SelectedItem.ToString() == "بحث العرض اولا")
            {

                comboBox3.Items.Add(" خوارزمية البحث بالعرض اولا ");
                comboBox3.Items.Add("خوارزمية  البحث بالعرض مع التلوين");
            }
            else if (comboBox2.SelectedItem.ToString() == "الاجتياز الاقل كلفة للشجرة")
            {
                comboBox3.Items.Add("كروسكال المتقدمة ");
                comboBox3.Items.Add("كروسكال الاساسية");
                comboBox3.Items.Add("بريم المتقدمة");
                comboBox3.Items.Add("بريم الاساسية");
            }
            else if (comboBox2.SelectedItem.ToString() == "إيجاد المسار الاقصر")
            {
                comboBox3.Items.Add("خوارزمية القوة الغاشمة");
                comboBox3.Items.Add("خوارزمية  فلويد");
                comboBox3.Items.Add("خوارزمية ديجسترا");
                comboBox3.Items.Add("خوارزمية بليمان");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {          
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();

            if (if_tree.Checked)
            {
                comboBox1.Items.Add("اجتياز الشجرة الثنائية");
                comboBox1.Items.Add("ايجاد ارتفاع الشجرة");
                if (comboBox1.SelectedItem.ToString() == "اجتياز الشجرة الثنائية")
                {
                    comboBox2.Items.Add("اجتياز الشجرة الثنائية");
                    comboBox3.Items.Add("اجتياز بالترتيب السابق");
                    comboBox3.Items.Add("جتياز بالترتيب الداخل");
                    comboBox3.Items.Add("اجتياز بالترتيب اللاحق");
                }

                else if (comboBox1.SelectedItem.ToString() == "ايجاد ارتفاع الشجرة")
                {
                    comboBox2.Items.Add("ايجاد ارتفاع الشجرة");
                    comboBox3.Items.Add("خوارزيمة ايجاد ارتفاع الشجره ");
                }
            }
            else
            {
                MessageBox.Show("erroe enter the tree");
            }
        }
        private void UpdateCombos(string type)
        {
            switch (type)
            {
                case "شجرة":
                    {
                        comboBox1.Text = null;
                        comboBox2.Text = null;
                        comboBox3.Text = null;
                        comboBox1.Items.Clear();
                        comboBox2.Items.Clear();
                        comboBox3.Items.Clear();
                        comboBox1.Items.Clear();
                        comboBox1.Items.AddRange(new string[] { "اجتياز الشجرة الثنائية", "ايجاد ارتفاع الشجرة" });
                        comboBox2.Items.AddRange(new string[] { "  اجتياز الشجرة الثنائية ", "ايجاد ارتفاع الشجرة" });
                        comboBox3.Items.AddRange(new string[] { "خوارزيمة ايجاد ارتفاع الشجره ", "اجتياز بالترتيب السابق", "جتياز بالترتيب الداخل", "اجتياز بالترتيب اللاحق" });

                        break;
                    }
                case "مخطط":
                    {
                       comboBox1.Text = null;
                        comboBox2.Text = null;
                        comboBox3.Text = null;
                        comboBox1.Items.Clear();
                        comboBox2.Items.Clear();
                        comboBox3.Items.Clear();
                        comboBox1.Items.AddRange(new string[] { " احتياز الرسم البياني", "المسار الاقصر" });
                        comboBox2.Items.AddRange(new string[] { "  بحث العمق اولا ", "بحث العرض اولا", "الاجتياز الاقل كلفة للشجرة", "إيجاد المسار الاقصر" });
                        comboBox3.Items.AddRange(new string[] { "كروسكال المتقدمة", " كروسكال الاساسية ", "بريم المتقدمة", "بريم الاساسية ", "خوارزمية  البحث بالعمق مع التلوين",
                            "خوارزمية  البحث بالعرض مع التلوين", "الخوارزمية البحث بالعرض اولا ", "الخوارزمية البحث بالعمق اولا ", "خوارزمية بليمان", "خوارزمية ديجسترا", "خوارزمية  فلويد", "خوارزمية القوة الغاشمة" });

                        break;

                    }
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "بحث العمق اولا")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add(" خوارزمية البحث بالعمق اولا");
                comboBox3.Items.Add("خوارزمية  البحث بالعمق مع التلوين");
            }
            else if (comboBox2.SelectedItem.ToString() == "بحث العرض اولا")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("خوارزمية البحث بالعرض اولا");
                comboBox3.Items.Add("خوارزمية البحث بالعرض مع التلوين");
            }
            else if (comboBox2.SelectedItem.ToString() == "الاجتياز الاقل كلفة للشجرة")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("كروسكال المتقدمة");
                comboBox3.Items.Add("كروسكال الاساسية");
                comboBox3.Items.Add("بريم المتقدمة");
                comboBox3.Items.Add("بريم الاساسية");
            }
         }
       
        private void button3_Click(object sender, EventArgs e)
        {
        
        
            Form2 form2 = new Form2();
            Panel clonedPanel = ClonePanel(this.panelGraph); // نسخ البانل
            form2.Controls.Add(clonedPanel); // إضافة البانل إلى الفورم الثاني
            form2.Show();
            this.Hide(); // إخفاء الفورم الأول
        


    }

        public static Panel ClonePanel(Panel originalPanel)
        {
            Panel newPanel = new Panel
            {
                Size = originalPanel.Size,
                Location = originalPanel.Location,
                BackColor = originalPanel.BackColor,
                Name = originalPanel.Name
            };

            foreach (Control control in originalPanel.Controls)
            {
                Control newControl = (Control)Activator.CreateInstance(control.GetType());
                newControl.Size = control.Size;
                newControl.Location = control.Location;
                newControl.Text = control.Text;
                newControl.Name = control.Name;
                newControl.BackColor = control.BackColor;
                newControl.ForeColor = control.ForeColor;
                newControl.Enabled = control.Enabled;

                // نسخ خصائص إضافية إذا لزم الأمر
                newPanel.Controls.Add(newControl);
            }

            return newPanel;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            //button3.Visible = false;
            //button2.Visible = false;
            panel4.Visible = false;
            textBox2.Visible = false;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //خوارزمية البحث بالعمق بدون الوان
        public void dsf()
        {
            // تنظيف panel4 قبل البدء في الرسم
            panel4.Refresh();

            // إنشاء الرسومات باستخدام Graphics
            using (Graphics g = panel4.CreateGraphics())
            {
                // تحديد عدد العقد وإنشاء مصفوفة لتتبع العقد التي تمت زيارتها
                bool[] visited = new bool[matrixSize];


                int startNode = 0;  // يمكنك تحديد العقدة التي تريد بدء البحث منها
                DFSWithDrawing(startNode, visited, g);
            }
        }
        public void DFSWithDrawing(int node, bool[] visited, Graphics g)
        {
            // علامة على أن العقدة تمت زيارتها
            visited[node] = true;

            // رسم العقدة الحالية باستخدام دالة DrawNodeAndEdge
            Point[] nodePositions = GenerateCircularPoints(panelGraph.Width, panelGraph.Height);
            DrawNodeAndEdge(node, nodePositions, visited, g, Pens.Black);

            Thread.Sleep(1000); // تأخير لرؤية التغييرات

            // التكرار عبر العقد المتصلة
            for (int i = 0; i < matrixSize; i++)
            {
                if (adjacencyMatrix[node, i] == 1 && !visited[i]) // إذا كانت العقدة متصلة ولم تتم زيارتها
                {
                    // رسم الحافة بين العقدتين باستخدام دالة DrawEdge
                    DrawEdge(node, i, nodePositions, g, Pens.Black);

                    // استدعاء الدالة DFS للعقدة المتصلة
                    DFSWithDrawing(i, visited, g);
                }
            }
        }

        //العرض بدون الوان
        public void bfs()
        {
                panel4.Refresh();
                // إعداد المصفوفة visited التي تستخدم لتتبع العقد التي تم زيارتها
                bool[] visited = new bool[matrixSize];
                for (int i = 0; i < matrixSize; i++)
                {
                    visited[i] = false;
                }

                // إعداد الرسم داخل الـ panelGraph
                using (Graphics g = panel4.CreateGraphics())
                {


                    // بدء البحث بالعمق من العقدة الأولى (أو أي عقدة تحددها)
                    int startingNode = 0;  // يمكن تعديلها لبدء من عقدة معينة
                                           // StartBFS();
                    BFSWith(startingNode, visited, g);  // بدء الخوارزمية من العقدة المحددة
                }
            }
         public void BFSWith(int startNode, bool[] visited, Graphics g)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startNode);
            visited[startNode] = true;
            Pen edgePen = new Pen(Color.Black, 2); // القلم المستخدم لربط العقد
           

            Point[] nodePositions = GenerateCircularPoints(panelGraph.Width, panelGraph.Height);

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                
                DrawNodeAndEdge(node, nodePositions, visited, g, edgePen);

                Thread.Sleep(1000); // تأخير بعد زيارة العقدة الحالية

                // التكرار على العقد المجاورة
                for (int i = 0; i < matrixSize; i++)
                {
                    if (adjacencyMatrix[node, i] == 1 && !visited[i])
                    {
                        visited[i] = true;
                        queue.Enqueue(i);

                        // رسم الحافة بين العقد
                        DrawEdge(node, i, nodePositions, g, edgePen);

                        // رسم العقدة المتصلة (بعد الزيارة بلون أخضر)
                        DrawNodeAndEdge(i, nodePositions, visited, g, edgePen);

                        Thread.Sleep(1000); // تأخير بعد رسم العقدة المتصلة
                    }
                }

                // بعد زيارة العقدة نغير لونها إلى الأخضر
                DrawNodeAndEdge(node, nodePositions, visited, g, edgePen);
            }
        }

        //العرض مع الوان
        public void bfs2()
        {
            panel4.Refresh();
            // إعداد المصفوفة visited التي تستخدم لتتبع العقد التي تم زيارتها
            bool[] visited = new bool[matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                visited[i] = false;
            }

            // إعداد الرسم داخل الـ panelGraph
            using (Graphics g = panel4.CreateGraphics())
            {


                // بدء البحث بالعمق من العقدة الأولى (أو أي عقدة تحددها)
                int startingNode = 0;  // يمكن تعديلها لبدء من عقدة معينة
                                       // StartBFS();
                BFSWithColorHelper(startingNode, visited, g);  // بدء الخوارزمية من العقدة المحددة
            }
        }
        public void BFSWithColorHelper(int startNode, bool[] visited, Graphics g)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startNode);
            visited[startNode] = true;

            Pen edgePen = new Pen(Color.Black, 2); // القلم المستخدم لربط العقد
            Point[] nodePositions = GenerateCircularPoints(panelGraph.Width, panelGraph.Height);

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                
                Point position = nodePositions[node];
                Brush nodeBrush = visited[node] ? Brushes.Gray : Brushes.Yellow; 

                // رسم العقدة
                g.FillEllipse(nodeBrush, position.X - 15, position.Y - 15, 30, 30);
                g.DrawEllipse(Pens.Black, position.X - 15, position.Y - 15, 30, 30);
                g.DrawString(((char)('A' + node)).ToString(), new Font("Arial", 12), Brushes.Black, position.X - 5, position.Y - 5);

                Thread.Sleep(1000); // تأخير بعد زيارة العقدة الحالية

                // التكرار على العقد المجاورة
                for (int i = 0; i < matrixSize; i++)
                {
                    if (adjacencyMatrix[node, i] == 1 && !visited[i])
                    {
                        visited[i] = true;
                        queue.Enqueue(i);

                        // رسم الحافة بين العقد
                        Point nextPosition = nodePositions[i];
                        g.DrawLine(edgePen, position, nextPosition);  // رسم الحافة بين العقدتين

                        // رسم العقدة المتصلة
                        Brush connectedNodeBrush = Brushes.Gray; // العقدة المتصلة تكون باللون الأخضر
                        g.FillEllipse(connectedNodeBrush, nextPosition.X - 15, nextPosition.Y - 15, 30, 30);
                        g.DrawEllipse(Pens.Black, nextPosition.X - 15, nextPosition.Y - 15, 30, 30);
                        g.DrawString(((char)('A' + i)).ToString(), new Font("Arial", 12), Brushes.Black, nextPosition.X - 5, nextPosition.Y - 5);

                        Thread.Sleep(1000); // تأخير بعد رسم العقدة المتصلة
                    }
                }

                // بعد زيارة العقدة، نغير لونها إلى الأخضر لتوضيح أنها تم زيارتها
                Brush visitedNodeBrush = Brushes.Green;
                g.FillEllipse(visitedNodeBrush, position.X - 15, position.Y - 15, 30, 30);
                g.DrawEllipse(Pens.Black, position.X - 15, position.Y - 15, 30, 30);
                g.DrawString(((char)('A' + node)).ToString(), new Font("Arial", 12), Brushes.Black, position.X - 5, position.Y - 5);
            }
        }
       
        //دالة الرسم بدون اوزان
        private void DrawNodeAndEdge(int node, Point[] nodePositions, bool[] visited, Graphics g, Pen edgePen)
        {
            // رسم العقدة
            Point position = nodePositions[node];
            Brush nodeBrush = visited[node] ? Brushes.White : Brushes.Black;
            g.FillEllipse(nodeBrush, position.X - 15, position.Y - 15, 30, 30);
            g.DrawEllipse(Pens.Black, position.X - 15, position.Y - 15, 30, 30);
            g.DrawString(((char)('A' + node)).ToString(), new Font("Arial", 12), Brushes.Black, position.X - 5, position.Y - 5);
        }
        private void DrawEdge(int startNode, int endNode, Point[] nodePositions, Graphics g, Pen edgePen)
        {
            Point startPosition = nodePositions[startNode];
            Point endPosition = nodePositions[endNode];
            g.DrawLine(edgePen, startPosition, endPosition);
        }

        //خوارزمية البحث بالعمق مع التلوين
        private void dfs2()
        {
            panel4.Refresh(); // إعادة رسم اللوحة
            // إعداد المصفوفة visited التي تستخدم لتتبع العقد التي تم زيارتها
            bool[] visited = new bool[matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                visited[i] = false;
            }
            // إعداد الرسم داخل الـ panelGraph
            using (Graphics g = panel4.CreateGraphics())
            {
                int startingNode = 0;
                DFSWithColorHelper(startingNode, visited, g);  // بدء الخوارزمية من العقدة المحددة
            }
        }
        private void DFSWithColorHelper(int node, bool[] visited, Graphics g)
        {
            visited[node] = true;  // وضع العقدة على أنها تم زيارتها

            // الحصول على موقع العقدة
            Point position = GenerateCircularPoints(panelGraph.Width, panelGraph.Height)[node];


            // رسم العقدة باستخدام دالة DrawNodeAndEdge
            DrawNodeAndEdge(node, GenerateCircularPoints(panelGraph.Width, panelGraph.Height), visited, g, Pens.Black);



            Thread.Sleep(1000);  // تأخير لكي يظهر التلوين بشكل مرئي

            // بعد زيارة العقدة، يمكن تغيير لون العقدة إلى الأخضر
            Pen nodePen = new Pen(Color.Green, 4);
            g.DrawEllipse(nodePen, position.X - 15, position.Y - 15, 30, 30);  // تغيير لون الحدود بعد زيارتها

            Pen edgePen = new Pen(Color.Red, 4);  // القلم لرسم الخطوط
            for (int i = 0; i < matrixSize; i++)  // التكرار عبر جميع العقد المتصلة
            {
                if (adjacencyMatrix[node, i] == 1 && !visited[i])  // إذا كانت العقدة متصلة ولم تتم زيارتها
                {
                    // رسم الخط الذي يربط العقدة بالعقدة المتصلة
                    Point nextPosition = GenerateCircularPoints(panelGraph.Width, panelGraph.Height)[i];
                    g.DrawLine(edgePen, position, nextPosition);  // رسم الخط بين العقدتين

                    // استدعاء الدالة للعقدة المتصلة
                    DFSWithColorHelper(i, visited, g);
                }
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //List<TreeNode> traversalResult = new List<TreeNode>();
            //TreeNode root = BuildTreeFromMatrix();
            int source = 0;
            if (comboBox3.SelectedItem == null)
            {
                MessageBox.Show(" الرجاء اختيار عنصر ");
                return;
            }
            string selection = comboBox3.SelectedItem.ToString();
            switch (selection)
            {
               
                case " خوارزمية البحث بالعمق اولا":
                    dsf();
                    break;
                case "خوارزمية  البحث بالعمق مع التلوين":
                    dfs2();
                    break;
                case "خوارزمية البحث بالعرض اولا":
                    bfs();
                    break;
                case "خوارزمية البحث بالعرض مع التلوين":
                    bfs2();
                    break;
                case "كروسكال الاساسية":
                    Kruskall();
                    break;
                case "كروسكال المتقدمة":
                    KruskalAdvanced(weightMatrix, matrixSize);
                    break;
                case "خوارزمية بليمان":
                    BellmanFordVisualization(source);
                    break;
                case "خوارزمية ديجسترا":
                   
                    DijkstraVisualization(source);
                    break;
                case "اجتياز بالترتيب اللاحق":

                    {
                        if (int.TryParse(number_points.Text, out int nodeCount) && nodeCount > 0)
                        {
                            panelGraph.Refresh();
                            tree.BuildTree(nodeCount); // بناء الشجرة
                            traversalSteps = tree.PostOrderTraversal(tree.Root, new List<string>()); // اجتياز الشجرة
                            currentStepIndex = 0; // بدء الرسم من الخطوة الأولى
                            textBox2.Text = string.Join(Environment.NewLine, traversalSteps); // عرض الخطوات في مربع النص

                            panelGraph.Refresh();
                            panel4.Refresh(); // إعادة رسم اللوحة
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid number of nodes.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    break;
                case "جتياز بالترتيب الداخل":

                    {
                        if (int.TryParse(number_points.Text, out int nodeCount) && nodeCount > 0)
                        {
                            panelGraph.Refresh();
                            tree.BuildTree(nodeCount); // بناء الشجرة
                            traversalSteps = tree.InOrderTraversal(tree.Root, new List<string>()); // اجتياز الشجرة
                            currentStepIndex = 0; // بدء الرسم من الخطوة الأولى
                            textBox2.Text = string.Join(Environment.NewLine, traversalSteps); // عرض الخطوات في مربع النص

                            panelGraph.Refresh();
                            panel4.Refresh(); // إعادة رسم اللوحة
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid number of nodes.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    break;
                case "اجتياز بالترتيب السابق":

                    {
                        if (int.TryParse(number_points.Text, out int nodeCount) && nodeCount > 0)
                        {
                            panelGraph.Refresh();
                            tree.BuildTree(nodeCount); // بناء الشجرة
                            traversalSteps = tree.PreOrderTraversal(tree.Root, new List<string>()); // اجتياز الشجرة
                            currentStepIndex = 0; // بدء الرسم من الخطوة الأولى
                            textBox2.Text = string.Join(Environment.NewLine, traversalSteps); // عرض الخطوات في مربع النص

                            panel4.Refresh();
                            panelGraph.Refresh();
                            // إعادة رسم اللوحة
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid number of nodes.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    break;
                case "خوارزيمة ايجاد ارتفاع الشجره ":

                    {
                        

                            if (traversalSteps == null || traversalSteps.Count == 0)
                            {
                                MessageBox.Show("No steps to display. Please generate and traverse the tree first.", "No Steps", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            panelGraph.Refresh();

                            if (currentStepIndex < traversalSteps.Count - 1)
                            {
                                currentStepIndex++; // الانتقال إلى الخطوة التالية
                                panel4.Refresh(); // إعادة رسم اللوحة
                            }
                            else
                            {
                                MessageBox.Show("You have reached the last step.", "End of Steps", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            int height = tree.GetHeight(tree.Root);
                            textBox2.Text = $"Height of the tree: {height}";
                        


                    }
                    break;


            }
           // DisplayTraversalInPanel4(traversalResult);

        }
 
        public void panelGraph_Paint_1(object sender, PaintEventArgs e)
        {
            if (tree.Root == null || traversalSteps == null || currentStepIndex < 0)
            {
                return; // لا شيء لرسمه إذا كانت الشجرة فارغة أو لا توجد خطوات
            }

            Graphics g = e.Graphics;

            // إعادة رسم الشجرة كاملة، لكن فقط عقد الخطوة الحالية يتم تلوينها
            DrawTreeWithSteps(g, tree.Root, panelGraph.Width / 2, 50, 100, 50, 0);
        }

        private void panelAdjacencyMatrix_Paint(object sender, PaintEventArgs e)
        {

        }

        private void number_points_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar<48||e.KeyChar>57)&&(e.KeyChar!=8))
            {
                e.Handled = true;
            }
        }
        
        //كروسكال الاساسيه
        public void Kruskall()
        {
            // قائمة لتخزين الحواف (الوزن، العقدة الأولى، العقدة الثانية)
            List<(int weight, int u, int v)> edges = new List<(int, int, int)>();

            // بناء قائمة الحواف من مصفوفة الأوزان
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = i + 1; j < matrixSize; j++) // تجنب الحواف المكررة
                {
                    if (weightMatrix[i, j] > 0)
                    {
                        edges.Add((weightMatrix[i, j], i, j));
                    }
                }
            }

            // ترتيب الحواف تصاعديًا حسب الوزن
            edges.Sort((edge1, edge2) => edge1.weight.CompareTo(edge2.weight));

            // إعداد مصفوفة parent لتتبع المجموعات (Union-Find)
            int[] parent = new int[matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                parent[i] = i;
            }

            // دالتان لاتحاد وإيجاد المجموعات
            int Find(int x)
            {
                if (parent[x] != x)
                {
                    parent[x] = Find(parent[x]);
                }
                return parent[x];
            }

            void Union(int x, int y)
            {
                int rootX = Find(x);
                int rootY = Find(y);
                if (rootX != rootY)
                {
                    parent[rootX] = rootY;
                }
            }

            // قائمة لتخزين الحواف المختارة للشجرة الممتدة الدنيا (MST)
            List<(int weight, int u, int v)> mstEdges = new List<(int, int, int)>();

            // إعداد الرسم
            using (Graphics g = panel4.CreateGraphics())
            {
                g.Clear(panel4.BackColor); // تنظيف اللوحة
                Point[] positions = GenerateCircularPoints(panel4.Width, panel4.Height);

                // رسم العقد
                for (int i = 0; i < matrixSize; i++)
                {
                    Point position = positions[i];
                    g.FillEllipse(Brushes.Yellow, position.X - 15, position.Y - 15, 30, 30);
                    g.DrawString(((char)('A' + i)).ToString(), new Font("Arial", 12), Brushes.Black, position.X - 8, position.Y - 8);
                }

                Pen pen = new Pen(Color.Blue, 2); // قلم لرسم الحواف

                // تنفيذ خوارزمية كروسكال مع التأخير
                foreach (var edge in edges)
                {
                    int u = edge.u;
                    int v = edge.v;

                    // التحقق إذا كانت العقدتان في مجموعتين مختلفتين
                    if (Find(u) != Find(v))
                    {
                        mstEdges.Add(edge); // إضافة الحافة إلى الشجرة
                        Union(u, v); // دمج المجموعتين

                        // رسم الحافة المختارة
                        Point uPosition = positions[u];
                        Point vPosition = positions[v];
                        g.DrawLine(pen, uPosition, vPosition);

                        // رسم الوزن بجانب الحافة
                        int midX = (uPosition.X + vPosition.X) / 2;
                        int midY = (uPosition.Y + vPosition.Y) / 2;
                        g.DrawString(edge.weight.ToString(), new Font("Arial", 10), Brushes.Black, midX, midY);

                        // تأخير 1000ms لإظهار الخطوة
                        Thread.Sleep(1000);

                        // التوقف إذا اكتملت الشجرة الممتدة
                        if (mstEdges.Count == matrixSize - 1)
                            break;
                    }
                }
            }
        }

        //كروسكال المتقدمه
        public void KruskalAdvanced(int[,] graph, int size)
        {
            // قائمة لتخزين الحواف (الوزن، العقدة الأولى، العقدة الثانية)
            List<(int weight, int u, int v)> edges = new List<(int, int, int)>();

            // بناء قائمة الحواف من مصفوفة الأوزان
            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++) // تجنب الحواف المكررة
                {
                    if (graph[i, j] > 0)
                    {
                        edges.Add((graph[i, j], i, j));
                    }
                }
            }

            // ترتيب الحواف تصاعديًا حسب الوزن
            edges.Sort((edge1, edge2) => edge1.weight.CompareTo(edge2.weight));

            // إعداد مصفوفة parent لتتبع المجموعات (Union-Find)
            int[] parent = new int[size];
            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
            }

            // دالتان لاتحاد وإيجاد المجموعات
            int Find(int x)
            {
                if (parent[x] != x)
                {
                    parent[x] = Find(parent[x]);
                }
                return parent[x];
            }

            void Union(int x, int y)
            {
                int rootX = Find(x);
                int rootY = Find(y);
                if (rootX != rootY)
                {
                    parent[rootX] = rootY;
                }
            }

            // قائمة لتخزين الحواف المختارة للشجرة الممتدة الدنيا (MST)
            List<(int weight, int u, int v)> mstEdges = new List<(int, int, int)>();

            // إعداد الرسم
            using (Graphics g = panel4.CreateGraphics())
            {
                g.Clear(panel4.BackColor); // تنظيف اللوحة
                Point[] positions = GenerateCircularPoints(panel4.Width, panel4.Height);

                // رسم العقد
                for (int i = 0; i < size; i++)
                {
                    Point position = positions[i];
                    g.FillEllipse(Brushes.Yellow, position.X - 15, position.Y - 15, 30, 30);
                    g.DrawString(((char)('A' + i)).ToString(), new Font("Arial", 12), Brushes.Black, position.X - 8, position.Y - 8);
                }

                Pen pen = new Pen(Color.Blue, 2); // قلم لرسم الحواف

                // تنفيذ خوارزمية كروسكال مع الرسم
                foreach (var edge in edges)
                {
                    int u = edge.u;
                    int v = edge.v;

                    // التحقق إذا كانت العقدتان في مجموعتين مختلفتين
                    if (Find(u) != Find(v))
                    {
                        mstEdges.Add(edge); // إضافة الحافة إلى الشجرة
                        Union(u, v); // دمج المجموعتين

                        // رسم الحافة المختارة
                        Point uPosition = positions[u];
                        Point vPosition = positions[v];
                        g.DrawLine(pen, uPosition, vPosition);

                        // رسم الوزن بجانب الحافة
                        int midX = (uPosition.X + vPosition.X) / 2;
                        int midY = (uPosition.Y + vPosition.Y) / 2;
                        g.DrawString(edge.weight.ToString(), new Font("Arial", 10), Brushes.Black, midX, midY);

                        // تأخير لإظهار الخطوة
                        Thread.Sleep(1000);

                        // التوقف إذا اكتملت الشجرة الممتدة
                        if (mstEdges.Count == size - 1)
                            break;
                    }
                    else
                    {
                        // رسم الحافة المرفوضة (لأنها تُكوّن دورة) باللون الأحمر
                        Point uPosition = positions[u];
                        Point vPosition = positions[v];
                        Pen rejectedPen = new Pen(Color.Red, 2);
                        g.DrawLine(rejectedPen, uPosition, vPosition);

                        // تأخير لإظهار الحافة المرفوضة
                        Thread.Sleep(500);
                    }
                }
            }
        }

     
            // دالة لتعطيل مربعات النص داخل panelWeightMatrix
            private void DisableWeightMatrix()
        {
            foreach (Control control in panelWeightMatrix.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Enabled = false; // تعطيل مربعات النص
                }
            }
        }

        // دالة لتمكين مربعات النص داخل panelWeightMatrix
        private void EnableWeightMatrix()
        {
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (adjacencyMatrix[i, j] == 1) // إذا كان هناك اتصال في مصفوفة الجوار
                    {
                        weightMatrixInputs[i, j].Enabled = true; // تمكين المربع المكافئ
                    }
                    else
                    {
                        //weightMatrixInputs[i, j].Enabled = false; // تعطيل المربع المكافئ
                        //weightMatrixInputs[i, j].Text = ""; // مسح المحتوى إذا لم يكن هناك اتصال
                    }
                }
            }
        }
        //دالة تعطيل المربعات في مصفوفة الاوزان
      
        //خوارزمية ديجسترا
        public void DijkstraVisualization(int source)
        {
            // عدد العقد في الرسم
            int vertexCount = matrixSize;

            // مصفوفة المسافات، العقد المزارة، والآباء
            int[] distances = new int[vertexCount];
            bool[] visited = new bool[vertexCount];
            int[] parents = new int[vertexCount];

            // قائمة لتخزين الحواف مع أوزانها لتسهيل الترتيب
            List<(int u, int v, int weight)> edgesToDraw = new List<(int u, int v, int weight)>();

            // تهيئة البيانات
            for (int i = 0; i < vertexCount; i++)
            {
                distances[i] = int.MaxValue; // تعيين المسافة كـ "لا نهائية"
                visited[i] = false;
                parents[i] = -1; // لا يوجد أب في البداية
            }
            distances[source] = 0; // مسافة العقدة المصدر تساوي صفر

            using (Graphics g = panel4.CreateGraphics())
            {
                g.Clear(panel4.BackColor); // تنظيف اللوحة
                Point[] positions = GenerateCircularPoints(panel4.Width, panel4.Height);

                // رسم العقد كدوائر
                for (int i = 0; i < vertexCount; i++)
                {
                    Point position = positions[i];
                    g.FillEllipse(Brushes.Yellow, position.X - 15, position.Y - 15, 30, 30);
                    g.DrawEllipse(Pens.Black, position.X - 15, position.Y - 15, 30, 30);
                    g.DrawString(((char)('A' + i)).ToString(), new Font("Arial", 12), Brushes.Black, position.X - 8, position.Y - 8);
                }

                // تنفيذ خوارزمية ديجسترا
                for (int count = 0; count < vertexCount; count++)
                {
                    // العثور على العقدة غير المزارة ذات المسافة الأقل
                    int u = -1;
                    int minDistance = int.MaxValue;

                    for (int i = 0; i < vertexCount; i++)
                    {
                        if (!visited[i] && distances[i] < minDistance)
                        {
                            u = i;
                            minDistance = distances[i];
                        }
                    }

                    if (u == -1) break; // إذا لم تكن هناك عقدة متبقية للوصول

                    visited[u] = true; // تعليم العقدة كمزارة

                    // تحديث المسافات للعقد المجاورة
                    for (int v = 0; v < vertexCount; v++)
                    {
                        if (!visited[v] && adjacencyMatrix[u, v] > 0 && weightMatrix[u, v] > 0)
                        {
                            int newDistance = distances[u] + weightMatrix[u, v];
                            if (newDistance < distances[v])
                            {
                                distances[v] = newDistance;
                                parents[v] = u;

                                // تخزين الحافة مع وزنها
                                edgesToDraw.Add((u, v, weightMatrix[u, v]));
                            }
                        }
                    }
                }

                // ترتيب الحواف حسب الأوزان
                edgesToDraw.Sort((edge1, edge2) => edge1.weight.CompareTo(edge2.weight));

                // رسم الحواف بترتيب الأوزان
                foreach (var edge in edgesToDraw)
                {
                    DrawEdgeWithWeight(edge.u, edge.v, positions, g, edge.weight);
                    Thread.Sleep(500); // تأخير لعرض الخطوات
                }
            }
        }
        //دالة رسم خاصه ب بليمان وديجسترا
        public void DrawEdgeWithWeight(int u, int v, Point[] positions, Graphics g, int weight)
        {
            Point uPosition = positions[u];
            Point vPosition = positions[v];

            // رسم الخط
            g.DrawLine(Pens.Blue, uPosition, vPosition);

            // رسم الوزن على منتصف الخط
            int midX = (uPosition.X + vPosition.X) / 2;
            int midY = (uPosition.Y + vPosition.Y) / 2;
            g.DrawString(weight.ToString(), new Font("Arial", 10), Brushes.Red, midX, midY);
        }
        //خوارزمية بليمان 
        public void BellmanFordVisualization(int startNode)
        {
            int[] distances = new int[matrixSize];
            int[] parents = new int[matrixSize];

            // تهيئة المسافات
            for (int i = 0; i < matrixSize; i++)
            {
                distances[i] = int.MaxValue;
                parents[i] = -1;
            }
            distances[startNode] = 0;

            using (Graphics g = panel4.CreateGraphics())
            {
                g.Clear(panel4.BackColor); // تنظيف اللوحة
                Point[] positions = GenerateCircularPoints(panel4.Width, panel4.Height);

                // رسم العقد
                for (int i = 0; i < matrixSize; i++)
                {
                    Point position = positions[i];
                    g.FillEllipse(Brushes.Yellow, position.X - 15, position.Y - 15, 30, 30);
                    g.DrawEllipse(Pens.Black, position.X - 15, position.Y - 15, 30, 30);
                    g.DrawString(((char)('A' + i)).ToString(), new Font("Arial", 12), Brushes.Black, position.X - 8, position.Y - 8);
                }

                // قائمة لتخزين الحواف لرسمها لاحقاً مرتبة حسب الأوزان
                List<(int u, int v, int weight)> edgesToDraw = new List<(int u, int v, int weight)>();

                // تنفيذ خوارزمية بيلمان-فورد
                for (int step = 0; step < matrixSize - 1; step++)
                {
                    for (int u = 0; u < matrixSize; u++)
                    {
                        for (int v = 0; v < matrixSize; v++)
                        {
                            if (adjacencyMatrix[u, v] > 0 && distances[u] != int.MaxValue)
                            {
                                int weight = weightMatrix[u, v];
                                if (distances[u] + weight < distances[v])
                                {
                                    distances[v] = distances[u] + weight;
                                    parents[v] = u;

                                    // إضافة الحافة إلى القائمة
                                    edgesToDraw.Add((u, v, weight));
                                }
                            }
                        }
                    }
                }

                // التحقق من دورات سالبة
                for (int u = 0; u < matrixSize; u++)
                {
                    for (int v = 0; v < matrixSize; v++)
                    {
                        if (adjacencyMatrix[u, v] > 0 && distances[u] != int.MaxValue)
                        {
                            if (distances[u] + weightMatrix[u, v] < distances[v])
                            {
                                MessageBox.Show("Graph contains a negative weight cycle!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }

                // ترتيب الحواف حسب الأوزان تصاعدياً
                edgesToDraw.Sort((edge1, edge2) => edge1.weight.CompareTo(edge2.weight));

                // رسم الحواف بترتيب الأوزان
                foreach (var edge in edgesToDraw)
                {
                    DrawEdgeWithWeight(edge.u, edge.v, positions, g, edge.weight);
                    Thread.Sleep(500); // تأخير لعرض الخطوات
                }
            }
        }

        private void unweighted_graph_CheckedChanged_1(object sender, EventArgs e)
        {
            if (unweighted_graph.Checked)
            {
                // تعطيل مصفوفة الأوزان
                DisableWeightMatrix();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


        //العمق
        private void PrepareDFSWithColor(int startNode)
        {
            currentStep = 0;
            stepsQueue.Clear();
            bool[] visited = new bool[matrixSize];
            Point[] nodePositions = GenerateCircularPoints(panelGraph.Width, panelGraph.Height);

            void DFS(int node)
            {
                stepsQueue.Add(() =>
                {
                    visited[node] = true;
                    DrawNodeAndEdge(node, nodePositions, visited, panel4.CreateGraphics(), Pens.Black);
                });

                for (int i = 0; i < matrixSize; i++)
                {
                    if (adjacencyMatrix[node, i] == 1 && !visited[i])
                    {
                        stepsQueue.Add(() =>
                        {
                            DrawEdge(node, i, nodePositions, panel4.CreateGraphics(), Pens.Red);
                        });
                        DFS(i);
                    }
                }

                stepsQueue.Add(() =>
                {
                    Point position = nodePositions[node];
                    using (Graphics g = panel4.CreateGraphics())
                    {
                        Pen greenPen = new Pen(Color.Green, 2);
                        g.DrawEllipse(greenPen, position.X - 15, position.Y - 15, 30, 30);
                    }
                });
            }

            DFS(startNode);
        }
        // زر الضغط
       




        private void weighted_graph_CheckedChanged_1(object sender, EventArgs e)
        {
            if (weighted_graph.Checked)
            {
                // تمكين مصفوفة الأوزان
                EnableWeightMatrix();
            }
        }

      

        private void save_adjacency_Click_1(object sender, EventArgs e)
        {
           
                if (adjacencyMatrixInputs == null)
                {
                    MessageBox.Show("يرجى إدخال عدد النقاط أولاً.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j < matrixSize; j++)
                    {
                        if (int.TryParse(adjacencyMatrixInputs[i, j].Text, out int value))
                        {
                            adjacencyMatrix[i, j] = value;
                            weightMatrixInputs[i, j].Enabled = value == 1; // تمكين أو تعطيل مربعات النص للأوزان بناءً على القيمة
                        }
                    else
                    {
                        adjacencyMatrix[i, j] = 0; // إذا كانت القيمة غير صالحة، تعيينها إلى 0
                        adjacencyMatrixInputs[i, j].Text = " ";
                    }
                }
                }

                // تعطيل مربعات النص لمصفوفة الجوار بعد الحفظ
                foreach (var textBox in adjacencyMatrixInputs)
                {
                    textBox.Enabled = false;
                }

                // تمكين أزرار التعديل والمسح
                update_adjacency.Enabled = true;
                delete_adjacency.Enabled = true;
                save_weight.Enabled = true;

                MessageBox.Show("تم حفظ مصفوفة الجوار بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        private void update_adjacency_Click(object sender, EventArgs e)
        {
            foreach (Control control in panelAdjacencyMatrix.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Enabled = true; // تمكين مربعات النص
                }
            }
        }

        private void delete_adjacency_Click_1(object sender, EventArgs e)
        {

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    adjacencyMatrix[i, j] = 0; // إعادة تعيين القيم في المصفوفة
                    if (adjacencyMatrixInputs[i, j] != null)
                    {
                        adjacencyMatrixInputs[i, j].Text = ""; // مسح النصوص داخل مربعات النص
                    }
                }
            }

            // تعطيل أزرار التعديل والمسح
            update_adjacency.Enabled = false;
            delete_adjacency.Enabled = false;

            MessageBox.Show("تم مسح مصفوفة الجوار بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void save_weight_Click(object sender, EventArgs e)
        {
            if (weightMatrixInputs == null || adjacencyMatrix == null)
            {
                MessageBox.Show("لم يتم تهيئة المصفوفة بشكل صحيح. تأكد من إدخال مصفوفة الجوار أولاً.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (adjacencyMatrix[i, j] == 1) // فقط إذا كان هناك اتصال
                    {
                        if (string.IsNullOrWhiteSpace(weightMatrixInputs[i, j].Text))
                        {
                            MessageBox.Show($"يرجى إدخال قيمة في الخلية ({i + 1}, {j + 1}).", "خطأ الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (!int.TryParse(weightMatrixInputs[i, j].Text, out int weight))
                        {
                            MessageBox.Show($"القيمة في الخلية ({i + 1}, {j + 1}) ليست عدداً صحيحاً.", "خطأ الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        weightMatrix[i, j] = weight; // حفظ الوزن
                    }
                }
            }

            // تعطيل مربعات النص بعد الحفظ
            foreach (var textBox in weightMatrixInputs)
            {
                if (textBox != null)
                {
                    textBox.Enabled = false;
                }
            }

            // تحديث الرسم في البانل جراف
            DrawWeightsOnGraph();

            MessageBox.Show("تم حفظ الأوزان بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // تمكين زر التعديل
            update_weight.Enabled = true;
            delete_weightt.Enabled = true;
        }

        private void update_weight_Click(object sender, EventArgs e)
        {
               

                // تمكين مربعات النص الخاصة بمصفوفة الأوزان فقط إذا كانت الجوار محفوظة
                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j < matrixSize; j++)
                    {
                        if (adjacencyMatrix[i, j] == 1) // فقط إذا كان هناك اتصال
                        {
                            weightMatrixInputs[i, j].Enabled = true; // تمكين مربع النص
                        }
                    }
                }

                MessageBox.Show("يمكنك الآن تعديل الأوزان.", "تعديل الأوزان", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //دالة رسم الاوزان في الرسم
            private void DrawWeightsOnGraph()
        {
            using (Graphics g = panelGraph.CreateGraphics())
            {
                g.Clear(panelGraph.BackColor); // تنظيف الرسم القديم

                Point[] points = GenerateCircularPoints(panelGraph.Width, panelGraph.Height);

                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j < matrixSize; j++)
                    {
                        if (adjacencyMatrix[i, j] == 1) // فقط إذا كان هناك اتصال
                        {
                            Point startPoint = points[i];
                            Point endPoint = points[j];

                            // رسم الخط
                            g.DrawLine(Pens.Black, startPoint, endPoint);

                            // رسم الوزن في منتصف الخط
                            if (weightMatrix[i, j] > 0)
                            {
                                int midX = (startPoint.X + endPoint.X) / 2;
                                int midY = (startPoint.Y + endPoint.Y) / 2;
                                g.DrawString(weightMatrix[i, j].ToString(), new Font("Arial", 10), Brushes.Red, midX, midY);
                            }
                        }
                    }
                }

                // رسم العقد
                for (int i = 0; i < points.Length; i++)
                {
                    g.FillEllipse(Brushes.White, points[i].X - 15, points[i].Y - 15, 30, 30);
                    g.DrawEllipse(Pens.Black, points[i].X - 15, points[i].Y - 15, 30, 30);
                    g.DrawString(vertexNames[i], new Font("Arial", 12), Brushes.Black, points[i].X - 10, points[i].Y - 10);
                }
            }
        }

        private void delete_weightt_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (weightMatrixInputs[i, j] != null)
                    {
                        weightMatrix[i, j] = 0; // إعادة تعيين الأوزان إلى 0
                        weightMatrixInputs[i, j].Text = ""; // مسح النصوص داخل مربعات النص
                    }
                }
            }

            MessageBox.Show("تم مسح مصفوفة الأوزان بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // تعطيل أزرار التعديل والحذف
            update_weight.Enabled = false;
            delete_weightt.Enabled = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            label3.Left = 750;
            textBox2.Left = 619;
            textBox2.Top = 495;
            panel4.Visible = true;
            panelWeightMatrix.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            panelAdjacencyMatrix.Visible = false;
            save_adjacency.Visible = false;
            update_adjacency.Visible = false;
            delete_adjacency.Visible = false;
            delete_weightt.Visible = false;
            update_weight.Visible = false;
            save_weight.Visible = false;
            panelGraph.Left = 613;
            panel4.Left = 15;
            panel4.Width = 550;
            panel4.Height = 352;

            if (if_tree.Checked)
            {

                if (traversalSteps == null || traversalSteps.Count == 0)
                {
                    MessageBox.Show("No steps to display. Please generate and traverse the tree first.", "No Steps", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                panelGraph.Refresh();

                if (currentStepIndex < traversalSteps.Count - 1)
                {
                    currentStepIndex++; // الانتقال إلى الخطوة التالية
                    panel4.Refresh(); // إعادة رسم اللوحة
                }
                else
                {
                    MessageBox.Show("You have reached the last step.", "End of Steps", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                int height = tree.GetHeight(tree.Root);
                textBox2.Text = $"Height of the tree: {height}";
            }
            
              

            //


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            if (tree.Root == null || traversalSteps == null || currentStepIndex < 0)
            {
                return; // لا شيء لرسمه إذا كانت الشجرة فارغة أو لا توجد خطوات
            }

            Graphics g = e.Graphics;

            // إعادة رسم الشجرة كاملة، لكن فقط عقد الخطوة الحالية يتم تلوينها
            DrawTreeWithSteps(g, tree.Root, panel4.Width / 2, 50, 100, 50, currentStepIndex);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBox2.Visible = true;

            textBox2.Left = 50;
            panel4.Visible = true;
            panelWeightMatrix.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            panelAdjacencyMatrix.Visible = false;
            save_adjacency.Visible = false;
            update_adjacency.Visible = false;
            delete_adjacency.Visible = false;
            delete_weightt.Visible = false;
            update_weight.Visible = false;
            save_weight.Visible = false;
            panelGraph.Left = 613;
            panel4.Left = 15;
            panel4.Width = 550;
            panel4.Height = 352;
        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }
    }
}
    
