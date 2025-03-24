public class ListNode(int val = 0, ListNode? next = null)
{
    public int Val { get; set; } = val;
    public ListNode? Next { get; set; } = next;

    public static ListNode? FromArray(int[] arr) 
    {
        if (arr.Length == 0)
            return null;

        var head = new ListNode(arr[0]);
        var current = head;
        for (var i = 1; i < arr.Length; i++) 
        {
            current.Next = new ListNode(arr[i]);
            current = current.Next;
        }
        return head;
    }

    public static int[] ToArray(ListNode head)
    {
        var list = new List<int>();
        var current = head;
        while(current != null)
        {
            list.Add(current.Val);
            current = current.Next;
        }
        return list.ToArray();
    }
}