using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Text;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Diagnostics;

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
                    Dictionary<string, string>  automata = transition.CreateAutomata(root, NodeData, followpos);
                    Generator program = new Generator(automata);
                    tbxScanner.Text = program.ExportCode(automata, path);

                    FOLLOWS.ColumnCount = followpos.Count;
                    int hola = FOLLOWS.ColumnCount = followpos.Count;
                    FOLLOWS.RowCount = 100;
                    FOLLOWS.Rows[0].DefaultCellStyle.BackColor = Color.Yellow;
                    
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
        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
            if (form4.DialogResult == DialogResult.Yes) { }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName + ".cs");
                streamWriter.Write(tbxScanner.Text);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;

                StreamReader streamReader = new StreamReader(path);
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(streamReader.ReadToEnd());

                //target framework v 4.6.1
                CSharpCodeProvider csc = new CSharpCodeProvider(new Dictionary<string, string> { { "CompilerVersion", "v4.0" } });
                CompilerParameters parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, "validation.exe", true);
                parameters.GenerateExecutable = true;
                CompilerResults compilerResults = csc.CompileAssemblyFromSource(parameters, stringBuilder.ToString());

                if (compilerResults.Errors.Cast<CompilerError>().ToList().Count == 0)
                {
                    Process.Start(Application.StartupPath + "/" + "validation.exe");
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
