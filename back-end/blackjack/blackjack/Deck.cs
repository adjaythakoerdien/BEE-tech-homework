using System;
namespace blackjack
{
	public class Deck
	{
		public List<Card> deck = new List<Card>();

		// DECK INIT
		public Deck(List<string> suits, List<string> ranks)
		{
			foreach (string suit in suits)
            {
				foreach (string rank in ranks)
                {
                    Card newCard = new(suit, rank);
                    deck.Add(newCard);
                }

            }
		}

        // SHOW THE CARDS IN THE DECK
        public string show()
        {
            string deckComp = "";
            foreach (Card card in deck)
            {
                deckComp += $"\n{card.rank} of {card.suit}";
            }
            return deckComp;
        }

        //SHUFFLE LIST
        public void shuffle()
        {
            deck = deck.OrderBy(x => Guid.NewGuid()).ToList();
        }

        //DEAL A CARD (REMOVE AND RETURN THE FIRST CARD)
        public Card deal()
        {
            Card firstCard = deck.First();
            deck.RemoveAt(0);
            return firstCard;
        }
    }
}
