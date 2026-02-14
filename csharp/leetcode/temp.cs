public class Temp
{
    public string Format(float value)
    {
        return value.ToString("0000000000.00");
    }
    public string Format2(float value)
    {
        var A = $"{value:f2}";
        var B = A.PadLeft(13, '0');
        // Console.WriteLine($"Formatting value: {B}");
        Console.WriteLine($"{A}\t | {B}");
        return $"{value:f2}".PadLeft(13, '0');
    }
    public static TheoryData<float, string> TestData => new()
    {
        {245.567f,   "0000000245.57"},
        {1245.678f,  "0000001245.68"},
        {11245.00f, "0000011245.00"},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(float value, string expected)
    {
        var formatted = Format2(value);
        Assert.Equal(expected, formatted);
    }
}
