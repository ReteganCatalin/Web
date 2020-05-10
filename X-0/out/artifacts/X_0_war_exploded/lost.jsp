<%@ page import="Model.User" %><%--
  Created by IntelliJ IDEA.
  User: Catalin
  Date: 5/10/2020
  Time: 6:24 PM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Lost</title>
</head>
<body>
<%
    User user = (User) session.getAttribute("user");
    out.println("Maybe next time "+ user.getUsername()+ " !");
%>
</body>
<form action="LogOutServlet" method="get">
    <input type="submit" value="Logout"/>
</form>
</body>
</html>
