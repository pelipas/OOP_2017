using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_demo
{
    /// <summary>
    /// Damage dealing unit
    /// </summary>
    class Warrior : Unit
    {
        /// <summary>
        /// Overriden to implement Warrior specific behavior
        /// </summary>
        public override void Action()
        {
            GameObject enemy = FindEnemy();
            if (enemy != null) //if enemy found nearby act like a warrior
            {

                Attack(enemy);
            }
            else //otherwise just like an ordinary unit
            {
                base.Action();
            }
        }

        /// <summary>
        /// Tune basic parameters in the constructor code
        /// </summary>
        /// <param name="game"></param>
        /// <param name="side"></param>
        public Warrior(Game game, Colony side) : base(game, side)
        {
            this.AttackPower = 100;
            this.AttackDispersion = 10;
            this.Def = 50;
            this.Hp = 200;
        }
    }
}
