using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Patterns.Observer
{
    public interface IObserver
    {
        void Update(int health);
    }

    public class HealthDisplay : IObserver
    {
        public void Update(int health) => Console.WriteLine($"Health: {health}");
    }

}
