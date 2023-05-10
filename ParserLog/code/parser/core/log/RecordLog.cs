namespace parser.core.log;

public enum TypeLog
{
    // Channel Server Log saved Wed Apr 12 15:48:26 2023
    eLogNoteSession = 0,

    // Boosted bosses contain more loot and count more kills for your Bosstiary.     
    eLogNoteMessage = 1,

    // XX:XX Today's boosted boss: Goshnar's Malice
    eLogMessage = 10,

    // XX:XX You healed yourself for 328 hitpoints.
    eLogPlayerHealedPower = 11,

    // XX:XX You lose 1 hitpoint.
    eLogPlayerLostPowerByUnknown = 12,

    // XX:XX You lose 31 hitpoints due to an attack by a cyclops.
    eLogPlayerLostPowerByCreature = 13,

    // XX:XX You gained 150 experience points.
    eLogPlayerGainedExperience = 14,

    // XX:XX Loot of a cyclops: 6 gold coins, a meet.
    eLogPlayerLootedByCreature = 15,

    // XX:XX A dragon healed itself for 60 hitpoints.
    eLogCreatureHealedPower = 16,

    // XX:XX A cyclops loses 260 hitpoints due to your attack.
    eLogCreatureLostPower = 17,

}

public class RecordLog : BaseLog
{
    public bool isHeader => type == TypeLog.eLogNoteSession;

    public RecordLog(string info) : base(info) { }

    public ILogPlayerPoints dataPlayerGainedExperience => regex.data.GetPlayerPoints();
    public ILogPlayerPoints dataPlayerHealedPower => regex.data.GetPlayerPoints();
    public ILogPlayerPoints dataPlayerLostPower => regex.data.GetPlayerPoints();
    public ILogCreaturePoints dataPlayerLostPowerByCreature => regex.data.GetCreaturePoints(TypeLog.eLogPlayerLostPowerByCreature);
    public ILogPlayerLooted dataPlayerLootedByCreature => regex.data.GetPlayerLooted();
    public ILogCreaturePoints GroupCreatureHealedPower => regex.data.GetCreaturePoints(TypeLog.eLogCreatureHealedPower);
    public ILogCreaturePoints GroupCreatureLostPower => regex.data.GetCreaturePoints(TypeLog.eLogCreatureLostPower);
}

public class RecordsLog : List<RecordLog>
{

    public RecordsLog filter(TypeLog type)
    {

        var logs = new RecordsLog();

        foreach (RecordLog log in this)
        {
            if (log.type == type)
                logs.Add(log);
        }

        return logs;
    }

}