package Servlets;

import Asset.Assets;
import Authentication.AuthenticationManager;
import DB.Manager;
import com.mysql.cj.xdevapi.JsonArray;
import netscape.javascript.JSObject;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import javax.jms.Session;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import java.io.IOException;
import java.io.PrintWriter;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;


@WebServlet("/AssetsServlet")
public class AssetsServlet extends HttpServlet {
    protected synchronized void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        int userID=(Integer) req.getSession().getAttribute("user");
        if(userID==0)
        {
            resp.sendRedirect("login.jsp");
        }
        List<Assets> assets=new ArrayList<>();
        String sql="SELECT * FROM assets where assets.userID='"+userID+"'";
        try {
            PreparedStatement stmt = Manager.getConnection().prepareStatement(sql);
            ResultSet result = stmt.executeQuery();
            while (result.next()) {
                int id = result.getInt("id");
                int user_id = result.getInt("userID");
                String name = result.getString("name");
                String description = result.getString("description");
                int value = result.getInt("value");
                Assets asset =new  Assets(id,user_id,name,description,value);
                assets.add(asset);

            }
            try {
                JSONArray array = AssetsConstruction(assets);
                resp.setContentType("application/json");
                PrintWriter out = new PrintWriter(resp.getOutputStream());
                System.out.println(array.toString());
                out.println(array.toString());
                out.flush();
            }
            catch (JSONException throwables) {
                throwables.printStackTrace();
                resp.sendRedirect("/index.jsp");
            }



        } catch (SQLException throwables) {
            throwables.printStackTrace();
            resp.sendRedirect("/index.jsp");
        }

    }

    private JSONArray AssetsConstruction(List<Assets> assets) throws JSONException {
        JSONArray jsonArray = new JSONArray();
        for (Assets asset: assets) {
            JSONObject jsonObject = new JSONObject();
            jsonObject.put("id", asset.getId());
            jsonObject.put("userID", asset.getUser_id());
            jsonObject.put("name",asset.getName());
            jsonObject.put("description", asset.getDescription());
            jsonObject.put("value", asset.getValue());
            jsonArray.put(jsonObject);
        }
        return jsonArray;
    }

    protected synchronized void  doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        List<String> names = Arrays.asList( req.getParameter("names").split(","));
        List<String> descriptions = Arrays.asList(req.getParameter("descriptions").split(","));
        List<String> values = Arrays.asList(req.getParameter("values").split(","));
        Integer userID = Integer.parseInt(req.getSession().getAttribute("user").toString());
        for(int i=0;i<names.size();i++) {
           String name=names.get(i);
           String description= descriptions.get(i);
           String value=values.get(i);

           String sql = "INSERT INTO Assets(userID,name,description,value) values ('" + userID + "','"+name+"','"+description+"',"+value+")";
           System.out.println(sql);
           try {
                PreparedStatement stmt = Manager.getConnection().prepareStatement(sql);
                stmt.execute();

            } catch (SQLException throwables) {
               throwables.printStackTrace();
           }
        }
    }






}
