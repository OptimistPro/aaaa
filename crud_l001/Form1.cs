using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crud_l001
{
    public partial class glav : Form
    {

        
        public glav()
        {
            InitializeComponent();
            full_users uc = new full_users();
            Point t = new Point(0, 0);
            uc.Location = t;
            this.Controls.Add(uc);
        }

        private void glav_Load(object sender, EventArgs e)
        {

        }
    }
}
