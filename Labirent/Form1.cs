using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labirent
{
    public partial class Form1 : Form
    {
        // Defining variables
        public static int size = 0;
        public static decimal[,] R_matris;
        public static decimal[,] Q_matris;
        public static int hedef_nokta;
        public static int rand_sutun=0;
        public static string[] line;
        public static int max_index;
        public static int start_node;
        public static string path;
        public static string q_drawe;
        public static string r_drawe;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           


            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files | *.txt"; // file types, that will be allowed to upload
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time
            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {  
                try
                {
                     path = dialog.FileName; // get name of file
                     file_name_label.Text= Path.GetFileName(path);
                     
                }
                catch (IOException)
                {
                    error.Text = "The file could not be uploaded please try again";
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            hedef_nokta = Convert.ToInt32(hedef_node_box.Text);
            //Assigning read file to text string
            string text = File.ReadAllText(path);
            //string text split
            line = text.Split('\n');
            //line array length 
            size = line.Length - 1;
            R_matris = new decimal[size, size];
            // //R_matris all index value -1 
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    R_matris[i, j] = -1;
                }
            }

            //node_size size
            int node_size;
            //iterasyon size
            int iterasyon = Convert.ToInt32(iterasyon_box.Text);
            //start node 
            start_node = Convert.ToInt32(start_node_box.Text);
            int baslangic = start_node;
            // Node neighborhoods
            for (int i = 0; i < size; i++)
            {
                string[] node = line[i].Split(',');
                node_size = node.Length;
                for (int j = 0; j < node_size; j++)
                {
                    int index = Convert.ToInt32(node[j]);
                    //If the target point is equal, give 100
                    if (hedef_nokta == index)
                    {
                        R_matris[i, index] = 100;
                    }
                    else
                    {
                        R_matris[i, index] = 0;
                    }
                }
            }

            //R_matris finish..

            //Q_matris start....-->
            Random rnd = new Random();
            Q_matris = new decimal[size, size];



            //

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Q_matris[i, j] = 0;
                }

            }
            int indis;
            int a = 0;
            int sayac = 0;
            for (int i = 0; i < iterasyon; i++)
            {

                while (hedef_nokta != rand_sutun)
                {
                    if (a == 0)
                    {
                        string[] komsular = (line[start_node]).Split(',');
                        if (komsular.Length == 0)
                        {
                            rand_sutun = Convert.ToInt32(komsular[0]);
                        }
                        else
                        {
                            indis = rnd.Next(0, komsular.Length);
                            rand_sutun = Convert.ToInt32(komsular[indis]);
                        }
                        a++;

                    }
                    if (start_node == 0)
                    {
                        decimal ass = Q_matris[start_node, rand_sutun];
                        sayac++;

                    }
                    Q_matris[start_node, rand_sutun] = R_matris[start_node, rand_sutun] + (MAX(rand_sutun) * 80 / 100);

                    a = 0;

                }

                rand_sutun = rnd.Next(0, size);

            }

            //Q_matris finish....-->

            //R_matris writer file...
            string outR = "";
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    outR = outR + R_matris[i, j].ToString() + "   ";
                }
                outR = outR + "\n";
            }
            r_drawe = outR;
            ///Q mtaris czim
            string outQ = "";
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    outQ = outQ + Q_matris[i, j].ToString("F") + "   ";
                }
                outQ = outQ + "\n";
            }
            q_drawe = outQ;
            //labirent cizim
       //     string way = draw_way(baslangic, hedef_nokta, size);

            System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Users\\Robots\\Desktop\\yazlab_out\\outR.txt");
            file.WriteLine(outR);
            file.Close();
            System.IO.StreamWriter file2 = new System.IO.StreamWriter("C:\\Users\\Robots\\Desktop\\yazlab_out\\outQ.txt");
            file2.WriteLine(outQ);
            file2.Close();
         //   System.IO.StreamWriter file3 = new System.IO.StreamWriter("C:\\Users\\Robots\\Desktop\\yazlab_out\\outPath.txt");
         //   file3.WriteLine(way);
         //   file3.Close();

            MessageBox.Show(sayac.ToString());

            Draw_Maze dm=new Draw_Maze();
            this.Hide();
            dm.Show();
        }




        public decimal MAX(int value)
        {

            string[] komsular = (line[value]).Split(',');
            int ix = komsular.Length-1;

            if (ix == 0)
            {
                value = 0;
                return value;
            }
            decimal enbuyuk = Q_matris[value, Convert.ToInt32(komsular[0])];
            decimal temp;
            for (int i=0;i<=ix;i++)
            {
                temp = Q_matris[value, Convert.ToInt32(komsular[i])];
                if (temp >enbuyuk)
                {
                    enbuyuk = temp;
                    
                }

            }

            //Random düğüm
            Random rnd=new Random();
            int indis = 0;
            indis = rnd.Next(0, komsular.Length);
            rand_sutun = Convert.ToInt32(komsular[indis]);
            start_node = value;
            return enbuyuk;
        }



        public string draw_way(int startnode, int endnode,int byt)
        {
            decimal enbuyuk = Q_matris[startnode,0];
            decimal temp;
            int new_start=startnode;
            string yol =new_start.ToString();
            while (new_start != endnode)
            {
                for (int i = 0; i < byt; i++)
                {
                    temp = Q_matris[new_start, i];
                    if (temp > enbuyuk)
                    {
                        enbuyuk = temp;
                        new_start = i;
                        yol = yol + " -> " + new_start;
                    }

                }
            }
            return yol;
        }

      

     
    }
}