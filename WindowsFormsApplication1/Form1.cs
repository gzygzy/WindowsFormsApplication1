using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO.Ports;

namespace WindowsFormsApplication1
{

    public partial class demo : Form
    {
        static int num = 100,cnum = 4,flag = 3; 
       // ShapeButton[] btns = new ShapeButton[num];
        Button[] btns = new Button[num];
        int[] flags = new int[num];
        Button[] btnc = new Button[cnum];
        Color[] clrc = new Color[] { Color.Blue,Color.Red, Color.Green, Color.Gray };
        //List<string> its = new List<string>();
        string[,] oc = {{ "1", "1", "0", "0", "0", "0", "1", "1" },
                        { "1", "0", "1", "0", "0", "1", "0", "1" },
                        { "0", "1", "1", "0", "0", "1", "1", "0" },
                        { "0", "0", "0", "0", "0", "0", "0", "0" }};
        Image[] myimage = new Image[6];
        Image[] imageok = { WindowsFormsApplication1.Properties.Resources.blue,
            WindowsFormsApplication1.Properties.Resources.red,
            WindowsFormsApplication1.Properties.Resources.green,
            WindowsFormsApplication1.Properties.Resources.gray,
            WindowsFormsApplication1.Properties.Resources.start,
            WindowsFormsApplication1.Properties.Resources.stop};
        int commflag = 0; 
        static int commmax = 4;
        SerialPort[] comm = new SerialPort[commmax];
         
         private void initpic()
         {
             String pwd = AppDomain.CurrentDomain.BaseDirectory+"ico\\";
             String[] fn = { "blue.png", "red.png", "green.png", "gray.png", "start.png", "stop.png" };
             for (int i = 0; i < 6; i++)
             {
                 Console.WriteLine("time  " + pwd + fn[i]);
                 if (System.IO.File.Exists(pwd + fn[i]))
                 {
                     myimage[i] = Image.FromFile(pwd + fn[i]);
                 }
                 else
                 {
                     myimage[i] = imageok[i];
                 }
             }
         }
        public demo()
        {
            InitializeComponent();
            initpic();
            Left = 50;
            Top = 25;
            for (int i = 0; i < num; i++)
            {
                btns[i] = new Button();
                btns[i].Width = 50;
                btns[i].Height = 50;
                btns[i].Left = Left;
                btns[i].Top = Top;
                btns[i].Name = i.ToString();
                flags[i] = 3;
              //  btns[i].BackColor = clrc[flags[i]];
              //  btns[i].Circle = true;
                // btns[i].BachgroundImage = Image.FromFile("图片路径");
              //  使用Properties.Resources类，这种方法需要你事先已经将图片添加到项目中来了
         //   双击Properties -->添加资源-->图片-->png/jpg
         //   命名比如 ：abc.png
//然后在解决方案里面，删掉该图片，把要做背景的图片 拖进来，改成同名
                //button2.BackgroundImage = 命名空间名.Properties.Resources.图片名称;
                btns[i].BackgroundImage = myimage[flags[i]];
                btns[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;// Stretch;// Zoom;
             //   btns[i].Anchor = AnchorStyles.Right | AnchorStyles.Left| AnchorStyles.Top| AnchorStyles.Bottom;
             //   btns[i].AutoSize = true;
                btns[i].FlatStyle = FlatStyle.Flat;
                btns[i].FlatAppearance.BorderSize = 0;
                this.Controls.Add(btns[i]);
                Left += 50;
                if (9 == i % 10) 
                {
                    Left = 50;
                    Top += 50;
                }
                btns[i].Click += new System.EventHandler(this.btns_Click);
            }
            comboBox1.Items.Add("");
            comboBox1.Items.Add("");
            comboBox1.Items.Add("");
            comboBox1.Items.Add("");
            comboBox1.BackColor = clrc[flag];

            Left = 350;
            for (int i = 0; i < cnum; i++)
            {
                btnc[i] = new Button();
                btnc[i].Width = 50;
                btnc[i].Height = 50;
                btnc[i].Left = Left;
                btnc[i].Top = 550;
                btnc[i].Name = i.ToString();
                btnc[i].BackgroundImage = myimage[i];
                btnc[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;//;Stretch;//Zoom;
                this.Controls.Add(btnc[i]);
                Left += 50;
               // flags[i] = 0;
                btnc[i].Click += new System.EventHandler(this.btnc_Click);
            }
            test.Top = 550;
            test.Left = 250;
            test.Width = 50;
            test.Height = 50;
            test.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;//;Stretch;//Zoom;
            init.BackgroundImage = myimage[4];
            init.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;//;.Stretch;//Zoom;

        }

        /*

        private void resize()
        {
           // InitializeComponent();
            Left = 50;
            Top = 25;
            for (int i = 0; i < num; i++)
            {
                btns[i] = new Button();
                btns[i].Width = 50;
                btns[i].Height = 50;
                btns[i].Left = Left;
                btns[i].Top = Top;
                btns[i].Name = i.ToString();
                flags[i] = 3;
                //  btns[i].BackColor = clrc[flags[i]];
                //  btns[i].Circle = true;
                // btns[i].BachgroundImage = Image.FromFile("图片路径");
                //  使用Properties.Resources类，这种方法需要你事先已经将图片添加到项目中来了
                //   双击Properties -->添加资源-->图片-->png/jpg
                //   命名比如 ：abc.png
                //然后在解决方案里面，删掉该图片，把要做背景的图片 拖进来，改成同名
                //button2.BackgroundImage = 命名空间名.Properties.Resources.图片名称;
                btns[i].BackgroundImage = myimage[flags[i]];
                btns[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                btns[i].Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
                btns[i].AutoSize = true;
                this.Controls.Add(btns[i]);
                Left += 50;
                if (9 == i % 10)
                {
                    Left = 50;
                    Top += 50;
                }
                btns[i].Click += new System.EventHandler(this.btns_Click);
            }
            comboBox1.Items.Add("");
            comboBox1.Items.Add("");
            comboBox1.Items.Add("");
            comboBox1.Items.Add("");
            comboBox1.BackColor = clrc[flag];

            Left = 350;
            for (int i = 0; i < cnum; i++)
            {
                btnc[i] = new Button();
                btnc[i].Width = 50;
                btnc[i].Height = 50;
                btnc[i].Left = Left;
                btnc[i].Top = 550;
                btnc[i].Name = i.ToString();
                btnc[i].BackgroundImage = myimage[i];
                btnc[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                this.Controls.Add(btnc[i]);
                Left += 50;
                // flags[i] = 0;
                btnc[i].Click += new System.EventHandler(this.btnc_Click);
            }
            test.Top = 550;
            test.Left = 250;
            test.Width = 50;
            test.Height = 50;

        }
         * */
        private void Form1_Load(object sender, EventArgs e)
        {
           
          //  comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
          //  comboBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(comboBoxs_DrawItem);
            this.Resize += new EventHandler(Form1_Resize);

            X = this.Width;
            Y = this.Height;

            setTag(this);
            Form1_Resize(new object(), new EventArgs());//x,y可在实例化时赋值  

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
          //  System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
         //   stopwatch.Start(); //  开始监视代码运行时间
            float newx = (this.Width) / X;
         //   Console.WriteLine("cthis.Width 1 " + this.Width);
            float newy = this.Height / Y;
            setControls(newx, newy, this);
          //  this.Text = this.Width.ToString() + " " + this.Height.ToString();
         //   stopwatch.Stop(); //  停止监视
         //   TimeSpan timespan = stopwatch.Elapsed; //  获取当前实例测量得出的总时间
         //   Console.WriteLine("time  " + timespan);
        }
        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top+":" + con.Font.Size;
               // con.Tag = con.Left + ":" + con.Top;
                if (con.Controls.Count > 0)
                    setTag(con);
            }
        }

        private float X;
        private float Y;
        private void setControls(float newx, float newy, Control cons)
        { 
            float z = Math.Min(newx, newy);
            float mid = (this.Width - X * z) / 2;
            foreach (Control con in cons.Controls)
            {
                // Console.WriteLine("i  " + i++);
                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                float a = Convert.ToSingle(mytag[0]) * Math.Min(newx, newy);// *newx;
                con.Width = (int)a;
                a = Convert.ToSingle(mytag[1]) * Math.Min(newx, newy);//newy;
                con.Height = (int)(a);
                a = Convert.ToSingle(mytag[2]) * Math.Min(newx, newy) + mid;//newx;
                con.Left = (int)(a);
                a = Convert.ToSingle(mytag[3]) * Math.Min(newx, newy);//newy;
                con.Top = (int)(a);
                Single currentSize = Convert.ToSingle(mytag[4]) * Math.Min(newx, newy);
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);
                }
            }
        }
        private void setControls2(float newx, float newy, Control cons)
        {
            //Console.WriteLine("cthis.Width 2 " + this.Width + "  " + (this.Width - X) / 2);
            float z = Math.Min(newx, newy);
            float mid = (this.Width - X * z) / 2;
           // Console.WriteLine("cz mid " + z + "  " + mid);
           // Left = 50;
            float a = 50 *  z + mid;
            int myleft = (int)a;
           // Top = 25;
            float b = 25 * z;
            int mytop = (int)b;

            float c = 50 * z;
            int mywh = (int)c;
          //  Console.WriteLine("left " + a+" "+Left + " Top " +b+" "+ Top);

            for (int i = 0; i < num; i++)
            {
                btns[i].Width = mywh;
                btns[i].Height = mywh;
                btns[i].Left = myleft;
                btns[i].Top = mytop;
                myleft += (int)(50 * z);
                if (9 == i % 10)
                {
                    myleft = (int)(50 * z + mid);
                    mytop += mywh;
                }
            }
            a = 50 * z + mid + 50 * 6 *z;
            myleft = (int)a;
            b = 25 * z*2 + 10 * 50 * z ;
            mytop = (int)b;
            for (int i = 0; i < cnum; i++)
            {
                btnc[i].Width = mywh;
                btnc[i].Height = mywh;
                btnc[i].Left = myleft;
                btnc[i].Top = mytop;
                myleft += (int)(50 * z);
            }
            a = 50 * z + mid + 50 * 2 * z;
            myleft = (int)a;
            init.Width = mywh;
            init.Height = mywh;
            init.Left = myleft;
            init.Top = mytop;
            a = 50 * z + mid + 50 * 4* z;
            myleft = (int)a;
            test.Width = mywh;
            test.Height = mywh;
            test.Left = myleft;
            test.Top = mytop;
           //     Console.WriteLine("i "+i+" "+btns[i].Width+" "+btns[i].Height+" "+btns[i].Left+" "+btns[i].Top);
         
            /*
            foreach (Control con in cons.Controls)
            {
               // Console.WriteLine("i  " + i++);
                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                float a;
                
                a = Convert.ToSingle(mytag[0]) * Math.Min(newx, newy)+mid;//newx;
                con.Left = (int)(a);
                a = Convert.ToSingle(mytag[1]) * Math.Min(newx, newy);//newy;
                con.Top = (int)(a);
                a = 50 * z;// *newx;
                con.Width = (int)a;
            
                con.Height = con.Width;
              //  Single currentSize = Convert.ToSingle(mytag[4]) * Math.Min(newx, newy);
              //  con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);
                }
                 */
                /*Console.WriteLine("cthis.Width  " + con.Width);

                con.Width = (int)(con.Width * z);
                con.Height = (int)(con.Height * z);
                con.Left = (int)(con.Left *z +mid);
                con.Top = (int)(con.Top  *z);
                Single currentSize = con.Font.Size * z;
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                
                float a = Convert.ToSingle(mytag[0]) * Math.Min(newx, newy);// *newx;
                con.Width = (int)a;
                a = Convert.ToSingle(mytag[1]) * Math.Min(newx, newy);//newy;
                con.Height = (int)(a);
                a = Convert.ToSingle(mytag[2]) * Math.Min(newx, newy) + mid;//newx;
                con.Left = (int)(a);
                a = Convert.ToSingle(mytag[3]) * Math.Min(newx, newy);//newy;
                con.Top = (int)(a);
                Single currentSize = Convert.ToSingle(mytag[4]) * Math.Min(newx, newy);
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);
                } 
            }*/

        }  
        /*
        private void roundButton_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath buttonPath =  new System.Drawing.Drawing2D.GraphicsPath();
            System.Drawing.Rectangle newRectangle = roundButton.ClientRectangle;
            newRectangle.Inflate(-10, -10);
            e.Graphics.DrawEllipse(System.Drawing.Pens.Black, newRectangle);
            newRectangle.Inflate( 1,  1);
            buttonPath.AddEllipse(newRectangle);
            roundButton.Region = new System.Drawing.Region(buttonPath);
        }
         * */
        private void comboBoxs_DrawItem(object sender, DrawItemEventArgs e)
        {
           // string s = comboBox1.Items[e.Index].ToString();
           // Console.WriteLine(e.Index);
            Rectangle r = new Rectangle(2, e.Bounds.Top + 2,e.Bounds.Height, e.Bounds.Height - 4);
            e.DrawBackground();
            e.Graphics.FillRectangle(new SolidBrush(clrc[e.Index]), new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
            e.DrawFocusRectangle();
        }

        private void btnc_Click(object sender, EventArgs e)
        {
           // Console.WriteLine("c:" + (sender as Button).Name);
            int c = int.Parse((sender as Button).Name);
            for (int i = 0; i < num; i++)
            {
                flags[i] = c;
                btns[i].BackgroundImage = myimage[flags[i]];
                OneCtr(i, c);
              //  Form1_Load(sender, e);
                //this.Refresh();
            }         
        }
        private void btns_Click(object sender, EventArgs e)
        {
          //  Console.WriteLine("c:" + (sender as Button).Name);
            int n = int.Parse((sender as Button).Name);
            flags[n] = flag;
            //btns[n].BackColor = clrc[flag];
            btns[n].BackgroundImage = myimage[flags[n]]; ;
            OneCtr(n, flag);
           // Form1_Load(sender, e);
            //this.Refresh();
        }
        /*
        private void btns_SelectedIndexChanged(object sender, EventArgs e)
        {
           // combobox comb = sender as ComboBox;
            //Console.WriteLine(comb);
            int f = ((sender as ComboBox).SelectedIndex);
            int n = int.Parse((sender as ComboBox).Name);
            Console.WriteLine("comb "+n+" : "+f);
            flags[n]=f;
            btns[n].BackColor = clrc[f];
            Form1_Load(sender, e);
        }
        */
        
        private void init_Click(object sender, EventArgs e)
        {
            if (commflag > 0)
            {
                flag = 3;
                test.BackgroundImage = myimage[flag];
                for (int n = 0; n < num; n++)
                {
                    flags[n] = flag;
                    btns[n].BackgroundImage = myimage[flags[n]];
                    OneCtr(n, flag);
                }
                for (int i = 0; i < commflag; i++)
                { 
                    comm[i].Close();
                }
                commflag = 0;
                //   init.BackgroundImage = WindowsFormsApplication1.Properties.Resources.start;
                init.BackgroundImage = myimage[4];
                // Form1_Load(sender, e);
            }
           // Console.WriteLine("comm " + commflag + " " + i + " : " + commnum[i]);
            String[] commnum = textBox1.Text.Split(' ');
            
            commflag = commnum.Length;
            Console.WriteLine("comm " + commflag + " "  + commnum.ToString());
            if (commflag > commmax)
                commflag = commmax;
            for (int i = 0; i < commflag; i++)
            {
                if (comm[i] == null) {
                    
                    comm[i] = new SerialPort(this.components);
                    //Console.WriteLine("new comm " + i + " " + comm[i]);
                }
               // Console.WriteLine("comm " + commflag+" "+i + " : " + commnum[i]);
                String c = "COM" + commnum[i];
                comm[i].PortName = c;
                comm[i].BaudRate = 9600;
                comm[i].DataBits = 8;
                comm[i].StopBits = StopBits.One;
                comm[i].Parity = Parity.None;
                comm[i].Handshake = Handshake.None;
                //comm[i].DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
                comm[i].Open();
            }
          
            for (int i = 0; i < num; i++)
            {
                OneCtr(i, flags[i]);
            }
            // init.BackgroundImage = WindowsFormsApplication1.Properties.Resources.stop;
            init.BackgroundImage = myimage[5];
        }
        /*
        private void init_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen) 
            {
                flag = 3;
                test.BackgroundImage = myimage[flag];
                for (int n = 0; n < num; n++)
                {
                    flags[n] = flag;
                    btns[n].BackgroundImage = myimage[flags[n]];
                    OneCtr(n, flag);
                }         
                serialPort1.Close();
             //   init.BackgroundImage = WindowsFormsApplication1.Properties.Resources.start;
                init.BackgroundImage = myimage[4];
               // Form1_Load(sender, e);
            }
            serialPort1.PortName = "COM" + textBox1.Text;
         //   serialPort1.BaudRate = 9600;
         //   serialPort1.DataBits = 8;
         //   serialPort1.StopBits = StopBits.One;
         //   serialPort1.Parity = Parity.None;
          //  serialPort1.Handshake = Handshake.Non;
          //  serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
            serialPort1.Open();
            for (int i = 0; i < num; i++)
            {
                OneCtr(i, flags[i]);
            }       
           // init.BackgroundImage = WindowsFormsApplication1.Properties.Resources.stop;
            init.BackgroundImage = myimage[5];
        }
      */
        private void OneCtr(int num, int flag)
        {
            string str;
            int commnum = num / 25;
            for (int i = 1; i <= 8; i++)
            {
                // string.Format("{0:000000}",a)
                Console.WriteLine("comb  : " + commnum + " " + comm[commnum]);       
                if ((null!=comm[commnum]) &&(comm[commnum].IsOpen))
                { 
                    str = "O(" + string.Format("{0:00}", num) + "," + string.Format("{0:00}", i) + "," + oc[flag % 4, i - 1] + ")E ";
                    comm[commnum].WriteLine(str);
                }
            }
        }
        /*
        private void OneCtr(int num, int flag)
        {
            string str;      
            for (int i = 1; i <= 8; i++) 
            {
               // string.Format("{0:000000}",a)
                str = "O(" + string.Format("{0:00}", num) + "," + string.Format("{0:00}", i)+","+oc[flag%4,i-1]+")E ";
                //Console.WriteLine("comb  : " + str);

                if (serialPort1.IsOpen)
                {
                    serialPort1.WriteLine(str);
                }
            }      
        }*/
        private void test_Click(object sender, EventArgs e)
        {
            flag++ ;
           // Console.WriteLine("coma " + flag);
            flag = flag % 4;
            test.BackgroundImage = myimage[flag];
           // Console.WriteLine("comb " + flag);
            /*
            for (int i = 0; i < 100; i++)
            {
                OneCtr(i, i % 4);
            }
             */
           
        }
        /*
           string str = "O(00,01,1)E ";
           serialPort1.WriteLine(str);
           str = "O(00,03,1)E ";
           serialPort1.WriteLine(str);
           str = "O(00,05,1)E ";
           serialPort1.WriteLine(str);
           str = "O(00,07,1)E ";
           serialPort1.WriteLine(str);
           str = "O(01,02,1)E ";
           serialPort1.WriteLine(str);
           str = "O(01,04,1)E ";
           serialPort1.WriteLine(str);
           str = "O(01,06,1)E ";
           serialPort1.WriteLine(str);
           str = "O(01,08,1)E ";
           serialPort1.WriteLine(str);    
             */


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            flag = ((sender as ComboBox).SelectedIndex);
           // int n = int.Parse((sender as ComboBox).Name);
           // Console.WriteLine("comb " + n + " : " + f);
            comboBox1.BackColor = clrc[flag];
            Form1_Load(sender, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
      
    }
}
