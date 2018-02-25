using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP_demo
{
    /// <summary>
    /// Game engine class
    /// </summary>
    class Game
    {
        private const int STEP_DELAY = 1000;

        private const int BOARD_SIZE_X = 10;
        private const int BOARD_SIZE_Y = 10;

        private Board _state;
        private Colony _blueColony;
        private Colony _redColony;
        private List<Unit> _units = new List<Unit>();
        private Visualizer visualizer = new ConsoleVisualizer();

        /// <summary>
        /// Game model initialization
        /// </summary>
        public void InitModel()
        {
            _state = new Board(BOARD_SIZE_X, BOARD_SIZE_Y);
            _blueColony = new Colony("Blue");
            _redColony = new Colony("Red");

            Warrior blue = new Warrior(this, _blueColony);
            blue.SetTargetLocation(BOARD_SIZE_X/2, BOARD_SIZE_Y/2); //go to the central square
            _state.SetObjAt(1, 1, blue);

            Warrior red = new Warrior(this, _redColony);
            red.SetTargetLocation(BOARD_SIZE_X / 2, BOARD_SIZE_Y / 2); //go to the central square
            _state.SetObjAt(BOARD_SIZE_X, BOARD_SIZE_Y, red);

            _units.Add(blue);
            _units.Add(red);
        }

        /// <summary>
        /// Game model main cycle
        /// </summary>
        public void RunModel()
        {
            do
            {
                foreach (Unit unit in _units)
                {
                    if (!unit.IsAlive()) return; //Fight until first death
                    unit.Action(); //make a move
                    visualizer.Draw(_state); //visualize new model state
                    Thread.Sleep(STEP_DELAY); //make slow human being able to see the progress
                }
            } while (true);
        }

        /// <summary>
        /// Moving the object on the board if all conditions are met
        /// </summary>
        /// <param name="obj">Object to move</param>
        /// <param name="x">Target X coordinate</param>
        /// <param name="y">Target Y coordinate</param>
        /// <returns>Success flag</returns>
        public bool TryToMove(GameObject obj, int x, int y)
        {
            bool success = false;
            if (Math.Abs(obj.GetX() - x) <= 1 && Math.Abs(obj.GetY() - y) <= 1 ) //allow moving to next square only
            {
                if (_state.GetObjAt(x, y) == null) //allow moving on empty square only
                {
                    _state.SetObjAt(x, y, obj);
                    success = true;
                }
            }
            return success;
        }

        /// <summary>
        /// Finds nearest enemy on the board
        /// </summary>
        /// <param name="unit">Who looks for enemy</param>
        /// <returns>Enemy object or null if not found</returns>
        public GameObject FindNearestEnemy(Unit unit)
        {
            for (int i = unit.GetX()-1 ; i <= unit.GetX()+1; i++)
            {
                for (int j = unit.GetY()-1; j <= unit.GetY()+1; j++)
                {
                    GameObject candidate = _state.GetObjAt(i, j);
                    if (candidate != null && candidate.GetSide() != unit.GetSide() && candidate.IsAlive())
                    {
                        return candidate;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Dispatches damage dealt to the enemy
        /// </summary>
        /// <param name="attacker">Attacker unit</param>
        /// <param name="enemy">Target unit</param>
        /// <param name="attackDamage">Damage dealt</param>
        public void DealDamage(Unit attacker, GameObject enemy, int attackDamage)
        {
            //for now just skip any additional logic like miss chance, etc.
            enemy.TakeDamage(attackDamage);
        }
    }
}
