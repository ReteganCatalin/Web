package Authentication;

import DB.Manager;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class AuthenticationManager {
    public static Integer authenticate(String username, String password) {
        ResultSet rs;
        Integer result = 0;
        Manager.connect();
        Connection con = Manager.getConnection();
        try {
            Statement stmt = con.createStatement();
            rs = stmt.executeQuery("select * from Users where username='" + username + "' and password='" + password + "'");
            if (rs.next()) {
                result=rs.getInt("id");
                //result = "success";
            }
            rs.close();
            Manager.disconnect();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return result;
    }
}
