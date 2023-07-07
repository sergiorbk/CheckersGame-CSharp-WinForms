using System.ComponentModel;
using System.Drawing;

namespace Checkers
{
    public class Map
    {
        public Map(int size)
        {
            this.size = size;
            this.map = new int[size, size];
            fill_map();
        }
        
        public int get_size()
        {
            return size;
        }

        private void fill_map()
        {
            int[,] map = {
                { 0,1,0,1,0,1,0,1 },
                { 1,0,1,0,1,0,1,0 },
                { 0,1,0,1,0,1,0,1 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 2,0,2,0,2,0,2,0 },
                { 0,2,0,2,0,2,0,2 },
                { 2,0,2,0,2,0,2,0 }
            };
            this.map = map;
        }
        
        private int size;
        private int[,] map;
    }
}