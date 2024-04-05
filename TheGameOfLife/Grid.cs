using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameOfLife
{
    internal class Grid
    {
        private int _width {  get; set; }
        private int _height { get; set; }
        private List<Cell> cells {  get; set; }
    }
}
