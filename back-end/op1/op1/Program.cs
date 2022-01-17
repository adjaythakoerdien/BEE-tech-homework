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
void exitMenu(string name, bool playActive)
{
    playActive = false;
    writeSomeLines(100);
    Console.WriteLine("Thank you for your time. Hope to see you soon, " + name + ".");
    Console.WriteLine("Have a nice day!");
    
}

//SHOW THE MENU
void showMenu(string name, bool playActive)
{
    writeSomeLines(100);
    Console.WriteLine("Welcome, " + name + "!");
    Console.WriteLine("\nWhat do you want to do today?");
    Console.WriteLine("1) Play guessing game");
    Console.WriteLine("2) Play checkerboard game");
    Console.WriteLine("3) Exit");

    
    switch (Console.ReadLine())
    {
        case "1": playGuessingGame(name, true); break;
        case "2": playCheckerboardGame(name, true); break;
        case "3":
            writeSomeLines(100);
            Console.WriteLine("Thank you for your time. Hope to see you soon, " + name + ".");
            Console.WriteLine("Have a nice day!"); break;
        default: showMenu(name, playActive); break;

    }
}

// PLAY GUESSING GAME
void playGuessingGame(string name, bool playActive)
{
    // CALCULATE AGE FUNCTION
    int calculateAge(int date)
    {
        int age = 2022 - date;
        return age;
    }

    // START GAME UNTIL BREAK
    while (playActive)
    {
        // EXPLAIN RULES
        writeSomeLines(100);
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
                        Console.WriteLine("\nThis is the third time you entered a wrong date. Mabybe you should check with your doctor to see if everything is okay?");
                        break;
                    case 4:
                        Console.WriteLine("\nI mean like seriously, are you okay?? Maybe get yourself a glass of water.. Slowly ofcourse");
                        break;
                    case 5:
                        Console.WriteLine("\nYou know what they say, fifth time's the charm.. NOT!!!!");
                        break;
                    case 6:
                        Console.WriteLine("\nIt is time to say goodbye my friend. I hope you can get out of this loop! I wish you luck...");
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
            playActive = false;
            showMenu(name, playActive);
        }
    }
}


// ASK FOR N ROWS
int askRows()
{
    writeSomeLines(100);
    Console.WriteLine("How many rows do you want to display? Pick a number BETWEEN 0 and 11.");
    bool succes = int.TryParse(Console.ReadLine(), out int rows);
    while (!succes)
    {
        writeSomeLines(100);
        Console.WriteLine("Try again!\nHow many rows do you want to display? Pick a number BETWEEN 0 and 11.");
        succes = int.TryParse(Console.ReadLine(), out rows);
        if (rows < 1 || rows > 10)
        {
            succes = false;
        }
    }
    return rows;
}

// ASK FOR N COLUMNS
int askColumns()
{
    //int rows = 0;
    writeSomeLines(100);
    Console.WriteLine("How many columns do you want to display? Pick a number BETWEEN 0 and 11.");
    bool succes = int.TryParse(Console.ReadLine(), out int cols);
    while (!succes)
    {
        writeSomeLines(100);
        succes = int.TryParse(Console.ReadLine(), out cols);
    }

    return cols;
}

void displayCheckerBoard(int rows, int cols)
{
    writeSomeLines(100);
    for (int i = 0; i < rows; i++)
    {

        string rowString = "";
        for (int j = 0; j < cols; j++)
        {
                rowString += "X";
            
        }
        Console.WriteLine(rowString);
    }
}

void playCheckerboardGame(string name, bool playActive)
{
    //int rows = askRows();
    //int cols = askColumns();
    while (playActive)
    {
        Console.WriteLine("Hi, " + name + "! We are going to play the checkerboard game..");
        int rows = askRows();
        int cols = askColumns();

        displayCheckerBoard(rows, cols);

        // PRESS KEY TO CONTINUE
        Console.WriteLine("\n\nPress any key to continue the game!");
        Console.ReadKey();

        // PLAY AGAIN OR EXIT TO MENU
        writeSomeLines(3);
        Console.WriteLine("Do you want to play again? (press 'n' to stop or play any key to continue..)");
        string playAgain = Console.ReadLine();

        if (playAgain == "n")
        {
            playActive = false;
            showMenu(name, playActive);
        }
    }
}


// OPEN THE CONSOLE APPLICATION
string name = askName();
showMenu(name, true);
