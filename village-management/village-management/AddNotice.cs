﻿using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace village_management
{
    public partial class AddNotice : Form
    {
        string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shasw\Desktop\netproject\village-management\village-management\VILLAGE-MANAGEMENT.mdf;Integrated Security=True";

        public AddNotice()
        {
            InitializeComponent();
            AllNotice();
        }

        private void NoticeSubmit_Click(object sender, EventArgs e)
        {

            string query = "insert into Notices(NoticeSubject,NoticeDesc)VALUES(@subject,@desc)";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@ComBy", "shaswat");
            cmd.Parameters.AddWithValue("@subject", NoticeSub.Text);
            cmd.Parameters.AddWithValue("@desc", NoticeDesc.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Submit Successfully!!!");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashboard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdminPanel obj = new AdminPanel();
            obj.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdminManage obj = new AdminManage();
            obj.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddNotice obj = new AddNotice();
            obj.Show();
            this.Hide();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdminComplaints obj = new AdminComplaints();
            obj.Show();
            this.Hide();
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            login obj = new login();
            obj.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }

        private void AllNotice()
        {
            SqlConnection con = new SqlConnection(constring);
            string query = "select*from Notices";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            AllNoticesGrid.DataSource = dt;
            con.Close();

        }

        private void DeleteNoticeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(constring);
                con.Open();

                string query = "DELETE FROM Notices WHERE id=@Nid";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nid", txtNoticeId.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Notice Deleted Succesfully");

                AddNotice obj = new AddNotice();
                obj.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Delete Notice ");
            }
        }
    }
}
