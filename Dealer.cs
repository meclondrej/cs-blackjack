class Dealer : Player {
    public Dealer() {
        this.hand.Add(new Card());
    }
    public void evaluateDealer() {
        while (this.getTotal() < 17) {
            this.hand.Add(new Card());
        }
    }
}