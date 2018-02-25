using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_demo
{
    /// <summary>
    /// Game board model class
    /// </summary>
    class Board
    {
        private int _sizeX, _sizeY;

        private Square[,] _squares;

        public Board(int sizeX, int sizeY)
        {
            _squares = new Square[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j <
                    sizeY; j++)
                {
                    _squares[i,j] = new Square(i+1, j+1);
                }
            }
            _sizeX = sizeX;
            _sizeY = sizeY;
        }

        public int GetMaxX()
        {
            return _sizeX;
        }

        public int GetMaxY()
        {
            return _sizeY;
        }

        public GameObject GetObjAt(int x, int y)
        {
            if(x>=1 && x<=_sizeX && y >= 1 && y<=_sizeY)
                return _squares[x-1, y-1].GetObject();

            return null;
        }

        internal void SetObjAt(int x, int y, GameObject obj)
        {
            if (x >= 1 && x <= _sizeX && y >= 1 && y <= _sizeY)
            {
                if (obj.GetX() >= 1 && obj.GetX() <= _sizeX && obj.GetY() >= 1 && obj.GetY() <= _sizeY)
                {
                    _squares[obj.GetX() - 1, obj.GetY() - 1].RemoveObject(); //remove from old square
                    _squares[x - 1, y - 1].SetObject(obj); //put to new square
                }
            }
        }

    }
}
