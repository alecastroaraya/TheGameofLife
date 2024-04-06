using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameOfLife
{
    internal class Cell
    {
        public bool _alive {  get; set; }
        public bool _isLeftEdge { get; set; }
        public bool _isRightEdge { get; set; }
        public bool _isCorner {  get; set; }

        public Cell(bool alive, bool isLeftEdge, bool isRightEdge, bool isCorner)
        {
            _alive = alive;
            _isLeftEdge = isLeftEdge;
            _isRightEdge = isRightEdge;
            _isCorner = isCorner;
        }
    }
}
