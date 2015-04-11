using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap.Graph;
using StructureMap.Web;
using Kiarah.LittleXavier.Data;
using System.Data.Entity;
using Kiarah.LittleXavier.Core.Interfaces;
using Kiarah.LittleXavier.Infrastructure.Data;
using AutoClutch.Auto.Service.Interfaces;
using AutoClutch.Auto.Repo.Interfaces;
using AutoClutch.Auto.Service.Services;
using AutoClutch.Auto.Repo.Objects;

namespace Kiarah.LittleXavier.CompositionRoot
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.AssembliesFromApplicationBaseDirectory();
                    scan.WithDefaultConventions();
                });

            For<DbContext>().HybridHttpOrThreadLocalScoped().Use<AuthContext>().Named("KiarahLittleXavierAuth");

            For<DbContext>().HybridHttpOrThreadLocalScoped().Use<littleXavierDbContext>();

            For<IAuthRepository>().Use<AuthRepository>();

            For(typeof(IService<>)).Use(typeof(Service<>));

            For(typeof(IRepository<>)).Use(typeof(Repository<>));

            //For(typeof(IRepository<StuffFinder.Core.Models.AspNetUser>)).Use(typeof(Repository<AspNetUser>)).Ctor<DbContext>("context").IsNamedInstance("stuffFinderAuth");

            //For<IEmailSender>().Use<EmailSender>();

            //For<ISystemSettingsGetter>().Use<SystemSettingsGetter>();
        }
    }
}
