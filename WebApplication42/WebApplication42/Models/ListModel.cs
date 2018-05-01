using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication42.Models
{
    public class ListModel<T>
    {
        public int id { get; set; }

        public List<T> Items { get; set; }

        public ListModel(List<T> list)
        {
            Items = list;
        }
    }
}