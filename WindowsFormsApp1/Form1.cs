using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0; int[] a;
            try
            {
                n = Convert.ToInt16(textBox1.Text);
                a = new int[n];
                Arrays.CreateArr(a);
                Arrays.PrintArr(a, dataGridView1, dataGridView2);

            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
        class Arrays
        {
            public bool error = false;
            int[] a;
            int length;
            public Arrays(int size)
            {
                a = new int[size]; length = size;
            }
            public int Length { get { return length; } }

            private static Random ran = new Random();
            public static void CreateArr(int[] a)
            {
                for (int i = 0; i < a.GetLength(0); i++)

                    a[i] = ran.Next(-100, 100);

            }
            public static void PrintArr(int[] a, DataGridView dg, DataGridView dg2)
            {
                dg.Rows.Clear();

                dg2.Rows.Clear();

                for (int i = 0; i < a.GetLength(0); i++)
                {

                    dg.Rows.Add(a[i].ToString());
                    a[i] = a[i] + 2;
                    dg2.Rows.Add(a[i].ToString());
                }

            }


            public int this[int i]
            {
                get
                {
                    if (i >= 0 && i < length) return a[i];
                    else { error = true; return 0; }
                }
                set
                {
                    if (i >= 0 && i < length && value >= -100 && value <= 100)
                        a[i] = value;
                    else error = true;
                }
            }
        }
    }
}
