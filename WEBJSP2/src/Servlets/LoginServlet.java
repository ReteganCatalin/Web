package Servlets;

import Authentication.AuthenticationManager;
import DB.Manager;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import java.io.IOException;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;


@WebServlet("/LoginServlet")
public class LoginServlet extends HttpServlet {
    @Override
    protected synchronized void  doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        String username = req.getParameter("username");
        String password = req.getParameter("password");

        Integer authentication = AuthenticationManager.authenticate(username,password);

        if(authentication>=0){

            login(req.getSession(), username, authentication);
            resp.sendRedirect("/assets.jsp");
        }
        else {
            resp.sendRedirect("/index.jsp");
        }
    }


    private void login(HttpSession session, String username, int authenticate) {
        session.setAttribute("user",authenticate);
        return ;

    }
}
