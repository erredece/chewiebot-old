using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChewieBot
{
    public partial class Form1 : Form
    {
        public static chewieBot chewiebot = new chewieBot();
        public static database db = new database();
        public Form1()
        {
            InitializeComponent();
            db.DBExists();
            //db.CreateTable("");
            //db.InsertValues("");
            //db.InsertValues("");
            //db.InsertValues("");
            //db.InsertValues("");
            //db.ReadValue("", "", "");

            chewiebot.Connect();
            chewiebot.Disconnect();

        }
    }
}