namespace guibisadong
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.ForeColor = Color.Transparent;
            button1.Image = Properties.Resources.choose;
            button1.Location = new Point(118, 173);
            button1.Name = "button1";
            button1.Size = new Size(141, 48);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = false;
            button1.MouseClick += button1_MouseClick;
            button1.MouseEnter += button1_MouseEnter;
            button1.MouseLeave += button1_MouseLeave;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.ForeColor = SystemColors.InactiveCaption;
            textBox1.Location = new Point(99, 249);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(146, 43);
            textBox1.TabIndex = 2;
            textBox1.Text = "TYPE HERE...";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.ForeColor = Color.Transparent;
            button2.Image = Properties.Resources.search;
            button2.Location = new Point(242, 249);
            button2.Name = "button2";
            button2.Size = new Size(35, 43);
            button2.TabIndex = 3;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            button2.MouseEnter += button2_MouseEnter;
            button2.MouseLeave += button2_MouseLeave;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.BackColor = Color.Transparent;
            radioButton1.Location = new Point(153, 386);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(21, 20);
            radioButton1.TabIndex = 4;
            radioButton1.TabStop = true;
            radioButton1.UseVisualStyleBackColor = false;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.BackColor = Color.Transparent;
            radioButton2.Location = new Point(153, 412);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(21, 20);
            radioButton2.TabIndex = 5;
            radioButton2.TabStop = true;
            radioButton2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.Image = Properties.Resources.visual;
            button3.Location = new Point(118, 453);
            button3.Name = "button3";
            button3.Size = new Size(141, 47);
            button3.TabIndex = 6;
            button3.UseVisualStyleBackColor = true;
            button3.MouseEnter += button3_MouseEnter;
            button3.MouseLeave += button3_MouseLeave;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1280, 892);
            Controls.Add(button3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            DoubleBuffered = true;
            MaximizeBox = false;
            Name = "Form1";
            Text = "BikiniBot";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private Button button2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Button button3;
    }
}