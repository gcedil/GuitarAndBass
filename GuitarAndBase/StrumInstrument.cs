using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarAndBass
{
    abstract class StrumInstrument
    {
        public int stringCount { get; set; }
        public int fretCount { get; set; }
        public int? stringPosition { get; set; }
        public int? fretPosition { get; set; }

        public void Note(int? stringPosition, int? fretPosition)
        {
            this.stringPosition = stringPosition;
            this.fretPosition = fretPosition;
        }

        public abstract string Strum();
        public abstract string Lift();
    }
}
