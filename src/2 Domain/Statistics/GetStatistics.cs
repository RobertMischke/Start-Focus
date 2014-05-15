using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GetStatistics
{
    public static Statistics Run()
    {
        var statistics = new Statistics();

        var allSessions = LoadAllSessions.Run();
        var today = DateTime.Now;
        
        var sessionsToday = allSessions.Where(x =>
            x.DateSaved.DayOfYear == today.DayOfYear &&
            x.DateSaved.Year == today.Year).ToList();

        statistics.Today = ForPeriod(sessionsToday, "today");
        statistics.Ever = ForPeriod(allSessions, "ever");

        return statistics;
    }

    private static StatisticsForPeriod ForPeriod(IList<FocusSession> sessions, string periodName)
    {
        var result = new StatisticsForPeriod
        {
            PeriodName = periodName,
            FocusMinutes = sessions.Sum(x => x.WasInterrupted ? - x.Minutes : x.Minutes),
            TotalMinutes = sessions.Sum(x => x.MinutesNet),
            InterruptionCount = sessions.Count(x => x.WasInterrupted),
            InterruptionMinutes = sessions.Where(x => x.WasInterrupted).Sum(x => x.Minutes),
            SessionCount = sessions.Count
        };

        return result;
    }
}

