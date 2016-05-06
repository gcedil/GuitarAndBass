using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarAndBass
{
    class GBStudio
    {
        static void Main(string[] args)
        {
            InstrumentFactory factory = new InstrumentFactory();
            StrumInstrument instrument = null;
            var ignoreCase = StringComparison.InvariantCultureIgnoreCase;
            string input;
            Console.WriteLine("Welcome to the Guitar and Bass studio! Input R to run test script or..");
            Console.WriteLine();
            Console.WriteLine("Input G to create a guitar or B to create a bass and begin playing!");
            do{
                input = Console.ReadLine();

                if (input.Equals("r", ignoreCase))
                {
                    testScript();
                }
                else if(input.Equals("g", ignoreCase) || input.Equals("b", ignoreCase))
                {
                    instrument = factory.makeInstrument(input);
                    Console.WriteLine("You picked up the " + instrument.GetType().Name + " instrument. Input 'down' to put the instrument down.");
                    Console.WriteLine("Input a string and optional fret to play a note. Ex: 2,1 (No Whitespace)");
                    do
                    {
                        input = Console.ReadLine();

                        if(input.Length == 3 && input[1].Equals(','))
                        {
                            selectNote(instrument, (int?)Char.GetNumericValue(input[0]), (int?)Char.GetNumericValue(input[2]));
                            Console.WriteLine(instrument.Strum());
                        }
                        else if(input.Equals("down"))
                        {
                            Console.WriteLine("You put down the " + instrument.GetType().Name + ".");
                            Console.WriteLine("Input G to pick up the guitar, B to pick up the bass, R to run test script, or 'esc' to exit.");
                            Console.WriteLine();
                        }

                    } while (input != "down");                    
                }

            } while (input != "esc");            
        }

        public static void selectNote(StrumInstrument instrument, int? stringPos, int? fretPos)
        {
            instrument.Note(stringPos, fretPos);
            instrument.Strum();
        }

        public static void testScript()
        {
            //Example Test Script
            Guitar guitar = new Guitar(2, 1);
            //New Guitar Created - Note Selected: Eb  
            Console.WriteLine(guitar.Strum());
            Console.WriteLine(guitar.Lift());
            //Guitar String Released
            guitar.Note(1, 0);
            //Guitar - Note Selected: A            
            Console.WriteLine(guitar.Strum());
            Console.WriteLine();

            Bass bass = new Bass(0, 2);
            //New Bass Created - Note Selected: F#
            Console.WriteLine(bass.Strum());
            Console.WriteLine(bass.Lift());
            //Bass String Released
            bass.Note(2, 1);
            //Bass - Note Selected: D#
            Console.WriteLine(bass.Strum());
            Console.WriteLine();

            guitar.Lift();
            bass.Lift();
            //Guitar and Base Strings Released
            IsSynchronized sync = new IsSynchronized();
            guitar.Note(0, 0);
            Console.WriteLine(guitar.Strum());
            //Guitar - Note Selected: E
            bass.stringPosition = 0;
            Console.WriteLine(bass.Strum());
            //Bass - Note Selected: E (fret = null)
            Console.WriteLine(sync.Check(guitar, bass));
            Console.WriteLine();

            guitar.Note(2, 0);
            Console.WriteLine(guitar.Strum());
            //Guitar - Note Selected: D
            bass.Note(1, 1);
            //Bass - Note Selected: A#
            Console.WriteLine(bass.Strum());
            Console.WriteLine(sync.Check(guitar, bass));
            Console.WriteLine();
        }
    }
}
