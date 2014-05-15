using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

public class Session_statistics : BaseTest
{
    [Test]
    public void Should_load_statistics()
    {
        for (var i = 0; i < 10; i++)
            SaveFocusSession(i.ToString());           
    }
}