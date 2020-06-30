﻿using DatabaseProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FileMovement
{
    public partial class Department_File_Registration : Form
    {
        DBAccess objDbAccess = new DBAccess();
        public Department_File_Registration()
        {
            InitializeComponent();
        }

        private void btnDeptFileNoGenerator_Click(object sender, EventArgs e)
        {
            char[] letters = "1234567890".ToCharArray();
            Random r = new Random();
            string randomString = "";
            for (int i = 0; i < 4; i++)
            {
                randomString += letters[r.Next(0, 9)].ToString();
            }
            MessageBox.Show(randomString);
        }

        private void btnDeptFileRegister_Click(object sender, EventArgs e)
        {
            string fileNumber = txtDeptFileNumber.Text;
            string subject = txtDeptFileSubject.Text;
            string department = txtDeptFileDept.Text;
            string subjectDetails = txtDeptFileSubjectDetails.Text;
            string fileBrowsed = txtDeptFileBrowsed.Text;
            string date = dateDeptFile.Text;
            string name = txtDeptFileName.Text;
            string user = txtDeptFileUser.Text;

            if (fileNumber.Equals(""))
            {
                MessageBox.Show("Please enter your File Number!!");
            }
            else if (subject.Equals(""))
            {
                MessageBox.Show("Please enter your Subject!!");
            }
            else if (department.Equals(""))
            {
                MessageBox.Show("Please enter your Department!!");
            }
            else if (subjectDetails.Equals(""))
            {
                MessageBox.Show("Please enter subject details of file!!");
            }
            else if (date.Equals(""))
            {
                MessageBox.Show("Please enter Date!!");
            }
            else if (name.Equals(""))
            {
                MessageBox.Show("Please enter your Name!!");
            }
            else if (user.Equals(""))
            {
                MessageBox.Show("Please enter type of User!!");
            }
            else
            {
                SqlCommand insertCommand = new SqlCommand("insert into fileRegistration(FILE_NO,SUBJECT,DEPT,SUB_DETAILS,FILE_BROWSED,DATE,NAME,[USER]) values(@fileNumber, @subject, @department, @subjectDetails, @fileBrowsed, @date, @name, @user)");

                insertCommand.Parameters.AddWithValue("@fileNumber", fileNumber);
                insertCommand.Parameters.AddWithValue("@subject", subject);
                insertCommand.Parameters.AddWithValue("@department", department);
                insertCommand.Parameters.AddWithValue("@subjectDetails", subjectDetails);
                insertCommand.Parameters.AddWithValue("@fileBrowsed", fileBrowsed);
                insertCommand.Parameters.AddWithValue("@date", date);
                insertCommand.Parameters.AddWithValue("@name", name);
                insertCommand.Parameters.AddWithValue("@user", user);

                int row = objDbAccess.executeQuery(insertCommand);

                if (row == 1)
                {
                    MessageBox.Show("Your file is Registered Successfully!!");
                }
                else
                {
                    MessageBox.Show("Error Occured While Registering your file!!.. Please Try Again!!");
                }
            }
        }
        OpenFileDialog ofd = new OpenFileDialog();
        private void btndeptFileBrowsed_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtDeptFileBrowsed.Text = ofd.FileName;
            }
        }
    }
}
