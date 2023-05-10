using parser.core.log;
namespace parser.unit;

public class UT01_RecordLogTest
{

    private RecordLog? log;

    [Theory]
    [InlineData(@"20:37 InitGame: \sv_floodProtect\1\sv_maxPing\0\sv_minPing\0\sv_maxRate\10000\sv_minRate\0\sv_hostname\Code Miner Server\g_gametype\0\sv_privateClients\2\sv_maxclients\16\sv_allowDownload\0\bot_minplayers\0\dmflags\0\fraglimit\20\timelimit\15\g_maxGameClients\0\capturelimit\8\version\ioq3 1.36 linux-x86_64 Apr 12 2009\protocol\68\mapname\q3dm17\gamename\baseq3\g_needpass\0", 1)]
    [InlineData(@"0:00 InitGame: \sv_floodProtect\1\sv_maxPing\0\sv_minPing\0\sv_maxRate\10000\sv_minRate\0\sv_hostname\Code Miner Server\g_gametype\0\sv_privateClients\2\sv_maxclients\16\sv_allowDownload\0\dmflags\0\fraglimit\20\timelimit\15\g_maxGameClients\0\capturelimit\8\version\ioq3 1.36 linux-x86_64 Apr 12 2009\protocol\68\mapname\q3dm17\gamename\baseq3\g_needpass\0", 328)]
    public void TST01_PlayerHealedPower(string info, int points, TypeLog type = TypeLog.eLogSession)
    {

        log = new(info);

        Assert.Equal(type, log.type);
        // Assert.Equal(points, log.dataPlayerHealedPower.points);

    }

    [Theory]
    [InlineData("20:54 Kill: 1022 2 22: <world> killed Isgalamido by MOD_TRIGGER_HURT", "<world>", "Isgalamido", "MOD_TRIGGER_HURT")]
    [InlineData("22:06 Kill: 2 3 7: Isgalamido killed Mocinha by MOD_ROCKET_SPLASH", "Isgalamido", "Mocinha", "MOD_ROCKET_SPLASH")]
    [InlineData("22:40 Kill: 2 2 7: Isgalamido killed Isgalamido by MOD_ROCKET_SPLASH", "Isgalamido", "Isgalamido", "MOD_ROCKET_SPLASH")]
    public void TST02_PlayerLostPowerByUnknown(string info, string killer, string dead, string cause, TypeLog type = TypeLog.eLogPlayerDead)
    {

        log = new(info);

        Assert.Equal(type, log.type);
        Assert.Equal(killer, log.dataPlayerDead.killer);
        Assert.Equal(dead, log.dataPlayerDead.dead);
        Assert.Equal(cause, log.dataPlayerDead.cause);

    }

}