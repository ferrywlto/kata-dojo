namespace dojo.leetcode;

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xunit;

public class ListNode 
{
    public int val;
    public ListNode? next;
    public ListNode(int val=0, ListNode? next=null) 
    {
        this.val = val;
        this.next = next;
    }
}

public class AddTwoNumbers {
    /// <summary>
    /// It doesn't have to check for null as the question stated the list will never be empty, just keep it until performance optimization stage 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public static bool ValidateInput(ListNode? input, int count = 1)  {
        if (input == null || count > 100 || !IsValidNumber(input)) {
            Console.WriteLine($"Q2: validation failed, count:{count} input:{input?.val}");
            return false;
        }
        else if (input.next == null) // last node
            return true;
        else
            return ValidateInput(input.next, count+1);
    }

    public static bool IsValidNumber(ListNode input) => input.val is >= 0 and <= 9;

    public ListNode Solve(ListNode l1, ListNode l2) {
        if (!ValidateInput(l1) || !ValidateInput(l2))
            return new ListNode(0);
        
        var sumList = new ListNode();
        var sum = l1.val + l2.val;

        if(sum >= 10)
        {
            sumList.val = sum % 10;
            sumList.next = new ListNode(1);
        }
        else
        {
            sumList.val = sum;
        }

        return sumList;
    }
}

public class AddTwoNumbersTestData : IEnumerable<object[]>
{
    private readonly List<object[]> _data =
    [
        [243, 564, 708],
        [0, 0, 0],
        [9999999, 9999, 89990001]
    ];

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class AddTwoNumbersTests
{
    [Fact]
    public void ShouldAbleToPerformSingleDigitAddition_TwoDigitsResult() {
        var x = new AddTwoNumbers();
        var l1 = new ListNode(9);
        var l2 = new ListNode(9);
        var expected = new ListNode(8, new ListNode(1));
        var actual = x.Solve(l1, l2);
        while (expected != null && actual != null) {
            Assert.Equal(expected.val, actual.val);
            expected = expected.next;
            actual = actual.next;
        }
    }

    [Fact]
    public void ShouldAbleToPerformSingleDigitAddition_SingleDigitResult() {
        var x = new AddTwoNumbers();
        var l1 = new ListNode(2);
        var l2 = new ListNode(3);
        var expected = new ListNode(5);
        var actual = x.Solve(l1, l2);
        Assert.Equal(expected.val, actual.val);
    }

    [Fact]
    public void ShouldAbleToPerformSingleDigitAddition_ZeroResult() {
        var x = new AddTwoNumbers();
        var l1 = new ListNode(0);
        var l2 = new ListNode(0);
        var expected = new ListNode(0);
        var actual = x.Solve(l1, l2);
        Assert.Equal(expected.val, actual.val);
    }
}


// it have to be per digit calculation in order to support 100 digits 

