public class Q1641_CountSortedVowelStrings(ITestOutputHelper output)
{
    Dictionary<int, int> accumulatedSum = [];
    Dictionary<int, int> sumFromOne = [];
    public int CountVowelStrings(int n)
    {
        // 1, 2, 3, 4, 5
        // 1, 2, 3, 4, 5 = 5
        // 11, 12, 13, 14, 15 = Sum 5..1
        // 22, 23, 24, 25
        // 33, 34, 35
        // 44, 45
        // 55
        var sum1 = 0;
        var sum2 = 0;
        for(var i = 1; i<=5+n; i++)
        {
            sum1 += i;
            sumFromOne.Add(i, sum1);
            sum2 += sumFromOne[i];
            accumulatedSum.Add(i, sum2);
        }

        output.WriteLine($"sum from 1 to n");
        foreach(var p in sumFromOne)
        {
            output.WriteLine($"key: {p.Key}, val: {p.Value}");
        }

        output.WriteLine($"accumulated sum of (sum from 1 to n)");
        foreach(var p in accumulatedSum)
        {
            output.WriteLine($"key: {p.Key}, val: {p.Value}");
        }

        return Cal(n);
        // S(1) = 5
        // S(2) = S(1)=5 + E4(4 + 3 + 2 + 1)
        // S(3) = S(2)=15 + E4 + E3 + E2 + 1
        // S(4) = S(3)=35 + E5 + E4 + E3 + E2 + 1
        // S(5) = S(4)=70 + E6 + E5 + E4 + E3 + E2 + 1 = 70 + 1 + 3 + 6 + 10 + 15 + 21 = 126
        // S(6) = S(5)=126 + (56 + 28) =  
        // 111, 112, 113, 114, 115 Sum 5..1 + Sum 4..1 + Sum 3..1 + Sum 2..1 + 1
        // 122, 123, 124, 125
        // 133, 134, 135
        // 144, 145
        // 155
        // 222, 223, 224, 225
        // 233, 234, 235
        // 244, 245
        // 255
        // 333, 334, 335
        // 344, 345
        // 355
        // 444, 445
        // 455
        // 555
        // len 1 - 2 - 3 - 4 - 5 - 6
        // u - 1 - 1 - 1 - 1 - 1 - 1
        // o - 1 - 2 - 3 - 4 - 5 - 6
        // i - 1 - 3 - 6 - 10 - 15 - 21
        // e - 1 - 4 - 10 - 20 - 35 - 56
        // a - 1 - 5 - 15 - 35 - 70 - 126
        // S - 5 - 15 - 35
        // s(u) = 1
        // s(e) = 3
        // s(i) = 



        // 1111, 1112, 1113, 1114, 1115 Sum 5..1 + Sum 4..1 + Sum 3..1 + Sum 2..1 + 1
        // 1122, 1123, 1124, 1125
        // 1133, 1134, 1135
        // 1144, 1145
        // 1155
        // 1222, 223, 224, 225
        // 1233, 234, 235
        // 1244, 245
        // 1255
        // 1333, 334, 335
        // 1344, 345
        // 1355
        // 1444, 445
        // 1455
        // 1555
    }
    int Cal(int input)
    {
        if(input == 1) return 5;
        else
        {
            return Cal(input - 1) + accumulatedSum[Math.Abs(input - 5)];
        }
    }

    public static TheoryData<int, int> TestData => new()
    {
        {1, 5},
        {2, 15},
        {3, 35},
        // {33, 66045},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = CountVowelStrings(input);
        Assert.Equal(expected, actual);
    }
}
