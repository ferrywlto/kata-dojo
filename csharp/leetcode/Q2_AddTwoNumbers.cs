using Xunit;
using Xunit.Abstractions;

namespace dojo.leetcode;
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
// it have to be per digit calculation in order to support 100 digits 
public class AddTwoNumbers {
    public ListNode Solve(ListNode l1, ListNode l2) {
        var sumList = new ListNode();
        Recursion(l1, l2, sumList);
        return sumList;
    }

    private bool carryOver = false;
    public void Recursion(ListNode? l1, ListNode? l2, ListNode current) {
        if(l1 != null && l2 != null) {
            var sum = l1.val + l2.val;
            if (carryOver) sum += 1;

            carryOver = sum >= 10;
            current!.val = sum % 10;

            if (l1.next != null || l2.next != null) {
                current.next = new ListNode();
                Recursion(l1.next, l2.next, current.next);
            }
            else if (carryOver) {
                current.next = new ListNode(1);
            }
        }
        else if(l1 != null && l2 == null) {
            RecursionSingle(l1, current);
        }
        else if(l1 == null && l2 != null) {
            RecursionSingle(l2, current);
        }
    }

    public void RecursionSingle(ListNode input, ListNode current) {
        if (carryOver) input.val += 1;

        carryOver = input.val >= 10;
        current!.val = input.val % 10;

        if (input.next != null) {
            current.next = new ListNode();
            RecursionSingle(input.next, current.next);
        }
        else if (carryOver) {
            current.next = new ListNode(1);
        }
    }
}

public class AddTwoNumbersTests(ITestOutputHelper output)
{
    private readonly ITestOutputHelper output = output;

    [Fact]
    public void CheckCase1() {
        var x = new AddTwoNumbers();
        var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
        var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));
        var expected = new ListNode(7, new ListNode(0, new ListNode(8)));
        var actual = x.Solve(l1, l2);
        AssertListNodeEquals(expected, actual);
    }

    [Fact]
    public void ShouldFailOnInvalidNumber_LargerThanNine() {
        var x = new AddTwoNumbers();
        var l1 = GenerateListNode(3, 10);
        var l2 = GenerateListNode(3, 1);
        Assert.Throws<Exception>(() => x.Solve(l1, l2));
    }

    [Fact]
    public void ShouldFailOnInvalidNumber_LessThanZero() {
        var x = new AddTwoNumbers();
        var l1 = GenerateListNode(3, -1);
        var l2 = GenerateListNode(3, 1);
        Assert.Throws<Exception>(() => x.Solve(l1, l2));
    }

    [Fact]
    public void ShouldFailOnTooLargeList_List2() {
        var x = new AddTwoNumbers();
        var l1 = GenerateListNode(10, 9);
        var l2 = GenerateListNode(101, 9);
        Assert.Throws<Exception>(() => x.Solve(l1, l2));
    }

    [Fact]
    public void ShouldFailOnTooLargeList_List1() {
        var x = new AddTwoNumbers();
        var l1 = GenerateListNode(101, 9);
        var l2 = GenerateListNode(10, 9);
        Assert.Throws<Exception>(() => x.Solve(l1, l2));
    }

    [Fact]
    public void ShouldAbleToPerformUnequalLengthAddition_List1Shorter() {
        var x = new AddTwoNumbers();
        var l1 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))));
        var l2 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))))));
        var expected = new ListNode(8, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(1))))))));
        var actual = x.Solve(l1, l2);
        AssertListNodeEquals(expected, actual);
    }

    [Fact]
    public void ShouldAbleToPerformUnequalLengthAddition_List2Shorter() {
        var x = new AddTwoNumbers();
        var l1 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))))));
        var l2 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))));
        var expected = new ListNode(8, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(1))))))));
        var actual = x.Solve(l1, l2);
        AssertListNodeEquals(expected, actual);
    }

    [Fact]
    public void ShouldAbleToPerformThreeDigitsAddition_CasadeCarryOver() {
        var x = new AddTwoNumbers();
        var l1 = new ListNode(9, new ListNode(9, new ListNode(9)));
        var l2 = new ListNode(9, new ListNode(9, new ListNode(9)));
        var expected = new ListNode(8, new ListNode(9, new ListNode(9, new ListNode(1))));
        var actual = x.Solve(l1, l2);
        AssertListNodeEquals(expected, actual);
    }

    [Fact]
    public void ShouldAbleToPerformDoubleDigitsAddition_SingleCarryOver() {
        var x = new AddTwoNumbers();
        var l1 = new ListNode(4, new ListNode(3));
        var l2 = new ListNode(7, new ListNode(4));
        var expected = new ListNode(1, new ListNode(8));
        var actual = x.Solve(l1, l2);
        AssertListNodeEquals(expected, actual);
    }

    [Fact]
    public void ShouldAbleToPerformDoubleDigitsAddition_NoCarryOver() {
        var x = new AddTwoNumbers();
        var l1 = new ListNode(2, new ListNode(3));
        var l2 = new ListNode(3, new ListNode(4));
        var expected = new ListNode(5, new ListNode(7));
        var actual = x.Solve(l1, l2);
        AssertListNodeEquals(expected, actual);
    }

    [Fact]
    public void ShouldAbleToPerformSingleDigitAddition_TwoDigitsResult() {
        var x = new AddTwoNumbers();
        var l1 = new ListNode(9);
        var l2 = new ListNode(9);
        var expected = new ListNode(8, new ListNode(1));
        var actual = x.Solve(l1, l2);
        AssertListNodeEquals(expected, actual);
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

    [Fact]
    public void ShouldAbleToPerformSingleDigitAddition_Default() {
        var x = new AddTwoNumbers();
        var l1 = new ListNode();
        var l2 = new ListNode();
        var expected = new ListNode();
        var actual = x.Solve(l1, l2);
        Assert.Equal(expected.val, actual.val);
    }

    private static ListNode GenerateListNode(int numDigits, int digitValue) {
        var head = new ListNode(digitValue);
        var current = head;
        for (int i = 1; i < numDigits; i++) {
            current.next = new ListNode(digitValue);
            current = current.next;
        }
        return head;
    }

    private long CountList(ListNode? list) {
        var count = 0;
        while (list != null) {
            count++;
            list = list.next;
        }
        output.WriteLine($"count:{count}");
        return count;
    }

    private void PrintList(ListNode? list) {
        var numList = new List<int>();
        while (list != null) {
            numList.Add(list.val);
            list = list.next;
        }
        var outputTxt = $"[{string.Join(",", numList)}]";
        output.WriteLine(outputTxt);
    }

    private void AssertListNodeEquals(ListNode? expected, ListNode? actual) {
        Assert.Equal(CountList(expected), CountList(actual));

        while (expected != null && actual != null) {
            Assert.Equal(expected.val, actual.val);
            expected = expected.next;
            actual = actual.next;
        }
    }
}