using System.Security.Cryptography.X509Certificates;
using System.Xml.XPath;

namespace Math_Game_Exercise
{
    public class MathGameLogic {

        List<string> gameHistoryList = new List<string>();
        public void ShowMainMenu() {
            Console.Write("""
            1. Addition
            2. Subtraction
            3. Division
            4. Multiplication
            5. Game History
            """);
        }

        public void ValidateMainMenuInput() {
            string mainMenuOption = Console.ReadLine().Trim().ToLower();

            if (mainMenuOption != null) {
                switch (mainMenuOption.ToLower()) {
                    case "1":
                    case "addition":
                        ProblemSetConstructor(addition: true);
                        break;
                    case "2":
                    case "subtraction":
                        ProblemSetConstructor(subtraction: true);
                        break;
                    case "3":
                    case "division":
                        ValidateUserResult(ProblemSetConstructor(division: true));
                        break;
                    case "4":
                    case "multiplication":
                        ProblemSetConstructor(multiplication: true);
                        break;
                    case "5":
                    case "game history":
                        ShowGameHistory(gameHistoryList);
                        PlayAgain();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        ShowMainMenu();
                        ValidateMainMenuInput();
                        break;
                }
            } else {
                Console.WriteLine("Input cannot be empty. Please provide a valid option.");
                ShowMainMenu();
                ValidateMainMenuInput();
            }
        }

        public int ProblemSetConstructor(
        bool addition = false, bool subtraction = false, bool division = false, bool multiplication = false) {
            Random random = new Random();
            int numberOfGames = NumberOfGames();

            if (addition) {
                int addend1;
                int addend2;
                int result = 0;
                for (int i = 1; i <= numberOfGames; i++) {
                    addend1 = random.Next(0, 1000);
                    addend2 = random.Next(0, 1000);
                    Console.WriteLine($"What is {addend1} + {addend2}?");
                    gameHistoryList.Add($"{addend1} + {addend2} = {addend1 + addend2}");
                    result = addend1 + addend2;
                    ValidateUserResult(result);
                }

                PlayAgain();
                return result;

            } else if (subtraction) {
                int minuend;
                int subtrahend;
                int result = 0;
                for (int i = 1; i <= numberOfGames; i++) {
                    minuend = random.Next(0, 1000);
                    subtrahend = random.Next(0, 1000);
                    Console.WriteLine($"What is {minuend} - {subtrahend}?");
                    gameHistoryList.Add($"{minuend} - {subtrahend} = {minuend - subtrahend}");
                    result = minuend - subtrahend;
                    ValidateUserResult(result);
                }
                
                PlayAgain();
                return result;

            } else if (division) {
                int dividend;
                int divisor;
                int result = 0;
                for (int i = 1; i <= numberOfGames; i++) {
                    do {
                        dividend = random.Next(0, 101);
                        divisor = random.Next(1, 101);
                    } while (dividend % divisor != 0);

                    Console.WriteLine($"What is {dividend} / {divisor}?");
                    gameHistoryList.Add($"{dividend} / {divisor} = {dividend / divisor}");
                    result = dividend / divisor;
                    ValidateUserResult(result);
                }
                    
                PlayAgain();
                return result;
                
            } else if (multiplication) {
                int multiplicand;
                int multiplier;
                int result = 0;
                for (int i = 1; i <= numberOfGames; i++) {
                    multiplicand = random.Next(0, 101);
                    multiplier = random.Next(0, 101);
                    Console.WriteLine($"What is {multiplicand} * {multiplier}?");
                    gameHistoryList.Add($"{multiplicand} * {multiplier} = {multiplicand * multiplier}");
                    result = multiplicand * multiplier;
                    ValidateUserResult(result);
                }
                
                PlayAgain();
                return result;
            } else {
                return 0;
            }
        }
        public void ValidateUserResult(int result) {
            bool userResult = Int32.TryParse(Console.ReadLine().Trim(), out int userResultInt);
            if (userResult) {
                if (userResultInt == result) {
                    Console.WriteLine("Correct!");
                } else {
                    Console.WriteLine($"Wrong! The right answer is {result}.");
                }
            } else {
                Console.WriteLine("Please enter a number.");
                ValidateUserResult(result);
            }            
        }

        public void ShowGameHistory(List<string> gameHistoryList) {
            if (gameHistoryList.Count == 0) {
                Console.WriteLine("You haven't played any games yet.");
            } else {
                Console.WriteLine("Your previous games.");
                for (int i = 1; i <= gameHistoryList.Count(); i++) {
                    Console.WriteLine($"{i}. {gameHistoryList[i-1]}");
                }
            }
            

        }
        public void PlayAgain() {
            Console.WriteLine("Would you like to go to main menu Y/N");
            switch (Console.ReadLine().Trim().ToLower()) {
                case "yes":
                case "y":
                    ShowMainMenu();
                    ValidateMainMenuInput();
                    break;
                case "n":
                case "no":
                    break;
                default:
                    Console.WriteLine("Please enter a valid option.");
                    PlayAgain();
                    break;
            }
        }
        public int NumberOfGames() {
            Console.WriteLine("How many questions would you like to try?");
            bool userInput = Int32.TryParse(Console.ReadLine().Trim(), out int userInputInt);
            if (userInput) {
                return userInputInt;
            }
            else {
                return 1;
            }
        }
    }
}