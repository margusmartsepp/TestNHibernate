<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <div>
        <h2>Add new team:</h2>
        <form method="get" action="/Teams/CreateNew">
            <label for="Team">Team: </label>
            <input type="text" name="team" />
            <input type="submit" value="Add team" />
        </form>
    </div>
</body>
</html>
