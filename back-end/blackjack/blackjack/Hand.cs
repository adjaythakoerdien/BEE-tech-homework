using System;
namespace blackjack
{
	public class Hand
	{
		// HAND INIT
		public List<Card> cards = new List<Card>();
		public int value = 0;
		int aces = 0;

		public Hand()
		{
		}

		public void addCard(Card card, Dictionary<string, int> values)
        {
			cards.Add(card);
			value += values[card.rank];
			Console.WriteLine("Card added..");
		}

		public void adjustForAces()
        {
			while ((value > 21) && (aces > 0))
            {
				value -= 10;
				aces -= 1;
            }
        }
    }
}

