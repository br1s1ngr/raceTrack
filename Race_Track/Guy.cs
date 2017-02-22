using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Race_Track
{
    class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;

        public RadioButton MyRadioButton;
        public Label MyLabel;

        internal Guy () {
            MyBet = new Bet()
            {
                Bettor = this
            };
        }
        public void UpdateLabels()
        {
            MyLabel.Text = MyBet.GetDescription();
            MyRadioButton.Text = Name + " has " + Cash + " bucks ";
        }
        public void ClearBet()
        {
            MyBet.Amount = 0;
        }
        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            if (Cash >= BetAmount) {
                MyBet.Amount = BetAmount;
                MyBet.Dog = DogToWin;
                return true;
            }
            else
            {
                MessageBox.Show("sorry, you can't place a bet", "broke ass");
                MyBet.Amount = 0;
                return false;
            }

        }
        public void Collect(int winner)
        {
            //ask my bet to pay out, clear my bet and update my labels
            Cash += MyBet.PayOut(winner);
            MyBet.Amount = 0;
            UpdateLabels();
        }
    }
}
