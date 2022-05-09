using System.Collections.Generic;
using System.Text;

namespace Solutions;

public class Solution17 {
    public IList<string> LetterCombinations(string digits) {
        var digitsMap = new[] {
            "abc",
            "def",
            "ghi",
            "jkl",
            "mno",
            "pqrs",
            "tuv",
            "wxyz"
        };

        var result = new List<string>();
        var prefix = new StringBuilder();

        if (digits.Length == 0)
            return result;
        GetCombinations(digits, digitsMap, prefix, result);
        return result;
    }
        
    private void GetCombinations(string digits, string[] map, StringBuilder prefix, List<string> result) {
        var digitIdx = prefix.Length;
        
        if (digits.Length == digitIdx)
        {
            result.Add(prefix.ToString());
            return;
        }

        var digit = digits[digitIdx] - '2';

        foreach (var letter in map[digit])
        {
            prefix.Append(letter);
            GetCombinations(digits, map, prefix, result);
            prefix.Remove(prefix.Length - 1, 1);
        }
    }
}