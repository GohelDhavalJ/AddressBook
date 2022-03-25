<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="ContactCategoryList.aspx.cs" Inherits="Admin_Panel_ContactCategory_ContactCategoryListaspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2 class="MainHeading">Contact Category List</h2>
        </div>

        <div class="row">
            <div class="col-md-12">
                <asp:Label runat="server" ID="lblDisplay" EnableViewState="False"></asp:Label>
            </div>
        </div>
        <br />
    </div>
    <div class="row">
        <div class="col-md-12">
             <div class="col-md-12">
                    <asp:HyperLink runat="server" ID="hlAddContactCategory" Text="Add New Contact Category" NavigateUrl="~/Admin Panel/ContactCategory/ContactCategoryAddEdit.aspx" CssClass="btn btn-info"></asp:HyperLink>
                </div>
            <br />
            <br />
            <br />
            <asp:GridView ID="gvContactCategory" runat="server" CssClass="table table-hover table-responsive table-bordered table-hover"  AutoGenerateColumns="false" OnRowCommand="gvConatctCategory_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactCategoryID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="btnEdit" Text="Edit" CssClass="btn btn-primary" NavigateUrl='<%# "~/Admin Panel/ContactCategory/ContactCategoryAddEdit.aspx?ContactCategoryID=" + Eval("ContactCategoryID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="ContactCategoryName" HeaderText="Name" />
                </Columns>
            </asp:GridView>
        </div>      
    </div>
</asp:Content>

