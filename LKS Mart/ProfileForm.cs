﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKS_Mart
{
    public partial class ProfileForm : CoreForm
    {
        private AppDataController appDataController = new AppDataController();
        private LKSMartEntities db = new LKSMartEntities();

        public ProfileForm()
        {
            InitializeComponent();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            lblTitle.Text = this.Text;
            btnClose.Click += btnClose_Click;

            LoadData();
        }

        private void LoadData()
        {
            var customerID = appDataController.GetAppData().LoginCustomerID;
            var customer = db.Customers.Where(x => x.id == customerID).ToList()[0];
            txtName.Text = customer.name;
            txtPhoneNumber.Text = customer.phone_number;
            txtEmail.Text = customer.email;
            txtPIN.Text = customer.pin_number;
            dtpDateOfBirth.Value = customer.date_of_birth.Value;
            txtAddress.Text = customer.address;
            comboGender.SelectedItem = customer.gender == null ? "Prefer not to say" : customer.gender;

            if(customer.profile_image_name == null)
            {
                picBoxProfilePicture.ImageLocation = Application.StartupPath + "/images/profile_pictures/default_profile_picture.png";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainForm().Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainForm().Show();
        }
    }
}
