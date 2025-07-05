using System.Text;

public class Q2698_FindPunishmentNumberOfInteger(ITestOutputHelper output)
{
    private List<List<string>> combinations = [];
    private string numStr = "";
    private string nStr = "";
    public int PunishmentNumber(int n)
    {
        // var p = 0;
        // for (var i = 0; i < 1001; i++)
        // {
        //     if(Possible(i))p++;
        // }
        // output.WriteLine("p: {0}", p);
        // n = 36;
        var sq = n * n;
        nStr = n.ToString();
        numStr = "1296";

        t(new List<string>(), 0, 0, 36);
        output.WriteLine("list: {0}", string.Join(Environment.NewLine, combinations.Select(c => $"[{string.Join(',', c)}]")));
        return 0;
    }
    private void t(List<string> list, int idx, int sum, int n)
    {
        if (idx >= numStr.Length)
        {
            if (sum == n)
            {
                output.WriteLine("found: [{0}]", string.Join(',', list));
                combinations.Add(list);
            }
            else
            {
                output.WriteLine("not-found: [{0}], sum: {1}", string.Join(',', list), sum);
            }
            return;
        }

        var sb = new StringBuilder();
        for (var i = idx; i < numStr.Length; i++)
        {
            var l = new List<string>(list);
            sb.Append(numStr[i]);
            var val = int.Parse(sb.ToString());

            l.Add(sb.ToString());
            t(l, i + 1, sum + val, n);
        }
    }
    public static TheoryData<int, int> TestData => new()
    {
        {10, 182},
        {37, 1478},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = PunishmentNumber(input);
        Assert.Equal(expected, actual);
    }
}