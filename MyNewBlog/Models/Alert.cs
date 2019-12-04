using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyNewBlog.Models
{
    public class Alert
    {
        public AlertType Type { get; set; }
        public string Message { get; set; }
    }
}