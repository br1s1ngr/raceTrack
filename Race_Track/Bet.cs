using System;
using System.Collections.Generic;
using System.Text;

namespace Race_Track
{
    class Bet
    {
        public int Amount;
        public int Dog ;
        public Guy Bettor;

        public string GetDescription()
        {
            if (Amount == 0)
                return (Bettor.Name + " hasn't placed a bet");
            else
                return (Bettor.Name + " bets " + Amount + " on dog #" + Dog );
        }
        public int PayOut(int Winner)
        {
            if (Dog == Winner)
                return Amount;
            else
                return (-Amount);
        }

    }
}
