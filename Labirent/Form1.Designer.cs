namespace Labirent
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.file_path_box = new System.Windows.Forms.TextBox();
            this.error = new System.Windows.Forms.Label();
            this.start_node_box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hedef_node_box = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.iterasyon_box = new System.Windows.Forms.TextBox();
            this.yaz = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(12, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Choose File";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File Path:";
            // 
            // file_path_box
            // 
            this.file_path_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.file_path_box.Location = new System.Drawing.Point(60, 146);
            this.file_path_box.Name = "file_path_box";
            this.file_path_box.ReadOnly = true;
            this.file_path_box.Size = new System.Drawing.Size(321, 20);
            this.file_path_box.TabIndex = 2;
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.ForeColor = System.Drawing.Color.Maroon;
            this.error.Location = new System.Drawing.Point(121, 116);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(0, 13);
            this.error.TabIndex = 3;
            // 
            // start_node_box
            // 
            this.start_node_box.Location = new System.Drawing.Point(87, 20);
            this.start_node_box.Name = "start_node_box";
            this.start_node_box.Size = new System.Drawing.Size(100, 20);
            this.start_node_box.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Başlangıç :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 22);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hedef";
            // 
            // hedef_node_box
            // 
            this.hedef_node_box.Location = new System.Drawing.Point(254, 19);
            this.hedef_node_box.Name = "hedef_node_box";
            this.hedef_node_box.Size = new System.Drawing.Size(100, 20);
            this.hedef_node_box.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Iterasyon Sayısı";
            // 
            // iterasyon_box
            // 
            this.iterasyon_box.Location = new System.Drawing.Point(87, 60);
            this.iterasyon_box.Name = "iterasyon_box";
            this.iterasyon_box.Size = new System.Drawing.Size(100, 20);
            this.iterasyon_box.TabIndex = 9;
            // 
            // yaz
            // 
            this.yaz.AutoSize = true;
            this.yaz.Location = new System.Drawing.Point(45, 209);
            this.yaz.Name = "yaz";
            this.yaz.Size = new System.Drawing.Size(35, 13);
            this.yaz.TabIndex = 10;
            this.yaz.Text = "label5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 411);
            this.Controls.Add(this.yaz);
            this.Controls.Add(this.iterasyon_box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.hedef_node_box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.start_node_box);
            this.Controls.Add(this.error);
            this.Controls.Add(this.file_path_box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox file_path_box;
        private System.Windows.Forms.Label error;
        private System.Windows.Forms.TextBox start_node_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox hedef_node_box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox iterasyon_box;
        private System.Windows.Forms.Label yaz;
    }
}

