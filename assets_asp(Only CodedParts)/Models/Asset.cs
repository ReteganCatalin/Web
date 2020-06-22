using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppASP.Models
{
    public class Asset
    {
        private int id;
        private int userID;
        private string description;
        private int value;
        private string name;

        public Asset(int id, int userID, string description, int value, string name)
        {
            this.Id = id;
            this.UserID = userID;
            this.Description = description;
            this.Value = value;
            this.Name = name;
        }
        
        public Asset()
        {

        }

        public int Id { get => id; set => id = value; }
        public int UserID { get => userID; set => userID = value; }
        public string Description { get => description; set => description = value; }
        public int Value { get => value; set => this.value = value; }
        public string Name { get => name; set => name = value; }
    }
}