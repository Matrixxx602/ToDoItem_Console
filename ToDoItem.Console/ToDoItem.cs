using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ToDoItem_Console
{
    public class ToDoItem
    {
        public string Task { get; set; }
        public bool IsCompleted { get; set; }

        public ToDoItem(string task)
        {
            Task = task;
            IsCompleted = false;
        }
    }
}
