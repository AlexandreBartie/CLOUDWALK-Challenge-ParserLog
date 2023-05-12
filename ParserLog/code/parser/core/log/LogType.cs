namespace parser.core.log;
public enum LogType
{

    // XX:XX InitGame: \sv_floodProtect\1\sv_maxPing\0\sv_m ...
    eLogUndefined = -1,

    // XX:XX InitGame: \sv_floodProtect\1\sv_maxPing\0\sv_m ...
    eLogSession = 0,

    // XX:XX Kill: 1022 2 22: <world> killed Isgalamido by MOD_TRIGGER_HURT
    eLogWorldKill = 10,

    // XX:XX Kill: 3 4 10: Isgalamido killed Zeh by MOD_RAILGUN
    eLogPlayerKill = 11,

}
