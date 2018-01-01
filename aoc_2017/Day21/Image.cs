using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day21
{
    // this is the container for the fractal image
    class Image
    {
        // start with storing as one string per row. that should make it very flexible and easier to maintain size.

        private List<List<Grid>> Grids { get; set; }
        private int NumGrids => Grids[0].Count; // number of grids across/down
        private int GridSize => Grids[0][0].Dimension; // number of rows/cols in each grid

        public int Pixels { get { return Grids.Sum(gridRow => gridRow.Sum(grid => grid.Pixels)); } }

        #region ctors
        private const string StarterSet = ".#./..#/###";
        //private const string StarterSet = "#..#/..../..../#..#";
        public static Image StartingImage => new Image(StarterSet);

        protected Image()
        {
            Grids = new List<List<Grid>>();
        }
        protected Image(string starterSet) : this()
        {
            Grids.Add(new List<Grid> { new Grid(starterSet) });
        }
        #endregion ctors

        // I started so quickly with StartingImage that I found my rules being added in the Expand method. If I were to make this more professional I would change it to be in the ctor or similar.
        internal void Expand(List<Rule> rules)
        {
            // convert grids in each row to a string
            var rows = GetRows();

            // break up into new "expanded" grids
            Grids.Clear();
            var gridSize = rows.Count % 2 == 0 ? 2 : 3;
            try
            {
                for (var rowIdx = 0; rowIdx < rows.Count / gridSize; rowIdx++)
                    Grids.Add(Grid.FromStrings(rows, rowIdx, gridSize).Select(g => g.Expand(rules)).ToList());

            }
            catch (Exception)
            {
                // TODO: move out of exception handler
                if (gridSize == 2 && rows.Count % 3 == 0)
                {
                    gridSize = 3;
                    Grids.Clear();
                    for (var rowIdx = 0; rowIdx < rows.Count / gridSize; rowIdx++)
                        Grids.Add(Grid.FromStrings(rows, rowIdx, gridSize).Select(g => g.Expand(rules)).ToList());
                }
                //throw;
            }
        }

        private List<string> GetRows()
        {
            // TODO: clean this up later...
            var numRows = NumGrids * GridSize;
            var rows = new List<string>(numRows);
            for (var gridRowIdx = 0; gridRowIdx < NumGrids; gridRowIdx++)
            {
                var tempRows = new string[GridSize]; // allocate for number of real rows per grid row
                for (var i = 0; i < GridSize; i++)
                    tempRows[i] = "";

                for (var gridColIdx = 0; gridColIdx < NumGrids; gridColIdx++)
                {
                    var splits = Grids[gridRowIdx][gridColIdx].ToString().Split('/');
                    for (var j = 0; j < GridSize; j++)
                    {
                        tempRows[j] = tempRows[j] + splits[j];
                    }
                }

                rows.AddRange(tempRows);
            }
            return rows;
        }
    }
}
