using System.Text;

public class Q1233_RemoveSubFoldersFromFileSystem
{
    // TC: O(n), n scale with length of folder
    // SC: O(n), for the set to hold initial values
    public IList<string> RemoveSubfolders(string[] folder)
    {
        var set = new HashSet<string>(folder);
        var toRemove = new List<string>();

        var sb = new StringBuilder();
        foreach (var p in folder)
        {
            sb.Clear();
            for (var i = 0; i < p.Length; i++)
            {
                if (p[i] == '/' && i > 0)
                {
                    if (set.Contains(sb.ToString()))
                    {
                        toRemove.Add(p);
                        break;
                    }
                }
                sb.Append(p[i]);
            }
        }
        foreach (var p in toRemove)
        {
            set.Remove(p);
        }
        return set.ToList();
    }
    public static TheoryData<string[], IList<string>> TestData => new()
    {
        {["/a","/a/b","/c/d","/c/d/e","/c/f"], ["/a","/c/d","/c/f"]},
        {["/a","/a/b/c","/a/b/d"], ["/a"]},
        {["/a/b/c","/a/b/ca","/a/b/d"], ["/a/b/c","/a/b/ca","/a/b/d"]},
        {["/ah/al/am","/ah/al"], ["/ah/al"]}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, IList<string> expected)
    {
        var actual = RemoveSubfolders(input);
        Assert.Equal(expected, actual);
    }
}
