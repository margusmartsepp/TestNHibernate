﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MF.Models.Entities.Result>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Edit</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Fields</legend>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.ResultFirst)%>
        </div>
        <div class="editor-field">
            <%: Html.DropDownListFor(model => model.ResultFirst.TeamName,
                new SelectList(MF.Models.Entities.Team.GetAllTeams(), "TeamId", "TeamName"),
                new { id = "ResultFirst.TeamId" })%>
            <%: Html.ValidationMessageFor(model => model.ResultFirst)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.ResultFirstScore) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.ResultFirstScore) %>
            <%: Html.ValidationMessageFor(model => model.ResultFirstScore) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.ResultSecond)%>
        </div>
        <div class="editor-field">
            <%: Html.DropDownListFor(model => model.ResultSecond.TeamName,
                new SelectList(MF.Models.Entities.Team.GetAllTeams(), "TeamId", "TeamName"))%>
            <%: Html.ValidationMessageFor(model => model.ResultSecond)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.ResultSecondScore) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.ResultSecondScore) %>
            <%: Html.ValidationMessageFor(model => model.ResultSecondScore) %>
        </div>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
