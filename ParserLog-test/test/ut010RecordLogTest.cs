using parser.core.log;
namespace parser.unit;

public class UT010_LogRecordTest
{

    private LogRecord? log;

    [Theory]
    [InlineData(@"20:37 InitGame: \sv_floodProtect\1\sv_maxPing\0\sv_minPing\0\sv_maxRate\10000\sv_minRate\0\sv_hostname\Code Miner Server\g_gametype\0\sv_privateClients\2\sv_maxclients\16\sv_allowDownload\0\bot_minplayers\0\dmflags\0\fraglimit\20\timelimit\15\g_maxGameClients\0\capturelimit\8\version\ioq3 1.36 linux-x86_64 Apr 12 2009\protocol\68\mapname\q3dm17\gamename\baseq3\g_needpass\0")]
    [InlineData(@"0:00 InitGame: \sv_floodProtect\1\sv_maxPing\0\sv_minPing\0\sv_maxRate\10000\sv_minRate\0\sv_hostname\Code Miner Server\g_gametype\0\sv_privateClients\2\sv_maxclients\16\sv_allowDownload\0\dmflags\0\fraglimit\20\timelimit\15\g_maxGameClients\0\capturelimit\8\version\ioq3 1.36 linux-x86_64 Apr 12 2009\protocol\68\mapname\q3dm17\gamename\baseq3\g_needpass\0")]
    public void TST01_InitGame(string info, LogType type = LogType.eLogSession)
    {

        log = new(info);

        Assert.Equal(type, log.type);

    }

    [Theory]
    [InlineData("20:54 Kill: 1022 2 22: <world> killed Isgalamido by MOD_TRIGGER_HURT", "Isgalamido", "TRIGGER_HURT")]
    [InlineData("09:10 Kill: 1022 2 19: <world> killed Dono da Bola by MOD_FALLING", "Dono da Bola", "FALLING")]

    public void TST02_WorldKill(string info, string dead, string cause, LogType type = LogType.eLogWorldKill)
    {

        log = new(info);

        Assert.Equal(type, log.type);
        Assert.Equal(dead, log.worldKill.dead);
        Assert.Equal(cause, log.worldKill.cause);

    }

    [Theory]
    [InlineData("22:06 Kill: 2 3 7: Isgalamido killed Mocinha by MOD_ROCKET_SPLASH", "Isgalamido", "Mocinha", "ROCKET_SPLASH")]
    [InlineData("22:40 Kill: 2 2 7: Isgalamido killed Isgalamido by MOD_ROCKET_SPLASH", "Isgalamido", "Isgalamido", "ROCKET_SPLASH")]
    [InlineData("5:11 Kill: 4 5 6: Zeh killed Assasinu Credi by MOD_ROCKET", "Zeh", "Assasinu Credi", "ROCKET")]
    public void TST03_PlayerKill(string info, string killer, string dead, string cause, LogType type = LogType.eLogPlayerKill)
    {

        log = new(info);

        Assert.Equal(type, log.type);
        Assert.Equal(killer, log.playerKill.killer);
        Assert.Equal(dead, log.playerKill.dead);
        Assert.Equal(cause, log.playerKill.cause);

    }

}