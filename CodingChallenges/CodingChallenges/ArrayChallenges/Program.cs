
Main();

static void Main()
{
    var matrix = new int[][] {
    new int[] {1, 2, 3},
    new int[] {4, 5, 6},
    new int[] {7, 8, 9}
    };

    RotateMatrix(matrix);
}

static int RemoveDuplicates(int[] nums)
{
    if (nums.Length == 0) return 0;

    int writeIndex = 1;

    for (int readIndex = 1; readIndex < nums.Length; readIndex++)
    {
        if (nums[readIndex] != nums[readIndex - 1])
        {
            nums[writeIndex] = nums[readIndex];
            writeIndex++;
        }
    }

    return writeIndex;
}

static int MaxProfit(int[] prices)
{
    int profit = 0;
    int boughtPrice = -1;

    for (int i = 0; i < prices.Length; i++)
    {
        int current = prices[i];

        if ((i == prices.Length - 1))
        {
            if (boughtPrice != -1)
                profit += current - boughtPrice;
            break;
        }

        if (current > prices[i + 1])
        {
            if (boughtPrice > -1)
            {
                profit += current - boughtPrice;
                boughtPrice = -1;
            }
            continue;
        }

        if (boughtPrice == -1)
        {
            boughtPrice = current;
        }
    }

    return profit;
}

static void Rotate(int[] nums, int k)
{
    if (nums == null || nums.Length == 0 || k <= 0)
        return;

    int n = nums.Length;
    k %= n;
    if (k == 0)
        return;

    Reverse(nums, 0, n - 1);
    Reverse(nums, 0, k - 1);
    Reverse(nums, k, n - 1);
}

static void Reverse(int[] nums, int start, int end)
{
    while (start < end)
    {
        int temp = nums[start];
        nums[start] = nums[end];
        nums[end] = temp;
        start++;
        end--;
    }
}

static bool ContainsDuplicate(int[] nums)
{
    if (nums == null || nums.Length == 0)
        return false;

    var numsWithoutDups = nums.ToHashSet();
    
    var result = numsWithoutDups.Count != nums.Length ? true : false;

    return result;
}

static int SingleNumber(int[] nums)
{
    foreach (var num in nums)
    {
        int count = 0;
        foreach (var num2 in nums) 
        { 
            if (num == num2)
                count++;
        }

        if (count == 1)
            return num;
    }

    return -1;
}

static int[] Intersect(int[] nums1, int[] nums2)
{
    var ocurrence = new Dictionary<int, int>();
    foreach (int number in nums1)
    {
        if (ocurrence.ContainsKey(number))
            ocurrence[number]++;
        else
            ocurrence[number] = 1;
    }

    var returnList = new List<int>();
    var counter = 0;
    foreach (int number in nums2)
    {
        if (ocurrence.ContainsKey(number))
        {
            if (ocurrence[number] > 0) 
            {
                returnList.Add(number);
                ocurrence[number]--;
                counter++;
            }
        }
    }

    return returnList.ToArray();
}

static int[] PlusOne(int[] digits)
{
    int n = digits.Length;

    for (int i = n - 1; i >= 0; i--)
    {
        if (digits[i] < 9)
        {
            digits[i]++;
            return digits;
        }
        
        digits[i] = 0;
    }

    var result = new int[n + 1];
    result[0] = 1; 
    return result;
}

static void MoveZeroes(int[] nums)
{
    int index = 0;

    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] != 0) 
        {
            nums[index] = nums[i];
            index++;
            continue;
        }
    }

    while (index < nums.Length)
    {
        nums[index] = 0;
        index++;
    };
}

static int[] TwoSum(int[] nums, int target)
{
    int[] sumIndexes = new int[2];
    for (int i = 0; i < nums.Length; i++)
    {
        int search = target - nums[i];
        if (nums.Contains(search))
        {
            int index2 = Array.IndexOf(nums, search);
            if (index2 == i)
                continue;

            sumIndexes[0] = i;
            sumIndexes[1] = index2;
            break;
        }
    }

    return sumIndexes;
}

static bool IsValidSudoku(char[][] board)
{
    HashSet<char>[] rows = new HashSet<char>[9];
    HashSet<char>[] cols = new HashSet<char>[9];
    HashSet<char>[] boxes = new HashSet<char>[9];

    for (int i = 0; i < 9; i++)
    {
        rows[i] = new HashSet<char>();
        cols[i] = new HashSet<char>();
        boxes[i] = new HashSet<char>();
    }

    for (int r = 0; r < 9; r++)
    {
        for (int c = 0; c < 9; c++)
        {
            if (board[r][c] == '.') 
                continue;

            char num = board[r][c];
            int boxIndex = (r / 3) * 3 + c / 3;

            if (rows[r].Contains(num) || cols[c].Contains(num) || boxes[boxIndex].Contains(num))
            {
                return false;
            }

            rows[r].Add(num);
            cols[c].Add(num);
            boxes[boxIndex].Add(num);
        }
    }

    return true;
}

static void RotateMatrix(int[][] matrix)
{
    int n = matrix.Length;

    for (int r = 0; r < n; r++)
    {
        for (int c = r + 1; c < n; c++)
        {
            int temp = matrix[r][c];
            matrix[r][c] = matrix[c][r];
            matrix[c][r] = temp;
        }
    }

    for (int i = 0; i < n; i++)
    {
        Array.Reverse(matrix[i]);
    }
}