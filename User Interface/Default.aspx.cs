using System;
using DAL;

namespace User_Interface
{
    public partial class Default : System.Web.UI.Page
    {
        private SongDAL _songDAL = new SongDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDDL();
            }
        }

        protected void FillDDL()
        {
            ddlUsers.DataSource = _songDAL.GetUsers();
            ddlUsers.DataTextField = "UserID";
            ddlUsers.DataValueField = "UserID";
            ddlUsers.DataBind();
        }

        protected void btnGoToDetailsPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetailsPage.aspx?user=" + ddlUsers.SelectedValue);
        }
    }
}