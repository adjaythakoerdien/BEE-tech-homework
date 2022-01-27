using System;
namespace blackjack
{
	public class Card
	{
		public string suit;
		public string rank;

		// CARD INIT
		public Card(string iSuit, string iRank)
		{
			rank = iRank;
			suit = iSuit;
		}

		public string show()
        {
			return $"{rank} of {suit}";
        }
	}
}

