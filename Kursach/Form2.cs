using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kursach;

namespace Kursach
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string TxtForLabel
        {
            get;set;
        }
        public Color BackColor_
        {
            get; set;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = TxtForLabel;
            label1.BackColor = BackColor_;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.f1.RestartGame();
            Program.f1.ReDrawAllMap();
            Program.f1.ReCountInfo();
            Program.f1.HighlightPossibleShashki();
            Program.f1.WinCheck();
        }
    }
}
