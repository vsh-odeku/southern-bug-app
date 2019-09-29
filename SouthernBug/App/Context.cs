using Ninject;

namespace SouthernBug.App
{
    public class Context
    {
        public Context(IKernel kernel)
        {
            Kernel = kernel;
        }

        public IKernel Kernel { get; }
    }
}