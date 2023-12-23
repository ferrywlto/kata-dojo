namespace dojo.leetcode;
// It have to be per digit calculation in order to support 100 digits 
// The performance can be improved by not using recursion and short circuiting the calculation of unequal length lists
// Speed: 89ms (53.44%), Memory: 49.2MB(79.69%) 
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

public class AddTwoNumbersTests(ITestOutputHelper output) : ListNodeTest(output)
{
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
}