﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetMed
{
    public partial class Form1 : Form
    {
        function fn = new function();
        String query;
        DataSet ds;
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure, you want to close this application?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if(dialog == DialogResult.No)
            {
                this.Show();
            }
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            query = "select * from users";
            ds = fn.getData(query);
            if(ds.Tables[0].Rows.Count == 0)
            {
                if(txtUsername.Text == "root" && txtPassword.Text == "root")
                {
                    Adminstrator admin = new Adminstrator();
                    admin.Show();
                    this.Hide();
                }
            }
            else
            {
                query = "select * from users where username = '"+txtUsername.Text+"' and pass = '"+txtPassword.Text+"'";
                ds = fn.getData(query);
                if(ds.Tables[0].Rows.Count != 0)
                {
                    String role = ds.Tables[0].Rows[0][1].ToString();
                    if(role == "Adminstrator")
                    {
                        Adminstrator admin = new Adminstrator(txtUsername.Text);
                        admin.Show();
                        this.Hide();
                    }
                    else if(role == "Pharmacist")
                    {
                        Pharmacist pharm = new Pharmacist();
                        pharm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong credentails, please enter your correct credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
