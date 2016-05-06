using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarAndBass
{
    class Guitar : StrumInstrument
    {
        private string[] noFretNotes = { "E", "A", "D", "G", "B", "E" };
        private string[] firstFretNotes = { "F", "Bb", "Eb", "Ab", "C", "F" };

        public Guitar()
        {
            this.stringCount = 6;
            this.fretCount = 2;
        }

        public Guitar(int stringPosition, int fretPosition)
        {
            this.stringCount = 6;
            this.fretCount = 2;
            this.stringPosition = stringPosition;
            this.fretPosition = fretPosition;
        }        

        public override string Strum()
        {
            string note = "You just played air guitar. Please select a string (0-5) and optional fret (0-2) to strum a note.";

            if(stringPosition != null)
            {
                if(stringPosition < 0 || stringPosition > 5)
                {
                    note = "There was an issue with your string placement on the Guitar. Please lift and select a string from 0 to 5.";
                }
                else
                {
                    if (fretPosition == 0 || fretPosition == null)
                    {
                        note = "You played the " + noFretNotes[(int)stringPosition] + " note with no fret on the Guitar!";
                    }
                    else if (fretPosition == 1)
                    {
                        note = "You played the " + firstFretNotes[(int)stringPosition] + " note on the first fret on the Guitar!";
                    }
                    else
                    {
                        note = "There was an issue with your fret placement on the Guitar. Please select a fret of 0 or 1.";
                    }
                }
                
            }

            return note;
        }

        public override string Lift()
        {
            stringPosition = null;
            fretPosition = null;
            string message = "You have released your notes on the guitar.";

            return message;
        }

    }
}
