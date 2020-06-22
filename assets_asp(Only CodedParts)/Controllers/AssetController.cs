using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;
using WebAppASP.CommunicateLayer;
using WebAppASP.Models;

namespace WebAppASP.Controllers
{
    public class AssetController : Controller
    {
        // GET: Asset
        public ActionResult Index()
        {
            return View("AssetsView");
        }

        public ActionResult GetAssets()
        {
            Database com = new Database();
            List<Asset> assetList = com.GetAssets();
            return Json(new { assets = assetList }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveAssets()
        {
            
            Database com = new Database();
            List<String> names = JsonConvert.DeserializeObject < List < String >> (Request.Params["names"]);
            List<String> descriptions = JsonConvert.DeserializeObject < List < String >> (Request.Params["descriptions"]);
            List<String> values = JsonConvert.DeserializeObject<List<String>>( Request.Params["values"]);
            String userID =Session["currentUser"].ToString();
            int size = names.Count;
            Debug.WriteLine(names);
            Debug.WriteLine(values);
            for(int i=0;i<size;i++)
            {
                Asset asset = new Asset();
                asset.UserID = Int32.Parse(userID);
                asset.Name =names[i];
                asset.Description = descriptions[i];
                asset.Value = Int32.Parse(values[i]);
                com.AddAsset(asset);

            }
           
            return Json(new { success = true });
        }
    }
}