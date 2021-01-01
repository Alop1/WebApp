using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Pages.Account
{
    public class User
    {
        public string login { get; set; }
        public string password { get; set; }
    }
    public static class SuperUser
    {
        public static string login = "Joanna";
        public static string password = "kotkidwa";
            
    }
}
