using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebForms
{
    public partial class Shop : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["WebFormsLabos"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // opcionalno: zaštita da ne ide bez logina
            // if (Session["user"] == null) Response.Redirect("Login.aspx");

            if (!IsPostBack)
                LoadGrid();
        }

        private void LoadGrid()
        {
            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand("SELECT Id, Name, Description FROM dbo.Products ORDER BY Id", con))
            {
                con.Open();

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(r);

                    gvProducts.DataSource = dt;
                    gvProducts.DataBind();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string desc = txtDesc.Text.Trim();

            if (name == "" || desc == "")
            {
                lblMsg.Text = "Upiši naziv i opis.";
                return;
            }

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Products(Name, Description) VALUES(@n,@d)", con))
            {
                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@d", desc);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            txtName.Text = "";
            txtDesc.Text = "";
            lblMsg.Text = "";

            LoadGrid(); // refresh nakon spremanja :contentReference[oaicite:1]{index=1}
        }
    }
}
