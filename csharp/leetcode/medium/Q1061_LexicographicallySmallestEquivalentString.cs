using System.Text;

public class Q1061_LexicographicallySmallestEquivalentString(ITestOutputHelper output)
{
    public string SmallestEquivalentString(string s1, string s2, string baseStr)
    {
        var dict = new Dictionary<char, char>();
        for (var i = 'a'; i <= 'z'; i++)
        {
            dict.Add(i, i);
        }
        var len = s1.Length;
        for (var i = 0; i < len; i++)
        {
            var min = Math.Min(s1[i], s2[i]);
            while (dict[(char)min] != (char)min)
            {
                min = dict[(char)min];
            }
            output.WriteLine("pair: {0}, {1}", s1[i], s2[i]);
            dict[s1[i]] = (char)min;
            dict[s2[i]] = (char)min;
        }
        output.WriteLine("before dict: {0}", string.Join(Environment.NewLine, dict.Select(p => $"{p.Key}: {p.Value}")));
        // back trace from z
        for (var i = 'z'; i >= 'a'; i--)
        {
            var min = dict[i];
            while (dict[min] != min)
            {
                min = dict[min];
            }
            dict[i] = min;
        }
        output.WriteLine("after dict: {0}", string.Join(Environment.NewLine, dict.Select(p => $"{p.Key}: {p.Value}")));

        // brute force
        // var maps = new List<HashSet<char>>();
        // for (var i = 0; i < len; i++)
        // {
        //     var count = 0;
        //     foreach (var set in maps)
        //     {
        //         if (set.Contains(s1[i]) || set.Contains(s2[i]))
        //         {
        //             set.Add(s1[i]);
        //             set.Add(s2[i]);
        //             count++;
        //             break;
        //         }
        //     }
        //     if (count == 0)
        //     {
        //         maps.Add([s1[i], s2[i]]);
        //     }
        // }
        // var mins = new char[26];
        // for (var x = 0; x < mins.Length; x++) mins[x] = (char)(x + 'a');
        // foreach (var bag in maps)
        // {
        //     var min = int.MaxValue;
        //     foreach (var ch in bag)
        //     {
        //         if (ch < min) min = ch;
        //     }
        //     foreach (var ch in bag)
        //     {
        //         mins[ch - 'a'] = (char)min;
        //     }
        // }
        // for (var j = 0; j < mins.Length; j++)
        // {
        //     output.WriteLine("min: {0}, {1}", (char)(j + 'a'), mins[j]);
        // }
        var sb = new StringBuilder(baseStr);
        for (var k = 0; k < sb.Length; k++)
        {
            sb[k] = dict[sb[k]];
        }

        // output.WriteLine("result: {0}", string.Join('|', maps.Select(s => string.Join(',', s))));
        return sb.ToString();
    }
    public static TheoryData<string, string, string, string> TestData => new()
    {
        {"parker", "morris", "parser", "makkek"},
        {"hello", "world", "hold", "hdld"},
        {"leetcode", "programs", "sourcecode", "aauaaaaada"},
        {"adbfgjdi", "bccgheej", "abcdefgheij", "aaaaafffaaa"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string s1, string s2, string baseStr, string expected)
    {
        var actual = SmallestEquivalentString(s1, s2, baseStr);
        Assert.Equal(expected, actual);
    }
}
