<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="Admin_Panel_Country_CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
  
    <div class="row">
        <div class="col-md-12">
            <h2 class="MainHeading">Country Add Edit Page</h2>
        </div>
   </div>
    <br />
    <div class="row">
        <div class="col-md-12" id="divMessage" runat="server" visible="false">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="False" ForeColor="Green"></asp:Label>
        </div>
   </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            *Country Name:
        </div>
        <div class="col-md-4">
            <asp:TextBox runat="server" ID="txtCountryName" CssClass="form-control" />
        </div>
        <div class="col-md-4">
             <asp:RequiredFieldValidator ID="rfvCountryName" runat="server" ErrorMessage="Enter CountryName" ControlToValidate="txtCountryName" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            Country Code:
        </div>
        <div class="col-md-4">
            <asp:TextBox runat="server" ID="txtCountryCode" CssClass="form-control" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">

        </div>
        <div class="col-md-8">
            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary btn-sm" OnClick="btnSave_Click" />
            <asp:HyperLink runat="server" ID="btnCancel" Text="Cancel" CssClass="btn btn-danger btn-sm" NavigateUrl="~/Admin Panel/Country/CountryList.aspx" />
        </div>
    </div>
 
</asp:Content>

