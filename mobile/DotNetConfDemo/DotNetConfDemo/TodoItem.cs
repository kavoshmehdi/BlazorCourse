using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetConfDemo
{
    public class TodoItem
    {
        [AutoIncrement]
        [PrimaryKey]
        public int ID { get; set; }
        public Boolean IsDone { get; set; }
        public string Text { get; set; }
        public string Notes { get; set; }
    }
}
