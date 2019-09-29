using System;
using System.Threading;
using Ninject;
using Ninject.Activation.Strategies;
using Ninject.Syntax;
using SouthernBug.App.Repository;

namespace SouthernBug.App.DI
{
    internal static class KernelTools
    {
        private static IKernel kernel;

        public static IKernel CreateKernel()
        {
            kernel = new StandardKernel();

            kernel.Components.Add<IActivationStrategy, MyMonitorActivationStrategy>();

            MakeSingleton<TableRepository>();

            MakeSingleton<Context>()
                .WithConstructorArgument(kernel);

            MakeSingleton<AllTablesServer>();

            return kernel;
        }

        public static void PreloadLibsInBackground(IKernel kernel)
        {
            ThreadPool.QueueUserWorkItem(state => { GC.KeepAlive(kernel.Get<TableRepository>()); });
        }

        public static IBindingNamedWithOrOnSyntax<T> MakeSingleton<T>()
        {
            return kernel
                .Bind<T>()
                .ToSelf()
                .InSingletonScope();
        }
    }
}