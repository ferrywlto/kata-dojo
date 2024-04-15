public abstract class MyHashMap 
{

    public MyHashMap() {}

    public abstract void Put(int key, int value);

    public abstract int Get(int key);

    public abstract void Remove(int key);
}

public class Q706_DesignHashMap : MyHashMap
{
    protected readonly Dictionary<int, int> map = [];
    public override int Get(int key)
    {
        if (!map.TryGetValue(key, out int value)) 
            return -1;
        return value;
    }

    public override void Put(int key, int value)
    {
        if(!map.TryAdd(key, value))
        {
            map[key] = value;
        }
    }

    public override void Remove(int key)
    {
        map.Remove(key);
    }
}

public class Q706_DesignHashMapTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            new string[]{"init", "put", "put", "get", "get", "put", "get", "remove", "get"},
            new int[][] {[], [1,1], [2,2], [1], [3], [2,1], [2], [2], [2]},
            new int?[] {null, null, null, 1, -1, null, 1, null, -1},
        ]
    ];
}

public class Q706_DesignHashMapTests
{
    [Theory]
    [ClassData(typeof(Q706_DesignHashMapTestData))]
    public void OfficialTestCases(string[] ops, int[][] @params, int?[] expected)
    {
        var sut = new Q706_DesignHashMap();
        for(var i=0; i<ops.Length; i++)
        {
            switch(ops[i])
            {
                case "init": break;
                case "put":
                    sut.Put(@params[i][0], @params[i][1]);
                    break;
                case "get":
                    var value = sut.Get(@params[i][0]);
                    Assert.Equal(expected[i], value);
                    break;
                case "remove":
                    sut.Remove(@params[i][0]);
                    break;
            }
        }
    }
}