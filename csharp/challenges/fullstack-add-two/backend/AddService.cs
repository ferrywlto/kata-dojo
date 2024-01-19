using Xunit;

public class AddServiceTest
{
    [Theory]
    [InlineData(1,2,3)]
    [InlineData(3,4,7)]
    public void AddServiceShouldReturnCorrectSum(int num1, int num2, int expected)
    {
        var sut = new AddService();
        Assert.Equal(expected, sut.Add(num1, num2));
    }
}

public class AddService
{
    public int Add(int num1, int num2)
    {
                
        return num1 + num2;
    }
}