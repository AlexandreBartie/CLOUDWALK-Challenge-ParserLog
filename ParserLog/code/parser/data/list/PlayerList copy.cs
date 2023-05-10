namespace parser.data.list;

public class PlayerList : EntityList<Player> {}

public class Player : Entity
{
    public Player(string name) : base(name) {}
}

