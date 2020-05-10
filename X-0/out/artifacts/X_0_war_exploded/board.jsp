<%@ page import="Model.User" %><%--
  Created by IntelliJ IDEA.
  User: Catalin
  Date: 5/10/2020
  Time: 5:04 PM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>X-0 room</title>
</head>
<body>
<%
    String board = (String) session.getAttribute("Board");
    User user = (User) session.getAttribute("user");
    int activePlayer = (Integer) session.getAttribute("activePlayer");
    out.println("<table>");
    for(int i=0;i<3;i++) {
        out.println("<tr>");
        for (int j = 0; j < 3; j++) {
            out.println("<td>");
            out.println(board.charAt(i * 3 + j));
            out.println("</td>");
        }
        out.println("</tr>");
    }
    out.println("</table>");
    out.println("<br>");
    if( activePlayer == user.getPlayerNo())
    {
        out.println("Your turn");
    }
    else
    {
        out.println("Your opponent turn(Try refreshing until it is your turn)");
    }
%>

<form action="MoveServlet" method="post">
    Enter column(1-3) : <input type="text" name="column"> <BR>
    Enter row(1-3) : <input type="text" name="row"> <BR>
    <input type="submit" value="Try Move/Refresh"/>
</form>
</body>
</html>
