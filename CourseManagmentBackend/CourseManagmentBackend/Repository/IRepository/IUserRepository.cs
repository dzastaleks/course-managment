using CourseManagmentBackend.Models;
using CourseManagmentBackend.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagmentBackend.Repository.IRepository
{
    public interface IUserRepository
    {
        bool isUnique(string username);
        User Authenticate(AuthenticateModel model);
        User Register(User user, string password);

    }
}
