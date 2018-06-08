using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.DbContextScope;
using Model.Auth;
using Persistence.Repository;
using Common;

namespace Service.Services.Implements
{
    public class UserService : IUserService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<ApplicationUser> _applicationUserRepo;

        public UserService(IDbContextScopeFactory dbContextScopeFactory, 
            IRepository<ApplicationUser> applicationUserRepo)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _applicationUserRepo = applicationUserRepo;
        }

        public ResponseHelper Update(ApplicationUser user)
        {
            var rh = new ResponseHelper();
            try
            {
                // Create(insertar y modificar datos)
                // CreateReadOnly(solo consultas)
                using(var context = _dbContextScopeFactory.Create())
                {
                    var originalUser = _applicationUserRepo.Single(
                            xx => xx.Id == user.Id
                        );
                    originalUser.Name = user.Name;
                    originalUser.LastName = user.LastName;
                    originalUser.Email = user.Email;

                    _applicationUserRepo.Update(originalUser);
                    context.SaveChanges();
                    rh.SetResponse(true);
                }
            }catch(Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, e.Message);
            }
            return rh;
        }
    }
}
