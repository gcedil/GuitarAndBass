using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarAndBass
{
    class IsSynchronized
    {
        public string Check(Guitar guitar, Bass bass)
        {
            string message = "The Guitar and Bass are not currently on the same note.";

            if (guitar.stringPosition == bass.stringPosition)
            {
                if (guitar.fretPosition == bass.fretPosition)
                {
                    message = "The Guitar and Bass are playing the same tune.";
                }
                else if(guitar.fretPosition == null || bass.fretPosition == null)
                {
                    if(guitar.fretPosition == 0 || bass.fretPosition == 0)
                    {
                        message = "The Guitar and Bass are playing the same tune.";
                    }
                }
            }

            return message;
        }

    }
}