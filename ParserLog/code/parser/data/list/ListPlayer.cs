namespace parser.data.list;

public class ListPlayer : ListEntity<Player> { }

public class Player : Entity
{
    public Player(string name) : base(name) { }
}

