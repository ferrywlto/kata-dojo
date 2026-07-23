public class Q3975_FilterOccupiedIntervals(ITestOutputHelper output)
{
    // TC: O(n)
    // SC: O(n), for storing result, worst case all intervals are included.
    public IList<IList<int>> FilterOccupiedIntervals(int[][] occupiedIntervals, int freeStart, int freeEnd)
    {
        Array.Sort(occupiedIntervals, (a, b) =>
        {
            if (a[0] > b[0]) return 1;
            if (a[0] < b[0]) return -1;
            if (a[1] > b[1]) return 1;
            if (a[1] < b[1]) return -1;
            return 0;
        });

        var lastStart = occupiedIntervals[0][0];
        var lastEnd = occupiedIntervals[0][1];
        var merged = new List<IList<int>>(occupiedIntervals.Length);

        // shrink each interval within free period
        for (var i = 1; i < occupiedIntervals.Length; i++)
        {
            var interval = occupiedIntervals[i];

            // means a new interval
            if (interval[0] > lastEnd + 1)
            {
                // further shrink before adding
                // interval start later then free period end, continue
                // interval end earlier than free period start, continue
                if(lastStart > freeEnd || lastEnd < freeStart)
                {
                    merged.Add([lastStart, lastEnd]);
                }
                else if (lastStart < freeStart && lastEnd > freeEnd)
                {
                    merged.Add([lastStart, freeStart - 1]);
                    merged.Add([freeEnd + 1, lastEnd]);
                }
                else if (lastStart < freeStart)
                {
                    merged.Add([lastStart, Math.Min(lastEnd, freeStart - 1)]);
                }
                else if(lastEnd > freeEnd)
                {
                    merged.Add([Math.Max(lastStart, freeEnd + 1), lastEnd]);
                }

                lastStart = interval[0];
            }
            lastEnd = Math.Max(lastEnd, interval[1]);
        }

        if (lastStart > freeEnd || lastEnd < freeStart)
        {
            merged.Add([lastStart, lastEnd]);
        }
        else if (lastStart < freeStart && lastEnd > freeEnd)
        {
            merged.Add([lastStart, freeStart - 1]);
            merged.Add([freeEnd + 1, lastEnd]);
        }
        else if (lastStart < freeStart)
        {
            merged.Add([lastStart, Math.Min(lastEnd, freeStart - 1)]);
        }
        else if (lastEnd > freeEnd)
        {
            merged.Add([Math.Max(lastStart, freeEnd + 1), lastEnd]);
        }

        output.WriteLine($"{string.Join(',', merged.Select(p => $"[{p[0]}, {p[1]}]"))}");
        return merged;
    }

    public static TheoryData<int[][], int, int, List<List<int>>> TestData => new()
    {
        {
            [[2, 6], [4, 8], [10, 10], [10, 12], [14, 16]], 7, 11, [[2, 6], [12, 12], [14, 16]]
        },
        {
            [[1, 5], [2, 3]], 3, 8, [[1, 2]]
        },
        { [[1, 1], [2, 2]], 100, 100, [[1, 2]] },
        { [[1,3]], 2,2, [[1,1],[3,3]]},
        { [[48, 57],[58,99],[76,80]], 58, 86, [[48,57],[87,99]]}
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int start, int end, List<List<int>> expected)
    {
        var actual = FilterOccupiedIntervals(input, start, end);
        Assert.Equal(expected, actual);
    }
}
