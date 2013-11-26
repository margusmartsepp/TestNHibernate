<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(document).ready(function () {
                $('#example').dataTable({
                    "bProcessing": true,
                    "sAjaxSource": '/Top/GetStandings/'
                });
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" id="example">
        <thead>
            <tr>
                <th>
                    Team
                </th>
                <th>
                    W
                </th>
                <th>
                    D
                </th>
                <th>
                    L
                </th>
                <th>
                    F
                </th>
                <th>
                    A
                </th>
            </tr>
        </thead>
        <tbody>
        </tbody>
        <tfoot>
        </tfoot>
    </table>
    <br/>
    <p><strong>Keys</strong> - <strong>W</strong>: Wins, <strong>D</strong>: Draws,<strong> L</strong>: Losses, <strong>F</strong>: Goals Scored, <strong>A</strong>: Goals Against</p>
    </asp:Content>
