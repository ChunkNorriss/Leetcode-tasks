using System.Collections.Generic;

namespace Solutions.AlgoExpert
{
    public class SolutionMoveElementToEnd
    {
        public static List<int> MoveElementToEnd(List<int> array, int toMove)
        {
            var toMoveIndex = array.Count - 1;
            for (var i = array.Count - 1; i >= 0; i--)
            {
                var currentValue = array[i];
                if (currentValue != toMove)
                    continue;

                if (i != toMoveIndex)
                    Swap(array, i, toMoveIndex);
                toMoveIndex--;
            }

            // Write your code here.
            return array;
        }

        private static void Swap(List<int> array, int i, int toMoveIndex)
        {
            var temp = array[i];
            array[i] = array[toMoveIndex];
            array[toMoveIndex] = temp;
        }
    }
}