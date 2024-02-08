namespace dojo.leetcode;

public class Q412_FizzBuzz
{
    // TC: O(n), SC: O(n)
    public IList<string> FizzBuzz(int n)
    {
        var result = new List<string>();
        for(var i=0; i<n; i++)
        {
            result.Add(FizzOrBuzz(i+1));
        }
        return result;
    }

    public string FizzOrBuzz(int n)
    {
        if (n % 3 == 0 && n % 5 == 0) return "FizzBuzz";
        if (n % 3 == 0) return "Fizz";
        if (n % 5 == 0) return "Buzz";
        return n.ToString();
    }

    // Same efficiency, slightly faster only if n is very large
    public IList<string> FizzBuzz_NoModulo(int n) 
    {
        var result = new List<string>();
        int fizz = 0, buzz = 0;

        for (int i = 1; i <= n; i++) 
        {
            fizz++;
            buzz++;
            if (fizz == 3 && buzz == 5) 
            {
                result.Add("FizzBuzz");
                fizz = 0;
                buzz = 0;
            } 
            else if (fizz == 3) 
            {
                result.Add("Fizz");
                fizz = 0;
            } 
            else if (buzz == 5) 
            {
                result.Add("Buzz");
                buzz = 0;
            } 
            else 
            {
                result.Add(i.ToString());
            }
        }

        return result;
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
        var result = q.FizzBuzz_NoModulo(n);
        Assert.Equal(expected, result);
    }
}