using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyUpdate.Utils;
using MyUpdate.Entity;
using System.IO;

namespace MyUpdate
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Hide();
            new UpdateForm().ShowDialog();
            this.Show();
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RecoverForm().ShowDialog();
            this.Show();
        }
    }
}
