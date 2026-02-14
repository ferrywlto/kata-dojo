public class Q3606_CouponCodeValidator
{
    // TC: O(n log n), n scale with length of code due to sorting
    // SC: O(n), to hold the result, otherwise O(1)
    public IList<string> ValidateCoupons(string[] code, string[] businessLine, bool[] isActive)
    {
        var result = new List<string>();
        var len = code.Length;
        for (var i = 0; i < len; i++)
        {
            var line = indexOf(businessLine[i]);
            if (isActive[i] && line > -1 && isValidCode(code[i]))
            {
                Groups[line].Add(code[i]);
            }
        }
        var gLen = Groups.Length;
        for (var j = 0; j < gLen; j++)
        {
            // The StringComparer.Ordinal sorts strings in lexicographical order, compare char by char in UNICODE order
            Groups[j].Sort(StringComparer.Ordinal);
            result.AddRange(Groups[j]);
        }
        return result;
    }

    private static readonly string[] ValidLines = ["electronics", "grocery", "pharmacy", "restaurant"];
    private List<string>[] Groups = [[], [], [], []];
    private int indexOf(string input) => Array.IndexOf(ValidLines, input);
    private bool isValidCode(string input)
    {

        if (string.IsNullOrEmpty(input)) return false;
        foreach (var c in input)
        {
            if (!char.IsDigit(c) && !char.IsAsciiLetter(c) && c != '_') return false;
        }
        return true;
    }
    public static TheoryData<string[], string[], bool[], List<string>> TestData => new()
    {
        {
            ["SAVE20", "", "PHARMA5", "SAVE@20"],
            ["restaurant","grocery","pharmacy","restaurant"],
            [true,true,true,true],
            ["PHARMA5","SAVE20"]
        },
        {
            ["GROCERY15","ELECTRONICS_50","DISCOUNT10"],
            ["grocery","electronics","invalid"],
            [false,true,true],
            ["ELECTRONICS_50"]
        },
        {
            ["pBXoMqBU0_aMgc9F8dy6TaSzza3KjSJFjxZa_NuyMjzEBR7fJNwpGHh7lzuoZvQeEUeo6YumHmIOjjchXlzSVa4ItdyDOImQgm","P8rIIUl35MW8yrqRbO0N_IITptYOxz9tOCbPL6d1aIF_hM2sapaDtUzNpmAZRmJQB1WgjLh8bdYADuSRSU21OzttUkq73qiA66","aFWkYookQlHYMXzhVGxbnrXIl1810ws3qHtketHSECHqJoktWXVZGc6ZyeOuzA_VL9zFL9znpIHwbkwJF2bOPQqsz3_0PYgETJ"],
            ["pharmacy","invalid","pharmacy"],
            [true,true,true],
            ["aFWkYookQlHYMXzhVGxbnrXIl1810ws3qHtketHSECHqJoktWXVZGc6ZyeOuzA_VL9zFL9znpIHwbkwJF2bOPQqsz3_0PYgETJ","pBXoMqBU0_aMgc9F8dy6TaSzza3KjSJFjxZa_NuyMjzEBR7fJNwpGHh7lzuoZvQeEUeo6YumHmIOjjchXlzSVa4ItdyDOImQgm"]
        },
        {
            ["MI","b_"],
            ["pharmacy","pharmacy"],
            [true,true],
            ["MI","b_"] // capital M comes before lowercase b in lexicographical order (lower ascii value)
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] code, string[] line, bool[] isActive, List<string> expected)
    {
        var actual = ValidateCoupons(code, line, isActive);
        Assert.Equal(expected, actual);
    }
}
