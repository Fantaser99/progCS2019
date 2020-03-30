using System;

namespace ClassLibrary1
{
    public class VoteEventArgs : EventArgs
    {
        public string Question { get; set; }
        public int VoteFor { get; set; }
        public int VoteAgainst { get; set; }
    }
}