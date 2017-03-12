using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labirent
{
    public partial class Draw_Maze : Form
    {
      
        public Draw_Maze()
        {
            InitializeComponent();
            string outR = "";
            for (int i = 0; i < Form1.size; i++)
            {
                for (int j = 0; j < Form1.size; j++)
                {
                    if (Form1.R_matris[i, j] != 0)
                    {
                        outR = outR + "[||]";

                    }
                    else
                    {
                        outR = outR + "    ";
                    }
                   
                }
                outR = outR + "\n";
            }
            label1.Text = outR;
        }
        
    }
}
