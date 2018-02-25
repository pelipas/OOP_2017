using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_demo
{
    /// <summary>
    /// Base class for all game world objects
    /// Represents destructible entity with some HP and Defence (damage absorption)
    /// The entity is positioned in some square of the game board and may be either alive or destroyed 
    /// </summary>
    class GameObject
    {
        protected Game _game;
        protected int _x, _y;
        protected Colony _side;
        protected int Hp;
        protected int Def;
        private bool _alive;

        public GameObject(Game game, Colony side)
        {
            _game = game;
            _side = side;
            _alive = true;
            _x = 1;
            _y = 1;
        }

        public bool IsAlive()
        {
            return _alive;
        }

        public int GetX()
        {
            return _x;
        }

        public int GetY()
        {
            return _x;
        }

        public void SetCoords(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public Colony GetSide()
        {
            return _side;
        }

        public int GetHp()
        {
            return Hp;
        }

        /// <summary>
        /// Damage and death calculation algorithm
        /// </summary>
        /// <param name="dmg">Damage dealt</param>
        public void TakeDamage(int dmg)
        {
            if (!_alive) return; //There's no sence in kicking dead horse :) 

            int resultDmg = dmg - Def; //Absorb Def units of damage 

            if (resultDmg > 0) //Avoid healing via Def :)
                Hp -= resultDmg;

            if (Hp <= 0) //Zed's dead, baby, Zed's dead...
                _alive = false;
        }

    }
}
