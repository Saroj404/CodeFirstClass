using CodeFirstClass.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstClass.Services
{
    public class UserService
    {
        public static CodeFirstClass.Models.CodeFirst db = new Models.CodeFirst();
        public static (bool,string) Login(UserLoginViewModel viewModel)
        {
            var existingUser = db.Users.FirstOrDefault(p => p.Username == viewModel.Username);
            if(existingUser==null)
            {
                return (false, "User not found");
            }
            if(existingUser.Password==viewModel.Password)
            {
                return (true, "All good");
            }
            else
            {
                return (false, "Password doesn't match");
            }
        }
        public static(bool,string)ChangePassword(UserViewModel viewModel)
        {
            var existingUser = db.Users.FirstOrDefault(p => p.Username == viewModel.Username);
            if (existingUser == null)
            {
                return (false, "Username not found");
            }  
            if(viewModel.Password!=viewModel.ConfirmPassword)
            {
                return (false, "Password doesn't match");
            }
            else
            {
                existingUser.Password = viewModel.Password;
                db.Entry(existingUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return(false, "Password changed successfully.");
            }
        }
    }
}
