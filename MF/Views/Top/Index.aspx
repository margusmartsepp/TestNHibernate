<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MF.Models.Entities.Standing>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table>
        <tr>
            <th>
                Team
            </th>
            <th>
                W
            </th>
            <th>
                T
            </th>
            <th>
                L
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: item.TeamName %>
            </td>
            <td>
                <%: item.TeamW %>
            </td>
            <td>
                <%: item.TeamT %>
            </td>
            <td>
                <%: item.TeamL %>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
