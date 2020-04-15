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
    public partial class Form4 : Form
    {
        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<string, List<string>> SETS1 = FileUpload.SETS;

            SETS.ColumnCount = SETS1.Count;
            SETS.RowCount = 300;
            for (int i = 0; i < SETS1.Count; i++)
            {
                string a = SETS1.ElementAt(i).Key;
                int b = SETS1[a].Count;
                SETS[i, 0].Value = SETS1.ElementAt(i).Key;
                SETS.Rows[0].DefaultCellStyle.BackColor = Color.Yellow;

                for (int j = 0; j < b; j++)
                {
                    SETS[i, j + 1].Value = SETS1.ElementAt(i).Value.ElementAt(j);
                }

            }

        }

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

        
    }
}
