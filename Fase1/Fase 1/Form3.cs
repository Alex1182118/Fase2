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
    public partial class Form3 : Form
    {
        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<string, List<int>> LastTree = Tree.LastTree;

            LAST.ColumnCount = LastTree.Count;
            LAST.RowCount = 400;
            for (int i = 0; i < LastTree.Count; i++)
            {
                string aLast = LastTree.ElementAt(i).Key;
                int bLast = LastTree[aLast].Count;
                string DatoLast = LastTree.ElementAt(i).Key.Substring(0, 1);
                LAST[i, 0].Value = DatoLast;

                for (int j = 0; j < bLast; j++)
                {
                    LAST[i, j + 1].Value = LastTree.ElementAt(i).Value.ElementAt(j);
                }

            }

            LastTree = new Dictionary<string, List<int>>();
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

       
    }
}
