﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhiskersAndWags
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            patients1.Visible = false;
            medicalHistory1.Visible = false;
            appointments1.Visible = false;
            //staffMembers1.Visible = false;
            //salesInvoice1.Visible = false;
            salesReport1.Visible = false;
            staff1.Visible = false;
            updateInventory1.Visible = false;
            appointments1.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            patients1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            medicalHistory1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            appointments1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            updateInventory1.Visible = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            salesReport1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //staffMembers1.Visible = true;

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            updateInventory1.Visible = true;
        }

        private void updateInventory1_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            appointments1.Visible = true;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            //staffMembers1.Visible = true;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            salesReport1.Visible = true;
        }

        private void appointments1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_2(object sender, EventArgs e)
        {

        }

        private void button6_Click_3(object sender, EventArgs e)
        {
            //staffMembers1.Visible = true;
            staff1.Visible = true;
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            salesReport1.Visible = true;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            appointments1.Visible = true;

        }
    }
}
