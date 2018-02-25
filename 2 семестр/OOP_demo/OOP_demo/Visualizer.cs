using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_demo
{
    /// <summary>
    /// Abstract class for model visualizer
    /// </summary>
    abstract class Visualizer
    {
        /// <summary>
        /// Board state visualization method
        /// </summary>
        /// <param name="board"></param>
        public abstract void Draw(Board board);
    }
}
