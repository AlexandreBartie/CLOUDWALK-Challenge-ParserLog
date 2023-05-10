namespace parser.core.log;
public enum TypeLog
{

    // XX:XX InitGame: \sv_floodProtect\1\sv_maxPing\0\sv_m ...
    eLogUndefined = -1,

    // XX:XX InitGame: \sv_floodProtect\1\sv_maxPing\0\sv_m ...
    eLogSession = 0,

    // XX:XX Kill: 1022 2 22: <world> killed Isgalamido by MOD_TRIGGER_HURT
    eLogPlayerDead = 10,

}
