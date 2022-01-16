// See https://aka.ms/new-console-template for more information
while (true)
{
    // ASK NAME
    Console.WriteLine("What is your name?");
    string naam = Console.ReadLine();
    Console.WriteLine("--------------------------");
    Console.WriteLine("");
    Console.WriteLine("");

    Console.WriteLine("Welcome, " + naam + "!");
    Console.WriteLine("");
    Console.WriteLine("Let's play a game...");

    Console.WriteLine("");
    Console.WriteLine("I am going to guess your age...");


    // ASK DATE OF BIRTH
    Console.WriteLine("");
    Console.WriteLine("What is your date of birth, " + naam + "?");
    string input = Console.ReadLine();
    Int32.TryParse(input, out int datum);


    void CalculateAge(int datum)
    {
        int leeftijd = 2022 - datum;
        Console.WriteLine("");
        Console.WriteLine("Your age is........ ");
        Console.WriteLine(leeftijd);
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
    }

    CalculateAge(datum);

    Console.WriteLine("I won the game!");
    Console.WriteLine("");
    Console.WriteLine("");

    Console.WriteLine("Press any key to continue the game!");
    Console.ReadKey();

    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("Do you wan't to play again? (press 'n' to stop or play any key to continue..)");
    string playAgain = Console.ReadLine();

    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");

    if (playAgain == "n")
    {
        break;
    }
}
