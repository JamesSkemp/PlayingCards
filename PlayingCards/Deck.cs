using System;
using System.Collections.Generic;
using System.Text;

namespace PlayingCards {
	public class Deck : ICloneable {
		//private Card[] cards;
		private Cards cards = new Cards();

		// Allow a Deck to be instantiated with specific Cards.
		// Used by Clone().
		private Deck(Cards newCards) {
			cards = newCards;
		}

		public object Clone() {
			Deck newDeck = new Deck(cards.Clone() as Cards);
			return newDeck;
		}

		public Deck() {
			for (int suitVal = 0; suitVal < 4; suitVal++) {
				for (int rankVal = 1; rankVal < 14; rankVal++) {
					//cards[suitVal * 13 + rankVal - 1] = new Card((Suit)suitVal, (Rank)rankVal);
					cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
				}
			}
		}

		// Allows aces to be set high.
		public Deck(bool isAceHigh) : this() {
			Card.isAceHigh = isAceHigh;
		}

		// Allows trump suit to be used.
		public Deck(bool useTrumps, Suit trump) : this() {
			Card.useTrumps = useTrumps;
			Card.trump = trump;
		}

		// Allows aces to be set high and trump suit to be used.
		public Deck(bool isAceHigh, bool useTrumps, Suit trump) : this() {
			Card.isAceHigh = isAceHigh;
			Card.useTrumps = useTrumps;
			Card.trump = trump;
		}

		public Card GetCard(int cardNum) {
			if (cardNum >= 0 && cardNum <= 51) {
				return cards[cardNum];
			} else {
				throw (new System.ArgumentOutOfRangeException("cardNum", cardNum, "Value must be between 0 and 51."));
			}
		}

		public void Shuffle() {
			//Card[] newDeck = new Card[52];
			Cards newDeck = new Cards();
			bool[] assigned = new bool[52];
			Random sourceGen = new Random();
			
			for (int i = 0; i < 52; i++) {
				//int destCard = 0;
				int sourceCard = 0;
				bool foundCard = false;
				while (foundCard == false) {
					//destCard = sourceGen.Next(52);
					sourceCard = sourceGen.Next(52);
					//if (assigned[destCard] == false) {
					if (assigned[sourceCard] == false) {
						foundCard = true;
					}
				}
				//assigned[destCard] = true;
				assigned[sourceCard] = true;
				//newDeck[destCard] = cards[i];
				newDeck.Add(cards[sourceCard]);
			}
			//newDeck.CopyTo(cards, 0);
			newDeck.CopyTo(cards);
		}
	}
}
