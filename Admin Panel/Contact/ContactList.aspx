<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="Admin_Panel_Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2 class="MainHeading">Contact List</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblDisplay" EnableViewState="False"></asp:Label>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">
            <div class="col-md-12">
                    <asp:HyperLink runat="server" ID="hlAddContact" Text="Add New Contact" NavigateUrl="~/Admin Panel/Contact/ContactAddEdit.aspx" CssClass="btn btn-info"></asp:HyperLink>
                </div>
             <br />
            <br />
            <br />
            <asp:GridView ID="gvContact" runat="server" CssClass="table table-hover table-responsive table-bordered table-hover" AutoGenerateColumns="false" OnRowCommand="gvContact_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnContact" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="btnEdit" Text="Edit" CssClass="btn btn-primary" NavigateUrl='<%# "~/Admin Panel/Contact/ContactAddEdit.aspx?ContactID=" + Eval("ContactID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
    
                    <asp:BoundField DataField="CountryName" HeaderText="Country"/>
                    <asp:BoundField DataField="StateName" HeaderText="State"/>
                    <asp:BoundField DataField="CityName" HeaderText="City"/>
                    <asp:BoundField DataField="ContactCategoryName" HeaderText="Contact Category"/>
                    <asp:BoundField DataField="ContactName" HeaderText="Contact Name"/>
                    <asp:BoundField DataField="ContactNo" HeaderText="Contact No"/>
                    <asp:BoundField DataField="Email" HeaderText="Email"/>
                    <asp:BoundField DataField="Age" HeaderText="Age"/>
                    <asp:BoundField DataField="Address" HeaderText="Address"/>
                </Columns>
            </asp:GridView>
        </div>      
    </div>
</asp:Content>

