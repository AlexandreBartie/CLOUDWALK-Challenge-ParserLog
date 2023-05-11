namespace parser.data.group;

// public class GroupPlayerList : List<GroupPlayer>
// {

//     public readonly ViewData view;

//     public readonly LogType type;

//     public PlayerList players => GetPlayers();

//     public int count => this.Count;

//     public GroupPlayerList(ViewData view, LogType type)
//     {
//         this.view = view;
//         this.type = type;
//     }

//     public void AddItem(LogItem log)
//     {
//         AddItem(log.dataPlayerKillSomeone);

//     }

//     private void AddItem(ILogPlayerKilledSomeone data)
//     {
//         Add(new GroupPlayer(data.killer));
//     }

//     public GroupPlayerList filter(string player)
//     {

//         var list = new GroupPlayerList(view, type);

//         foreach (GroupPlayer item in this)
//         {
//             if (Text.IsMatch(item.player, player))
//                 list.Add(item);
//         }

//         return list;
//     }

//     private PlayerList GetPlayers()
//     {

//         var list = new PlayerList();

//         foreach (GroupPlayer item in this)
//         {
//             list.AddItem(item.player);
//         }

//         return list;

//     }

//     private int GetTotal()
//     {
//         var total = 0;

//         foreach (GroupPlayer item in this)
//         {
//             total++;
//         }

//         return total;
//     }

//     public string log()
//     {

//         var memo = new Memo();

//         foreach (Player item in players.OrderBy(item => item.name))
//         {
//             var player = item.name;

//             var list = filter(player);

//             var log = view.GetLogPoints(player, 100, list.count, 3);

//             memo.Add(log);
//         }

//         return memo.txt;

//     }

// }

// public class GroupPlayer
// {

//     public string player;
//     public int kills;
//     public int deaths;

//     public GroupPlayer(string player)
//     {
//         this.player = player;
//     }

// }