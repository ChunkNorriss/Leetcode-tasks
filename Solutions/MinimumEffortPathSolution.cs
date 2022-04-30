using System;

namespace Solutions
{
    public class MinimumEffortPathSolution
    {
        public int MinimumEffortPath(int[][] heights)
        {
            var rows = heights.Length;
            var columns = heights[0].Length;

            var x = rows - 1;
            var y = columns - 1;
            var minEfforts = new int[rows][];
            for (var i = 0; i < rows; i++)
            {
                minEfforts[i] = new int[columns];
                for (var j = 0; j < columns; j++) 
                    minEfforts[i][j] = int.MaxValue;
            }

            var visited = new int[rows][];
            for (int i = 0; i < rows; i++)
                visited[i] = new int[columns];

            return MinimumEffortPath(heights, x, y, x, y, minEfforts, visited);
        }

        private int MinimumEffortPath(int[][] heights, int x, int y, int prevX, int prevY, int[][] minEfforts,
            int[][] visited)
        {
            if (!InBounds(heights, x, y))
                return int.MaxValue;

            visited[x][y] = 1;
            var height = heights[x][y];
            var previousHeight = heights[prevX][prevY];
            var effort = Math.Abs(previousHeight - height);
            if (minEfforts[prevX][prevY] != int.MaxValue) 
                effort = Math.Max(effort, minEfforts[prevX][prevY]);
            
            if (minEfforts[x][y] > effort)
                minEfforts[x][y] = effort;
            else
                return int.MaxValue;

            if (x == 0 && y == 0)
                return minEfforts[0][0];

            int nextEffort;
            var minNextEffort = int.MaxValue;

            if (InBounds(heights, x - 1, y) && visited[x - 1][y] == 0)
            {
                nextEffort = MinimumEffortPath(heights, x - 1, y, x, y, minEfforts, visited);
                visited[x - 1][y] = 0;
                minNextEffort = Math.Min(minNextEffort, nextEffort);
            }


            if (InBounds(heights, x + 1, y) && visited[x + 1][y] == 0)
            {
                nextEffort = MinimumEffortPath(heights, x + 1, y, x, y, minEfforts, visited);
                visited[x + 1][y] = 0;
                minNextEffort = Math.Min(minNextEffort, nextEffort);
            }


            if (InBounds(heights, x, y - 1) && visited[x][y - 1] == 0)
            {
                nextEffort = MinimumEffortPath(heights, x, y - 1, x, y, minEfforts, visited);
                visited[x][y - 1] = 0;
                minNextEffort = Math.Min(minNextEffort, nextEffort);
            }


            if (InBounds(heights, x, y + 1) && visited[x][y + 1] == 0)
            {
                nextEffort = MinimumEffortPath(heights, x, y + 1, x, y, minEfforts, visited);
                visited[x][y + 1] = 0;
                minNextEffort = Math.Min(minNextEffort, nextEffort);
            }

            return Math.Max(minNextEffort, effort);
        }

        private bool InBounds(int[][] heights, int x, int y)
        {
            if (x < 0 || x >= heights.Length)
                return false;
            if (y < 0 || y >= heights[0].Length)
                return false;
            return true;
        }
    }
}
