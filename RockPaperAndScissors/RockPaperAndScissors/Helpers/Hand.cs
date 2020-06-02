using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperAndScissors.Helpers
{
    public class Hand
    {
        public OptionRPS Selection { get; set; }
        public OptionRPS WinsAgaintst { get; set; }
        public OptionRPS LosesAgaintst { get; set; }
        public string Image { get; set; }

        public GameStatus PlayAgainst(Hand opponentHand)
        {
            if (Selection == opponentHand.Selection)
            {
                return GameStatus.Draw;
            }
            if(LosesAgaintst == opponentHand.Selection)
            {
                return GameStatus.Loss;
            }
            return GameStatus.Victory;
        }

    }
}
