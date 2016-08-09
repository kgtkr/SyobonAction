using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyobonAction
{
    public abstract class Scene
    {
        /// <summary>
        /// nullならまだこのシーンは必要
        /// </summary>
        public Scene NextScene
        {
            get;
            protected set;
        }

        public abstract void Update();
        public abstract void Draw();
    }
}
