class Dealer : Player {
    public Dealer() {
        this.hand.Add(new Card());
    }
    public void evaluateDealer() {
        while (this.getTotal() < 17) {
            this.hand.Add(new Card());
        }
    }
    public string getFormattedHand() {
        string msg = "Dealer's hand: ";
        foreach (Card card in this.hand) {
            msg = msg + Card.ResolveValue(card.value) + " ";
        }
        msg = msg + "(Total: " + this.getTotal() + ")";
        return msg;
    }
}