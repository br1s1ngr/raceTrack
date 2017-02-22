using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Race_Track
{
    class Greyhound
    {
        public int StartingPosition;
        public int RaceTrackLength;
        public PictureBox MyPictureBox;
        public int Location = 0;
        public Random Randomizer;

        public bool Run(){
            Location += Randomizer.Next(1, 11);
            MyPictureBox.Left = StartingPosition + Location;

            if (MyPictureBox.Left >= RaceTrackLength)
                return true;
            else
                return false;
        }
        public void TakeStartingPosition()
        {
            Location = 0;
            MyPictureBox.Left = StartingPosition;
        }
    }
}
