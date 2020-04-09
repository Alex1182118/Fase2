using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fase_1
{
    public partial class Form2 : Form
    {
        private void button2_Click_1(object sender, EventArgs e)
        {
            Dictionary<string, List<int>> FirstTree = Tree.FirstTree;

            FIRST.ColumnCount = FirstTree.Count;
            FIRST.RowCount = 400;
            for (int i = 0; i < FirstTree.Count; i++)
            {
                string aFirst = FirstTree.ElementAt(i).Key;
                int bFirst = FirstTree[aFirst].Count;
                string DatoFirst = FirstTree.ElementAt(i).Key.Substring(0, 1);
                FIRST[i, 0].Value = DatoFirst;

                for (int j = 0; j < bFirst; j++)
                {
                    FIRST[i, j + 1].Value = FirstTree.ElementAt(i).Value.ElementAt(j);
                }

            }
        }
        private void FIRST_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Dictionary<string, List<int>> FirstTree = Tree.FirstTree;

            FIRST.ColumnCount = FirstTree.Count;
            FIRST.RowCount = 400;
            for (int i = 0; i < FirstTree.Count; i++)
            {
                string aFirst = FirstTree.ElementAt(i).Key;
                int bFirst = FirstTree[aFirst].Count;
                string DatoFirst = FirstTree.ElementAt(i).Key.Substring(0, 1);
                FIRST[i, 0].Value = DatoFirst;

                for (int j = 0; j < bFirst; j++)
                {
                    FIRST[i, j + 1].Value = FirstTree.ElementAt(i).Value.ElementAt(j);
                }

            }

        }

        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
