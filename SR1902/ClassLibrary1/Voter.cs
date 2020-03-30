using System;

namespace ClassLibrary1
{
    public class Voter
    {
        private static Random rnd = new Random();
        
        public void OnVoteHandler(object sender, VoteEventArgs args)
        {
            if (rnd.NextDouble() > 0.4)
                args.VoteFor++;
            else
            {
                args.VoteAgainst++;
            }
        }
    }
}