<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="Admin_Panel_State_State" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2 class="MainHeading">State List</h2>
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
                    <asp:HyperLink runat="server" ID="hlAddState" Text="Add New State" NavigateUrl="~/Admin Panel/State/StateAddEdit.aspx" CssClass="btn btn-info"></asp:HyperLink>
                </div>
            <br />
            <br />
            <br />
            <asp:GridView ID="gvState" runat="server" CssClass="table table-hover table-responsive table-bordered table-hover"   AutoGenerateColumns="false" OnRowCommand="gvState_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("StateID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="btnEdit" Text="Edit" CssClass="btn btn-primary" NavigateUrl='<%# "~/Admin Panel/State/StateAddEdit.aspx?StateID=" + Eval("StateID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CountryName" HeaderText="Country"/>
                    <asp:BoundField DataField="StateName" HeaderText="State"/>
                    <asp:BoundField DataField="StateCode" HeaderText="StateCode"/>
                </Columns>
            </asp:GridView>
        </div>
        
    </div>
</asp:Content>

