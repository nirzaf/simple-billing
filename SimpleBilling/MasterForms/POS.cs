using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class POS : Form
    {
        public POS()
        {
            InitializeComponent();
        }

        private void POS_Load(object sender, EventArgs e)
        {
            systemTimer_Tick(sender, e);
        }

        private void LoadDateAndTime()
        {
            LblDate.Text = DateTime.Now.ToShortDateString();
            LblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void systemTimer_Tick(object sender, EventArgs e)
        {
            LoadDateAndTime();
        }
    }
}
