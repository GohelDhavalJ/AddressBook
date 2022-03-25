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

public partial class Admin_Panel_Country_CountryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            if(Request.QueryString["CountryID"] != null)
            {
                lblMessage.Text = "CountryID = " + Request.QueryString["CountryID"];

                FillControls(Convert.ToInt32(Request.QueryString["CountryID"]));
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
        SqlString strCountryName = SqlString.Null;
        SqlString strCountryCode = SqlString.Null;

        #endregion Local Variables

        try
        {
            #region Server Side Validation

            //validate The Data
            String strErrorMessage = "";

            if (txtCountryName.Text.Trim() == "")
            {
                strErrorMessage += "- Enter CountryName <br/>";
            }
            if (strErrorMessage != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }

            #endregion Server Side Validation

            #region Gather The Information

            //Gather Information
            if (txtCountryName.Text.Trim() != "")
            {
                strCountryName = txtCountryName.Text.Trim();
            }

            strCountryCode = txtCountryCode.Text.Trim();

            #endregion Gather The Information

            #region set Connection & Command object

            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
           
            //Pass the parameters in the SP
            objCmd.Parameters.AddWithValue("@CountryName", strCountryName);
            objCmd.Parameters.AddWithValue("@CountryCode", strCountryCode);

            #endregion set Connection & Command object

            if (Request.QueryString["CountryID"] != null)
            {
                #region Update Record

                objCmd.Parameters.AddWithValue("@CountryID", Request.QueryString["CountryID"].ToString().Trim());
                objCmd.CommandText = "[dbo].[PR_Country_UpdateByPK]";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/Admin Panel/Country/CountryList.aspx", true);

                #endregion Update Record
            }

            else
            {
                #region Insert Record

                objCmd.CommandText = "[dbo].[PR_Country_Insert]";
                objCmd.ExecuteNonQuery();
                lblMessage.Text = "Data Inserted SucessFully";
                txtCountryName.Text = "";
                txtCountryName.Focus();
                txtCountryCode.Text = "";
                txtCountryCode.Focus();

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
    private void FillControls(SqlInt32 CountryID)
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
            objCmd.CommandText = "[dbo].[PR_Country_SelectByPK]";
            objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString().Trim());

            #endregion Set Connection & Command object

            #region Read the value and set the controls
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    //if(objSDR["CountryID"].Equals(DBNull.Value) !=true)
                    if(!objSDR["CountryName"].Equals(DBNull.Value))
                    {
                        txtCountryName.Text = objSDR["CountryName"].ToString().Trim();
                    }
                    if (!objSDR["CountryCode"].Equals(DBNull.Value))
                    {
                        txtCountryCode.Text = objSDR["CountryCode"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data Available for the StateID = " + CountryID.ToString();
            }
            #endregion Read the value and set the controls

            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }
        catch(Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if(objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }
    }

    #endregion FillControls
}