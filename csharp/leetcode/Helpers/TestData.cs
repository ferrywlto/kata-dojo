using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public abstract class TestData : IEnumerable<object?[]>
{
    protected abstract List<object[]> Data { get; }

    public IEnumerator<object[]> GetEnumerator() => Data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
