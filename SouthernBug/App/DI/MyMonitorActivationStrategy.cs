using System;
using Ninject.Activation;
using Ninject.Activation.Strategies;

namespace SouthernBug.App.DI
{
    public class MyMonitorActivationStrategy : ActivationStrategy
    {
        public override void Activate(IContext context, InstanceReference reference)
        {
            Console.WriteLine("Ninject Activate: " + reference.Instance.GetType());
            base.Activate(context, reference);
        }

        public override void Deactivate(IContext context, InstanceReference reference)
        {
            Console.WriteLine("Ninject DeActivate: " + reference.Instance.GetType());
            base.Deactivate(context, reference);
        }
    }
}