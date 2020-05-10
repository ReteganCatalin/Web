<%@ page import="Model.User" %><%--
  Created by IntelliJ IDEA.
  User: Catalin
  Date: 5/10/2020
  Time: 6:22 PM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Won the game</title>
</head>
<body>
<%
    User user = (User) session.getAttribute("user");
    out.println("Congrats "+ user.getUsername()+ " you won !");
%>
</body>
<form action="LogOutServlet" method="get">
    <input type="submit" value="Logout"/>
</form>
</html>
