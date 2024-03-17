namespace dojo.leetcode;

public class Q705_DesignHashSet
{
    public Q705_DesignHashSet() {
        
    }
    
    public void Add(int key) {
        
    }
    
    public void Remove(int key) {
        
    }
    
    public bool Contains(int key) {
        return false;
    }
}

public enum TestCommands { Add, Contains, Remove }
public class Q705_DesignHashSetTestData : TestData
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