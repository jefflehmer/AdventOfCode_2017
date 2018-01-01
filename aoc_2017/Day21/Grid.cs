using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day21
{
    class Grid
    {
        private char[,] Elements;
        public int Dimension => (int)Math.Sqrt(Elements.Length); // we know we are always a perfect square

        public int Pixels { get { return this.ToString().Sum(character => (character == '#') ? 1 : 0); } }

        protected Grid() { }
        protected Grid(char[,] elements) { Elements = elements; }
        public Grid(string set)
        {
            var rows = set.Split('/');
            Elements = new char[rows.Length, rows.Length];
            for (var rowIdx = 0; rowIdx < rows.Length; rowIdx++)
            {
                var elements = rows[rowIdx].ToCharArray();
                for (var colIdx = 0; colIdx < elements.Length; colIdx++)
                    Elements[rowIdx, colIdx] = elements[colIdx];
            }
        }

        public override string ToString()
        {
            var gridString = string.Empty;

            for (var rowIdx = 0; rowIdx < Dimension; rowIdx++)
            {
                if (rowIdx != 0)
                    gridString += "/"; // add separator

                for (var colIdx = 0; colIdx < Dimension; colIdx++)
                    gridString += Elements[rowIdx, colIdx];
            }

            return gridString;
        }

        internal static List<Grid> FromStrings(List<string> rows, int rowIdx, int gridSize)
        {
            var grids = new List<Grid>();
            var colCount = rows.First().Length;

            // add a grid for each colCount%gridSize jump
            for (var i = 0; i < colCount; i += gridSize)
            {
                var gridSet = string.Empty;

                // loop over the rows
                for (var j = 0; j < gridSize; j++)
                {
                    if (j != 0)
                        gridSet += "/";

                    // loop over the cols
                    for (var k = 0; k < gridSize; k++)
                    {
                        gridSet += rows[rowIdx * gridSize + j][i + k];
                    }
                }

                grids.Add(new Grid(gridSet));
            }

            return grids;
        }

        public Grid Expand(List<Rule> rules)
        {
            //foreach (var conformation in Conformations())
            //{
            //    Console.WriteLine(conformation.ToString());
            //}
            //    Console.ReadLine();
            foreach (var conformation in Conformations())
            {
                foreach (var rule in rules)
                {
                    if (conformation.ToString() == rule.Match)
                        return new Grid(rule.Conversion);
                }
            }

            throw new Exception("No rules match any conformations for given Grid. Try mod 3 instead.");
        }

        private IEnumerable<Grid> Conformations()
        {
            yield return this;
            yield return this.Rotate();
            yield return this.Rotate().Rotate(); // cascading Rotate() calls is just me being lazy
            yield return this.Rotate().Rotate().Rotate();
            yield return this.Flip();
            yield return this.Flip().Rotate();
            yield return this.Flip().Rotate().Rotate();
            yield return this.Flip().Rotate().Rotate().Rotate();
        }

        private Grid Rotate()
        {
            //return new Grid(Transpose(Elements));
            var grid = new char[Dimension, Dimension];
            if (Dimension == 2)
            {
                grid[0, 0] = Elements[1, 0]; grid[0, 1] = Elements[0, 0];
                grid[1, 0] = Elements[1, 1]; grid[1, 1] = Elements[0, 1];
            }
            else
            {
                grid[0, 0] = Elements[2, 0]; grid[0, 1] = Elements[1, 0]; grid[0, 2] = Elements[0, 0];
                grid[1, 0] = Elements[2, 1]; grid[1, 1] = Elements[1, 1]; grid[1, 2] = Elements[0, 1];
                grid[2, 0] = Elements[2, 2]; grid[2, 1] = Elements[1, 2]; grid[2, 2] = Elements[0, 2];
            }
            return new Grid(grid);
        }
        // so#29483660
        public char[,] Transpose(char[,] matrix)
        {
            var w = matrix.GetLength(0);
            var h = matrix.GetLength(1);

            var result = new char[h, w];

            for (var i = 0; i < w; i++)
            {
                for (var j = 0; j < h; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }

        private Grid Flip()
        {
            var grid = new char[Dimension, Dimension];
            if (Dimension == 2)
            {
                grid[0, 0] = Elements[0, 1];grid[0, 1] = Elements[0, 0];
                grid[1, 0] = Elements[1, 1];grid[1, 1] = Elements[1, 0];
            }
            else
            {
                grid[0, 0] = Elements[0, 2];grid[0, 1] = Elements[0, 1];grid[0, 2] = Elements[0, 0];
                grid[1, 0] = Elements[1, 2];grid[1, 1] = Elements[1, 1];grid[1, 2] = Elements[1, 0];
                grid[2, 0] = Elements[2, 2];grid[2, 1] = Elements[2, 1];grid[2, 2] = Elements[2, 0];
            }
            return new Grid(grid);
        }
    }
}
