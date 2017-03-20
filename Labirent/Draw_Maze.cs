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
    public partial class Draw_Maze : Form
    {

        //degişken tanimlamalari baslangic
        System.Drawing.Graphics graphics;
        public static string sonucYol = Form1.yol;
        public static int basla = Form1.start_node;
        public static int bitir = Form1.hedef_nokta;
        public static double Maze_size = Math.Sqrt(Form1.size);
        public static double lenght = 300 / Maze_size;
        public static int xkordinati = 250;
        public static double artan_deger = 0;
        public static double count = 0;
        public static double komsuluk_noktasi;
        public static  string image_path =
            "C:\\Users\\Robots\\Documents\\Visual Studio 2015\\Projects\\Labirent\\Labirent\\Properties\\image.png";
        public static string image_path2 =
         "C:\\Users\\Robots\\Documents\\Visual Studio 2015\\Projects\\Labirent\\Labirent\\Properties\\image2.png";
     
       public static int x1 = 0;
       public static int y1 = 0;
       public static int ilerle_sayac=0;
       public static bool bir_defa_gir = true;
       public static string[] yol;
       public static int ss = 0;
        //degişken tanimlamalari bitis
        public Draw_Maze()
        {
            
            InitializeComponent();

            label3.Text = Form1.yol;
        }
        public void Labirenti_ciz()
        {

            graphics = this.CreateGraphics();
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(
                250, 50, 300, 300);
            graphics.DrawRectangle(System.Drawing.Pens.Black, rectangle);
           
            for (int i = 1; i < Maze_size; i++)
            {
                graphics.DrawLine(System.Drawing.Pens.Black, xkordinati, Convert.ToInt32(lenght * i) + 50, 550, Convert.ToInt32(lenght * i) + 50);
            }
            for (int i = 1; i < Maze_size; i++)
            {
                graphics.DrawLine(System.Drawing.Pens.Black, Convert.ToInt32(lenght * i) + xkordinati, 50, Convert.ToInt32(lenght * i) + xkordinati, 350);
            }
            double gama = basla / Maze_size;
            int giris_noktasi;
            if (basla % Maze_size == 0)
            {
                giris_noktasi = Convert.ToInt32(lenght * (gama + 1)) / 2;

                PictureBox resim = new PictureBox();
                resim.SizeMode=PictureBoxSizeMode.StretchImage;
                resim.Size = new Size(45,55);
                resim.Image = Image.FromFile(image_path);
                resim.Location=new Point(xkordinati-20 + Convert.ToInt32(lenght / 2), giris_noktasi + Convert.ToInt32((lenght / 2) * gama) + 20);
                
                graphics.DrawLine(System.Drawing.Pens.White, xkordinati, Convert.ToInt32(lenght * gama) + 50, xkordinati, Convert.ToInt32(lenght * (gama + 1)) + 50);
                this.Controls.Add(resim);
            }
            else if ((basla + 1) % Maze_size == 0)
            {
              
                gama = (basla + 1) / Maze_size;
                gama--;
                giris_noktasi = Convert.ToInt32(lenght * (gama + 1)) / 2;
                PictureBox resim2 = new PictureBox();
                resim2.SizeMode = PictureBoxSizeMode.StretchImage;
                resim2.Size = new Size(45, 55);
                resim2.Image = Image.FromFile(image_path);
                resim2.Location = new Point( 530 - Convert.ToInt32(lenght / 2), giris_noktasi + Convert.ToInt32((lenght / 2) * gama) + 20);

                graphics.DrawLine(System.Drawing.Pens.White, 550, Convert.ToInt32(lenght * gama) + 50, 550, Convert.ToInt32(lenght * (gama + 1)) + 50);
                this.Controls.Add(resim2);
            }
            else if (basla < Maze_size)
            {
                PictureBox resim3 = new PictureBox();
                resim3.SizeMode = PictureBoxSizeMode.StretchImage;
                resim3.Size = new Size(45, 55);
                resim3.Image = Image.FromFile(image_path);
                resim3.Location = new Point(xkordinati-20 + Convert.ToInt32(lenght / 2) + Convert.ToInt32(lenght * basla), 20 + Convert.ToInt32(lenght / 2));

                graphics.DrawLine(System.Drawing.Pens.White, xkordinati + Convert.ToInt32(lenght * basla), 50, xkordinati + Convert.ToInt32(lenght * (basla + 1)), 50);
                this.Controls.Add(resim3);
            }
            else if (basla >= Maze_size * (Maze_size - 1) && basla <= ((Maze_size * Maze_size) - 1))
            {
                gama = basla - (Maze_size * (Maze_size - 1));
                PictureBox resim4 = new PictureBox();
                resim4.SizeMode = PictureBoxSizeMode.StretchImage;
                resim4.Size = new Size(45, 55);
                resim4.Image = Image.FromFile(image_path);
                resim4.Location = new Point(xkordinati-20 + Convert.ToInt32(lenght * (gama + 1)), 320);

                 graphics.DrawLine(System.Drawing.Pens.White, xkordinati + Convert.ToInt32(lenght * gama), 350, xkordinati + Convert.ToInt32(lenght * (gama + 1)), 350);
                this.Controls.Add(resim4);
            }


            if (bitir % Maze_size == 0)
            {
              
                gama = bitir / Maze_size;
                giris_noktasi = Convert.ToInt32(lenght * (gama + 1)) / 2;
                PictureBox resim5 = new PictureBox();
                resim5.SizeMode = PictureBoxSizeMode.StretchImage;
                resim5.Size = new Size(45, 55);
                resim5.Image = Image.FromFile(image_path2);
                resim5.Location = new Point(xkordinati-20, giris_noktasi + Convert.ToInt32((lenght / 2) * gama) + 30);

                graphics.DrawLine(System.Drawing.Pens.White, xkordinati, Convert.ToInt32(lenght * gama) + 50, xkordinati, Convert.ToInt32(lenght * (gama + 1)) + 50);
                this.Controls.Add(resim5);
            }
            else if ((bitir + 1) % Maze_size == 0)
            {
               
                gama = (bitir + 1) / Maze_size;
                gama--;
                giris_noktasi = Convert.ToInt32(lenght * (gama + 1)) / 2;
                PictureBox resim6 = new PictureBox();
                resim6.SizeMode = PictureBoxSizeMode.StretchImage;
                resim6.Size = new Size(45, 55);
                resim6.Image = Image.FromFile(image_path2);
                resim6.Location = new Point(520, giris_noktasi + Convert.ToInt32((lenght / 2) * gama) + 30);

                graphics.DrawLine(System.Drawing.Pens.White, xkordinati, Convert.ToInt32(lenght * gama) + 50, 550, Convert.ToInt32(lenght * (gama + 1)) + 50);
                this.Controls.Add(resim6);
            }
            else if (bitir < Maze_size)
            {

                PictureBox resim7 = new PictureBox();
                resim7.SizeMode = PictureBoxSizeMode.StretchImage;
                resim7.Size = new Size(45, 55);
                resim7.Image = Image.FromFile(image_path2);
                resim7.Location = new Point(xkordinati-20 + Convert.ToInt32(lenght * gama), 330 - Convert.ToInt32((lenght / 2) * gama));

                graphics.DrawLine(System.Drawing.Pens.White, xkordinati + Convert.ToInt32(lenght * bitir), 50, xkordinati + Convert.ToInt32(lenght * (bitir + 1)), 50);
                this.Controls.Add(resim7);
            }
            else if (bitir >= Maze_size * (Maze_size - 1) && bitir <= ((Maze_size * Maze_size) - 1))
            {
               
                gama = bitir - (Maze_size * (Maze_size - 1));
                PictureBox resim8 = new PictureBox();
                resim8.SizeMode = PictureBoxSizeMode.StretchImage;
                resim8.Size = new Size(45, 55);
                resim8.Image = Image.FromFile(image_path2);
                resim8.Location = new Point(xkordinati-20 + Convert.ToInt32(lenght / 2) + Convert.ToInt32(lenght * gama), 330 - Convert.ToInt32((lenght / 2)));
                graphics.DrawLine(System.Drawing.Pens.White, xkordinati + Convert.ToInt32(lenght * gama), 350, xkordinati + Convert.ToInt32(lenght * (gama + 1)), 350);
                this.Controls.Add(resim8);
            }
         
            //komsu olanlar labirentten silinir...
            komsuluklari_sil();
           
        
        }



        public void komsuluklari_sil()
        {
            graphics = this.CreateGraphics();
            for (count = 0; count < Form1.size; count++)
            {

                string[] komsu = Form1.line[Convert.ToInt32(count)].Split(',');

                int[] komsular = Array.ConvertAll(komsu, a => int.Parse(a));
                for (int t = 0; t < komsular.Length; t++)
                {
                    if (komsular[t] == (count + Maze_size))
                    {
                        komsuluk_noktasi = (Convert.ToInt32(Math.Floor(count / Maze_size)) * Maze_size);
                        artan_deger = (count - komsuluk_noktasi);
                        graphics.DrawLine(System.Drawing.Pens.White, xkordinati + Convert.ToInt32(lenght * artan_deger), 50 + Convert.ToInt32(lenght * (Convert.ToInt32(Math.Floor(count / Maze_size)) + 1)), xkordinati + Convert.ToInt32(lenght * (artan_deger + 1)), 50 + Convert.ToInt32(lenght * (Convert.ToInt32(Math.Floor(count / Maze_size)) + 1)));
                    }
                    else if (komsular[t] == (count + 1))
                    {
                        komsuluk_noktasi = (Convert.ToInt32(Math.Floor(count / Maze_size)) * Maze_size);
                        artan_deger = (count - komsuluk_noktasi);
                        graphics.DrawLine(System.Drawing.Pens.White, xkordinati + Convert.ToInt32(lenght * (artan_deger + 1)), 50 + Convert.ToInt32(lenght * (Convert.ToInt32(Math.Floor(count / Maze_size)))), xkordinati + Convert.ToInt32(lenght * (artan_deger + 1)), 50 + Convert.ToInt32(lenght * (Convert.ToInt32(Math.Floor(count / Maze_size)) + 1)));
                    }
                    else if (komsular[t] == (count - 1))
                    {
                        komsuluk_noktasi = (Convert.ToInt32(Math.Floor(count / Maze_size)) * Maze_size);
                        artan_deger = (count - komsuluk_noktasi);
                        graphics.DrawLine(System.Drawing.Pens.White, xkordinati + Convert.ToInt32(lenght * (artan_deger)), 50 + Convert.ToInt32(lenght * (Convert.ToInt32(Math.Floor(count / Maze_size)))), xkordinati + Convert.ToInt32(lenght * (artan_deger)), 50 + Convert.ToInt32(lenght * (Convert.ToInt32(Math.Floor(count / Maze_size)) + 1)));
                    }
                    else if (komsular[t] == (count - Maze_size))
                    {
                        komsuluk_noktasi = (Convert.ToInt32(Math.Floor(count / Maze_size)) * Maze_size);
                        artan_deger = (count - komsuluk_noktasi);
                        graphics.DrawLine(System.Drawing.Pens.White, xkordinati + Convert.ToInt32(lenght * (artan_deger)), 50 + Convert.ToInt32(lenght * (Convert.ToInt32(Math.Floor(count / Maze_size)))), xkordinati + Convert.ToInt32(lenght * (artan_deger + 1)), 50 + Convert.ToInt32(lenght * (Convert.ToInt32(Math.Floor(count / Maze_size)))));
                    }
                }


            }
        }


        public void ilerle(int s,double i)
        {
            graphics = this.CreateGraphics();
            if (s == (i + Maze_size))
            {
              
                 graphics.DrawLine(System.Drawing.Pens.Red, Convert.ToInt32(250 + x1), Convert.ToInt32(50 + y1), Convert.ToInt32(250 + x1), Convert.ToInt32(50 + y1 + lenght));
              
                y1 = Convert.ToInt32(y1 + lenght);
              
            }
            else if (s == (i + 1))
            {
                graphics.DrawLine(System.Drawing.Pens.Red, Convert.ToInt32(250 + x1), Convert.ToInt32(50 + y1), Convert.ToInt32(250 + lenght + x1), Convert.ToInt32(50 + y1));
                x1 = Convert.ToInt32(x1 + lenght);
            }
            else if (s == (i - 1))
            {
                graphics.DrawLine(System.Drawing.Pens.Red, Convert.ToInt32(250 + x1 - lenght), Convert.ToInt32(50 + y1), Convert.ToInt32(250 + x1), Convert.ToInt32(50 + y1));
                x1 = Convert.ToInt32(x1 - lenght);
            }
            else if (s == (i - Maze_size))
            {
                graphics.DrawLine(System.Drawing.Pens.Red, Convert.ToInt32(250 + x1), Convert.ToInt32(50 + y1), Convert.ToInt32(250 + x1), Convert.ToInt32(50 + y1 - lenght));
                y1 = Convert.ToInt32(y1 - lenght);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Labirenti_ciz();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bir_defa_gir)
            {
                 yol = sonucYol.Split(',');
                artan_deger = 0;
                ss = Convert.ToInt32(yol[1]);
                count = Convert.ToInt32(yol[0]);

                var satirDurum = Convert.ToInt32(Convert.ToInt32(Math.Floor(count/Maze_size)));
                var Xnoktasi = count - (satirDurum*Maze_size);
                x1 = Convert.ToInt32(Xnoktasi*lenght) + Convert.ToInt32(lenght/2);

                var Ynoktasi = (satirDurum*lenght) + (lenght/2);

                y1 = Convert.ToInt32(Ynoktasi);
                bir_defa_gir = false;
            }
        

                ss = Convert.ToInt32(yol[ilerle_sayac + 1]);
                count = Convert.ToInt32(yol[ilerle_sayac]);

                ilerle(ss, count);
             
            
            ilerle_sayac++;
        }
    }
}
