namespace Solutions;

public class Solution28
{
    public int StrStr(string haystack, string needle)
    {
        if (string.IsNullOrEmpty(needle))
            return 0;

        for (var i = 0; i < haystack.Length; i++)
        {
            var pos = i;
            for (var j = 0; j < needle.Length; j++)
            {
                if (pos >= haystack.Length)
                    return -1;

                var isLastNeedleSymbol = j == needle.Length - 1;
                if (haystack[pos] != needle[j])
                    break;
                if (isLastNeedleSymbol)
                    return i;

                pos++;
            }
        }

        return -1;
    }
}