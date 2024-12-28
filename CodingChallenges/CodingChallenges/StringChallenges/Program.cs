Main();

static void Main()
{
    Console.WriteLine(Reverse(1534236469));
}

static void ReverseString(char[] s)
{
    Array.Reverse(s);
}

static int Reverse(int x)
{
    string reversedNum = "";
    var numAsString = x.ToString();

    for (int i = numAsString.Length - 1; i > -1; i--)
    {
        if (numAsString[i] == '-')
            continue;

        reversedNum += numAsString[i];
    }

    int.TryParse(reversedNum, out int result);
    if (numAsString[0] == '-')
        result *= -1;

    return result;
}

static int FirstUniqChar(string s)
{
    for (int i = 0; i < s.Length; i++)
    {
        int count = 0;
        for (int j = 0; j < s.Length; j++)
        {
            if (s[i] == s[j])
                count++;
        }

        if (count == 1)
            return i;
    }

    return -1;
}