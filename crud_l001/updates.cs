﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace crud_l001
{
    public partial class updates : UserControl
    {
        string id = "";
        public updates(string ids)
        {
            id = ids;
            InitializeComponent();



            using (SqlConnection con = new SqlConnection(@"Data source=.\SQLEXPRESS;Initial Catalog=crud_l001;User ID=user;Password=Passw0rd;"))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    //заполнение данных
                    cmd.CommandText = "select * from [users] where id="+id;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                       
                        login.Text = Convert.ToString(String.Format("{0}", reader[1]));
                        password.Text = Convert.ToString(String.Format("{0}", reader[2]));
                        names.Text = Convert.ToString(String.Format("{0}", reader[3]));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex));
                }
                finally
                {
                    con.Close();
                }



            }

        }

        private void otmena_Click(object sender, EventArgs e)
        {
            full_users uc = new full_users();
            Point t = new Point(0, 0);
            uc.Location = t;
            Application.OpenForms[0].Controls.Add(uc);
            this.Parent.Controls.Remove(this);
        }

        private void news_Click(object sender, EventArgs e)
        {
            string logins = login.Text;
            string passwords = password.Text;
            string namess = names.Text;

            if (logins != "" && passwords != "" && namess != "")
            {
                using (SqlConnection con = new SqlConnection(@"Data source=.\SQLEXPRESS;Initial Catalog=crud_l001;User ID=user;Password=Passw0rd;"))
                {
                    try
                    {

                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "UPDATE [users] SET login='" + logins + "', password='" + passwords + "', name='" + namess + "' Where [users].id=" + id;
                        cmd.ExecuteScalar();
                        con.Close();

                        full_users uc = new full_users();
                        Point t = new Point(0, 0);
                        uc.Location = t;
                        Application.OpenForms[0].Controls.Add(uc);
                        this.Parent.Controls.Remove(this);



                    }
                    catch (Exception ex)
                    {
                        if ("-2146232060" == Convert.ToString(ex.HResult))
                        {
                            MessageBox.Show("Логин занят");
                        }
                        else
                        {
                            MessageBox.Show(Convert.ToString(ex));
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
    }
}
