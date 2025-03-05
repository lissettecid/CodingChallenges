using System.Text.RegularExpressions;

Main();

static void Main()
{
    LongestCommonPrefix(["flower", "flow", "flight"]);
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
    var charCount = new Dictionary<char, int>();

    foreach (char c in s)
    {
        if (charCount.ContainsKey(c))
            charCount[c]++;
        else 
            charCount[c] = 1;
    }

    for (int i = 0; i < s.Length; i++)
    {
        if (charCount[s[i]] == 1)
            return i;
    }

    return -1;
}

static bool IsAnagram(string s, string t)
{
    var charSource = new Dictionary<char, int>();
    var charDestination = new Dictionary<char, int>();

    foreach(char c in s)
    {
        if (charSource.ContainsKey(c))
            charSource[c]++;
        else
            charSource[c] = 1;
    }

    foreach (char c in t)
    {
        if (charDestination.ContainsKey(c))
            charDestination[c]++;
        else
            charDestination[c] = 1;
    }

    bool areEqual = charSource.Count == charDestination.Count &&
                        charSource.All(pair => charDestination.TryGetValue(pair.Key, out var value) && value == pair.Value);

    return areEqual;
}

static bool IsPalindrome(string s)
{
    s = s.ToLower();
    s = Regex.Replace(s, "[^a-zA-Z0-9]", "");

    var original = s.ToCharArray();
    var reversed = s.ToCharArray();
    Array.Reverse(reversed);

    if (original.SequenceEqual(reversed))
        return true;

    return false;
}

static int MyAtoi(string s)
{
    s = s.Trim();
    if (s.Length == 0) return 0;

    int sign = 1;
    int index = 0;
    if (s[0] == '-')
    {
        sign = -1;
        index++;
    }
    else if (s[0] == '+')
    {
        index++;
    }

    long result = 0;
    while (index < s.Length && char.IsDigit(s[index]))
    {
        result = result * 10 + (s[index] - '0');

        if (result * sign <= int.MinValue) return int.MinValue;
        if (result * sign >= int.MaxValue) return int.MaxValue;

        index++;
    }

    return (int)(result * sign);
}

static int StrStr(string haystack, string needle)
{
    return haystack.IndexOf(needle);
}

static string LongestCommonPrefix(string[] strs)
{
    if (strs == null || strs.Length == 0)
        return "";

    string prefix = strs[0];

    for (int i = 1; i < strs.Length; i++)
    {
        while (!strs[i].StartsWith(prefix))
        {
            prefix = prefix.Substring(0, prefix.Length - 1);
            if (string.IsNullOrEmpty(prefix))
                return "";
        }
    }

    return prefix;
}