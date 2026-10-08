using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        public Form3(Panel p)
        {
            this.Controls.Add(p);
            p.Size = new Size();
            p.Show();
        }
       



        // private Form2 form2;
        public Form3(Form2 existingForm2)
        {
            InitializeComponent();
           // form2 = existingForm2;
           
          

        }
        public static void TransferPanel(Panel sourcePanel, Form3 targetForm)
        {
            Panel newPanel = new Panel
            {
                Size = sourcePanel.Size,
                Location = sourcePanel.Location,
                BackColor = sourcePanel.BackColor,
                BorderStyle = sourcePanel.BorderStyle
            };

            foreach (Control control in sourcePanel.Controls)
            {
                Control newControl = (Control)Activator.CreateInstance(control.GetType());
                newControl.Text = control.Text;
                newControl.Size = control.Size;
                newControl.Location = control.Location;
                newControl.BackColor = control.BackColor;
                newControl.ForeColor = control.ForeColor;

                newPanel.Controls.Add(newControl);
            }

            targetForm.Controls.Add(newPanel);
        }
       


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            //form2.ShowDialog();
            form2.StartPosition = FormStartPosition.Manual;
            form2.Location = this.Location;
            form2.Size = this.Size;
            form2.Show();
            this.Hide();



        }

        public Form3()
        {
            InitializeComponent();
            Panel my = new Panel();
             my.Size = new Size(200, 200);
          //  this.Controls.Add(my);
          //  Form2.pane(my);
            my.Show();

        }
        private void Form3_Load(object sender, EventArgs e)
        {

            //Panel graphPanel = form2.GetGraphPanel();
            //if (graphPanel != null)
            //{
            //    form2.Controls.Remove(graphPanel);
            //    graphPanel.Location = new Point(600, 122);
            //    this.Controls.Add(graphPanel);
            //    graphPanel.Dock = DockStyle.None;
            //}
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
