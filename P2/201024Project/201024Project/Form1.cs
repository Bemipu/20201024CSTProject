using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _201024Project {
    public partial class Form1 : Form {

        //public int[,] tbpos = new int[20,4];
        public const int tba = 6;
        public const int tbla = 20;
        public TextBox[] tb = new TextBox[tba];
        public Label[] tbl = new Label[tbla];
        public int[,] tbpos = new int[,] { {180, 230},{274, 275},{440,275},{190, 345},{130, 528},{195, 600} };
        public string[] tblchoice = new string[] { "a", "b", "a/b", "a%b", "b/a", "b%a", "a>b", "a=b", "a==b", "a<b", "int", "char", "bool", "float", "a/b !=", "a/b ==", "a%b !=", "a%b ==", "cout<<a", "cout<<b" };
        public int[] ans = new int[] { 16, 1, 3, 19, 10, 6 };

        public Form1() {
            
            tb_Init();
            InitializeComponent();
            //Array.Clear(tbpos, 0, tbpos.Length);

        }

        public void tb_Init() {
            
            //textboxs
            for (int i = 0; i < tba; i++) {
                this.tb[i] = new TextBox(); //https://forum.gamer.com.tw/C.php?bsn=60292&snA=5546
                this.tb[i].AllowDrop = true;
                this.tb[i].BackColor = System.Drawing.SystemColors.Window;
                this.tb[i].ForeColor = System.Drawing.SystemColors.WindowText;
                this.tb[i].ReadOnly = true;
                this.tb[i].Font = new System.Drawing.Font("Consolas", 24F);
                this.tb[i].Location = new System.Drawing.Point(tbpos[i,0], tbpos[i,1]);
                this.tb[i].Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
                this.tb[i].Name = "tB" + (i+1).ToString();
                this.tb[i].Size = new System.Drawing.Size(140, 45);
                this.tb[i].TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                //this.tb[i].TabIndex = i;
                this.Controls.Add(tb[i]);
                this.tb[i].BringToFront(); //https://stackoverflow.com/questions/18092711/textbox-not-showing-in-winforms-form/18092767
                this.tb[i].Click += new System.EventHandler(this.textBox_Click);
            }

            //labels
            for (int i = 0; i < tbla; i++) {
                this.tbl[i] = new Label();
                this.tbl[i].AutoSize = true;
                this.tbl[i].BackColor = System.Drawing.SystemColors.ControlDark;
                this.tbl[i].Font = new System.Drawing.Font("Consolas", 24F);
                this.tbl[i].Location = new System.Drawing.Point(830, 0 + (i*40));
                this.tbl[i].Name = "tbl" + (i).ToString();
                this.tbl[i].Size = new System.Drawing.Size(544, 56);
                this.tbl[i].Tag = i;
                this.tbl[i].Text = tblchoice[i];//"l" + (i).ToString();
                this.tbl[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
                this.tbl[i].MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_MouseMove);
                this.tbl[i].MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_MouseUp);
                this.Controls.Add(tbl[i]);
                this.tbl[i].BringToFront();
            }
        }

        public bool onTarget = false;

        private void label_MouseDown(object sender, MouseEventArgs e) {
            onTarget = true;
            Label dalabel = (Label)sender;
            dalabel.BringToFront();
        }

        private void label_MouseUp(object sender, MouseEventArgs e) {
            onTarget = false;
            Label dalabel = (Label)sender;
            for (int i = 0; i < tba; i++) {
                if (dalabel.Location.X + dalabel.Size.Width / 2 >= this.tb[i].Location.X && 
                    dalabel.Location.X + dalabel.Size.Width / 2 <= this.tb[i].Location.X + this.tb[i].Size.Width &&
                    dalabel.Location.Y + dalabel.Size.Height / 2 >= this.tb[i].Location.Y && 
                    dalabel.Location.Y + dalabel.Size.Height / 2 <= this.tb[i].Location.Y + this.tb[i].Size.Height) {
                
                    if (tb[i].Text == "") {
                        dalabel.Visible = false;
                        this.tb[i].Text = dalabel.Text;
                        this.tb[i].Tag = dalabel.Tag;
                    }
                }
            } 
        }

        private void label_MouseMove(object sender, MouseEventArgs e) {
            if (onTarget) {
                Label dalabel = (Label)sender;
                dalabel.Location = new Point(
                    dalabel.Location.X + e.X - (dalabel.Size.Width/2),
                    dalabel.Location.Y + e.Y - (dalabel.Size.Height/2)
                );
            }
        }

        private void textBox_Click(object sender, EventArgs e) {
            TextBox datb = (TextBox)sender;
            if (datb.Text != "") { 
                tbl[int.Parse(datb.Tag.ToString())].Visible = true;
                datb.Tag = null;
                datb.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            bool pass = true;
            for (int i = 0; i < tba; i++) {
                if (this.tb[i].Tag != null) {
                    if (int.Parse((this.tb[i].Tag).ToString()) != this.ans[i]) {
                        pass = false;
                        break;
                    }
                } else {
                    pass = false;
                    break;
                }
            }
            if (pass) {
                label3.Text = "NICE";
            }
        }
    }
}
