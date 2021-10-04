using Mark2.Models;
using Mark2.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mark2.Services.Business
{
    public class SecurityService
    {
        SecurityDAO daoService = new SecurityDAO();
        
        public bool Authenticate(UserModel user)
        {
            return daoService.FindByUser(user);
        }
        public bool Signup(UserModel user)
        {
            return daoService.Signup(user);
        }
    }
}