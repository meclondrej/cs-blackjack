class Player {
    public List<Card> hand = new List<Card>();
    public bool eval = true;
    public Player() {
        if (this.GetType() != typeof(Player)) {
            return;
        }
        this.hand.Add(new Card());
        this.hand.Add(new Card());
    }
    public int getTotal() {
        int total = 0;
        foreach (Card c in this.hand) {
            if (c.value == 1) {
                if (total + 11 > 21) {
                    total += 1;
                } else {
                    total += 11;
                }
            } else if (c.value >= 2 && c.value <= 9) {
                total += c.value;
            } else if (c.value >= 10 && c.value <= 13) {
                total += 10;
            }
        }
        return total;
    }

    public string getFormattedHand(int i) {
        string msg = "Player " + i.ToString() + "'s hand: ";
        foreach (Card card in this.hand) {
            msg = msg + Card.ResolveValue(card.value) + " ";
        }
        msg = msg + "(Total: " + this.getTotal() + ")";
        return msg;
    }
    public bool isBJ() {
        if (this.hand.Count != 2) {
            return false;
        }
        if (this.getTotal() == 21) {
            return true;
        } else {
            return false;
        }
    }
    public bool isBusted() {
        if (this.getTotal() > 21) {
            return true;
        } else {
            return false;
        }
    }
}