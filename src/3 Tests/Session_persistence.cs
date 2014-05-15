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
        {
            SaveFocusSession.Run(new FocusSession
            {
                DateSaved = DateTime.Now,
                Minutes = 7,
                On = i.ToString(),
                Success = true
            });                
        }

        var allSessions = LoadAllSessions.Run();
        Assert.That(allSessions.Count, Is.EqualTo(10));
        Assert.That(allSessions[3].On, Is.EqualTo("3"));
    }

}



