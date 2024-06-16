using Moq;
using Tetris.Model;
namespace Tetris.UnitTest;

public class DotTest
{
    [Fact]
    public void CanRotateRight_MustReturn_False()
    {
        var sut = new Dot();
        var actual = sut.CanRotateRight(It.IsAny<int[,]>(), It.IsAny<int>(), It.IsAny<int>());
        Assert.False(actual);
    }
}