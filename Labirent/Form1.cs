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
                String path = dialog.FileName; // get name of file
                file_path_box.Text = path;
                try
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

                    // Node neighborhoods
                    for (int i = 0; i < size; i++)
                    {
                        string[] node = line[i].Split(',');
                        node_size = node.Length;
                        for (int j = 0; j < node_size; j++)
                        {
                            int index = Convert.ToInt32(node[j]);
                            //If the target point is equal, give 100
                                if (hedef_nokta == index )
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
                    for (int i = 0; i < iterasyon;  i++)
                    {
                        if (i == 0)
                        {
                            rand_sutun = start_node;
                        }
                        while (hedef_nokta!=rand_sutun)
                        {
                            string[] komsular = (line[start_node]).Split(',');
                            if (komsular.Length == 0)
                            {
                                rand_sutun= Convert.ToInt32(komsular[0]);
                            }
                            else
                            {
                                indis = rnd.Next(0, komsular.Length);
                                rand_sutun = Convert.ToInt32(komsular[indis]);
                            }
                           

                            Q_matris[start_node, rand_sutun] = R_matris[start_node, rand_sutun] + (MAX(rand_sutun)*80/100);

                            start_node = max_index;

                        }
                        rand_sutun = rnd.Next(0,size);

                    }

                    //Q_matris finish....-->

                    //R_matris writer file...
                    string lines = "";
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            lines = lines + R_matris[i, j].ToString() + "   ";
                        }
                        lines = lines + "\n";
                    }
                    string l = "";
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            l = l + Q_matris[i, j].ToString() + "   ";
                        }
                        l = l + "\n";
                    }


                    System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Users\\Robots\\Desktop\\edt.txt");
                    file.WriteLine(lines+"\n\n"+l);

                    file.Close();
                    MessageBox.Show("R_matris hazırlandı..");
                }
                catch (IOException)
                {
                    error.Text = "The file could not be uploaded please try again";
                }
            }
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
            decimal enbuyuk = -1;
            decimal temp;
            for (int i=0;i<=ix;i++)
            {
                temp = Q_matris[value, Convert.ToInt32(komsular[i])];
                if (temp >= enbuyuk)
                {
                    enbuyuk = temp;
                 
                    max_index = Convert.ToInt32(komsular[i]);
                    if (i!=0 && (max_index < Convert.ToInt32(komsular[i - 1])))
                    {
                        max_index = Convert.ToInt32(komsular[i - 1]);
                    }
                }

            }
           
            return enbuyuk;
        }
    }
}