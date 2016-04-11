using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayingCards {
	public class Cards : CollectionBase, ICloneable {

		public object Clone() {
			Cards newCards = new Cards();
			foreach (Card sourceCard in List) {
				newCards.Add(sourceCard.Clone() as Card);
			}
			return newCards;
		}

		public void Add(Card newCard) {
			List.Add(newCard);
		}

		public void Remove(Card oldCard) {
			List.Remove(oldCard);
		}

		public Cards() {
		}

		public Card this[int cardIndex] {
			get {
				return (Card)List[cardIndex];
			}
			set {
				List[cardIndex] = value;
			}
		}

		// Copy card instances into another Cards instance.
		// Source and target collections must be the same size.
		public void CopyTo(Cards targetCards) {
			for (int index = 0; index < this.Count; index++) {
				targetCards[index] = this[index];
			}
		}

		// Check to see if a Cards collection contains a particular card.
		public bool Contains(Card card) {
			return InnerList.Contains(card);
		}
	}
}
