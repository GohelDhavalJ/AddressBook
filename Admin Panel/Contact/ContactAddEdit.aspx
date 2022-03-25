<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="Admin_Panel_Contact_ContactAddEditaspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2 class="MainHeading">Contact Add Edit Page</h2>
        </div>
   </div>
    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="False"></asp:Label>
        </div>
   </div>
    <br />
    
            <div class="row">
                <div class="col-md-4">
                    *Country:
                </div>
                <div class="col-md-4">
                    <asp:DropDownList runat="server" ID="ddlCountryID" CssClass="form-control dropdown-toggle" AutoPostBack="True" OnSelectedIndexChanged="ddlCountryID_SelectedIndexChanged1" />
                </div>
                <div class="col-md-4">
                    <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ErrorMessage="Select Country" ControlToValidate="ddlCountryID" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>

    <br />


            <div class="row">
                <div class="col-md-4">
                    *State:
                </div>
                <div class="col-md-4">
                    <asp:DropDownList runat="server" ID="ddlStateID" CssClass="form-control dropdown-toggle" AutoPostBack="True" OnSelectedIndexChanged="ddlStateID_SelectedIndexChanged1"/>
                </div>
                <div class="col-md-4">
                    <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="Select State" ControlToValidate="ddlStateID" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>

    <br />


            <div class="row">
                <div class="col-md-4">
                    *City:
                </div>
                <div class="col-md-4">
                    <asp:DropDownList runat="server" ID="ddlCityID" CssClass="form-control dropdown-toggle"/>
                </div>
                <div class="col-md-4">
                    <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="Select City" ControlToValidate="ddlCityID" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>

    <br />


            <div class="row">
                <div class="col-md-4">
                    *Contact Category:
                </div>
                <div class="col-md-4">
                    <asp:DropDownList runat="server" ID="ddlContactCategoryID" CssClass="form-control dropdown-toggle"/>
                </div>
                 <div class="col-md-4">
                    <asp:RequiredFieldValidator ID="rfvContactCategory" runat="server" ErrorMessage="Select ContactCategory" ControlToValidate="ddlContactCategoryID" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>

    <br />


            <div class="row">
                <div class="col-md-4">
                    *Contact Name:
                </div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="txtContactName" CssClass="form-control"/>
                </div>
                <div class="col-md-4">
                    <asp:RequiredFieldValidator ID="rfvContactName" runat="server" ErrorMessage="Enter Contact Name" ControlToValidate="txtContactName"  ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
              </div>  

    <br />


            <div class="row">
                <div class="col-md-4">
                    *Contact No:
                </div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="txtContactNo" CssClass="form-control"/>
                </div>
                <div class="col-md-4">
                    <asp:RequiredFieldValidator ID="rfvContactNo" runat="server" ErrorMessage="Enter ContactNo" ControlToValidate="txtContactNo"  ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revContactNo" runat="server" ControlToValidate="txtContactNo" ErrorMessage="Enter Valid ContactNo(10 digit)" ForeColor="Red" ValidationExpression="^[7-9][0-9]{9}$" Display="Static"></asp:RegularExpressionValidator>
                </div>
            </div>

    <br />
    
            <div class="row">
                <div class="col-md-4">
                    WhatsApp No:
                </div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="txtWhatsAppNo" CssClass="form-control"/>
                </div>
                <div class="col-md-4">
                    <asp:RegularExpressionValidator ID="revWhatsAppNo" runat="server" ControlToValidate="txtWhatsAppNo" ErrorMessage="Enter Valid WhatsAppNo(10 digit)" ForeColor="Red" ValidationExpression="^[7-9][0-9]{9}$" Display="Static"></asp:RegularExpressionValidator>
                </div>
            </div>

    <br />

            <div class="row">
                <div class="col-md-4">
                    Birth date:
                </div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="txtBirthdate" CssClass="form-control" TextMode="DateTime"/>
                </div>
            </div>

    <br />

            <div class="row">
                <div class="col-md-4">
                    *Email:
                </div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"/>
                </div>
                <div class="col-md-4">
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Enter Email" ControlToValidate="txtEmail"  ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter Valid Email Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator>
                </div>
            </div>

    <br />


            <div class="row">
                <div class="col-md-4">
                    Age:
                </div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="txtAge" CssClass="form-control"/>
                </div>
            </div>

    <br />


            <div class="row">
                <div class="col-md-4">
                    *Address:
                </div>
                <div class="col-md-4">
                     <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control"/>
                </div>
                <div class="col-md-4">
                    <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="Enter Address" ControlToValidate="txtAddress"  ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>

    <br />


            <div class="row">
                <div class="col-md-4">
                    Blood Group:
                </div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="txtBloodGroup" CssClass="form-control"/>
                </div>
            </div>

    <br />


            <div class="row">
                <div class="col-md-4">
                    FaceBookID:
                </div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="txtFaceBookID" CssClass="form-control"/>
                </div>
            </div>

    <br />


            <div class="row">
                <div class="col-md-4">
                    LinkedINID:
                </div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="txtLinkedINID" CssClass="form-control"/>
                </div>
            </div>

    <br />

    <div class="row">
        <div class="col-md-4">

        </div>
        <div class="col-md-">
            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary btn-sm" OnClick="btnSave_Click" />
             <asp:HyperLink runat="server" ID="btnCancel" Text="Cancel" CssClass="btn btn-danger btn-sm" NavigateUrl="~/Admin Panel/Contact/ContactList.aspx" />
        </div>
    </div>
</asp:Content>

