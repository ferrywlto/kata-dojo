namespace dojo.leetcode
{
    public class LeetCodeTestData: IEnumerable<object[]>
    {
        protected virtual List<object[]> Data(){ return [];}

        public IEnumerator<object[]> GetEnumerator() => Data().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}