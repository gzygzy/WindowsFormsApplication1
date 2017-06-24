namespace WindowsFormsApplication1
{
    partial class demo
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.init = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.test = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(50, 576);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(90, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // init
            // 
            this.init.BackColor = System.Drawing.Color.White;
            this.init.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.start;
            this.init.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.init.Location = new System.Drawing.Point(150, 550);
            this.init.Name = "init";
            this.init.Size = new System.Drawing.Size(50, 50);
            this.init.TabIndex = 1;
            this.init.UseVisualStyleBackColor = true;
            this.init.Click += new System.EventHandler(this.init_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(322, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(42, 20);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 561);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "COM:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // test
            // 
            this.test.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.gray;
            this.test.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.test.Location = new System.Drawing.Point(446, 88);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(75, 64);
            this.test.TabIndex = 2;
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(644, 625);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.test);
            this.Controls.Add(this.init);
            this.Controls.Add(this.textBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "demo";
            this.Text = "Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button init;
        private System.Windows.Forms.Button test;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;



    }
}

