public class Q3270_FindKeyOfNumbers
{
    public int GenerateKey(int num1, int num2, int num3)
    {
        return 0;
    }
    public static TheoryData<int, int, int, int> TestData => new()
    {
        {1, 10 ,1000, 0},
        {987, 879 ,798, 777},
        {1, 2 ,3, 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int input2, int input3, int expected)
    {
        var actual = GenerateKey(input1, input2, input3);
        Assert.Equal(expected, actual);
    }
}
