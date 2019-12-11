using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyNewBlog.Models
{
    //自定义校验
    public class UserValidation : ValidationAttribute
    {
        private NewsInformationEntities db = new NewsInformationEntities();
        public UserValidation()
        {
            this.ErrorMessage = "用户账号已存在";
        }
        public override bool IsValid(object value)
        {
            if (value is string)
            {
                string s = (string)value;
                var temp = from u in db.Admin
                           where u.adminName == s
                           select u;
                if (temp.Count() > 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}