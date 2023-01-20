class Program {
    static void Main(string[] args) {
        List<Player> players = new List<Player>();
        if (args.Length != 0) {
            int count;
            if (int.TryParse(args[0], out count)) {
                for (int i = 0; i < count; i++) {
                    players.Add(new Player());
                }
            } else {
                Console.WriteLine("unable to convert: invalid format");
                return;
            }
        } else {
            Console.WriteLine("no player count argument passed: falling back to 1 player");
            players.Add(new Player());
        }
        Console.WriteLine("C# Blackjack");
        Dealer dealer = new Dealer();
        Console.WriteLine("Dealer's first card: " + Card.ResolveValue(dealer.hand[0].value));
        for (int i = 0; i < players.Count; i++) {
            Console.WriteLine("");
            bool loop = true;
            while (loop) {    
                Console.WriteLine(players[i].getFormattedHand(i + 1));
                if (players[i].isBJ()) {
                    Console.WriteLine("Player " + (i + 1).ToString() + " BLACKJACKED!");
                    players[i].eval = false;
                    loop = false;
                } else if (players[i].isBusted()) {
                    Console.WriteLine("Player " + (i + 1).ToString() + " BUSTED!");
                    players[i].eval = false;
                    loop = false;
                } else {
                    Console.WriteLine("hit/stand [h/s]: ");
                    string? choice = Console.ReadLine();
                    if (choice == "h") {
                        players[i].hand.Add(new Card());
                    } else if (choice == "s") {
                        loop = false;
                    }
                }
            }
        }
        dealer.evaluateDealer();
        Console.WriteLine("");
        Console.WriteLine(dealer.getFormattedHand());
        if (dealer.isBJ()) {
            Console.WriteLine("Dealer BLACKJACKED!");
            for (int i = 0; i < players.Count; i++) {
                if (!players[i].eval) {
                    continue;
                }
                if (players[i].isBJ()) {
                    Console.WriteLine("Player " + (i + 1).ToString() + " PUSHED!");
                } else {
                    Console.WriteLine("Player " + (i + 1).ToString() + " LOST!");
                }
            }
        } else if (dealer.isBusted()) {
            for (int i = 0; i < players.Count; i++) {
                if (players[i].eval) {
                    Console.WriteLine("Player " + (i + 1).ToString() + " WON!");
                }
            }
        } else {
            for (int i = 0; i < players.Count; i++) {
                if (!players[i].eval) {
                    continue;
                }
                if (players[i].getTotal() > dealer.getTotal()) {
                    Console.WriteLine("Player " + (i + 1).ToString() + " WON!");
                }
                if (players[i].getTotal() == dealer.getTotal()) {
                    Console.WriteLine("Player " + (i + 1).ToString() + " PUSHED!");
                }
                if (players[i].getTotal() < dealer.getTotal()) {
                    Console.WriteLine("Player " + (i + 1).ToString() + " LOST!");
                }
            }
        }
    }
}
