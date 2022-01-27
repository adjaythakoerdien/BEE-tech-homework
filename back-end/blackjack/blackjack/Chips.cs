using System;
namespace blackjack
{
	public class Chips
	{
		// CHIPS INIT
		public int total = 100;
		public int bet = 0;

		public Chips()
		{
		}

		public void winBet()
        {
			total += bet;
        }

		public void loseBet()
        {
			total -= bet;
        }
	}
}

