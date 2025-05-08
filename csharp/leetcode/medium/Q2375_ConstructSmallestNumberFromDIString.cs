using System.Diagnostics.CodeAnalysis;
using System.Text;

public class Q2375_ConstructSmallestNumberFromDIString
{
    public string SmallestNumber(string pattern)
    {
        // var updown = new int[2];
        // var result = new char[9];
        // for(var i=0; i<pattern.Length; i++)
        // {
        //     if(pattern[i] == 'I') updown[0]++;
        //     else updown[1]++;
        // }
        // var sb = new StringBuilder();
        var digits = new int[] { 1, 2, 3, 4, 5 ,6 ,7, 8, 9};
        digits.ToHashSet();
        for(var i=1; i<=9; i++)
        {
            Console.WriteLine($"pattern: {pattern}, possible: {Recursion(digits.ToHashSet(), i, pattern)}");
        }
        return string.Empty;
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
        {"IIIDIDDD", "123549876"},
        // {"IDIDIDID", "1 23549876"},
        // {"DIDIDIDI", "5 46 37 28 19"},
        // {"DIDIDIDI", "4 46 37 28 19"},
        // {"ID DD DD DD", "12 98 76 54 3"},
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