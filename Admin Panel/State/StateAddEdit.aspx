<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="StateAddEdit.aspx.cs" Inherits="Admin_Panel_State_StateAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2 class="MainHeading">State Add Edit Page</h2>
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
                    <asp:DropDownList runat="server" ID="ddlCountryID" CssClass="form-control dropdown-toggle"/>
                </div>
                <div class="col-md-4">
                    <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ErrorMessage="Select Country" ControlToValidate="ddlCountryID" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>

    <br />

            <div class="row">
                <div class="col-md-4">
                    *StateName:
                </div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="txtStateName" CssClass="form-control"/>
                </div>
                <div class="col-md-4">
                    <asp:RequiredFieldValidator ID="rfvStateName" runat="server" ErrorMessage="Enter State Name" ControlToValidate="txtStateName"  ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>

    <br />

            <div class="row">
                <div class="col-md-4">
                    StateCode:
                </div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="txtStateCode" CssClass="form-control"/>
                </div>
          </div>
    <br />
    <div class="row">
        <div class="col-md-4">

        </div>
        <div class="col-md-8">
            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary btn-sm" OnClick="btnSave_Click" />&nbsp&nbsp
            <asp:HyperLink runat="server" ID="btnCancel" Text="Cancel" CssClass="btn btn-danger btn-sm" NavigateUrl="~/Admin Panel/State/StateList.aspx" />
        </div>
    </div>
</asp:Content>

