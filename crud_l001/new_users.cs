using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace crud_l001
{
    public partial class new_users : UserControl
    {
        
        public new_users()
        {
           
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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
                        cmd.CommandText = "INSERT users (login, password, name) VALUES ('" + logins + "','" + passwords + "','" + namess + "')";
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
                        if ("-2146232060"== Convert.ToString(ex.HResult))
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

        private void otmena_Click(object sender, EventArgs e)
        {
            full_users uc = new full_users();
            Point t = new Point(0, 0);
            uc.Location = t;
            Application.OpenForms[0].Controls.Add(uc);
            this.Parent.Controls.Remove(this);
        }
    }
}
