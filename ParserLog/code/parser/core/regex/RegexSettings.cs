using parser.core.log;

namespace parser.core.regex;

public class RegexSettings
{
    // variations of gameSession
    // example: InitGame: \sv_floodProtect\1\sv_maxPing\0\sv_minPing ...

    private string tagSession = "^InitGame: .*$";

    // variations of tagWorldKilled
    // example2: Kill: 1022 2 22: <world> killed Isgalamido by MOD_TRIGGER_HURT
    private string tagWorldKillSomeone = @"^Kill:(.*): <world> killed (.*) by (.*)$";

    // variations of tagPlayerKilled
    // example1: Kill: 3 2 10: Isgalamido killed Dono da Bola by MOD_RAILGUN
    // example2: Kill: 1022 2 22: <world> killed Isgalamido by MOD_TRIGGER_HURT
    private string tagPlayerKillSomeone = @"^Kill:(.*): (.*) killed (.*) by (.*)$";

    public string getPattern(LogType type)
    {

        return (type) switch
        {
            LogType.eLogSession => tagSession,
            LogType.eLogWorldKillSomeone => tagWorldKillSomeone,
            LogType.eLogPlayerKillSomeone => tagPlayerKillSomeone,
            _ => ""
        };

    }

}