using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_demo
{
    /// <summary>
    /// Just a sample class for model visualization using console output
    /// </summary>
    class ConsoleVisualizer : Visualizer
    {
        public override void Draw(Board board)
        {
            const int RED_STAT_POS = 1;
            const int BLUE_STAT_POS = 2;
            const int BOARD_OFFSET = 3;
            

            int statCursorPos = 1;

            Console.Clear();
            for (int i = 1; i <= board.GetMaxX(); i++)
            {
                for (int j = 1; j <= board.GetMaxY(); j++)
                {
                    Console.CursorLeft = i;
                    Console.CursorTop = j + BOARD_OFFSET;
                    GameObject obj = board.GetObjAt(i, j);
                    if (obj == null) Console.Write('O');
                    if (obj != null && !obj.IsAlive()) Console.Write('x');
                    if (obj != null && obj.IsAlive() && obj is Unit)
                    {
                        if (obj.GetSide().GetName().ToUpper() == "BLUE")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            statCursorPos = BLUE_STAT_POS;
                        }
                        if (obj.GetSide().GetName().ToUpper() == "RED")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            statCursorPos = RED_STAT_POS;
                        }
                        Console.Write('W');
                        Console.CursorLeft = 1;
                        Console.CursorTop = statCursorPos;
                        Console.Write("X= {0}, Y={1}, HP = {2}, side = {3}", obj.GetX(), obj.GetY(), obj.GetHp(), obj.GetSide().GetName());
                        Console.ResetColor();
                    }
                }
            }
        }
    }
}
