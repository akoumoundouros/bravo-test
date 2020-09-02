using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Svc
{
    public interface IDependencyService
    {
        int GetRand();
    }

    public class DependencyService : IDependencyService
    {
        /// <summary>
        /// Returns a random integer between 0 and 100
        /// </summary>
        /// <returns></returns>
        public int GetRand()
        {
            return new Random().Next(0,100);
        }
    }
}
