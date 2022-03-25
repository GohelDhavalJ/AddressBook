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

public partial class Admin_Panel_City_CityAddEdit : System.Web.UI.Page
{
        #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            FillDropDownList();

            if(Request.QueryString["CityID"] != null)
            {
                lblMessage.Text = "CityID = " + Request.QueryString["CityID"];

                FillControls(Convert.ToInt32(Request.QueryString["CityID"]));
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
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnetionString"].ConnectionString);

        SqlInt32 strStateID = SqlInt32.Null;
        SqlString strCityName = SqlString.Null;
        SqlString strSTDCode = SqlString.Null;
        SqlString strPinCode = SqlString.Null;

        #endregion Local Variables

        try
        {
            #region Server Side Validation

            String strErrorMessage = "";

            if (ddlStateID.SelectedIndex == 0)
            {
                strErrorMessage += "- Select State<br/>";
            }
            if (txtCityName.Text.Trim() == "")
            {
                strErrorMessage += "- Enter CityName<br/>";
            }
            if (strErrorMessage.Trim() != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }

            #endregion Server Side Validation

            #region Gather The Information
            //Gather The Information

            if (ddlStateID.SelectedIndex > 0)
            {
                strStateID = Convert.ToInt32(ddlStateID.SelectedValue);
            }
            if (txtCityName.Text.Trim() != "")
            {
                strCityName = txtCityName.Text.Trim();
            }

            strSTDCode = txtSTDCode.Text.Trim();
            strPinCode = txtPincode.Text.Trim();

            #endregion Gather The Information

            #region set Connection & Command object

            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            //Pass the parameters in the SP
            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CityName", strCityName);
            objCmd.Parameters.AddWithValue("@STDCode", strSTDCode);
            objCmd.Parameters.AddWithValue("@PinCode", strPinCode);

            #endregion set Connection & Command object

            if (Request.QueryString["CityID"] != null)
            {
                #region Update Record
                objCmd.Parameters.AddWithValue("@CityID", Request.QueryString["CityID"].ToString().Trim());
                objCmd.CommandText = "[dbo].[PR_City_UpdateByPK]";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/Admin Panel/City/CityList.aspx", true);
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                objCmd.CommandText = "[dbo].[PR_City_Insert]";
                objCmd.ExecuteNonQuery();
                txtCityName.Text = "";
                txtSTDCode.Text = "";
                txtPincode.Text = "";
                ddlStateID.SelectedIndex = 0;
                ddlStateID.Focus();
                lblMessage.Text = "Data Inserted SuccessFully";
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

        #region FillDropDownList
    private void FillDropDownList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnetionString"].ConnectionString);
        try
        {
            #region Set Connection & Command object

            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_State_SelectForDropDownList]";

            #endregion Set Connection & Command object

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddlStateID.DataSource = objSDR;
                ddlStateID.DataValueField = "StateID";
                ddlStateID.DataTextField = "StateName";
                ddlStateID.DataBind();
            }

            ddlStateID.Items.Insert(0, new ListItem("---Select State---", "-1"));

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

    #endregion FillDropDownList

        #region FillControls
    private void FillControls(SqlInt32 CityID)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnetionString"].ConnectionString);
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
            objCmd.CommandText = "[dbo].[PR_City_SelectByPK]";
            objCmd.Parameters.AddWithValue("@CityID", CityID.ToString().Trim());

            #endregion Set Connection & Command object

            #region Read the value and set the controls

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if(objSDR.HasRows)
            {
                while(objSDR.Read())
                {
                    //if(objSDR["CountryID"].Equals(DBNull.Value) != true)
                    if(!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }
                    if (!objSDR["CityName"].Equals(DBNull.Value))
                    {
                        txtCityName.Text = objSDR["CityName"].ToString().Trim();
                    }
                    if (!objSDR["STDCode"].Equals(DBNull.Value))
                    {
                        txtSTDCode.Text = objSDR["STDCode"].ToString().Trim();
                    }
                    if (!objSDR["PinCode"].Equals(DBNull.Value))
                    {
                        txtPincode.Text = objSDR["PinCode"].ToString().Trim();
                    }
                    break;
                }

            }
            else
            {
                lblMessage.Text = "No Data Available for the StateID = " + CityID.ToString();
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
            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }
    }

    #endregion FillControls
}