public class Q1233_RemoveSubFoldersFromFileSystem
{
    public IList<string> RemoveSubfolders(string[] folder)
    {
        return [];
    }
    public static TheoryData<string[], IList<string>> TestData => new()
    {
        {["/a","/a/b","/c/d","/c/d/e","/c/f"], ["/a","/c/d","/c/f"]},
        {["/a","/a/b/c","/a/b/d"], ["/a"]},
        {["/a/b/c","/a/b/ca","/a/b/d"], ["/a/b/c","/a/b/ca","/a/b/d"]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, IList<string> expected)
    {
        var actual = RemoveSubfolders(input);
        Assert.Equal(expected, actual);
    }
}
