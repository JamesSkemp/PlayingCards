using System;
using System.Collections.Generic;
using System.Text;

namespace PlayingCards {
	public class Card : ICloneable {

		public object Clone() {
			return MemberwiseClone();
		}
		
		public readonly Suit suit;
		public readonly Rank rank;

		// Flag for trump usage.
		// If true, trump suit cards are valued higher than cards from other suits.
		public static bool useTrumps = false;
		public static Suit trump = Suit.Club;

		// Flag that determines whether aces are higher than kings.
		public static bool isAceHigh = true;

		private Card() {
		}

		public Card(Suit newSuit, Rank newRank) {
			suit = newSuit;
			rank = newRank;
		}

		public override string ToString() {
			return "The " + rank + " of " + suit + "s";
		}

		// Operator overloads.
		public static bool operator ==(Card card1, Card card2) {
			return (card1.suit == card2.suit) && (card1.rank == card2.rank);
		}

		public static bool operator !=(Card card1, Card card2) {
			return !(card1 == card2);
		}

		public override bool Equals(object card) {
			return this == (Card)card;
		}
		public override int GetHashCode() {
			return 13 * (int)rank + (int)suit;
		}

		public static bool operator >(Card card1, Card card2) {
			if (card1.suit == card2.suit) {
				if (isAceHigh) {
					if (card1.rank == Rank.Ace) {
						if (card2.rank == Rank.Ace) {
							return false;
						} else {
							return true;
						}
					} else {
						if (card2.rank == Rank.Ace) {
							return false;
						} else {
							return (card1.rank > card2.rank);
						}
					}
				} else {
					return (card1.rank > card2.rank);
				}
			} else {
				if (useTrumps && (card2.suit == Card.trump)) {
					return false;
				} else {
					//return true;
					return (card1.rank > card2.rank);
				}
			}
		}

		public static bool operator <(Card card1, Card card2) {
			return !(card1 >= card2);
		}

		public static bool operator >=(Card card1, Card card2) {
			if (card1.suit == card2.suit) {
				if (isAceHigh) {
					if (card1.rank == Rank.Ace) {
						return true;
					} else {
						if (card2.rank == Rank.Ace) {
							return false;
						} else {
							return (card1.rank >= card2.rank);
						}
					}
				} else {
					return (card1.rank >= card2.rank);
				}
			} else {
				if (useTrumps && (card2.suit == Card.trump)) {
					return false;
				} else {
					//return true;
					return (card1.rank >= card2.rank);
				}
			}
		}

		public static bool operator <=(Card card1, Card card2) {
			return !(card1 > card2);
		}

	}
}
