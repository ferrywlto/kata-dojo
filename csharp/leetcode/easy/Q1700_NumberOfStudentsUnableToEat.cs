class Q1700_NumberOfStudentsUnableToEat
{
    // TC: O(n), where n is number of sandwiches
    // SC: O(n+m), where 2 queues are needed
    public int CountStudents(int[] students, int[] sandwiches)
    {
        var queueStudents = new Queue<int>(students);
        var queueSandwiches = new Queue<int>(sandwiches);
        var failedCount = 0;

        while (queueSandwiches.Count > 0 && failedCount < queueStudents.Count)
        {
            if (queueStudents.Peek() == queueSandwiches.Peek())
            {
                queueStudents.Dequeue();
                queueSandwiches.Dequeue();
                failedCount = 0;
            }
            else
            {
                queueStudents.Enqueue(queueStudents.Dequeue());
                failedCount++;
            }
        }
        return queueStudents.Count;
    }
}
class Q1700_NumberOfStudentsUnableToEatTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1,1,0,0}, new int[] {0,1,0,1}, 0],
        [new int[] {1,1,1,0,0,1}, new int[] {1,0,0,0,1,1}, 3],
        [new int[] {0,0,0,1,0,1,1,1,1,0,1}, new int[] {0,0,0,1,0,0,0,0,0,1,0}, 5],
    ];
}
public class Q1700_NumberOfStudentsUnableToEatTests
{
    [Theory]
    [ClassData(typeof(Q1700_NumberOfStudentsUnableToEatTestData))]
    public void OfficialTestCases(int[] students, int[] sandwiches, int expected)
    {
        var sut = new Q1700_NumberOfStudentsUnableToEat();
        var actual = sut.CountStudents(students, sandwiches);
        Assert.Equal(expected, actual);
    }
}
