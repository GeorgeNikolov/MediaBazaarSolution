﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaarSolution
{
    public partial class LogInScreen : Form
    {
        public LogInScreen()
        {
            InitializeComponent();
            ScheduleForm form = new ScheduleForm();
            form.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}