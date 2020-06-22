<%--
  Created by IntelliJ IDEA.
  User: Catalin
  Date: 6/22/2020
  Time: 1:45 PM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<!DOCTYPE html>

<html>
<head>
    <meta charset="UTF-8">
    <title>Login</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <style>
        form {
            margin-left: auto;
            margin-right: auto;
            width: 400px;
        }
        input {
            border-radius: 5px;
        }
    </style>
</head>
<body>
<form action="LoginServlet" method="post">
    Enter username : <input type="text" name="username"> <BR>
    Enter password : <input type="password" name="password"> <BR>
    <input type="submit" value="Login"/>
</form>

</body></html>
