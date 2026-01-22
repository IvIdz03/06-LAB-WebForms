using System;
using System.Configuration;
using System.Data.SqlClient;

namespace WebForms
{
    public partial class Login : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["WebFormsLabos"].ConnectionString;

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUserName.Text.Trim();
            string pass = txtPassword.Text;

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM dbo.Users WHERE UserName=@u AND Password=@p", con))
            {
                cmd.Parameters.AddWithValue("@u", user);
                cmd.Parameters.AddWithValue("@p", pass);

                con.Open();
                int ok = (int)cmd.ExecuteScalar();

                if (ok == 1)
                {
                    Session["user"] = user;
                    Response.Redirect("Shop.aspx"); // po uputama :contentReference[oaicite:1]{index=1}
                }
                else
                {
                    lblMsg.Text = "Pogrešno korisničko ime ili lozinka.";
                }
            }
        }
    }
}
