List<string> suits = new List<string>() { "Hearts", "Clubs", "Clovers", "Diamonds" };
List<string> ranks = new List<string>() { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
Dictionary<string, int> values = new Dictionary<string, int>()
{
    { "Two", 2 },
    { "Three", 3 },
    { "Four", 4 },
    { "Five", 5 },
    { "Six", 6 },
    { "Seven", 7 },
    { "Eight", 8 },
    { "Nine", 9 },
    { "Ten", 10 },
    { "Jack", 10 },
    { "Queen", 10 },
    { "King", 10 },
    { "Ace", 11 }
};

// TAKE BET FUNCTION
void takeBet(Chips chips)
{
    while (true)
    {
        Console.WriteLine("Place your bet: ");
        bool succes = int.TryParse(Console.ReadLine(), out int betInt);
        chips.bet = betInt;
        if (succes)
        {
            if (betInt > chips.total)
            {
                Console.WriteLine($"Sorry your bet can't be higher than your total chips. Total chips: {chips.total}");
            }
            else
            {
                break;
            }
        }

    }
}

// HIT OR STAND FUNCTION
void hit(Deck deck, Hand hand)
{
    hand.addCard(deck.deal(), values);
    hand.adjustForAces();
}

// HIT OR STAND FUNCTION
// WON'T BREAK FROM THE PLAYING WHILE LOOP
void hitOrStand(Deck deck, Hand hand,  Playing playing)
{
    while (true)
    {
        Console.WriteLine("Would you hit to hit or stand? (h/s)");
        string x = Console.ReadLine()??"";

        if (x == "h")
        {
            hit(deck, hand);
        }
        else if (x == "s") {
            Console.WriteLine("Player stands. Dealer is playing.");
            playing.state = false;
            break;
        }
        else
        {
            Console.WriteLine("Sorry, please try again.");
            continue;
        }
        break;
    }
}

// SHOW SOME OF THE CARDS
void showSome(Hand playerHand, Hand dealerHand, Chips chips)
{
    Console.WriteLine("\nDealer's hand:");
    Console.WriteLine("<card hidden>");
    Console.WriteLine($" {dealerHand.cards[0].show()}");
    Console.WriteLine("\nPlayer's hand:");
    foreach (Card card in playerHand.cards)
    {
        Console.WriteLine($"{card.rank} of {card.suit}");
    }

}

//SHOW All ALL THE CARDS
void showAll(Hand playerHand, Hand dealerHand, Chips chips)
{
    Console.WriteLine("\nDealer's hand:");
    foreach (Card card in dealerHand.cards)
    {
        Console.WriteLine($"{card.rank} of {card.suit}");
    }
    Console.WriteLine($"Dealer's hand: {dealerHand.value}");

    Console.WriteLine("\nPlayer's hand:");
    foreach (Card card in playerHand.cards)
    {
        Console.WriteLine($"{card.rank} of {card.suit}");
    }
    Console.WriteLine($"\nPlayer's hand: {playerHand.value}");
}

// RESULTS OF THE FAME
void playerBusts(Hand playerHand, Hand dealerHand, Chips chips)
{
    Console.WriteLine("Player busts!");
    chips.loseBet();
}

void playerWins(Hand playerHand, Hand dealerHand, Chips chips)
{
    Console.WriteLine("Player wins!");
    chips.winBet();
}

void dealerBusts(Hand playerHand, Hand dealerHand, Chips chips)
{
    Console.WriteLine("Dealer busts!");
    chips.winBet();
}

void dealerWins(Hand playerHand, Hand dealerHand, Chips chips)
{
    Console.WriteLine("Dealer wins!");
    chips.loseBet();
}

void push(Hand playerHand, Hand dealerHand)
{
    Console.WriteLine("Tie!");
}

// GAME ON!!
Playing playing = new Playing();
bool gameOn = true;

Console.WriteLine("WELCOME TO BLACKJACK!");
Chips playerChips = new Chips();

while (gameOn)
{
    Deck deck = new Deck(suits, ranks);
    deck.shuffle();

    Hand playerHand = new Hand();
    playerHand.addCard(deck.deal(), values);
    playerHand.addCard(deck.deal(), values);

    Hand dealerHand = new Hand();
    dealerHand.addCard(deck.deal(), values);
    dealerHand.addCard(deck.deal(), values);

    takeBet(playerChips);

    showSome(playerHand, dealerHand, playerChips);

    while (playing.state)
    {
        hitOrStand(deck, playerHand, playing);

        showSome(playerHand, dealerHand, playerChips);

        if (playerHand.value > 21)
        {
            playerBusts(playerHand, dealerHand, playerChips);
            playing.state = false;
        }
    }

    if (playerHand.value <= 21)
    {
        while (dealerHand.value < 17)
        {
            hit(deck, dealerHand);
        }
        showAll(playerHand, dealerHand, playerChips);

        if (dealerHand.value > 21)
        {
            dealerBusts(playerHand, dealerHand, playerChips);
        }
        else if (dealerHand.value > playerHand.value) {
            dealerWins(playerHand, dealerHand, playerChips);
        }
        else if (dealerHand.value < playerHand.value)
        {
            playerWins(playerHand, dealerHand, playerChips);
        }
        else { push(playerHand, dealerHand); }

    }

    Console.WriteLine($"\nPLayer's winnings: {playerChips.total}");

    Console.WriteLine("Exit?");
    string key = Console.ReadLine()??"";
    if (key == "y") { gameOn = false; }
}