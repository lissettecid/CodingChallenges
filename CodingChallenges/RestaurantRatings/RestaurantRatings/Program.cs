// See https://aka.ms/new-console-template for more information

    String line;
    line = Console.ReadLine();
    int N = Convert.ToInt32(line);
    int[][] ratings = new int[N][];
    for (int i_ratings = 0; i_ratings < N; i_ratings++)
    {
        line = Console.ReadLine();
        ratings[i_ratings] = line.Split().Select(str => int.Parse(str)).ToArray();
    }
    int out_ = solution(N, ratings);
    Console.Out.WriteLine(out_);

static int solution(int N, int[][] ratings)
{
    // You must complete the logic for the function that is provided
    // before compiling or submitting to avoid an error.
    // Write your code here
    
}