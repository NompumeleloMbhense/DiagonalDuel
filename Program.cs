namespace DiagonalDuel;

class Program
{
    static Random random = new Random(); // Random number generator

    public static int DiagonalDifference(List<List<int>> matrix)
    {
        int n = matrix.Count;
        int leftSum = 0;
        int rightSum = 0;

        for (int i = 0; i < n; i++)
        {
            leftSum += matrix[i][i];
            rightSum += matrix[i][n - 1 - i];
        }

        return Math.Abs(leftSum - rightSum);
    }


    public static List<List<int>> GenerateRandomMatrix(int size)
    {
        List<List<int>> matrix = new List<List<int>>();

        for (int i = 0; i < size; i++)
        {
            List<int> row = new List<int>();

            for (int j = 0; j < size; j++)
            {
                row.Add(random.Next(1, 10));
            }
            matrix.Add(row);
        }

        return matrix;
    }

    public static void PrintMatrix(List<List<int>> matrix)
    {
        for (int i = 0; i < matrix.Count; i++)
        {
            for (int j = 0; j < matrix[i].Count; j++)
            {
                Console.Write(matrix[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void Main(string[] args)
    {
        int score = 0;
        int round = 1;
        int maxRounds = 5;

        Console.WriteLine("Welcome to Diagnonal Duel");
        Console.WriteLine("---------------------------");

        while (round <= maxRounds)
        {
            Console.WriteLine($"Round {round} of {maxRounds}");

            int size = random.Next(2, 6);
            var matrix = GenerateRandomMatrix(size);
            Console.WriteLine($"\nMatrix Size: ({size} x {size})");
            PrintMatrix(matrix);

            Console.WriteLine("\nGuess the absolute diagonal difference of the matrix:");
            int userGuess = Convert.ToInt32(Console.ReadLine());

            int correctAnswer = DiagonalDifference(matrix);

            int difference = Math.Abs(userGuess - correctAnswer);

            if (difference == 0)
            {
                Console.WriteLine("Perfect guess!");
                score += 2;
            }
            else if (difference <= 2)
            {
                Console.WriteLine($"Almost there! You were off by {difference}.");
                score += 1;
            }
            else
            {
                Console.WriteLine("Too far off! Better luck next time.");
            }

            Console.WriteLine($"Current Score: {score}");
            Console.WriteLine("-------------------------");


            round++;

            if (round <= maxRounds)
            {
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
            }

        }

        Console.WriteLine($"\nGame over! Your final score is {score}.");
        Console.WriteLine("Thank you for playing Diagnonal Duel!");
    }
}
