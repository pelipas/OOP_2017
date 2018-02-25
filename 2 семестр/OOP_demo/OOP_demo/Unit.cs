using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP_demo
{
    class Unit : GameObject
    {
        private int _targetX, _targetY;
        protected int AttackPower;
        protected int AttackDispersion;

        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="game">The instance of current game engine</param>
        /// <param name="side">The instance of the Colony Unit belongs to</param>
        public Unit(Game game, Colony side) : base(game, side)
        {
        }

        /// <summary>
        /// Sets movement target location
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">X coordinate</param>
        public void SetTargetLocation(int x, int y)
        {
            _targetX = x;
            _targetY = y;
        }

        /// <summary>
        /// Tries to move unit to X, Y
        /// </summary>
        /// <param name="x">target X coordinate</param>
        /// <param name="y">target Y coordinate</param>
        /// <returns>Success flag</returns>
        public bool Move(int x, int y)
        {
            return _game.TryToMove(this, x, y);
        }

        /// <summary>
        /// Makes a move at his turn
        /// Dafault behavior is just moving towards a target
        /// Needs to be overriden in derived classes
        /// </summary>
        public virtual void Action()
        {
            MoveToTargetLocation();
        }

        /// <summary>
        /// Simple linear movement algorithm
        /// May be overriden in derived classes
        /// </summary>
        protected virtual void MoveToTargetLocation()
        {
            int newX = (_targetX == _x) ? _x : (_targetX < _x) ? _x - 1 : _x + 1;
            int newY = (_targetY == _y) ? _y : (_targetY < _y) ? _y - 1 : _y + 1;
            Move(newX, newY);
        }

        /// <summary>
        /// Calculate damage done to the target and send it to the game engine
        /// May be overriden in derived classes
        /// </summary>
        /// <param name="enemy"></param>
        protected virtual void Attack(GameObject enemy)
        {
            //skip any additional checks for now
            Random rnd = new Random((int)DateTime.Now.Ticks);
            int attackDamage = AttackPower + AttackDispersion*rnd.Next(-100, 100)/100;
            _game.DealDamage(this, enemy, attackDamage);
        }

        /// <summary>
        /// Finds nearest enemy using the game engone
        /// </summary>
        /// <returns></returns>
        protected GameObject FindEnemy()
        {
            return _game.FindNearestEnemy(this);
        }

    }
}
