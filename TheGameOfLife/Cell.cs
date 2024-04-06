﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameOfLife
{
    internal class Cell
    {
        private bool _alive {  get; set; }
        private bool _isLeftEdge { get; set; }
        private bool _isRightEdge { get; set; }
        private bool _isCorner {  get; set; }

        public Cell(bool alive, bool isLeftEdge, bool isRightEdge, bool isCorner)
        {
            _alive = alive;
            _isLeftEdge = isLeftEdge;
            _isRightEdge = isRightEdge;
            _isCorner = isCorner;
        }

        public bool Alive
        {
            get { return _alive; }
            set { _alive = value; }
        }

        public bool IsLeftEdge
        { 
            get { return _isLeftEdge; } 
            set { _isLeftEdge = value; } 
        }

        public bool IsRightEdge
        {
            get { return _isRightEdge; }
            set { _isRightEdge = value; }
        }

        public bool IsCorner
        {
            get { return _isCorner; }
            set { _isCorner = value; }
        }
    }
}
