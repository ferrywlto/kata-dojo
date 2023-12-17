namespace dojo.leetcode;

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xunit;


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
    [Theory]
    [ClassData(typeof(AddTwoNumbersTestData))]
    public void AddTwoNumbersTest(int input1, int input2, int input3)
    {
        var subject = new AddTwoNumbers();
        var l1 = subject.NumToList(input1);
        var l2 = subject.NumToList(input2);
        var expectedList = subject.NumToList(input3);
        var actualList = subject.Solve(l1, l2);

        var expected = subject.ListToNum(expectedList);
        var actual = subject.ListToNum(actualList);
        Console.WriteLine($"Q2: AddTwoNumbersTest: expected:{expected} actual:{actual}");
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(243)]
    [InlineData(564)]
    [InlineData(708)]
    [InlineData(0)]
    [InlineData(9999999)]
    public void ShouldAbleToTransfromBetweenListAndNum(int input) {
        var x = new AddTwoNumbers();
        var list = x.NumToList(input);
        var num = x.ListToNum(list); 
        Console.WriteLine($"Q2: ShouldAbleToTransfromBetweenListAndNum concat:{AddTwoNumbers.Concat(list)}  toNum:{num}");
        Assert.Equal(input, num);
    }
}


  public class ListNode {
      public int val;
      public ListNode? next;
      public ListNode(int val=0, ListNode? next=null) {
          this.val = val;
          this.next = next;
      }
  }

public class AddTwoNumbers {
    // public static void ValidateInput(LinkedList<byte> input)  {
    //     if ((input.Count == 0) || (input.Count > 100)) 
    //         throw new Exception("List size should be between 1-100");

    //     var invalid = input.FirstOrDefault(i => i < 0 || i > 9);
        
    //     if (invalid != default) 
    //         throw new Exception("Number should within 0-9");
    // }
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

    public static string Concat(ListNode? input) {
        if (input == null) 
            return string.Empty;
        
        var buffer = new StringBuilder();
        var current = input;
        do {
            buffer.Append(input.val);
            input = input.next;
        } while (input != null);
        
        return buffer.ToString();
    }

    // public LinkedList<byte> Solve(LinkedList<byte> list1, LinkedList<byte> list2) {
    //     ValidateInput(list1);
    //     ValidateInput(list2);

    //     var num1 = ListToInt(list1);
    //     var num2 = ListToInt(list2);
    //     var sum = num1 + num2;
    //     var sumInText = sum.ToString();
    //     var sumInList = StringToList(sumInText);
    //     return sumInList;
    // }
    public long ListToNum(ListNode? input) {
        var @string = Concat(input);
        Console.WriteLine($"Q2 ListToNum1: {@string}");
        var reversed = @string.Reverse();
        @string = string.Join(string.Empty, reversed);
        Console.WriteLine($"Q2 ListToNum2: {@string}");
        return long.Parse(@string);
    }


    public ListNode NumToList(long input) {
        var numInText = input.ToString();
        var lastDigit = int.Parse(numInText[0].ToString());
        var lastNode = new ListNode(lastDigit);

        for (var i = 1; i < numInText.Length; i++) {
            var currentNum = int.Parse(numInText[i].ToString());
            var currentNode = new ListNode(currentNum, lastNode);
            lastNode = currentNode;
        }

        return lastNode;
    }

    public ListNode Solve(ListNode l1, ListNode l2) {
        if (!ValidateInput(l1) || !ValidateInput(l2))
            return new ListNode(0);
        
        var num1 = ListToNum(l1);
        var num2 = ListToNum(l2);

        var sum = num1 + num2;
        Console.WriteLine($"Q2: Solve: sum: ${sum}");
        var sumInList = NumToList(sum);
        
        return sumInList;
    }

    // public static uint ListToInt(LinkedList<byte> input) {
    //     var reversed = input.Reverse();
    //     var numInText = string.Join(string.Empty, reversed.Select(i => i.ToString()).ToArray());
    //     return uint.Parse(numInText);
    // }

    // public static LinkedList<byte> StringToList(string input) {
    //     var list = new LinkedList<byte>();
    //     foreach (var c in input) {
    //         list.AddFirst(byte.Parse(c.ToString()));
    //     }
    //     return list;
    // } 
}