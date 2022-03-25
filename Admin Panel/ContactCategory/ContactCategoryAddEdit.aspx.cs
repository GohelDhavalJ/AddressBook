using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Admin_Panel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            if (Request.QueryString["ContactCategoryID"] != null)
            {
                lblMessage.Text = "ContactCategoryID = " + Request.QueryString["ContactCategoryID"];

                FillControls(Convert.ToInt32(Request.QueryString["ContactCategoryID"]));
            }
            else
            {
                lblMessage.Text = "Add Mode";
            }

        }
    }

    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variables

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnetionString"].ConnectionString.Trim());

        //Declare Local Variables to insert the data
        SqlString strContactCategoryName = SqlString.Null;

        #endregion Local Variables

        try
        {
            #region Server Side Validation

            //validate The Data
            String strErrorMessage = "";

            if (txtContactCategoryName.Text.Trim() == "")
            {
                strErrorMessage += "- Enter ContactCategoryName <br/>";
            }
            if (strErrorMessage != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }

            #endregion Server Side Validation

            #region Gather The Information

            //Gather Information
            if (txtContactCategoryName.Text.Trim() != null)
            {
                strContactCategoryName = txtContactCategoryName.Text.Trim();
            }

            #endregion Gather The Information

            #region set Connection & Command object

            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            //Pass the parameters in the SP

            objCmd.Parameters.AddWithValue("@ContactCategoryName", strContactCategoryName);

            #endregion set Connection & Command object

            if (Request.QueryString["ContactCategoryID"] != null)
            {
                #region Update Record
                objCmd.Parameters.AddWithValue("@ContactCategoryID", Request.QueryString["ContactCategoryID"].ToString().Trim());
                objCmd.CommandText = "[dbo].[PR_ContactCategory_UpdateByPK]";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/Admin Panel/ContactCategory/ContactCategoryList.aspx", true);
                #endregion Update Record

            }
            else
            {
                #region Insert Record
                objCmd.CommandText = "[dbo].[PR_ContactCategory_Insert]";
                objCmd.ExecuteNonQuery();
                lblMessage.Text = "Data Inserted SucessFully";
                txtContactCategoryName.Text = "";
                txtContactCategoryName.Focus();
                #endregion Insert Record

            }


            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }
       
    }

    #endregion Button : Save

    #region FillControls
    private void FillControls(SqlInt32 ContactCategoryID)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnetionString"].ConnectionString.Trim());
        #endregion Local Variables

        try
        {
            #region Set Connection & Command object
            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_ContactCategory_SelectByPK]";
            objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID.ToString().Trim());

            #endregion Set Connection & Command object

            #region Read the value and set the controls

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    //if(objSDR["CountryID"].Equals(DBNull.Value) !=true)
                    if (!objSDR["ContactCategoryName"].Equals(DBNull.Value))
                    {
                        txtContactCategoryName.Text = objSDR["ContactCategoryName"].ToString().Trim();
                    }
                    
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data Available for the StateID = " + ContactCategoryID.ToString();
            }

            #endregion Read the value and set the controls

            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }
    }

    #endregion FillControls
}