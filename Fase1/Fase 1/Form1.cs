using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;


namespace Fase_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            FileUpload fileLecture = new FileUpload();
            Dictionary<string, List<string>> SETS1 = FileUpload.SETS;
            Automata transition = new Automata();
            Tree tree = new Tree();
            OpenFileDialog ofd = new OpenFileDialog();
            Dictionary<int, List<int>> followpos;
            Dictionary<int, string> NodeData = new Dictionary<int, string>();
            

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                try
                {
                    string Register = fileLecture.ReadFile(path);
                    ExpressionNode root = transition.CreateTree(Register);
                    root = tree.assignRules(root);
                    root = tree.FirstAndLast(root);
                    followpos = tree.Follows(root);
                    followpos = tree.FollowTable(root, followpos);
                    NodeData = tree.ObtainLeafs(root, NodeData);
                    Dictionary<string, string> automata = transition.CreateAutomata(root, NodeData, followpos);

                    //introducirlo al arbol con reglas
                    //1ero: numero de nodo
                    //segundo: followpos
                    //tercero: dato del arbol
                   
                    FOLLOWS.ColumnCount = followpos.Count;
                    FOLLOWS.RowCount = 400;
                    for (int i = 0; i < followpos.Count; i++)
                    {
                        int a = followpos.ElementAt(i).Key;
                        int b = followpos[a].Count;
                        FOLLOWS[i, 0].Value = followpos.ElementAt(i).Key;
                       
                        for (int j = 0; j < b; j++)
                        {
                            FOLLOWS[i, j + 1].Value = followpos.ElementAt(i).Value.ElementAt(j);
                        }

                    }

                    SETS.ColumnCount = SETS1.Count;
                    SETS.RowCount = 400;
                    for (int i = 0; i < SETS1.Count; i++)
                    {
                        string a = SETS1.ElementAt(i).Key;
                        int b = SETS1[a].Count;
                        SETS[i, 0].Value = SETS1.ElementAt(i).Key;

                        for (int j = 0; j < b; j++)
                        {
                            SETS[i, j + 1].Value = SETS1.ElementAt(i).Value.ElementAt(j);
                        }

                    }

                    Follow.ColumnCount = 2;
                    Follow.RowCount = followpos.Count + 1;
                    Follow[0, 0].Value = "Estado: ";
                    Follow[1, 0].Value = "Transicion";
                    Follow.ColumnHeadersVisible = false;
                    Follow.RowHeadersVisible = false;

                    for (int i = 0; i < automata.Count; i++)
                    {
                        Follow[1, i + 1].Value = automata.ElementAt(i).Key;
                        Follow[0, i + 1].Value = automata.ElementAt(i).Value;
                    }

                    Register = "";
                    root = new ExpressionNode();
                    followpos = new Dictionary<int, List<int>>();
                    SETS1 = new Dictionary<string, List<string>>();
                    NodeData = new Dictionary<int, string>();
                    automata = new Dictionary<string, string>();
                    fileLecture = new FileUpload();
                    transition = new Automata();
                    tree = new Tree();
                    ofd = new OpenFileDialog();
                }
                catch (Exception x)
                {
                    MessageBox.Show((x.Message), "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Follow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            if (form2.DialogResult == DialogResult.Yes) { }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
            if (form3.DialogResult == DialogResult.Yes) { }
           
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
