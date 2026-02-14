using System.Text;

// TC: O(2^(n-1))
// SC: O(n), to store the result
public class Q22_GenerateParentheses
{
    private int leftCount = 0;
    private int rightCount = 0;
    private int max = 0;
    private int pairCount = 0;
    private readonly List<string> result = [];
    public IList<string> GenerateParenthesis(int n)
    {
        leftCount = 1;
        max = n * 2;
        pairCount = n;

        var sb = new StringBuilder("(");
        Backtrack(leftCount, rightCount, sb);
        return result;
    }
    private void Backtrack(int leftCount, int rightCount, StringBuilder sb)
    {
        if (sb.Length == max)
            result.Add(sb.ToString());

        if (leftCount < max && leftCount < pairCount)
        {
            sb.Append('(');
            Backtrack(leftCount + 1, rightCount, sb);
            sb.Length--;
        }

        if (rightCount < leftCount)
        {
            sb.Append(')');
            Backtrack(leftCount, rightCount + 1, sb);
            sb.Length--;
        }
    }

    public static TheoryData<int, List<string>> TestData => new()
    {
        {3, ["((()))","(()())","(())()","()(())","()()()"]},
        {2, ["(())","()()"]},
        {1, ["()"]},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, List<string> expected)
    {
        var actual = GenerateParenthesis(input);
        Assert.Equal(expected, actual);
    }
}
