using System.Data.Entity;
using System.Web;
using BrentUniversity_Azure.Data;
using BrentUniversity_Azure.Models;
using BrentUniversity_Azure.Repository;
using BrentUniversity_Azure.Repository.Base;
using BrentUniversity_Azure.Service;
using BrentUniversity_Azure.Service.Base;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using StructureMap.Web;

namespace BrentUniversity_Azure.DependencyResolution {
    
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;

    public class DefaultRegistry : Registry
    {
        #region Constructors and Destructors

        public DefaultRegistry()
        {
            Scan(
                scan =>
                {
                    scan.LookForRegistries();
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.With(new ControllerConvention());
                });

            For<IUnitOfWork>().HybridHttpOrThreadLocalScoped().Use<UnitOfWork>();
            For<IDbContext>().HybridHttpOrThreadLocalScoped().Use<UniversityContext>();
            For<IStudentService>().HybridHttpOrThreadLocalScoped().Use<StudentService>();
            For<DbContext>().HybridHttpOrThreadLocalScoped().Use(() => new ApplicationDbContext());
            For<IAuthenticationManager>().Use(o => HttpContext.Current.GetOwinContext().Authentication);
            For(typeof(IGenericRepository<>)).HybridHttpOrThreadLocalScoped().Use(typeof(GenericRepository<>));
            For<IUserStore<ApplicationUser>>().HybridHttpOrThreadLocalScoped().Use<UserStore<ApplicationUser>>();
        }
        #endregion
    }
}