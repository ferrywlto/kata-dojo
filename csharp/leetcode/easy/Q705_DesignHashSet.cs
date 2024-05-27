class Q705_DesignHashSet
{
    private readonly Dictionary<int, int> dict = [];
    
    public void Add(int key) 
    {
        var hash = key.GetHashCode();
        dict.TryAdd(hash, key);
    }
    
    public void Remove(int key) 
    {
        dict.Remove(key.GetHashCode());
    }
    
    public bool Contains(int key) 
    {
        return dict.ContainsKey(key.GetHashCode());
    }
}

public enum TestCommands { Add, Contains, Remove }
class Q705_DesignHashSetTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            new List<(TestCommands command, int param, bool? result)>
            {
                new (TestCommands.Add, 1, null),
                new (TestCommands.Add, 2, null),
                new (TestCommands.Contains, 1, true),
                new (TestCommands.Contains, 3, false),
                new (TestCommands.Add, 2, null),
                new (TestCommands.Contains, 2, true),
                new (TestCommands.Remove, 2, null),
                new (TestCommands.Contains, 2, false),
            },
        ]
    ];
}

public class Q705_DesignHashSetTests
{
    [Theory]
    [ClassData(typeof(Q705_DesignHashSetTestData))]
    public void OfficialTestCases(List<(TestCommands command, int param, bool? result)> input)
    {
        var sut = new Q705_DesignHashSet();
        foreach(var (command, param, result) in input)
        {
            switch (command)
            {
                case TestCommands.Add:
                    sut.Add(param);
                    break;
                case TestCommands.Remove:
                    sut.Remove(param);
                    break;
                case TestCommands.Contains:
                    Assert.Equal(result, sut.Contains(param));
                    break;
            }
        }
    }
}