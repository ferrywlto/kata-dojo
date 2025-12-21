public class Q1910_RemoveAllOccurencesOfSubstring(ITestOutputHelper output)
{
    public string RemoveOccurrences(string s, string part)
    {
        var len = part.Length;
        var matchCount = 0;
        var stackUnseen = new Stack<char>();
        foreach(var c in s.ToArray().Reverse()) stackUnseen.Push(c);

        var stackSeen = new Stack<char>();

        while(stackUnseen.Count > 0)
        {
            var current = stackUnseen.Pop();
            output.WriteLine($"current: {current}, matchCount: {matchCount}, part: {part[matchCount]}");
            if(current == part[matchCount])
            { 
                stackSeen.Push(current);      

                if(matchCount == len - 1)
                {
                    // stackSeen.Push(')');
                    for(var i = 0; i < len; i++) stackSeen.Pop();
                    output.WriteLine($"pop back: {string.Join("", stackSeen.ToArray().Reverse())}");
                    // while(stackSeen.Count > 0 && stackSeen.Peek() != part[0])
                    // {
                    //     stackUnseen.Push(stackSeen.Pop());
                    // }
                    // if(stackSeen.Count > 0 && stackSeen.Peek() == part[0])
                    //     matchCount = 1;
                    // else 
                    //     matchCount = 0;
                    while(stackSeen.Count > 0)
                    {
                        stackUnseen.Push(stackSeen.Pop());
                    }
                    matchCount = 0;                    
                }
                else
                {   
                    output.WriteLine($"progress: {matchCount}");          
                    matchCount++;
                }            
            }
            // else if(current == part[0])
            // {
            //     output.WriteLine($"reset - soft");
            //     stackSeen.Push(current);
            //     matchCount = 1;                
            // }
            else 
            {
                output.WriteLine($"reset - hard");
                stackSeen.Push(current);
                matchCount = 0;
                if(current == part[matchCount]) matchCount = 1;
            }
            output.WriteLine($"{string.Join("", stackSeen.ToArray().Reverse())}");
        }

        return string.Join("", stackSeen.ToArray().Reverse());
    }
    public static TheoryData<string, string, string> TestData => new()
    {
        {"daabcbaabcbc", "abc", "dab"},
        {"axxxxyyyyb", "xy", "ab"},
        {"gjzgbpggjzgbpgsvpwdk", "gjzgbpg", "svpwdk"},
        {"rrrzokrrrzoktbgnlerpstimuatbgnlerpstimuagdgtmfy", "rrrzoktbgnlerpstimua", "gdgtmfy"},
        {"kpygkivtlqoocskpygkpygkivtlqoocssnextkqzjpycbylkaondskivtlqoocssnextkqzjpycbylkaondssnextkqzjpycbylkaondshijzgaovndkjiiuwjtcpdpbkrfsi", "kpygkivtlqoocssnextkqzjpycbylkaonds", "hijzgaovndkjiiuwjtcpdpbkrfsi"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string substring, string expected)
    {
        var actual = RemoveOccurrences(input, substring);
        Assert.Equal(expected, actual);
    }
}
