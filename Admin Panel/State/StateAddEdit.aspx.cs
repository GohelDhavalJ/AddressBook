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

public partial class Admin_Panel_State_StateAddEdit : System.Web.UI.Page
{

    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            FillDropDownList();
            
            if(Request.QueryString["StateID"] != null)
            {
                lblMessage.Text = "StateID = "+Request.QueryString["StateID"];

                FillControls(Convert.ToInt32(Request.QueryString["StateID"]));
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

        SqlInt32 strCountryID = SqlInt32.Null;
        SqlString strStateName = SqlString.Null;
        SqlString strStateCode = SqlString.Null;

        #endregion Local Variables

        try
        {
            #region Server Side Validation

            //Server Side Validation
            String strErrorMessage = "";

            if (ddlCountryID.SelectedIndex == 0)
            {
                strErrorMessage += "- Select Country<br/>";
            }
            if (txtStateName.Text.Trim() == "")
            {
                strErrorMessage += "- Enter StateName<br/>";
            }

            if (strErrorMessage.Trim() != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }
            #endregion Server Side Validation

            #region Gather The Information
            //Gather The Information

            if (ddlCountryID.SelectedIndex > 0)
            {
                strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
            }
            if (txtStateName.Text.Trim() != "")
            {
                strStateName = txtStateName.Text.Trim();
            }

            strStateCode = txtStateCode.Text.Trim();

            #endregion Gather The Information

            #region set Connection & Command object

            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }

            
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            //Pass the parameters in the SP
            objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
            objCmd.Parameters.AddWithValue("@StateName", strStateName);
            objCmd.Parameters.AddWithValue("@StateCode", strStateCode);

            #endregion set Connection & Command object

            if (Request.QueryString["StateID"] != null)
            {
                #region Update Record

                objCmd.Parameters.AddWithValue("@StateID", Request.QueryString["StateID"].ToString().Trim());
                objCmd.CommandText = "[dbo].[PR_State_UpdateByPK]";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/Admin Panel/State/StateList.aspx",true);

                #endregion Update Record
            }
            else
            {
                #region Insert Record

                objCmd.CommandText = "[dbo].[PR_State_Insert]";
                objCmd.ExecuteNonQuery();
                txtStateName.Text = "";
                txtStateCode.Text = "";
                ddlCountryID.SelectedIndex = 0;
                ddlCountryID.Focus();
                lblMessage.Text = "Data Inserted SuccessFully";

                #endregion Insert Record
            }

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

    #endregion Button : Save

    #region FillDroapDownList
    private void FillDropDownList()
    {

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnetionString"].ConnectionString.Trim());

        try
        {

            #region Set Connection & Command object

            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_Country_SelectForDropDownList]";

            #endregion Set Connection & Command object

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddlCountryID.DataSource = objSDR;
                ddlCountryID.DataValueField = "CountryID";
                ddlCountryID.DataTextField = "CountryName";
                ddlCountryID.DataBind();
            }

            ddlCountryID.Items.Insert(0, new ListItem("---Select Country---", "-1"));

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
            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }
    }

    #endregion FillDroapDownList

    #region FillControls
    private void FillControls(SqlInt32 StateID)
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
            objCmd.CommandText = "[dbo].[PR_State_SelectByPK]";
            objCmd.Parameters.AddWithValue("@StateID", StateID.ToString().Trim());

            #endregion Set Connection & Command object

            #region Read the value and set the controls

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if(objSDR.HasRows)
            {
                while(objSDR.Read())
                {
                    //if(objSDR["CountryID"].Equals(DBNull.Value) !=true)
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    if (!objSDR["StateName"].Equals(DBNull.Value))
                    {
                        txtStateName.Text = objSDR["StateName"].ToString().Trim();
                    }
                    
                    if (!objSDR["Statecode"].Equals(DBNull.Value))
                    {
                        txtStateCode.Text = objSDR["Statecode"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data Available for the StateID = " + StateID.ToString();
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