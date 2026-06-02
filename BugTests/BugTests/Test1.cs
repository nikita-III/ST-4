namespace BugTests;

using System.Reflection;
namespace Proc;

[TestClass]
public sealed class Test1
{

    public TestContext TestContext { get; set; }

    [TestMethod]
    public void TestMethodOneStep()
    {
        var bug = new Bug();
        bug.NxtState(Bug.Trig.LetsSee);
        //TestContext.WriteLine(bug.GetState().ToString());
        Assert.AreEqual(Bug.State.DeffOverview, bug.GetState(), "\n\nTest - TestMethodOneStep - NotPassed\n\n");
    }

    [TestMethod]
    public void TestMethodNoTime()
    {
        var bug = new Bug();
        bug.NxtState(Bug.Trig.LetsSee);
        bug.NxtState(Bug.Trig.HaveNoTime);
        
        //TestContext.WriteLine(bug.GetState().ToString());
        Assert.AreEqual(Bug.State.NoTimeNow, bug.GetState(), "\n\nTest - TestMethodNoTime - NotPassed\n\n");
    }

    [TestMethod]
    public void TestMethodNotADeff()
    {
        var bug = new Bug();
        bug.NxtState(Bug.Trig.LetsSee);
        bug.NxtState(Bug.Trig.ItsNotDeff);
        //TestContext.WriteLine(bug.GetState().ToString());
        Assert.AreEqual(Bug.State.NotDeff, bug.GetState(), $"\n\nTest - {MethodBase.GetCurrentMethod().Name} - NotPassed\n\n");
    }

    [TestMethod]
    public void TestMethodJustCorr()
    {
        var bug = new Bug();
        bug.NxtState(Bug.Trig.LetsSee);
        bug.NxtState(Bug.Trig.ToCorr);
        //TestContext.WriteLine(bug.GetState().ToString());
        Assert.AreEqual(Bug.State.Corr, bug.GetState(), $"\n\nTest - {MethodBase.GetCurrentMethod().Name} - NotPassed\n\n");
    }

    [TestMethod]
    public void TestMethodNoTimeThenCorr()
    {
        var bug = new Bug();
        bug.NxtState(Bug.Trig.LetsSee);
        bug.NxtState(Bug.Trig.HaveNoTime);
        bug.NxtState(Bug.Trig.ToCorr);
        //TestContext.WriteLine(bug.GetState().ToString());
        Assert.AreEqual(Bug.State.Corr, bug.GetState(), $"\n\nTest - {MethodBase.GetCurrentMethod().Name} - NotPassed\n\n");
    }

    [TestMethod]
    public void TestMethodIsOk()
    {
        var bug = new Bug();
        bug.NxtState(Bug.Trig.LetsSee);
        bug.NxtState(Bug.Trig.ItsDoNotCorr);
        bug.NxtState(Bug.Trig.ToIsOk);
        //TestContext.WriteLine(bug.GetState().ToString());
        Assert.AreEqual(Bug.State.IsOk, bug.GetState(), $"\n\nTest - {MethodBase.GetCurrentMethod().Name} - NotPassed\n\n");
    }

    [TestMethod]
    public void TestMethodOkClose()
    {
        var bug = new Bug();
        bug.NxtState(Bug.Trig.LetsSee);
        bug.NxtState(Bug.Trig.ItsDubl);
        bug.NxtState(Bug.Trig.ToIsOk);
        bug.NxtState(Bug.Trig.ItsOk);
        //TestContext.WriteLine(bug.GetState().ToString());
        Assert.AreEqual(Bug.State.Close, bug.GetState(), $"\n\nTest - {MethodBase.GetCurrentMethod().Name} - NotPassed\n\n");
    }

    [TestMethod]
    public void TestMethodNotOkRet()
    {
        var bug = new Bug();
        bug.NxtState(Bug.Trig.LetsSee);
        bug.NxtState(Bug.Trig.ItsNotReplicable);
        bug.NxtState(Bug.Trig.ToIsOk);
        bug.NxtState(Bug.Trig.ItsNotOk);
        //TestContext.WriteLine(bug.GetState().ToString());
        Assert.AreEqual(Bug.State.Ret, bug.GetState(), $"\n\nTest - {MethodBase.GetCurrentMethod().Name} - NotPassed\n\n");
    }

    [TestMethod]
    public void TestMethodSolvedClose()
    {
        var bug = new Bug();
        bug.NxtState(Bug.Trig.LetsSee);
        bug.NxtState(Bug.Trig.ToCorr);
        bug.NxtState(Bug.Trig.Solving);
        bug.NxtState(Bug.Trig.ProbSolved);
        //TestContext.WriteLine(bug.GetState().ToString());
        Assert.AreEqual(Bug.State.Close, bug.GetState(), $"\n\nTest - {MethodBase.GetCurrentMethod().Name} - NotPassed\n\n");
    }

    [TestMethod]
    public void TestMethodToIsProbSolved()
    {
        var bug = new Bug();
        bug.NxtState(Bug.Trig.LetsSee);
        bug.NxtState(Bug.Trig.ToCorr);
        bug.NxtState(Bug.Trig.Solving);
        //TestContext.WriteLine(bug.GetState().ToString());
        Assert.AreEqual(Bug.State.IsProbSolved, bug.GetState(), $"\n\nTest - {MethodBase.GetCurrentMethod().Name} - NotPassed\n\n");
    }

    [TestMethod]
    public void TestMethodNotSolvedRet()
    {
        var bug = new Bug();
        bug.NxtState(Bug.Trig.LetsSee);
        bug.NxtState(Bug.Trig.ToCorr);
        bug.NxtState(Bug.Trig.Solving);
        bug.NxtState(Bug.Trig.ProbNotSolved);
        //TestContext.WriteLine(bug.GetState().ToString());
        Assert.AreEqual(Bug.State.Ret, bug.GetState(), $"\n\nTest - {MethodBase.GetCurrentMethod().Name} - NotPassed\n\n");
    }

    [TestMethod]
    public void TestMethodNotSolvFullCycle()
    {
        var bug = new Bug();
        bug.NxtState(Bug.Trig.LetsSee);
        bug.NxtState(Bug.Trig.ToCorr);
        bug.NxtState(Bug.Trig.Solving);
        bug.NxtState(Bug.Trig.ProbNotSolved);
        bug.NxtState(Bug.Trig.Returning);
        //TestContext.WriteLine(bug.GetState().ToString());
        Assert.AreEqual(Bug.State.DeffOverview, bug.GetState(), $"\n\nTest - {MethodBase.GetCurrentMethod().Name} - NotPassed\n\n");
    }

    [TestMethod]
    public void TestMethodNoTimeThenDeffOthrvw()
    {
        var bug = new Bug();
        bug.NxtState(Bug.Trig.LetsSee);
        bug.NxtState(Bug.Trig.HaveNoTime);
        bug.NxtState(Bug.Trig.ToDeffOthrvw);
        //TestContext.WriteLine(bug.GetState().ToString());
        Assert.AreEqual(Bug.State.DeffOverview, bug.GetState(), $"\n\nTest - {MethodBase.GetCurrentMethod().Name} - NotPassed\n\n");
    }

    [TestMethod]
    public void TestMethodToReopen()
    {
        var bug = new Bug();
        bug.NxtState(Bug.Trig.LetsSee);
        bug.NxtState(Bug.Trig.ToCorr);
        bug.NxtState(Bug.Trig.Solving);
        bug.NxtState(Bug.Trig.ProbSolved);
        bug.NxtState(Bug.Trig.Reopeni);
        //TestContext.WriteLine(bug.GetState().ToString());
        Assert.AreEqual(Bug.State.ReOpen, bug.GetState(), $"\n\nTest - {MethodBase.GetCurrentMethod().Name} - NotPassed\n\n");
    }

    [TestMethod]
    public void TestMethodToReopenFullCycle()
    {
        var bug = new Bug();
        bug.NxtState(Bug.Trig.LetsSee);
        bug.NxtState(Bug.Trig.ToCorr);
        bug.NxtState(Bug.Trig.Solving);
        bug.NxtState(Bug.Trig.ProbSolved);
        bug.NxtState(Bug.Trig.Reopeni);
        bug.NxtState(Bug.Trig.Reopeni);
        //TestContext.WriteLine(bug.GetState().ToString());
        Assert.AreEqual(Bug.State.DeffOverview, bug.GetState(), $"\n\nTest - {MethodBase.GetCurrentMethod().Name} - NotPassed\n\n");
    }

    [TestMethod]
    public void TestMethodNop()
    {
        var bug = new Bug();
        bug.NxtState(Bug.Trig.LetsSee);
        bug.NxtState(Bug.Trig.Nop);
        //TestContext.WriteLine(bug.GetState().ToString());
        Assert.AreEqual(Bug.State.DeffOverview, bug.GetState(), $"\n\nTest - {MethodBase.GetCurrentMethod().Name} - NotPassed\n\n");
    }

    [TestMethod]
    public void TestMethodShortNop()
    {
        var bug = new Bug();
        bug.NxtState(Bug.Trig.Nop);
        //TestContext.WriteLine(bug.GetState().ToString());
        Assert.AreEqual(Bug.State.NewDeff, bug.GetState(), $"\n\nTest - {MethodBase.GetCurrentMethod().Name} - NotPassed\n\n");
    }

    [TestMethod]
    public void TestMethodThrow()
    {
        var bug = new Bug();
        Assert.Throws<InvalidOperationException>(() => bug.NxtState(Bug.Trig.Solving));
        //TestContext.WriteLine(bug.GetState().ToString());
        //Assert.AreEqual(Bug.State.NewDeff, bug.GetState(), $"\n\nTest - {MethodBase.GetCurrentMethod().Name} - NotPassed\n\n");
    }

    [TestMethod]
    public void TestMethodLongThrow()
    {
        var bug = new Bug();
        bug.NxtState(Bug.Trig.LetsSee);
        Assert.Throws<InvalidOperationException>(() => bug.NxtState(Bug.Trig.ItsNotOk));
        //TestContext.WriteLine(bug.GetState().ToString());
        //Assert.AreEqual(Bug.State.NewDeff, bug.GetState(), $"\n\nTest - {MethodBase.GetCurrentMethod().Name} - NotPassed\n\n");
    }

    [TestMethod]
    public void TestMethodNoThrow()
    {
        var bug = new Bug();
        //Assert.DoesNotThrow(() => bug.NxtState(Bug.Trig.LetsSee));
        try
        {
            bug.NxtState(Bug.Trig.LetsSee);
        }
        catch (Exception ex)
        {
            Assert.Fail($"exept-thrown: {ex.Message}");
        }
        //TestContext.WriteLine(bug.GetState().ToString());
        Assert.AreEqual(Bug.State.DeffOverview, bug.GetState(), $"\n\nTest - {MethodBase.GetCurrentMethod().Name} - NotPassed\n\n");
    }
}
