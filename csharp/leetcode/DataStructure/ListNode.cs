public class ListNode(int val = 0, ListNode? next = null)
{
    public int _val = val;
    public ListNode? _next = next;

    public static ListNode? FromArray(int[] arr) 
    {
        if (arr.Length == 0)
            return null;

        var head = new ListNode(arr[0]);
        var current = head;
        for (var i = 1; i < arr.Length; i++) 
        {
            current._next = new ListNode(arr[i]);
            current = current._next;
        }
        return head;
    }

    public static int[] ToArray(ListNode head)
    {
        var list = new List<int>();
        var current = head;
        while(current != null)
        {
            list.Add(current._val);
            current = current._next;
        }
        return list.ToArray();
    }
}