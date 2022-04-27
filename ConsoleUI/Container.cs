using Autofac;
using DemoLibrary.Logic;
using DemoLibrary.Database;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public static class Container
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<App>().As<IApp>();
            builder.RegisterType<PersonHandler>().As<IPersonHandler>();
            builder.RegisterType<SqliteDataAccess>().As<ISqliteDataAccess>();

            return builder.Build();
        }
    }
}
