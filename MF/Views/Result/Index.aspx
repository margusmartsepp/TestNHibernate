<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MF.Models.Entities.Result>>" %>
<%@ Import Namespace="MF.Models.Entities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <table>
        <tr>
            <th>
                Team 1
            </th>
            <th>
               
            </th>
            <th>
                vs
            </th>
             <th>
               
            </th>
            <th>
                Team 2
            </th>
            <th>Actions</th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: (item.ResultFirst == null ? "null" : Team.GetTeamById(item.ResultFirst.TeamId).TeamName)%>
            </td>
            <td>
                <%: item.ResultFirstScore %>
            </td>
            <td>
               :
            </td>
            <td>
                <%: item.ResultSecondScore %>
            </td>
            <td>
                <%: (item.ResultSecond == null ? "null" : Team.GetTeamById(item.ResultSecond.TeamId).TeamName)%>
            </td>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new {  id=item.ResultId  }) %> |
                <%: Html.ActionLink("Delete", "Delete", new { id = item.ResultId })%>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

