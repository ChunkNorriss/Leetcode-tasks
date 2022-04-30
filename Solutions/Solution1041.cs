namespace Solutions
{
    public class Solution1041
    {
        private readonly Vector[] directions =
        {
            new Vector(0, 1),
            new Vector(1, 0),
            new Vector(0, -1),
            new Vector(-1, 0)
        };

        public bool IsRobotBounded(string instructions)
        {
            var position = new Vector(0, 0);
            var dirIdx = 0;

            foreach (var c in instructions)
                switch (c)
                {
                    case 'L':
                        dirIdx = (dirIdx + directions.Length - 1) % directions.Length;
                        break;
                    case 'R':
                        dirIdx = (dirIdx + 1) % directions.Length;
                        break;
                    default:
                        var direction = directions[dirIdx];
                        position.X += direction.X;
                        position.Y += direction.Y;
                        break;
                }

            return position.X == 0 && position.Y == 0 || dirIdx > 0;
        }

        private struct Vector
        {
            public Vector(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X;
            public int Y;
        }
    }
}