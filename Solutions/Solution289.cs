namespace Solutions
{
    public class Solution289
    {
        public void GameOfLife(int[][] board)
        {
            var rows = board.Length;
            var columns = board[0].Length;

            for (var r = 0; r < rows; r++)
            for (var c = 0; c < columns; c++)
            {
                var nextState = ComputeNextState(board, r, c);
                board[r][c] |= nextState << 1;
            }

            FlushNextStep(board);
        }

        private static int ComputeNextState(int[][] board, int r, int c)
        {
            var livesNeighbours = CalculateLivesNeighbours(board, r, c);
            var isAlive = (board[r][c] & 0x1) == 1;

            return livesNeighbours switch
            {
                3 => 1,
                2 when isAlive => 1,
                _ => 0
            };
        }

        private static void FlushNextStep(int[][] board)
        {
            var rows = board.Length;
            var columns = board[0].Length;
            for (var r = 0; r < rows; r++)
            for (var c = 0; c < columns; c++)
                board[r][c] >>= 1;
        }

        private static int CalculateLivesNeighbours(int[][] board, int r, int c)
        {
            var rows = board.Length;
            var columns = board[0].Length;
            var livesCount = 0;

            for (var i = r - 1; i <= r + 1; i++)
            {
                if (i < 0 || i >= rows)
                    continue;

                for (var j = c - 1; j <= c + 1; j++)
                {
                    if (j < 0 || j >= columns)
                        continue;

                    if (i == r && j == c)
                        continue;

                    if ((board[i][j] & 0x1) == 1)
                        ++livesCount;
                }
            }

            return livesCount;
        }
    }
}