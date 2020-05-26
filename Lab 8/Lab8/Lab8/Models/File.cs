using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class File
    {
        private int id;
        private string title;
        private string format;
        private string location;
        private string genre;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Location { get => location; set => location = value; }
        public string Format { get => format; set => format = value; }
        public string Genre { get => genre; set => genre = value; }
    }
}