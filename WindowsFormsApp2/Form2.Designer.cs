namespace WindowsFormsApp2
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelAdjacencyMatrix = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelWeightMatrix = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelGraph = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.number_points = new System.Windows.Forms.TextBox();
            this.labels_points = new System.Windows.Forms.TextBox();
            this.save_adjacency = new System.Windows.Forms.Button();
            this.update_adjacency = new System.Windows.Forms.Button();
            this.delete_adjacency = new System.Windows.Forms.Button();
            this.delete_weightt = new System.Windows.Forms.Button();
            this.update_weight = new System.Windows.Forms.Button();
            this.save_weight = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.if_graph = new System.Windows.Forms.RadioButton();
            this.if_tree = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textsolving = new System.Windows.Forms.TextBox();
            this.textrequr = new System.Windows.Forms.TextBox();
            this.textproplem = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.unweighted_graph = new System.Windows.Forms.RadioButton();
            this.weighted_graph = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.undirect_graph = new System.Windows.Forms.RadioButton();
            this.direct_graph = new System.Windows.Forms.RadioButton();
            this.execute_step_by_step = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAdjacencyMatrix
            // 
            this.panelAdjacencyMatrix.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelAdjacencyMatrix.Location = new System.Drawing.Point(933, 212);
            this.panelAdjacencyMatrix.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.panelAdjacencyMatrix.Name = "panelAdjacencyMatrix";
            this.panelAdjacencyMatrix.Size = new System.Drawing.Size(309, 297);
            this.panelAdjacencyMatrix.TabIndex = 0;
            this.panelAdjacencyMatrix.Paint += new System.Windows.Forms.PaintEventHandler(this.panelAdjacencyMatrix_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.RoyalBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(636, 171);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "مصفوفة الاوزان";
            // 
            // panelWeightMatrix
            // 
            this.panelWeightMatrix.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelWeightMatrix.Location = new System.Drawing.Point(551, 212);
            this.panelWeightMatrix.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.panelWeightMatrix.Name = "panelWeightMatrix";
            this.panelWeightMatrix.Size = new System.Drawing.Size(309, 297);
            this.panelWeightMatrix.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.RoyalBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1026, 171);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "مصفوفة الجوار";
            // 
            // panelGraph
            // 
            this.panelGraph.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelGraph.Location = new System.Drawing.Point(23, 212);
            this.panelGraph.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.panelGraph.Name = "panelGraph";
            this.panelGraph.Size = new System.Drawing.Size(421, 347);
            this.panelGraph.TabIndex = 2;
            this.panelGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGraph_Paint_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.RoyalBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(193, 179);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "الرسم";
            // 
            // number_points
            // 
            this.number_points.Location = new System.Drawing.Point(703, 62);
            this.number_points.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.number_points.Name = "number_points";
            this.number_points.Size = new System.Drawing.Size(95, 22);
            this.number_points.TabIndex = 3;
            this.number_points.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.number_points_KeyPress);
            // 
            // labels_points
            // 
            this.labels_points.Location = new System.Drawing.Point(539, 59);
            this.labels_points.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.labels_points.Name = "labels_points";
            this.labels_points.Size = new System.Drawing.Size(127, 22);
            this.labels_points.TabIndex = 4;
            // 
            // save_adjacency
            // 
            this.save_adjacency.BackColor = System.Drawing.Color.RoyalBlue;
            this.save_adjacency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_adjacency.ForeColor = System.Drawing.Color.White;
            this.save_adjacency.Location = new System.Drawing.Point(1150, 515);
            this.save_adjacency.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.save_adjacency.Name = "save_adjacency";
            this.save_adjacency.Size = new System.Drawing.Size(75, 36);
            this.save_adjacency.TabIndex = 5;
            this.save_adjacency.Text = "حفظ";
            this.save_adjacency.UseVisualStyleBackColor = false;
            this.save_adjacency.Click += new System.EventHandler(this.save_adjacency_Click_1);
            // 
            // update_adjacency
            // 
            this.update_adjacency.BackColor = System.Drawing.Color.RoyalBlue;
            this.update_adjacency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update_adjacency.ForeColor = System.Drawing.Color.White;
            this.update_adjacency.Location = new System.Drawing.Point(1038, 515);
            this.update_adjacency.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.update_adjacency.Name = "update_adjacency";
            this.update_adjacency.Size = new System.Drawing.Size(75, 36);
            this.update_adjacency.TabIndex = 6;
            this.update_adjacency.Text = "تعديل";
            this.update_adjacency.UseVisualStyleBackColor = false;
            this.update_adjacency.Click += new System.EventHandler(this.update_adjacency_Click);
            // 
            // delete_adjacency
            // 
            this.delete_adjacency.BackColor = System.Drawing.Color.RoyalBlue;
            this.delete_adjacency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete_adjacency.ForeColor = System.Drawing.Color.White;
            this.delete_adjacency.Location = new System.Drawing.Point(939, 515);
            this.delete_adjacency.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.delete_adjacency.Name = "delete_adjacency";
            this.delete_adjacency.Size = new System.Drawing.Size(75, 36);
            this.delete_adjacency.TabIndex = 7;
            this.delete_adjacency.Text = "مسح";
            this.delete_adjacency.UseVisualStyleBackColor = false;
            this.delete_adjacency.Click += new System.EventHandler(this.delete_adjacency_Click_1);
            // 
            // delete_weightt
            // 
            this.delete_weightt.BackColor = System.Drawing.Color.RoyalBlue;
            this.delete_weightt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete_weightt.ForeColor = System.Drawing.Color.White;
            this.delete_weightt.Location = new System.Drawing.Point(570, 515);
            this.delete_weightt.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.delete_weightt.Name = "delete_weightt";
            this.delete_weightt.Size = new System.Drawing.Size(75, 36);
            this.delete_weightt.TabIndex = 10;
            this.delete_weightt.Text = "مسح";
            this.delete_weightt.UseVisualStyleBackColor = false;
            this.delete_weightt.Click += new System.EventHandler(this.delete_weightt_Click);
            // 
            // update_weight
            // 
            this.update_weight.BackColor = System.Drawing.Color.RoyalBlue;
            this.update_weight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update_weight.ForeColor = System.Drawing.Color.White;
            this.update_weight.Location = new System.Drawing.Point(671, 515);
            this.update_weight.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.update_weight.Name = "update_weight";
            this.update_weight.Size = new System.Drawing.Size(75, 36);
            this.update_weight.TabIndex = 9;
            this.update_weight.Text = "تعديل";
            this.update_weight.UseVisualStyleBackColor = false;
            this.update_weight.Click += new System.EventHandler(this.update_weight_Click);
            // 
            // save_weight
            // 
            this.save_weight.BackColor = System.Drawing.Color.RoyalBlue;
            this.save_weight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_weight.ForeColor = System.Drawing.Color.White;
            this.save_weight.Location = new System.Drawing.Point(774, 515);
            this.save_weight.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.save_weight.Name = "save_weight";
            this.save_weight.Size = new System.Drawing.Size(75, 36);
            this.save_weight.TabIndex = 8;
            this.save_weight.Text = "حفظ";
            this.save_weight.UseVisualStyleBackColor = false;
            this.save_weight.Click += new System.EventHandler(this.save_weight_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.RoyalBlue;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.label4.Location = new System.Drawing.Point(688, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "عدد الرؤوس";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.RoyalBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.label5.Location = new System.Drawing.Point(535, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "تسميات الرؤوس";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.if_graph);
            this.panel1.Controls.Add(this.if_tree);
            this.panel1.Location = new System.Drawing.Point(1139, 71);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(101, 71);
            this.panel1.TabIndex = 12;
            // 
            // if_graph
            // 
            this.if_graph.AutoSize = true;
            this.if_graph.BackColor = System.Drawing.Color.RoyalBlue;
            this.if_graph.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.if_graph.ForeColor = System.Drawing.Color.White;
            this.if_graph.Location = new System.Drawing.Point(16, 42);
            this.if_graph.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.if_graph.Name = "if_graph";
            this.if_graph.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.if_graph.Size = new System.Drawing.Size(64, 23);
            this.if_graph.TabIndex = 1;
            this.if_graph.TabStop = true;
            this.if_graph.Text = "مخطط";
            this.if_graph.UseVisualStyleBackColor = false;
            this.if_graph.CheckedChanged += new System.EventHandler(this.if_graph_CheckedChanged_1);
            // 
            // if_tree
            // 
            this.if_tree.AutoSize = true;
            this.if_tree.BackColor = System.Drawing.Color.RoyalBlue;
            this.if_tree.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.if_tree.ForeColor = System.Drawing.Color.White;
            this.if_tree.Location = new System.Drawing.Point(15, 14);
            this.if_tree.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.if_tree.Name = "if_tree";
            this.if_tree.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.if_tree.Size = new System.Drawing.Size(62, 23);
            this.if_tree.TabIndex = 0;
            this.if_tree.TabStop = true;
            this.if_tree.Text = "شجرة";
            this.if_tree.UseVisualStyleBackColor = false;
            this.if_tree.CheckedChanged += new System.EventHandler(this.if_tree_CheckedChanged_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.RoyalBlue;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1032, 26);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 25);
            this.label6.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(880, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(347, 37);
            this.button1.TabIndex = 16;
            this.button1.Text = "نوع الرسم وخصائصه";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textsolving
            // 
            this.textsolving.Location = new System.Drawing.Point(325, 108);
            this.textsolving.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.textsolving.Name = "textsolving";
            this.textsolving.ReadOnly = true;
            this.textsolving.Size = new System.Drawing.Size(164, 22);
            this.textsolving.TabIndex = 19;
            this.textsolving.Text = "خوارزمية الحل     ";
            this.textsolving.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textrequr
            // 
            this.textrequr.Location = new System.Drawing.Point(325, 59);
            this.textrequr.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.textrequr.Name = "textrequr";
            this.textrequr.ReadOnly = true;
            this.textrequr.Size = new System.Drawing.Size(164, 22);
            this.textrequr.TabIndex = 18;
            this.textrequr.Text = "المطلوب";
            this.textrequr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textproplem
            // 
            this.textproplem.Location = new System.Drawing.Point(325, 12);
            this.textproplem.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.textproplem.Name = "textproplem";
            this.textproplem.ReadOnly = true;
            this.textproplem.Size = new System.Drawing.Size(164, 22);
            this.textproplem.TabIndex = 17;
            this.textproplem.Text = "المشكلة      ";
            this.textproplem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(34, 108);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(261, 24);
            this.comboBox3.TabIndex = 22;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(34, 62);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(261, 24);
            this.comboBox2.TabIndex = 21;
            this.comboBox2.SelectionChangeCommitted += new System.EventHandler(this.comboBox2_SelectionChangeCommitted);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(34, 14);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(261, 24);
            this.comboBox1.TabIndex = 20;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(1544, 653);
            this.button2.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 41);
            this.button2.TabIndex = 23;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Controls.Add(this.unweighted_graph);
            this.panel3.Controls.Add(this.weighted_graph);
            this.panel3.Location = new System.Drawing.Point(847, 71);
            this.panel3.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(129, 71);
            this.panel3.TabIndex = 25;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // unweighted_graph
            // 
            this.unweighted_graph.AutoSize = true;
            this.unweighted_graph.BackColor = System.Drawing.Color.RoyalBlue;
            this.unweighted_graph.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unweighted_graph.ForeColor = System.Drawing.Color.White;
            this.unweighted_graph.Location = new System.Drawing.Point(21, 14);
            this.unweighted_graph.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.unweighted_graph.Name = "unweighted_graph";
            this.unweighted_graph.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.unweighted_graph.Size = new System.Drawing.Size(95, 23);
            this.unweighted_graph.TabIndex = 1;
            this.unweighted_graph.TabStop = true;
            this.unweighted_graph.Text = "غير موزون";
            this.unweighted_graph.UseVisualStyleBackColor = false;
            this.unweighted_graph.CheckedChanged += new System.EventHandler(this.unweighted_graph_CheckedChanged_1);
            // 
            // weighted_graph
            // 
            this.weighted_graph.AutoSize = true;
            this.weighted_graph.BackColor = System.Drawing.Color.RoyalBlue;
            this.weighted_graph.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weighted_graph.ForeColor = System.Drawing.Color.White;
            this.weighted_graph.Location = new System.Drawing.Point(43, 42);
            this.weighted_graph.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.weighted_graph.Name = "weighted_graph";
            this.weighted_graph.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.weighted_graph.Size = new System.Drawing.Size(69, 23);
            this.weighted_graph.TabIndex = 0;
            this.weighted_graph.TabStop = true;
            this.weighted_graph.Text = "موزون";
            this.weighted_graph.UseVisualStyleBackColor = false;
            this.weighted_graph.CheckedChanged += new System.EventHandler(this.weighted_graph_CheckedChanged_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Controls.Add(this.undirect_graph);
            this.panel2.Controls.Add(this.direct_graph);
            this.panel2.Location = new System.Drawing.Point(993, 71);
            this.panel2.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(123, 71);
            this.panel2.TabIndex = 24;
            // 
            // undirect_graph
            // 
            this.undirect_graph.AutoSize = true;
            this.undirect_graph.BackColor = System.Drawing.Color.RoyalBlue;
            this.undirect_graph.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.undirect_graph.ForeColor = System.Drawing.Color.White;
            this.undirect_graph.Location = new System.Drawing.Point(21, 14);
            this.undirect_graph.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.undirect_graph.Name = "undirect_graph";
            this.undirect_graph.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.undirect_graph.Size = new System.Drawing.Size(87, 23);
            this.undirect_graph.TabIndex = 1;
            this.undirect_graph.TabStop = true;
            this.undirect_graph.Text = "غير موجه";
            this.undirect_graph.UseVisualStyleBackColor = false;
            // 
            // direct_graph
            // 
            this.direct_graph.AutoSize = true;
            this.direct_graph.BackColor = System.Drawing.Color.RoyalBlue;
            this.direct_graph.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.direct_graph.ForeColor = System.Drawing.Color.White;
            this.direct_graph.Location = new System.Drawing.Point(46, 42);
            this.direct_graph.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.direct_graph.Name = "direct_graph";
            this.direct_graph.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.direct_graph.Size = new System.Drawing.Size(61, 23);
            this.direct_graph.TabIndex = 0;
            this.direct_graph.TabStop = true;
            this.direct_graph.Text = "موجة";
            this.direct_graph.UseVisualStyleBackColor = false;
            // 
            // execute_step_by_step
            // 
            this.execute_step_by_step.Location = new System.Drawing.Point(410, 956);
            this.execute_step_by_step.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.execute_step_by_step.Name = "execute_step_by_step";
            this.execute_step_by_step.Size = new System.Drawing.Size(206, 23);
            this.execute_step_by_step.TabIndex = 27;
            this.execute_step_by_step.Text = "button2";
            this.execute_step_by_step.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Location = new System.Drawing.Point(76, 685);
            this.button3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(170, 42);
            this.button3.TabIndex = 28;
            this.button3.Text = "تنفيذ خطوة -خطوة";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Linen;
            this.panel4.Location = new System.Drawing.Point(1355, 212);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(406, 347);
            this.panel4.TabIndex = 29;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1354, 148);
            this.textBox2.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(405, 22);
            this.textBox2.TabIndex = 31;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ClientSize = new System.Drawing.Size(1773, 750);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.execute_step_by_step);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textsolving);
            this.Controls.Add(this.textrequr);
            this.Controls.Add(this.textproplem);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.delete_weightt);
            this.Controls.Add(this.update_weight);
            this.Controls.Add(this.save_weight);
            this.Controls.Add(this.delete_adjacency);
            this.Controls.Add(this.update_adjacency);
            this.Controls.Add(this.save_adjacency);
            this.Controls.Add(this.labels_points);
            this.Controls.Add(this.number_points);
            this.Controls.Add(this.panelGraph);
            this.Controls.Add(this.panelWeightMatrix);
            this.Controls.Add(this.panelAdjacencyMatrix);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.Name = "Form2";
            this.Text = "i";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panelAdjacencyMatrix;
        public System.Windows.Forms.Panel panelWeightMatrix;
        public System.Windows.Forms.Panel panelGraph;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox number_points;
        public System.Windows.Forms.TextBox labels_points;
        public System.Windows.Forms.Button save_adjacency;
        public System.Windows.Forms.Button update_adjacency;
        public System.Windows.Forms.Button delete_adjacency;
        public System.Windows.Forms.Button delete_weightt;
        public System.Windows.Forms.Button update_weight;
        public System.Windows.Forms.Button save_weight;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.RadioButton if_tree;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.RadioButton if_graph;
        public System.Windows.Forms.TextBox textsolving;
        public System.Windows.Forms.TextBox textrequr;
        public System.Windows.Forms.TextBox textproplem;
        public System.Windows.Forms.ComboBox comboBox3;
        public System.Windows.Forms.ComboBox comboBox2;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.RadioButton unweighted_graph;
        public System.Windows.Forms.RadioButton weighted_graph;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.RadioButton undirect_graph;
        public System.Windows.Forms.RadioButton direct_graph;
        public System.Windows.Forms.Button execute_step_by_step;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.TextBox textBox2;
    }
}