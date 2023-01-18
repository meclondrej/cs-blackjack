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
    }
}
