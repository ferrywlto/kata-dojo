using System.Text;

public class Q2375_ConstructSmallestNumberFromDIString//(ITestOutputHelper output)
{
    public string SmallestNumber(string pattern)
    {
        var sb = new StringBuilder("I" + pattern);
        var result = new StringBuilder();

        var dCount = 0;
        var smallestDigit = 1;
        var currentValue = 0;
        for(var i=0; i<sb.Length; i++)
        {
            if(sb[i] == 'I')
            {
                currentValue = smallestDigit + dCount;
                result.Append(currentValue);
                dCount = 0;
                smallestDigit++;
            }
            else
            {
                result.Append(--currentValue);
                dCount++;
            }
        }
        return result.ToString();
    }
    private int FirstPossibleSmaller(HashSet<int> set, int targetToCompare)
    {
        var arr = set.ToArray();
        Array.Sort(arr);

        for(var i=0; i<arr.Length; i++)
        {
            if(arr[i] < targetToCompare) return arr[i];
        }
        return -1;
    }
    private int FirstPossibleLarger(HashSet<int> set, int targetToCompare)
    {
        var arr = set.ToArray();
        Array.Sort(arr);
        for(var i=0; i<arr.Length; i++)
        {
            if(arr[i] > targetToCompare) return arr[i];
        }
        return -1;
    }
    private string Recursion(HashSet<int> set, int start, string pattern) 
    {
        set.Remove(start);
        var sb = new StringBuilder();
        sb.Append(start.ToString());

        while(set.Count > 0) 
        {
            for(var i=0; i<pattern.Length; i++)
            {
                if(pattern[i] == 'D') {
                    var smaller = FirstPossibleSmaller(set, start);
                    if(smaller == -1) return "impossible";
                    sb.Append(smaller);
                    set.Remove(smaller);
                    start = smaller;
                }
                else {
                    var larger = FirstPossibleLarger(set, start);
                    if(larger == -1) return "impossible";
                    sb.Append(larger);
                    set.Remove(larger);
                    start = larger;
                }
            }
        }
        return sb.ToString();
    }
    public static TheoryData<string, string> TestData => new()
    {
        // length: 8
        // possible largest digit: 8 + 1 = 9
        // number of I = 4
        // number of D = 4

        {"IIIDIDDD", "123549876"},
        // {"IDIDIDID", "1 23549876"},
        // {"DIDIDIDI", "5 46 37 28 19"},
        // {"DIDIDIDI", "4 46 37 28 19"},

        // {"ID DD ID ID", "1 54 32 87 96"},
        // {"ID DD ID ID", "1 54 32 87 96"},
        // {"ID ID ID DD", "1 54 76 98 32"},
        // {"ID DD ID DD", "1 54 32 98 76"},
        // {"ID DD DD DD", "1 98 76 54 32"},
        // IIIIDDDD  1 23 49 87 65 

        // IIIIIIII, 1 23 45 67 89 +8
        // DIIIIIII  2 13 45 67 89
        // DDIIIIII. 3 21 45 67 89
        // DDDIIIII. 4 32 15 67 89
        // DDDDIIII  5 43 21 67 89
        // DDDDDIII. 6 54 32 17 89
        // DDDDDDII. 7 65 43 21 89
        // DDDDDDDI  8 76 54 32 19
        // DDDDDDDD, 9 87 65 43 21 -8

        // DDIDIIII  3 21 54 6789  

        // IDIIIIII  1 32 45 67 89  
        // D 2 1
        // I 1 2
        // DD 3 2 1
        // DI 2 1 3
        // ID 1 3 2
        // II 1 2 3
        // DDD 4 321
        // DDI 4 213
        // DID 4 132
        // DII 4 123
        // IDD 1 432
        // IDI 1 324
        // IID 1 243
        // III 1 234
        
        {"DDD", "4321"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = SmallestNumber(input);
        Assert.Equal(expected, actual);
    }
}
