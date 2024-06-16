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

    [Fact]
    public void CanRotateLeft_MustReturn_False()
    {
        var sut = new Dot();
        var actual = sut.CanRotateLeft(It.IsAny<int[,]>(), It.IsAny<int>(), It.IsAny<int>());
        Assert.False(actual);
    }

    [Fact]
    public void RotateLeft_MustThrow_NotImplementedException()
    {
        var sut = new Dot();
        Assert.Throws<NotImplementedException>(() => sut.RotateLeft(It.IsAny<int[,]>(), It.IsAny<int>(), It.IsAny<int>()));
    }

    [Fact]
    public void RotateRight_MustThrow_NotImplementedException()
    {
        var sut = new Dot();
        Assert.Throws<NotImplementedException>(() => sut.RotateRight(It.IsAny<int[,]>(), It.IsAny<int>(), It.IsAny<int>()));
    }
}