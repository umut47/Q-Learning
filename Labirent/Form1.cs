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
        public static int aksiyom = 0;
        public static string[] line;
        public static int max_index;
        public static int start_node;
        public static string path;
        public static int sonraki_aksiyom;
        public static string yol;
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
                    file_name_label.Text = Path.GetFileName(path);

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
            size = line.Length;
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
                    int suanki_yer = Convert.ToInt32(node[j]);
                    //If the target point is equal, give 100
                    if (hedef_nokta == suanki_yer)
                    {
                        R_matris[i, suanki_yer] = 100;
                    }
                    else
                    {
                        R_matris[i, suanki_yer] = 0;
                    }

                }
                R_matris[hedef_nokta, hedef_nokta] = 100;
            }

            //R_matris finish..

            //Q_matris start....-->

            Q_matris = new decimal[size, size];

            //Q_matris elemanları ilk anda sıfır yapılıyor..
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
            //iterasyon start
            Random rnd = new Random();
            for (int i = 0; i < iterasyon; i++)
            {

                string[] komsular = (line[start_node]).Split(',');
                indis = rnd.Next(0, komsular.Length);
                aksiyom = Convert.ToInt32(komsular[indis]);

                while (hedef_nokta != aksiyom)
                {

                    Q_matris[start_node, aksiyom] = R_matris[start_node, aksiyom] + (MAX(aksiyom) * 80 / 100);
                    start_node = aksiyom;
                    aksiyom = sonraki_aksiyom;
                    if (sonraki_aksiyom == hedef_nokta || start_node == hedef_nokta)
                    {

                        Q_matris[start_node, aksiyom] = R_matris[start_node, aksiyom] + (MAX(aksiyom) * 80 / 100);
                    }


                }

                start_node = baslangic;

            }
            //iterasyon stop
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

            //labirent cizim
            string way = draw_way(baslangic, hedef_nokta, size);

            System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Users\\Robots\\Desktop\\yazlab_out\\outR.txt");
            file.WriteLine(outR);
            file.Close();
            System.IO.StreamWriter file2 = new System.IO.StreamWriter("C:\\Users\\Robots\\Desktop\\yazlab_out\\outQ.txt");
            file2.WriteLine(outQ);
            file2.Close();
            System.IO.StreamWriter file3 = new System.IO.StreamWriter("C:\\Users\\Robots\\Desktop\\yazlab_out\\outPath.txt");
            file3.WriteLine(way);
            file3.Close();

            MessageBox.Show("Tamamlandı.");

            Draw_Maze dm = new Draw_Maze();
            this.Hide();
            dm.Show();
        }




        public decimal MAX(int value)
        {

            string[] komsular = (line[value]).Split(',');
            int ix = komsular.Length - 1;

            if (ix == 0)
            {
                sonraki_aksiyom = Convert.ToInt32(komsular[0]);
                return Q_matris[value, Convert.ToInt32(komsular[0])];
            }
            decimal enbuyuk = Q_matris[value, Convert.ToInt32(komsular[0])];
            decimal temp;
            for (int i = 0; i <= ix; i++)
            {
                temp = Q_matris[value, Convert.ToInt32(komsular[i])];
                if (temp > enbuyuk)
                {
                    enbuyuk = temp;

                }

            }

            //Random düğüm
            Random rnd = new Random();
            int indis = 0;
            indis = rnd.Next(0, komsular.Length);
            sonraki_aksiyom = Convert.ToInt32(komsular[indis]);
            return enbuyuk;
        }



        public string draw_way(int startnode, int endnode, int byt)
        {
            decimal newState;
           
                sonraki_aksiyom = startnode;
                 newState = 0;
                do
                {
                    newState = max_yol(sonraki_aksiyom);
                     yol=yol+ sonraki_aksiyom + ", ";
                    sonraki_aksiyom = Convert.ToInt32(newState);
                } while (sonraki_aksiyom != hedef_nokta);
                yol = yol + hedef_nokta;
           
            return yol;
        }

     public decimal max_yol(int state)
        {
          
            int aksiyom;
            bool kucuk_mu;
            bool  buyuk_mu= false;

            aksiyom = 0;

            do
            {
                kucuk_mu = false;
                for (int i = 0; i <= (size - 1); i++)
                {
                    if ((i < aksiyom) || (i > aksiyom))
                    {    
                        if (Q_matris[state,i] > Q_matris[state, aksiyom])
                        {
                            aksiyom = i;
                            kucuk_mu = true;
                        }
                    }
                } 

                if (kucuk_mu == false)
                {
                    buyuk_mu = true;
                }

            } while (buyuk_mu == false);

                //Q matrisinin indexini döndürür..
                return aksiyom;
         

        }




    }
}