namespace Solutions;

public class Solution682
{
    public int CalPoints(string[] ops)
    {
        var index = 0;
        var scores = new int[ops.Length];
        var result = 0;

        foreach (var op in ops)
            switch (op)
            {
                case "+":
                    var plusScore = scores[index - 1] + scores[index - 2];
                    scores[index++] = plusScore;
                    result += plusScore;
                    break;
                case "D":
                    var dScore = scores[index - 1] * 2;
                    scores[index++] = dScore;
                    result += dScore;
                    break;
                case "C":
                    var cScore = scores[index - 1];
                    index--;
                    result -= cScore;
                    break;
                default:
                    var score = int.Parse(op);
                    scores[index++] = score;
                    result += score;
                    break;
            }

        return result;
    }
}


