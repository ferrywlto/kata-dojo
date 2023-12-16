namespace dojo.leetcode;

using System.Collections;
using System.Collections.Generic;
using Xunit;


public class AddTwoNumbersTestData : IEnumerable<object[]>
{
    private readonly List<object[]> _data =
    [
        [new LinkedList<byte>(new byte[]{2, 4, 3}), new LinkedList<byte>(new byte[]{5, 6, 4}), new LinkedList<byte>(new byte[]{7, 0, 8})],
        [new LinkedList<byte>(new byte[]{0}), new LinkedList<byte>(new byte[]{0}), new LinkedList<byte>(new byte[]{0})],
        [new LinkedList<byte>(new byte[]{9, 9, 9, 9, 9, 9, 9}), new LinkedList<byte>(new byte[]{9, 9, 9, 9}), new LinkedList<byte>(new byte[]{8, 9, 9, 9, 0, 0, 0, 1})],
    ];

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class AddTwoNumbersTests
{
    [Theory]
    [ClassData(typeof(AddTwoNumbersTestData))]
    public void AddTwoNumbersTest(LinkedList<byte> l1, LinkedList<byte> l2, LinkedList<byte> expected)
    {
        var subject = new AddTwoNumbers();
        var actual = subject.Solve(l1, l2);
        Assert.Equal(expected, actual);
    }
}

public class AddTwoNumbers {
    public static void ValidateInput(LinkedList<byte> input)  {
        if ((input.Count == 0) || (input.Count > 100)) 
            throw new Exception("List size should be between 1-100");

        var invalid = input.FirstOrDefault(i => i < 0 || i > 9);
        
        if (invalid != default) 
            throw new Exception("Number should within 0-9");
    }

    public LinkedList<byte> Solve(LinkedList<byte> list1, LinkedList<byte> list2) {
        ValidateInput(list1);
        ValidateInput(list2);

        var num1 = ListToInt(list1);
        var num2 = ListToInt(list2);
        var sum = num1 + num2;
        var sumInText = sum.ToString();
        var sumInList = StringToList(sumInText);
        return sumInList;
    }

    public static uint ListToInt(LinkedList<byte> input) {
        var reversed = input.Reverse();
        var numInText = string.Join(string.Empty, reversed.Select(i => i.ToString()).ToArray());
        return uint.Parse(numInText);
    }

    public static LinkedList<byte> StringToList(string input) {
        var list = new LinkedList<byte>();
        foreach (var c in input) {
            list.AddFirst(byte.Parse(c.ToString()));
        }
        return list;
    } 
}