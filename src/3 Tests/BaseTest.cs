using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


[TestFixture]
public class BaseTest
{
    public BaseTest()
    {
        Settings.SessionFileName = "Sessions.tests.json";
    }

    [SetUp]
    public void SetUp()
    {
        File.WriteAllText(Settings.GetSessionFileFullPath(), "");
    }

    protected static void SaveFocusSession(string focusOn)
    {
        global::SaveFocusSession.Run(new FocusSession
        {
            DateSaved = DateTime.Now,
            Minutes = 7,
            On = focusOn,
            Success = true
        });
    }
}

