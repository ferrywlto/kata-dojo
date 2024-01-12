namespace dojo.leetcode
{
    public class TestData: IEnumerable<object[]>
    {
        protected virtual List<object[]> Data => [];

        public IEnumerator<object[]> GetEnumerator() => Data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}