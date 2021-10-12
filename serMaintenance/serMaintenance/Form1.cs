﻿using serMaintenance.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serMaintenance
{

    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();

            label1.Text = Resource1.LastName; // label1
            label2.Text = Resource1.FirstName; // label2
            button1.Text = Resource1.Add; // button1


            // listbox1
            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text + " " + textBox2.Text
            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using(var sfd = new SaveFileDialog())
            {
                sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.FilterIndex = 2;

                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    TextWriter tw = new StreamWriter(sfd.FileName);

                    foreach(User s in users)
                    {
                        tw.WriteLine(s.FullName+";");


                    }
                    tw.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var x = (User)listBox1.SelectedItem;
            users.Remove(x);
        }
    }
}
