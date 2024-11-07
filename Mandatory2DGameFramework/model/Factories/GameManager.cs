using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Factories
{
    public class GameManager
    {
        private static GameManager _instance;

        private GameManager() { }

        public static GameManager Instance => _instance ??= new GameManager();
    }

}
