using System;
using ClassLibrary1;

namespace SR1902
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            ElectoralCommission commission = new ElectoralCommission();
            for (int i = 0; i < 10; i++)
            {
                Voter voter = new Voter();
                commission.OnVote += voter.OnVoteHandler;
            }

            VoteEventArgs voteEventArgs = commission.Vote("Question?");
            Console.WriteLine($"{voteEventArgs.Question}: For: {voteEventArgs.VoteFor}; Against: {voteEventArgs.VoteAgainst}");
        }
    }
}