using Stateless;

namespace Proc
{
    public class Bug
    {
        public enum State
        {
            NewDeff,
            DeffOverview, 
            NotDeff, 
            DoNotCorr, 
            Dubl,
            CanNotRepli, 
            Ret, 
            NoTimeNow, 
            NeedSepSol, 
            OthrProdProb, 
            NeedInfo, 
            Corr, 
            Close, 
            ReOpen, 
            IsProbSolved,
            IsOk
        }

        public enum Trig
        {
            ToCorr, 
            ToIsOk, 
            Solving, 
            ProbSolved, 
            ProbNotSolved, 
            ItsOk, 
            ItsNotOk, 
            Closing, 
            Reopeni, 
            ToDeffOthrvw, 
            CanNotOthrv, 
            Returning, 
            HaveNoTime, 
            HaveNoPropSol, 
            ItsNotMyProb, 
            DontHaveInfo, 
            LetsSee, 
            ItsNotDeff, 
            ItsDoNotCorr, 
            ItsDubl, 
            ItsNotReplicable, 
            Nop
        }

        private StateMachine<State, Trig> workFlow = new StateMachine<State, Trig>(State.NewDeff);

        public State GetState()
        {
            return workFlow.State;
        }

        public void NxtState(Trig trig)
        {
            workFlow.Fire(trig);
        }

        public Bug ()
        {
            // The comments between lines of code are purely auxillary
            // Also there is an auxillary picture in the repo, the code below is essentially based on it
            // You can risk your eyes and view it xD

            // light-blue on picture
            workFlow.Configure(State.NewDeff).Permit(Trig.LetsSee, State.DeffOverview);
            
            // swampy on picture
            workFlow.Configure(State.DeffOverview).Permit(Trig.ToCorr, State.Corr);
            
            // light-green on picture
            workFlow.Configure(State.ReOpen).Permit(Trig.Reopeni, State.DeffOverview);
            
            // orange on picture
            workFlow.Configure(State.Corr).Permit(Trig.Solving, State.IsProbSolved);
            
            // light-orange on picture
            workFlow.Configure(State.IsProbSolved).Permit(Trig.ProbSolved, State.Close);
            
            // azure(?) on picture
            workFlow.Configure(State.IsProbSolved).Permit(Trig.ProbNotSolved, State.Ret);
            
            // light-red on picture
            workFlow.Configure(State.IsOk).Permit(Trig.ItsOk, State.Close);
            
            // dark-red on picture
            workFlow.Configure(State.IsOk).Permit(Trig.ItsNotOk, State.Ret);
            
            // pink on picture
            workFlow.Configure(State.Close).Permit(Trig.Reopeni, State.ReOpen);
            
            // light-pink on picture
            workFlow.Configure(State.Ret).Permit(Trig.Returning, State.DeffOverview);

            // green on picture
            workFlow.Configure(State.DeffOverview).Permit(Trig.HaveNoTime, State.NoTimeNow);
            workFlow.Configure(State.DeffOverview).Permit(Trig.HaveNoPropSol, State.NeedSepSol);
            workFlow.Configure(State.DeffOverview).Permit(Trig.ItsNotMyProb, State.OthrProdProb);
            workFlow.Configure(State.DeffOverview).Permit(Trig.DontHaveInfo, State.NeedInfo);

            // dark-pink on picture
            workFlow.Configure(State.DeffOverview).Permit(Trig.ItsNotDeff, State.NotDeff);
            workFlow.Configure(State.DeffOverview).Permit(Trig.ItsDoNotCorr, State.DoNotCorr);
            workFlow.Configure(State.DeffOverview).Permit(Trig.ItsDubl, State.Dubl);
            workFlow.Configure(State.DeffOverview).Permit(Trig.ItsNotReplicable, State.CanNotRepli);

            // purple on picture
            workFlow.Configure(State.NoTimeNow).Permit(Trig.ToDeffOthrvw, State.DeffOverview);
            workFlow.Configure(State.NeedSepSol).Permit(Trig.ToDeffOthrvw, State.DeffOverview);
            workFlow.Configure(State.OthrProdProb).Permit(Trig.ToDeffOthrvw, State.DeffOverview);
            workFlow.Configure(State.NeedInfo).Permit(Trig.ToDeffOthrvw, State.DeffOverview);

            // red on picture
            workFlow.Configure(State.NoTimeNow).Permit(Trig.ToCorr, State.Corr);
            workFlow.Configure(State.NeedSepSol).Permit(Trig.ToCorr, State.Corr);
            workFlow.Configure(State.OthrProdProb).Permit(Trig.ToCorr, State.Corr);
            workFlow.Configure(State.NeedInfo).Permit(Trig.ToCorr, State.Corr);

            // black on picture
            workFlow.Configure(State.Corr).Permit(Trig.ItsNotDeff, State.NotDeff);
            workFlow.Configure(State.Corr).Permit(Trig.ItsDoNotCorr, State.DoNotCorr);
            workFlow.Configure(State.Corr).Permit(Trig.ItsDubl, State.Dubl);
            workFlow.Configure(State.Corr).Permit(Trig.ItsNotReplicable, State.CanNotRepli);

            // yellow on picture
            workFlow.Configure(State.Corr).Permit(Trig.HaveNoTime, State.NoTimeNow);
            workFlow.Configure(State.Corr).Permit(Trig.HaveNoPropSol, State.NeedSepSol);
            workFlow.Configure(State.Corr).Permit(Trig.ItsNotMyProb, State.OthrProdProb);
            workFlow.Configure(State.Corr).Permit(Trig.DontHaveInfo, State.NeedInfo);

            // blue on picture
            workFlow.Configure(State.NotDeff).Permit(Trig.ToIsOk, State.IsOk);
            workFlow.Configure(State.DoNotCorr).Permit(Trig.ToIsOk, State.IsOk);
            workFlow.Configure(State.Dubl).Permit(Trig.ToIsOk, State.IsOk);
            workFlow.Configure(State.CanNotRepli).Permit(Trig.ToIsOk, State.IsOk);

            // when nop is performed, we don't move anywhere
            workFlow.Configure(State.NewDeff).Ignore(Trig.Nop);
            workFlow.Configure(State.DeffOverview).Ignore(Trig.Nop);
            workFlow.Configure(State.Corr).Ignore(Trig.Nop);
            workFlow.Configure(State.NoTimeNow).Ignore(Trig.Nop);
            workFlow.Configure(State.NeedSepSol).Ignore(Trig.Nop);
            workFlow.Configure(State.OthrProdProb).Ignore(Trig.Nop);
            workFlow.Configure(State.NeedInfo).Ignore(Trig.Nop);
            workFlow.Configure(State.NotDeff).Ignore(Trig.Nop);
            workFlow.Configure(State.DoNotCorr).Ignore(Trig.Nop);
            workFlow.Configure(State.Dubl).Ignore(Trig.Nop);
            workFlow.Configure(State.CanNotRepli).Ignore(Trig.Nop);
            workFlow.Configure(State.Ret).Ignore(Trig.Nop);
            workFlow.Configure(State.Close).Ignore(Trig.Nop);
            workFlow.Configure(State.IsProbSolved).Ignore(Trig.Nop);
            workFlow.Configure(State.IsOk).Ignore(Trig.Nop);
            workFlow.Configure(State.ReOpen).Ignore(Trig.Nop);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var bugs = new Bug();
            Console.WriteLine(bugs.GetState().ToString());
            bugs.NxtState(Bug.Trig.LetsSee);
            Console.WriteLine(bugs.GetState().ToString());
            //Console.WriteLine("It works\nhoraaay!!!!!!!");
        }
    }
}