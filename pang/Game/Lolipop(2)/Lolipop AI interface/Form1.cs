﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Motivation;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Drawing.Imaging;

namespace Lolipop_AI_interface
{
    public partial class Form1 : Form
    {
        private const int port = 6001;
        private const int panelCount = 2;
        private MyTableLayoutPanel TLP;
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            {
                TLP = new MyTableLayoutPanel((panelCount+1)/2,2,new Func<int,string>((int n)=>{
                    string ans = "";for (int i = 0; i < n; i++) ans += "P";return ans;
                })((panelCount + 1) / 2),"PP");
                for(int i=0;i< panelCount; i++)
                {
                    TLP.AddControl(new GamePanel(port + i), i / 2, i % 2);
                }
                this.Controls.Add(TLP);
            }
            this.FormClosing += Form1_FormClosing;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}