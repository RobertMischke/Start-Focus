using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using NUnit.Framework;



public class Session_persistence : BaseTest
{
    [Test]
    public void Should_save_session()
    {
        for (var i = 0; i < 10; i++)
            SaveFocusSession(i.ToString());

        var allSessions = LoadAllSessions.Run();
        Assert.That(allSessions.Count, Is.EqualTo(10));
        Assert.That(allSessions[3].On, Is.EqualTo("3"));
    }

    [Test]
    public void Should_be_fast()
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        for (var i = 0; i < 10000; i++)
            SaveFocusSession(i.ToString());

        Assert.That(stopWatch.Elapsed.TotalSeconds, Is.LessThan(10));
        stopWatch.Reset();

        var allSessions = LoadAllSessions.Run();
        Assert.That(stopWatch.Elapsed.Milliseconds, Is.LessThan(300));
        Assert.That(allSessions.Count, Is.EqualTo(10000));

        stopWatch.Reset();
        Console.WriteLine(allSessions.Sum(x => x.Minutes));
        Console.WriteLine(stopWatch.Elapsed);
    }

}



