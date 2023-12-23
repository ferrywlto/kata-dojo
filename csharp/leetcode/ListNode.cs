using System.Security.Cryptography;

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

    public static ListNode? FromArray(int[] arr) 
    {
        if (arr.Length == 0)
            return null;

        var head = new ListNode(arr[0]);
        var current = head;
        for (int i = 1; i < arr.Length; i++) 
        {
            current.next = new ListNode(arr[i]);
            current = current.next;
        }
        return head;
    }
}
