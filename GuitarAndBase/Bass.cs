using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarAndBass
{
    class Bass : StrumInstrument
    {
        private string[] noFretNotes = { "E", "A", "D", "G" };
        private string[] firstFretNotes = { "F", "A#", "D#", "G#" };
        private string[] secondFretNotes = { "F#", "B", "E", "A" };

        public Bass()
        {
            this.stringCount = 4;
            this.fretCount = 3;
        }

        public Bass(int stringPosition, int fretPosition)
        {
            this.stringCount = 4;
            this.fretCount = 3;
            this.stringPosition = stringPosition;
            this.fretPosition = fretPosition;
        }

        public override string Strum()
        {
            string note = "You just played air bass. Please select a string (0-5) and optional fret (0-2) to strum a note.";

            if (stringPosition != null)
            {
                if (stringPosition < 0 || stringPosition > 3)
                {
                    note = "There was an issue with your string placement on the Bass. Please lift and select a string from 0 to 3.";
                }
                else
                {
                    if (fretPosition == 0 || fretPosition == null)
                    {
                        note = "You played the " + noFretNotes[(int)stringPosition] + " note with no fret on the Bass!";
                    }
                    else if (fretPosition == 1)
                    {
                        note = "You played the " + firstFretNotes[(int)stringPosition] + " note on the first fret on the Bass!";
                    }
                    else if (fretPosition == 2)
                    {
                        note = "You played the " + secondFretNotes[(int)stringPosition] + " note on the second fret on the Bass!";
                    }
                    else
                    {
                        note = "There was an issue with your fret placement on the Bass. Please select a fret of 0, 1, or 2.";
                    }
                }

            }

            return note;
        }

        public override string Lift()
        {
            stringPosition = null;
            fretPosition = null;
            string message = "You have released your notes on the bass.";

            return message;
        }

    }
}
