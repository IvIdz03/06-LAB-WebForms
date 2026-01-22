using System;
using System.Configuration;
using System.Data.SqlClient;

namespace WebForms
{
    public partial class Registracija : System.Web.UI.Page
    {
        string cs = ConfigurationManager
            .ConnectionStrings["WebFormsLabos"].ConnectionString;

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string user = txtUserName.Text.Trim();
            string full = txtFullName.Text.Trim();
            string p1 = txtPassword.Text;
            string p2 = txtPassword2.Text;

            if (user == "" || full == "" || p1 == "")
            {
                lblMsg.Text = "Popuni sva polja.";
                return;
            }

            if (p1 != p2)
            {
                lblMsg.Text = "Lozinke se ne podudaraju.";
                return;
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                SqlCommand check = new SqlCommand(
                    "SELECT COUNT(*) FROM Users WHERE UserName=@u", con);
                check.Parameters.AddWithValue("@u", user);

                int exists = (int)check.ExecuteScalar();
                if (exists > 0)
                {
                    lblMsg.Text = "Korisnik vec postoji.";
                    return;
                }

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Users(UserName,Password,FullName) VALUES(@u,@p,@f)", con);
                cmd.Parameters.AddWithValue("@u", user);
                cmd.Parameters.AddWithValue("@p", p1);
                cmd.Parameters.AddWithValue("@f", full);

                cmd.ExecuteNonQuery();
            }

            Response.Redirect("Login.aspx");
        }
    }
}
