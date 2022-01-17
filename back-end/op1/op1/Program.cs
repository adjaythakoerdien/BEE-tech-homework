// FUNCTION FOR WRITING N NEW LINES
void writeSomeLines(int n)
{
    for (int i = 0;i <= n;i++)
    {
        Console.WriteLine("");
    }
}

// ASK FOR THE PLAYER'S NAME
string askName()
{
    Console.WriteLine("What is your name?");
    string name = Console.ReadLine();
    return name;
}

// EXIT GAME
void exitMenu(string name)
{
    writeSomeLines(100);
    Console.WriteLine("Thank you for your time. Hope to see you soon, " + name + ".");
    Console.WriteLine("Have a nice day!");

}


//SHOW THE MENU
void showMenu(string name)
{
    writeSomeLines(100);
    Console.WriteLine("Welcome, " + name + "!");
    Console.WriteLine("\nWhat do you want to do today?");
    Console.WriteLine("1) Play guessing game");
    Console.WriteLine("3) Exit");
    //string input = Console.ReadLine;
    switch (Console.ReadLine())
    {
        case "1": playGuessingGame(name); break;
        case "3": exitMenu(name); break;

    }
}


void playGuessingGame(string name)
{
    // CALCULATE AGE
    int calculateAge(int date)
    {
        int age = 2022 - date;
        return age;
    }

    // START GAME UNTIL BREAK
    while (true)
    {
        writeSomeLines(100);
        
        writeSomeLines(4);
        Console.WriteLine("I am going to guess your age...");


        // ASK DATE OF BIRTH
        
        Console.WriteLine("What is your date of birth, " + name + "?");
        string input = Console.ReadLine();
        bool succes = int.TryParse(input, out int date);




        // CHECK IF STRING TO INT WAS SUCCES
        int t = 1;
        if (succes)
        {
            int age = calculateAge(date);
            if (age < 0 || age > 120)
            {
                succes = false;
            }
        } else
        {
            while (!succes)
            {
                writeSomeLines(100);
                Console.WriteLine("Something went wrong with your input. Did you enter a valid date?");
                switch (t)
                {
                    case 3:
                        Console.WriteLine("\nThis is the third timne you entered a wrong date. Mabybe you should check with your doctor to see if everything is okay?");
                        break;
                    case 4:
                        Console.WriteLine("\nI mean like seriously, are you okay?? Maybe get yourself a glass of water.. Slowly ofcourse");
                        break;
                    case 5:
                        Console.WriteLine("\nYou know what they say, fifth time's the charm.. NOT!!!!");
                        break;
                    case 6:
                        Console.WriteLine("\nIt is time to say goodbye my friend. I hope you can get out of this loop!");
                        break;
                }

                Console.WriteLine("\nWhat is you date of birth?");
                
                input = Console.ReadLine();
                succes = int.TryParse(input, out date);

                if (succes)
                {
                    int age = calculateAge(date);
                    if (age < 0 || age > 120)
                    {
                        succes = false;
                        t++;
                    }
                    continue;
                }
                t++;
            }
        }

        int lft = calculateAge(date);

        // SHOW AGE GUESS
        writeSomeLines(100);
        Console.WriteLine("Your age is.......");
        Console.WriteLine(lft);
        Console.WriteLine("\nTadaaa, I won the game!");

        // PRESS KEY TO CONTINUE
        Console.WriteLine("\n\nPress any key to continue the game!");
        Console.ReadKey();

        // PLAY AGAIN OR EXIT TO MENU
        writeSomeLines(3);
        Console.WriteLine("Do you want to play again? (press 'n' to stop or play any key to continue..)");
        string playAgain = Console.ReadLine();

        if (playAgain == "n")
        {
            showMenu(name);
        }
    }
}

// OPEN THE CONSOLE APPLICATION
string name = askName();
showMenu(name);
