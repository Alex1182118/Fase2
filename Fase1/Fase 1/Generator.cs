using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase_1
{
    class Generator
    {
        StringBuilder sb;
        int state_principal = 0;
        Dictionary<string, bool> esFinal = new Dictionary<string, bool>();


        public Generator(Dictionary<string, string> AFD)

        {
            sb = new StringBuilder();
        }

        private Dictionary<int, List<string>> ObtenerTransiciones(Dictionary<string, string> AFD, List<int> cantidadTransiciones)
        {
            Dictionary<int, List<string>> transiciones = new Dictionary<int, List<string>>();


            esFinal = new Dictionary<string, bool>();

            for (int i = 0; i < cantidadTransiciones.Count; i++)
            {
                esFinal.Add(i.ToString(), false);
            }

            for (int i = 0; i < cantidadTransiciones.Count; i++)
            { 
                List<string> insert = new List<string>();

                for (int j = 0; j < AFD.Count; j++)
                {

                    string[] split = AFD.ElementAt(j).Key.Split('/');
                    string compare = "";

                    for (int k = 1; k < split[0].Trim().Length; k++)
                    {
                        compare += split[0].Substring(k, 1);
                    }

                    if (Convert.ToInt32(compare) == i)
                    {
                        string add_string = "";


                        for (int k = 1; k < AFD.ElementAt(j).Value.Length; k++)
                        {
                            if (int.TryParse(AFD.ElementAt(j).Value.Substring(k, 1), out int n) == true)
                            {
                                add_string += AFD.ElementAt(j).Value.Substring(k, 1);

                            }
                            else
                            {
                                continue;
                            }
                        }

                        if (AFD.ElementAt(j).Value.Substring(0, 1) == "#")
                        {   
                            string numero = add_string;


                            esFinal[numero] = true;
                        }

                        add_string += "/";
                        add_string += split[1];
                        insert.Add(add_string);

                    }
                    else
                    {
                        continue;
                    }
                }

                transiciones.Add(i, new List<string>(insert));


            }



            return transiciones;
        }

        private List<int> obtenerCantidadTransiciones(Dictionary<string, string> AFD)
        {
            List<int> TotalTransiciones = new List<int>();
            string numero = "";

            for (int i = 0; i < AFD.Count; i++)
            {
                numero = "";
                string[] temp = AFD.ElementAt(i).Key.Split('/');

                for (int j = 1; j < temp[0].Trim().Length; j++)
                {
                    numero += temp[0].Substring(j, 1);
                }

                if (!TotalTransiciones.Contains(Convert.ToInt32(numero)))
                {
                    TotalTransiciones.Add(Convert.ToInt32(numero));
                }

                numero = "";

                for (int j = 1; j < AFD.ElementAt(i).Value.Length; j++)
                {
                    if (int.TryParse(AFD.ElementAt(i).Value.Substring(j, 1), out int n) == true)
                    {
                        numero += AFD.ElementAt(i).Value.Substring(j, 1);
                    }

                }

                if (!TotalTransiciones.Contains(Convert.ToInt32(numero)))
                {
                    TotalTransiciones.Add(Convert.ToInt32(numero));
                }
            }

            TotalTransiciones.Sort();

            return TotalTransiciones;
        }

        public string GenerateCode(Dictionary<string, string> AFD, int state)
        {
            List<int> totalTransiciones = new List<int>();
            totalTransiciones = obtenerCantidadTransiciones(AFD);
            Dictionary<int, List<string>> transiciones = new Dictionary<int, List<string>>();
            transiciones = ObtenerTransiciones(AFD, totalTransiciones);


            sb.AppendLine("case " + state_principal.ToString() + ":");

            List<string> datos_transicion = transiciones[state_principal];

            for (int i = 0; i < totalTransiciones.Count; i++)
            {

                string data = "";
                data += "if(";

                for (int j = 0; j < datos_transicion.Count; j++)
                {

                    string[] split = datos_transicion.ElementAt(j).Split('/');


                    if (split[1] == " \'")
                    {
                        split[1] = "\\" + split[1].Trim();
                    }
                    if (split[1] == " \"")
                    {
                        split[1] = "\\" + split[1].Trim();
                    }

                    if (Convert.ToInt32(split[0]) == i + 1)
                    {
                        if (split[1].Trim().Length > 1 && split[1] != "\\\'" && split[1] != "\\\"")
                        {
                            for (int k = 0; k < FileUpload.SETS.Count; k++)
                            {
                                if (split[1].Trim() == FileUpload.SETS.ElementAt(k).Key.Trim())
                                {
                                    int count = 1;
                                    int dato_inicial = Convert.ToChar(FileUpload.SETS.ElementAt(k).Value.ElementAt(0));
                                    int dato_final = Convert.ToChar(FileUpload.SETS.ElementAt(k).Value.ElementAt(
                                         FileUpload.SETS.ElementAt(k).Value.Count - 1));

                                    if (dato_final > dato_inicial)
                                    {
                                        char dato = (char)dato_inicial;
                                        data += "principal >= \'" + dato + "\' &&";
                                        dato = (char)dato_final;
                                        data += " principal <= \'" + dato + "\' ||";
                                    }
                                    else
                                    {
                                        while (dato_final < dato_inicial)
                                        {
                                            count = count + 1;
                                            dato_final = Convert.ToChar(FileUpload.SETS.ElementAt(k).Value.ElementAt(
                                            FileUpload.SETS.ElementAt(k).Value.Count - 1));
                                        }

                                    }
                                }
                            }
                        }
                        else
                        {
                            data += "principal == \'" + split[1].Trim() + "\'";
                            data += " ||";
                        }

                    }
                }

                data = data.Remove(data.Length - 2, 2);
                data += ")" + "\r\n";

                if (data[0] == 'i' && data[1] == ')' /*&& data[2] == ')'*/)
                {
                    data = "";
                    continue;
                }
                else
                {

                    sb.Append(data.Trim());
                    sb.AppendLine("{");

                }
                sb.AppendLine("word_chunk += readline[pos].ToString();");
                sb.AppendLine("state_principal = " + (i + 1).ToString() + ";");

                sb.AppendLine("pos = pos + 1;");
                sb.AppendLine("ValuateStr(readline, pos, state_principal);");
                sb.AppendLine("return;");
                sb.AppendLine("}");

            }

            if (state_principal < totalTransiciones.Count)
            {
                if (state_principal > 0)
                {
                    if (esFinal[state_principal.ToString()] == true && transiciones[state_principal].Count == 0)
                    {
                        sb.AppendLine("error = Retroceso(state_principal);");
                        sb.AppendLine("if(!error)");
                        sb.AppendLine("{");
                        sb.AppendLine("Console.WriteLine(word_chunk + \":\" + VerificarActions(\"ERROR\").ToString());");
                        sb.AppendLine("Console.ReadLine();");
                        sb.AppendLine("int originalLength = readline.Length;");
                        sb.AppendLine("readline = readline.Substring(word_chunk.Length, (readline.Length - word_chunk.Length));");
                        sb.AppendLine("if (pos < originalLength)");
                        sb.AppendLine("{");
                        sb.AppendLine("word_chunk = \"\";");
                        sb.AppendLine("ValuateStr(readline, 0, 0);");
                        sb.AppendLine("return;");

                        sb.AppendLine("}");
                        sb.AppendLine("}");
                        sb.AppendLine("else");
                        sb.AppendLine("{");
                        sb.AppendLine("Console.WriteLine(word_chunk + \":\" + VerificarActions(word_chunk).ToString()); ");
                        sb.AppendLine("Console.ReadLine();");
                        sb.AppendLine("int originalLength = readline.Length;");
                        sb.AppendLine("readline = readline.Substring(word_chunk.Length, (readline.Length - word_chunk.Length));");
                        sb.AppendLine("if (pos < originalLength)");
                        sb.AppendLine("{");
                        sb.AppendLine("word_chunk = \"\";");
                        sb.AppendLine("ValuateStr(readline, 0, 0);");
                        sb.AppendLine("return;");

                        sb.AppendLine("}");
                        sb.AppendLine("}");
                    }
                    else
                    {
                        sb.AppendLine("else");
                        sb.AppendLine("{");
                        sb.AppendLine("error = Retroceso(state_principal);");
                        sb.AppendLine("if(!error)");
                        sb.AppendLine("{");
                        sb.AppendLine("Console.WriteLine(word_chunk + \":\" + VerificarActions(\"ERROR\").ToString());");
                        sb.AppendLine("Console.ReadLine();");
                        sb.AppendLine("int originalLength = readline.Length;");
                        sb.AppendLine("readline = readline.Substring(word_chunk.Length, (readline.Length - word_chunk.Length));");
                        sb.AppendLine("if (pos < originalLength)");
                        sb.AppendLine("{");
                        sb.AppendLine("word_chunk = \"\";");
                        sb.AppendLine("ValuateStr(readline, 0, 0);");
                        sb.AppendLine("return;");

                        sb.AppendLine("}");

                        sb.AppendLine("}");
                        sb.AppendLine("else");
                        sb.AppendLine("{");
                        sb.AppendLine("Console.WriteLine(word_chunk + \":\" + VerificarActions(word_chunk).ToString());");
                        sb.AppendLine("Console.ReadLine();");
                        sb.AppendLine("int originalLength = readline.Length;");
                        sb.AppendLine("readline = readline.Substring(word_chunk.Length, (readline.Length - word_chunk.Length));");
                        sb.AppendLine("if (pos < originalLength)");
                        sb.AppendLine("{");
                        sb.AppendLine("word_chunk = \"\";");
                        sb.AppendLine("ValuateStr(readline, 0, 0);");
                        sb.AppendLine("return;");
                        sb.AppendLine("}");

                        sb.AppendLine("}");
                        sb.AppendLine("}");
                    }

                }


            }

            if (state_principal + 1 < totalTransiciones.Count)
            {
                sb.AppendLine();

                sb.AppendLine("break;");
                state_principal = state_principal + 1;
                GenerateCode(AFD, state_principal);
            }
            /*
            if (state_principal + 1 == totalTransiciones.Count)
            {
                sb.AppendLine("break;");
            }
            */
            else
            {
                //sb.AppendLine("break;");
                return sb.ToString();
            }

            return sb.ToString();
        }

        public string ExportCode(Dictionary<string, string> automata, string path)
        {
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("using System.IO;");

            sb.AppendLine();

            sb.AppendLine("namespace Generator");
            sb.AppendLine("{");
            sb.AppendLine("class Program");
            sb.AppendLine("{");

            sb.AppendLine("public static char principal_anterior = default(char);");
            sb.AppendLine("public static char principal = default(char);");
            sb.AppendLine("public static int pos = 0;");
            sb.AppendLine("public static string word_chunk = \"\";");
            sb.AppendLine("public static bool error = false;");
            sb.AppendLine();
            sb.AppendLine("static void Main(string[] args)");
            sb.AppendLine("{");
            sb.AppendLine(FilesPath(path));
            sb.AppendLine("while(!sr.EndOfStream)");
            sb.AppendLine("{");
            sb.AppendLine("string readline = sr.ReadLine().Trim();");
            sb.AppendLine("ValuateStr(readline, 0, 0);");
            sb.AppendLine("word_chunk = \"\";");
            sb.AppendLine("}");
            sb.AppendLine("}");
            sb.AppendLine();

            sb.AppendLine("public static void ValuateStr(string readline, int pos, int state_principal)");
            sb.AppendLine("{");
            sb.AppendLine("if( pos == readline.Length)");
            sb.AppendLine("{");
            sb.AppendLine("error = Retroceso(state_principal);");
            sb.AppendLine("if(!error)");
            sb.AppendLine("{");
            sb.AppendLine("Console.WriteLine(word_chunk + \":\" + VerificarActions(\"ERROR\").ToString());");
            sb.AppendLine("Console.ReadLine();");
            sb.AppendLine("int originalLength = readline.Length;");
            sb.AppendLine("readline = readline.Substring(word_chunk.Length, (readline.Length - word_chunk.Length));");
            sb.AppendLine("if (pos < originalLength)");
            sb.AppendLine("{");
            sb.AppendLine("word_chunk = \"\";");
            sb.AppendLine("ValuateStr(readline, 0, 0);");
            sb.AppendLine("}");
            sb.AppendLine("}");
            sb.AppendLine("else");
            sb.AppendLine("{");
            sb.AppendLine("Console.WriteLine(word_chunk + \":\" + VerificarActions(word_chunk).ToString()); ");
            sb.AppendLine("Console.ReadLine();");
            sb.AppendLine("int originalLength = readline.Length;");
            sb.AppendLine("readline = readline.Substring(word_chunk.Length, (readline.Length - word_chunk.Length));");
            sb.AppendLine("if (pos < originalLength)");
            sb.AppendLine("{");
            sb.AppendLine("word_chunk = \"\";");
            sb.AppendLine("ValuateStr(readline, 0, 0);");
            sb.AppendLine("}");
            sb.AppendLine("}");
            sb.AppendLine("return;");
            sb.AppendLine("}");
            sb.AppendLine("principal = readline[pos];");
            sb.AppendLine();
            sb.AppendLine(" switch( " + "state_principal" + " )");
            sb.AppendLine(" {");

            GenerateCode(automata, 0);

            sb.AppendLine("break;");
            sb.AppendLine(" }");
            sb.AppendLine("}");
            //sb.AppendLine("}");
            //sb.AppendLine("}");

            sb.AppendLine("private static bool Retroceso(int state_principal)");
            sb.AppendLine("{");
            sb.AppendLine(EscribirRetroceso());
            sb.AppendLine("}");
            sb.AppendLine("private static string VerificarActions(string state_principal)");
            sb.AppendLine("{");
            VerificarActions();
            sb.AppendLine("}");
            sb.AppendLine("private static string VerificationFuntion(string state_principal)");
            sb.AppendLine("{");
            VerificationFuntion();
            sb.AppendLine("}");
            sb.AppendLine("}");
            return sb.ToString();
        }



        private void VerificarActions()
        {
            int number = 18;
            sb.AppendLine("switch(state_principal)");
            sb.AppendLine("{");

            for (int i = 0; i < FileUpload.ACTIONS.Count; i++)
            {
                if (FileUpload.ACTIONS.ElementAt(i).Value == "ERROR")
                {
                    sb.AppendLine("case" + "\"" + "ERROR" + "\"" + ":");
                    sb.AppendLine("return " + "\"" + "54" + "\"" + ";");
                }
                else
                {
                    sb.AppendLine("case" + "\"" + number++ + "\"" + ":");
                    sb.AppendLine("return " + "\"" + FileUpload.ACTIONS.ElementAt(i).Value + "\"" + ";");
                }
               
            }

            sb.AppendLine("default: ");
            sb.AppendLine("return"+"  "+"VerificationFuntion(state_principal)"+"; ");
            sb.AppendLine("}");
        }
        private void VerificationFuntion()
        {

            sb.AppendLine("if(state_principal =="+ "\"" + "SETS"+ "\"" + ")");
            sb.AppendLine("{");
            sb.AppendLine("return"+ "\""+"\""+";");
            sb.AppendLine("}");
            sb.AppendLine("else if(state_principal ==" + "\"" +"TOKENS" +"\""+ ")");
            sb.AppendLine("{");
            sb.AppendLine("return" + "\"" + "\"" + ";");
            sb.AppendLine("}");
            sb.AppendLine("else if(state_principal ==" + "\"" + "ACTIONS" + "\"" + ")");
            sb.AppendLine("{");
            sb.AppendLine("return" + "\"" + "\"" + ";");
            sb.AppendLine("}");
            sb.AppendLine("else if(state_principal ==" + "\"" + "RESERVADAS" + "\"" + ")");
            sb.AppendLine("{");
            sb.AppendLine("return" + "\"" + "\"" + ";");
            sb.AppendLine("}");
            sb.AppendLine("else if(state_principal ==" + "\"" + "LETRA" + "\"" + ")");
            sb.AppendLine("{");
            sb.AppendLine("return" + "\"" + 1+"\"" + ";");
            sb.AppendLine("}");
            sb.AppendLine("else if(state_principal ==" + "\"" + "DIGITO" + "\"" + ")");
            sb.AppendLine("{");
            sb.AppendLine("return" + "\"" +2+ "\"" + ";");
            sb.AppendLine("}");
            sb.AppendLine("else if(state_principal ==" + "\"" + "CHARSET" + "\"" + ")");
            sb.AppendLine("{");
            sb.AppendLine("return" + "\"" +3+"\"" + ";");
            sb.AppendLine("}");
            string data = "";
            data += "return"+"\""+ 1 +"\""+";";
            sb.AppendLine(data);
            sb.AppendLine("}");
        }


        private string EscribirRetroceso()
        {
            string data = "";
            data += "switch(state_principal)\r\n";
            data += "{\r\n";

            for (int i = 0; i < esFinal.Count; i++)
            {
                data += "case " + i.ToString() + ":\r\n";
                data += "return " + esFinal.ElementAt(i).Value.ToString().ToLower() + ";" + "\r\n";
            }
            data += "default:\r\n";
            data += "return false; \r\n";
            data += "}";
            return data;
        }
        
        private string FilesPath(string path)
        {
            string pathfile = "StreamReader sr = new StreamReader";
            pathfile += "(";
            pathfile += "@";
            pathfile += "\"";
            pathfile += path;
            pathfile += "\");";

            return pathfile;
        }
    }
}
