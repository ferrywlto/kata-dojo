public class Q3839_NumPrefixConnectedGroups
{
    public int PrefixConnected(string[] words, int k) {
        return 0;
    }   

    public static TheoryData<string[], int, int> TestData => new ()
    {
        {["apple","apply","banana","bandit"], 2, 2},
        {["car","cat","cartoon"], 3 , 1},
        {["bat","dog","dog","doggy","bat"], 3, 2}
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, int k, int expected)
    {
        var actual = PrefixConnected(input, k);
        Assert.Equal(expected, actual);
    }
     
}
