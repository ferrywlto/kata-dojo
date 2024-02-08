namespace dojo.leetcode;

public class Q412_FizzBuzz
{
    public IList<string> FizzBuzz(int n)
    {
        return [];
    }
}

public class Q412_FizzBuzzTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [15, new List<string> { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz" }],
        [1, new List<string> { "1" }],
        [3, new List<string> { "1", "2", "Fizz" }]
    ];
}

public class Q412_FizzBuzzTests
{
    [Theory]
    [ClassData(typeof(Q412_FizzBuzzTestData))]
    public void Test_FizzBuzz(int n, List<string> expected)
    {
        var q = new Q412_FizzBuzz();
        var result = q.FizzBuzz(n);
        Assert.Equal(expected, result);
    }
}