
namespace NumberGuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            IRandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();
            IInputValidator inputValidator = new GuessInputValidator();
            IFeedbackProvider feedbackProvider = new FeedbackProvider();

            NumberGuessingGame game = new NumberGuessingGame(
                randomNumberGenerator,
                inputValidator,
                feedbackProvider
            );

            game.Start();
        }
    }

    interface IRandomNumberGenerator
    {
        int Generate(int min, int max);
    }

    interface IInputValidator
    {
        bool IsValid(string input);
    }

    interface IFeedbackProvider
    {
        string GetFeedback(int guess, int target);
    }


    class RandomNumberGenerator : IRandomNumberGenerator
    {
        private readonly Random random = new Random();

        public int Generate(int min, int max)
        {
            return random.Next(min, max + 1);
        }
    }

    class GuessInputValidator : IInputValidator
    {
        public bool IsValid(string input)
        {
            return int.TryParse(input, out int value)
                   && value >= 1
                   && value <= 100;
        }
    }

    class FeedbackProvider : IFeedbackProvider
    {
        public string GetFeedback(int guess, int target)
        {
            if (guess < target)
                return "Too low. Guess again: ";

            if (guess > target)
                return "Too high. Guess again: ";

            return "Correct";
        }
    }

    class NumberGuessingGame
    {
        private readonly IRandomNumberGenerator randomNumberGenerator;
        private readonly IInputValidator inputValidator;
        private readonly IFeedbackProvider feedbackProvider;

        private const int MinNumber = 1;
        private const int MaxNumber = 100;

        public NumberGuessingGame(
            IRandomNumberGenerator randomNumberGenerator,
            IInputValidator inputValidator,
            IFeedbackProvider feedbackProvider)
        {
            this.randomNumberGenerator = randomNumberGenerator;
            this.inputValidator = inputValidator;
            this.feedbackProvider = feedbackProvider;
        }

        public void Start()
        {
            int targetNumber = randomNumberGenerator.Generate(MinNumber, MaxNumber);
            int attemptCount = 0;
            string promptMessage = $"Guess a number between {MinNumber} and {MaxNumber}: ";

            while (true)
            {
                int guess = ReadValidGuess(promptMessage);
                attemptCount++;

                string feedback = feedbackProvider.GetFeedback(guess, targetNumber);

                if (feedback == "Correct")
                {
                    Console.WriteLine($"You guessed the number in {attemptCount} attempts.");
                    break;
                }

                promptMessage = feedback;
            }
        }

        private int ReadValidGuess(string promptMessage)
        {
            Console.Write(promptMessage);
            string userInput = Console.ReadLine();

            while (!inputValidator.IsValid(userInput))
            {
                Console.Write("Invalid input. Enter a number between 1 and 100: ");
                userInput = Console.ReadLine();
            }

            return int.Parse(userInput);
        }
    }
}
