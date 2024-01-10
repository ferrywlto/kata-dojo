namespace dojo.leetcode
{
    public class TestDataBase: IEnumerable<object[]>
    {
        protected virtual List<object[]> Data => [];

        public IEnumerator<object[]> GetEnumerator() => Data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}