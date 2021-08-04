namespace ERP.ProgressBar
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBarEx8 = new ERP.ProgressBar.ProgressBarEx();
            this.progressBarEx7 = new ERP.ProgressBar.ProgressBarEx();
            this.progressBarEx6 = new ERP.ProgressBar.ProgressBarEx();
            this.progressBarEx5 = new ERP.ProgressBar.ProgressBarEx();
            this.progressBarEx4 = new ERP.ProgressBar.ProgressBarEx();
            this.progressBarEx3 = new ERP.ProgressBar.ProgressBarEx();
            this.progressBarEx2 = new ERP.ProgressBar.ProgressBarEx();
            this.progressBarEx1 = new ERP.ProgressBar.ProgressBarEx();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(420, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBarEx8
            // 
            this.progressBarEx8.BackColor = System.Drawing.Color.Black;
            this.progressBarEx8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBarEx8.ForeColor = System.Drawing.Color.White;
            this.progressBarEx8.GradiantPosition = ERP.ProgressBar.ProgressBarEx.GradiantArea.Center;
            this.progressBarEx8.Image = null;
            this.progressBarEx8.Location = new System.Drawing.Point(265, 141);
            this.progressBarEx8.Name = "progressBarEx8";
            this.progressBarEx8.ProgressColor = System.Drawing.Color.Blue;
            this.progressBarEx8.Size = new System.Drawing.Size(149, 23);
            this.progressBarEx8.Text = "progressBarEx8";
            // 
            // progressBarEx7
            // 
            this.progressBarEx7.GradiantPosition = ERP.ProgressBar.ProgressBarEx.GradiantArea.Center;
            this.progressBarEx7.Image = global::ERP.ProgressBar.Properties.Resources.SaveFolder;
            this.progressBarEx7.ImageLayout = ERP.ProgressBar.ProgressBarEx.ImageLayoutType.Center;
            this.progressBarEx7.Location = new System.Drawing.Point(265, 87);
            this.progressBarEx7.Name = "progressBarEx7";
            this.progressBarEx7.ProgressColor = System.Drawing.Color.Aquamarine;
            this.progressBarEx7.Size = new System.Drawing.Size(200, 35);
            this.progressBarEx7.Text = "progressBarEx7";
            this.progressBarEx7.Value = 76;
            // 
            // progressBarEx6
            // 
            this.progressBarEx6.BackColor = System.Drawing.Color.Plum;
            this.progressBarEx6.Border = false;
            this.progressBarEx6.Image = null;
            this.progressBarEx6.Location = new System.Drawing.Point(265, 50);
            this.progressBarEx6.Name = "progressBarEx6";
            this.progressBarEx6.ProgressColor = System.Drawing.Color.DarkViolet;
            this.progressBarEx6.Size = new System.Drawing.Size(200, 23);
            this.progressBarEx6.Text = "progressBarEx6";
            this.progressBarEx6.Value = 42;
            // 
            // progressBarEx5
            // 
            this.progressBarEx5.BackColor = System.Drawing.Color.White;
            this.progressBarEx5.GradiantPosition = ERP.ProgressBar.ProgressBarEx.GradiantArea.None;
            this.progressBarEx5.Image = null;
            this.progressBarEx5.Location = new System.Drawing.Point(265, 12);
            this.progressBarEx5.Name = "progressBarEx5";
            this.progressBarEx5.ProgressColor = System.Drawing.Color.Aqua;
            this.progressBarEx5.Size = new System.Drawing.Size(200, 23);
            this.progressBarEx5.Text = "progressBarEx5";
            this.progressBarEx5.Value = 42;
            // 
            // progressBarEx4
            // 
            this.progressBarEx4.BorderColor = System.Drawing.Color.Red;
            this.progressBarEx4.GradiantPosition = ERP.ProgressBar.ProgressBarEx.GradiantArea.Center;
            this.progressBarEx4.Image = null;
            this.progressBarEx4.Location = new System.Drawing.Point(12, 141);
            this.progressBarEx4.Name = "progressBarEx4";
            this.progressBarEx4.ProgressColor = System.Drawing.Color.Red;
            this.progressBarEx4.Size = new System.Drawing.Size(200, 23);
            this.progressBarEx4.Text = "progressBarEx4";
            this.progressBarEx4.Value = 18;
            // 
            // progressBarEx3
            // 
            this.progressBarEx3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBarEx3.GradiantPosition = ERP.ProgressBar.ProgressBarEx.GradiantArea.Bottom;
            this.progressBarEx3.Image = null;
            this.progressBarEx3.Location = new System.Drawing.Point(12, 87);
            this.progressBarEx3.Name = "progressBarEx3";
            this.progressBarEx3.ProgressColor = System.Drawing.Color.Yellow;
            this.progressBarEx3.ShowPercentage = true;
            this.progressBarEx3.Size = new System.Drawing.Size(224, 35);
            this.progressBarEx3.Text = "progressBarEx3";
            this.progressBarEx3.Value = 28;
            // 
            // progressBarEx2
            // 
            this.progressBarEx2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBarEx2.Image = null;
            this.progressBarEx2.Location = new System.Drawing.Point(12, 52);
            this.progressBarEx2.Name = "progressBarEx2";
            this.progressBarEx2.ProgressColor = System.Drawing.Color.Orange;
            this.progressBarEx2.ShowPercentage = true;
            this.progressBarEx2.Size = new System.Drawing.Size(200, 17);
            this.progressBarEx2.Text = "progressBarEx2";
            this.progressBarEx2.Value = 33;
            // 
            // progressBarEx1
            // 
            this.progressBarEx1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBarEx1.Image = null;
            this.progressBarEx1.Location = new System.Drawing.Point(12, 12);
            this.progressBarEx1.Name = "progressBarEx1";
            this.progressBarEx1.ShowPercentage = true;
            this.progressBarEx1.ShowText = true;
            this.progressBarEx1.Size = new System.Drawing.Size(200, 23);
            this.progressBarEx1.Text = "Progress - ";
            this.progressBarEx1.Value = 64;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 180);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBarEx8);
            this.Controls.Add(this.progressBarEx7);
            this.Controls.Add(this.progressBarEx6);
            this.Controls.Add(this.progressBarEx5);
            this.Controls.Add(this.progressBarEx4);
            this.Controls.Add(this.progressBarEx3);
            this.Controls.Add(this.progressBarEx2);
            this.Controls.Add(this.progressBarEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProgressBarEx Demo";
            this.ResumeLayout(false);

        }

        #endregion

        private ProgressBarEx progressBarEx1;
        private ProgressBarEx progressBarEx2;
        private ProgressBarEx progressBarEx3;
        private ProgressBarEx progressBarEx4;
        private ProgressBarEx progressBarEx5;
        private ProgressBarEx progressBarEx6;
        private ProgressBarEx progressBarEx7;
        private ProgressBarEx progressBarEx8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;

    }
}

