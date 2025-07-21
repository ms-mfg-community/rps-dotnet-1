using System;
using System.Collections.Generic;

class Program
{
    enum Move { Rock = 1, Paper, Scissors }

    static void Main()
    {
        int userScore = 0, computerScore = 0, draws = 0;
        var history = new List<string>();
        var random = new Random();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1. Play Rock, Paper, Scissors");
            Console.WriteLine("2. View Game History");
            Console.WriteLine("3. View Score");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option (1-4): ");
            string menuInput = Console.ReadLine()?.Trim();

            switch (menuInput)
            {
                case "1":
                    Console.WriteLine("\nEnter your move: (1) Rock, (2) Paper, (3) Scissors, (b) Back to Menu, (q) Quit");
                    bool inGame = true;
                    while (inGame)
                    {
                        Console.Write("\nYour move: ");
                        string input = Console.ReadLine()?.Trim().ToLower();

                        if (input == "b")
                        {
                            break;
                        }
                        if (input == "q")
                        {
                            running = false;
                            inGame = false;
                            Console.WriteLine("\nExiting game. Goodbye!");
                            break;
                        }

                        if (!int.TryParse(input, out int userMoveInt) || userMoveInt < 1 || userMoveInt > 3)
                        {
                            Console.WriteLine("Invalid input. Please enter 1, 2, 3, b, or q.");
                            continue;
                        }

                        Move userMove = (Move)userMoveInt;
                        Move computerMove = (Move)random.Next(1, 4);

                        string result;
                        if (userMove == computerMove)
                        {
                            result = "Draw";
                            draws++;
                        }
                        else if ((userMove == Move.Rock && computerMove == Move.Scissors) ||
                                 (userMove == Move.Paper && computerMove == Move.Rock) ||
                                 (userMove == Move.Scissors && computerMove == Move.Paper))
                        {
                            result = "You Win";
                            userScore++;
                        }
                        else
                        {
                            result = "Computer Wins";
                            computerScore++;
                        }

                        string roundSummary = $"You: {userMove} | Computer: {computerMove} => {result}";
                        history.Add(roundSummary);
                        Console.WriteLine(roundSummary);
                        Console.WriteLine($"Score - You: {userScore}, Computer: {computerScore}, Draws: {draws}");

                        // Prompt after each round
                        while (true)
                        {
                            Console.Write("\nWhat would you like to do next? (p)lay again, (b)ack to menu, (q)uit: ");
                            string nextAction = Console.ReadLine()?.Trim().ToLower();
                            if (nextAction == "p")
                            {
                                break; // Play again
                            }
                            else if (nextAction == "b")
                            {
                                inGame = false;
                                break;
                            }
                            else if (nextAction == "q")
                            {
                                running = false;
                                inGame = false;
                                Console.WriteLine("\nExiting game. Goodbye!");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter p, b, or q.");
                            }
                        }
                    }
                    break;

                case "2":
                    Console.WriteLine("\n--- Game History ---");
                    if (history.Count == 0)
                    {
                        Console.WriteLine("No games played yet.");
                    }
                    else
                    {
                        foreach (var entry in history)
                        {
                            Console.WriteLine(entry);
                        }
                    }
                    break;

                case "3":
                    Console.WriteLine($"\n--- Current Score ---");
                    Console.WriteLine($"You: {userScore}, Computer: {computerScore}, Draws: {draws}");
                    break;

                case "4":
                    Console.WriteLine("\nExiting game. Goodbye!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please select 1, 2, 3, or 4.");
                    break;
            }
        }
    }
}
