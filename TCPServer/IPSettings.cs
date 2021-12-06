using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPServer
{
    public partial class IPSettings : Form
    {
        private readonly ResourceManager Resources = new ResourceManager("TCPServer.Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
        public IPSettings()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        }
    }
}
