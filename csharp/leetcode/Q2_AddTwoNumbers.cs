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
    /// <summary>
    /// It doesn't have to check for null as the question stated the list will never be empty, just keep it until performance optimization stage 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public static bool ValidateInput(ListNode? input, int count = 1)  {
        if (input == null || count > 100 || !IsValidNumber(input)) {
            throw new Exception($"Q2: validation failed, count:{count} input:{input?.val}");
        }
        else if (input.next == null) // last node
            return true;
        else
            return ValidateInput(input.next, count+1);
    }

    public static bool IsValidNumber(ListNode input) => input.val is >= 0 and <= 9;

    public ListNode Solve(ListNode l1, ListNode l2) {
        if (!ValidateInput(l1) || !ValidateInput(l2))
            throw new Exception("Invalid input");
        
        var sumList = new ListNode();

        Recursion(l1, l2, sumList);
        return sumList;
    }

    public void Recursion(ListNode? l1, ListNode? l2, ListNode current, bool carryOver = false) {
        if(l1 != null && l2 != null) {
            var sum = l1.val + l2.val;
            if (carryOver)
                sum += 1;
            var reminder = sum % 10;
            current!.val = reminder;
            if (l1.next != null || l2.next != null) {
                current.next = new ListNode();
                Recursion(l1.next, l2.next, current.next, sum >= 10);
            }
            else if (sum >= 10) {
                current.next = new ListNode(1);
            }
        }
        else if(l1 != null && l2 == null) {
            var sum = l1.val;
            if (carryOver)
                sum += 1;
            var reminder = sum % 10;
            current!.val = reminder;
            if (l1.next != null) {
                current.next = new ListNode();
                Recursion(l1.next, null, current.next, sum >= 10);
            }
            else if (sum >= 10) {
                current.next = new ListNode(1);
            }
        }
        else if(l1 == null && l2 != null) {
            var sum = l2.val;
            if (carryOver)
                sum += 1;
            var reminder = sum % 10;
            current!.val = reminder;
            if (l2.next != null) {
                current.next = new ListNode();
                Recursion(null, l2.next, current.next, sum >= 10);
            }
            else if (sum >= 10) {
                current.next = new ListNode(1);
            }
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