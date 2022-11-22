using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loto
{
    public partial class Begin : Form
    {
        public Form game = new Loto.Lotto();
        public Begin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            game.Show();
            this.Hide();
        }
    }
}
