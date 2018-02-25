using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_demo
{
    /// <summary>
    /// Game board square class
    /// </summary>
    class Square
    {
        private int _x, _y;
        private GameObject _obj;

        public Square(int x, int y)
        {
            _x = x;
            _y = y;
            _obj = null;
        }

        public GameObject GetObject()
        {
            return _obj;
        }

        public void SetObject(GameObject obj)
        {
            _obj = obj;
            obj.SetCoords(_x, _y);
        }

        public void RemoveObject()
        {
            _obj = null;
        }
    }
}
