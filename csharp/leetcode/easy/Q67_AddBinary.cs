public class Q67_AddBinaryTests {
    [Theory]
    [InlineData("11", "1", "100")]
    [InlineData("1010", "1011", "10101")]
    public void OfficialTestCases(string a, string b, string expected) {
        var sut = new Q67_AddBinary();
        Assert.Equal(expected, sut.AddBinary(a, b));
    }

    [Theory]
    [InlineData("0", "0", "0")]
    [InlineData("0", "1", "1")]
    [InlineData("1", "0", "1")]
    [InlineData("1", "1", "10")]
    public void ExtraTestCases(string a, string b, string expected) {
        var sut = new Q67_AddBinary();
        Assert.Equal(expected, sut.AddBinary(a, b));
    }
}

/*
Constraints:

1 <= a.length, b.length <= 104
a and b consist only of '0' or '1' characters.
Each string does not contain leading zeros except for the zero itself.
*/
public class Q67_AddBinary {
    // Speed: 51ms (99.39%), Memory: 40.08MB (44.57%)
    public string AddBinary(string a, string b) {
        string shorterStr;
        string longerStr; 
        if (a.Length >= b.Length) {
            longerStr = a;
            shorterStr = b;
        }
        else {
            longerStr = b;
            shorterStr = a;
        }
        var result = new char[longerStr.Length];

        bool carryOver = false;
        
        for (int i=1; i<=shorterStr.Length; i++) {
            
            if (carryOver) {
                if (shorterStr[^i] == '0' && longerStr[^i] == '0') {
                    result[^i] = '1';
                    carryOver = false;
                } 
                else if (shorterStr[^i] == '1' && longerStr[^i] == '1') {
                    result[^i] = '1';
                    carryOver = true;
                }
                else {
                    result[^i] = '0';
                    carryOver = true;
                }
            }
            else {
                if (shorterStr[^i] == '0' && longerStr[^i] == '0') {
                    result[^i] = '0';
                    carryOver = false;
                } 
                else if (shorterStr[^i] == '1' && longerStr[^i] == '1') {
                    result[^i] = '0';
                    carryOver = true;
                }
                else {
                    result[^i] = '1';
                    carryOver = false;
                }
            }
        }

        var diff = longerStr.Length - shorterStr.Length;
        if (diff > 0) {
            for (int j= diff-1; j>=0; j--) {
                if(carryOver) {
                    if (longerStr[j]=='0')
                    {
                        result[j] = '1';
                        carryOver = false;
                    }
                    else {
                        result[j] = '0';
                        carryOver = true;
                    }
                } else {
                    result[j] = longerStr[j];
                }
            }        
        }

        if (!carryOver)
            return new string(result);
        else {
            char[] x = new char[result.Length+1];
            Array.Copy(result, 0, x, 1, result.Length);
            x[0] = '1';
            return new string(x);
        }
    }
}