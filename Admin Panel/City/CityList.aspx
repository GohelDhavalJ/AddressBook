<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="Admin_Panel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2 class="MainHeading">City List</h2>
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
                 <asp:HyperLink runat="server" ID="hlAdd" Text="Add New City" CssClass="btn btn-info" NavigateUrl="~/Admin Panel/City/CityAddEdit.aspx"></asp:HyperLink>
            </div>
            <br />
            <br />
            <br />
            <asp:GridView ID="gvCity" runat="server" CssClass="table table-hover table-responsive table-bordered table-hover"   AutoGenerateColumns="false" OnRowCommand="gvCity_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("CityID").ToString() %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-primary" NavigateUrl='<%# "~/Admin Panel/City/CityAddEdit.aspx?CityID=" + Eval("CityID").ToString()%>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="StateName" HeaderText="State" />
                    <asp:BoundField DataField="CityName" HeaderText="City" />
                    <asp:BoundField DataField="STDCode" HeaderText="STDCode" />
                    <asp:BoundField DataField="PinCode" HeaderText="PinCode" />
                </Columns>
            </asp:GridView>
        </div>      
    </div>
</asp:Content>

