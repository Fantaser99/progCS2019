using System;

namespace ClassLibrary1
{
    public class ElectoralCommission
    {
        public event EventHandler<VoteEventArgs> OnVote;

        public VoteEventArgs Vote(string Question)
        {
            VoteEventArgs voteEventArgs = new VoteEventArgs();
            voteEventArgs.Question = Question;
            OnVote?.Invoke(this, voteEventArgs);
            return voteEventArgs;
        }
    }
}