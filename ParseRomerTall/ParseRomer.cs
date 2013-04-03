using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ParseRomerTall
{
    public class RomanWrapper
    {
        public int value { get; set; }
        public string RomanValue { get; set; }
    }

    public class ParseRomer
    {
        private List<RomanWrapper> staticRomans;

        public ParseRomer()
        {
            staticRomans = new List<RomanWrapper>()
                {
                    new RomanWrapper() {RomanValue = "I",value = 1},
                    new RomanWrapper() {RomanValue = "V",value = 5},
                    new RomanWrapper() {RomanValue = "X", value = 10},
                    new RomanWrapper() {RomanValue = "L", value = 50},
                    new RomanWrapper() {RomanValue = "C", value = 100},
                    new RomanWrapper() {RomanValue = "D",value = 500},
                    new RomanWrapper() {RomanValue = "M", value = 1000}
                };
        }

        


        //public partial class System.String 
        //{
        //    public string Left()
        //    {
        //        return this.
        //    }
        //}

        public int Parse(string Roman)
        {
            if (ValidateRomaenValueInputForFucksSake(Roman))
            {
                return Parse(Roman, 0, 0);
            }
        }

        private bool ValidateRomaenValueInputForFucksSake(string roman)
        {
            //List<RomanWrapper> validate = new List<RomanWrapper>();
            //for (int i = 0; i < roman.Length; i++)
            //{
            //    if(staticRomans.Count(m=>m.RomanValue == roman[i].ToString()) == 0)throw new Exception("You suck at roman numerals you invalid fool!!");
            //    validate.Add(new RomanWrapper(){RomanValue = roman[i].ToString(),value = staticRomans.First(m=> m.RomanValue == roman[i].ToString()).value});
            //}
            /*
             * CM
             * 
             * */

            

            var tabell = new List<RomanWrapper>(){staticRomans.Count};
            Array.Copy(staticRomans.ToArray(),tabell.ToArray(),staticRomans.Count);
            
            var last = new RomanWrapper(){RomanValue = "",value = 0};
            int max = 0;
            int counter = 0;
            bool negative = false;
            for (int i = roman.Length - 1; i >= roman.Length; i--)
            {

                if (last.RomanValue != roman[i].ToString())
                {
                   var temp = tabell.First(m => m.RomanValue == roman[i].ToString());
                    if (temp == null) return false;

                    if (temp.value < max && negative == true || counter > 1) return false;
                    if (temp.value < max)
                    {
                        if (max/temp.value != 10) return false;
                        negative = true;
                    }
                    else
                    {
                        max = temp.value;
                        negative = false;
                    }

                    last = temp;
                   tabell.Remove(tabell.First(m => m.RomanValue == roman[i].ToString()));
                   counter = 1;
                }
                else
                {
                    counter++;
                    if(counter > 3) return false;
                }

                
            }
            

        }

        private int Parse(string Roman,int sum = 0,int LastValue = 0)
        {
            
            if (String.IsNullOrEmpty(Roman)) return sum;
            int current = staticRomans.First(m => m.RomanValue == Roman[Roman.Length - 1].ToString()).value;
            if(current >= LastValue)
            return Parse(Roman.Substring(0,Roman.Length-1),current+sum,current);
            else
            {
                return Parse(Roman.Substring(0, Roman.Length - 1),  sum-current, current);
            }
        }

        public string Parse(int i, int enkelt = 1)
        {
            //Debug.WriteLine(string.Format("i:{0},enkelt:{1}",i,enkelt));
            if(i > 3999 ) throw new Exception("Max man kunne ha i det romerske riket av noen som helst ting var 3999");
            if (i == 0) return "";
            //1999
            //MCMXCIX
            var sb = new StringBuilder();
            var res = i%10;
            if (res == 9)
            {
                res -= 10;
                sb.Append(staticRomans[enkelt*2].RomanValue);
            }

            if(res >= 4)
            {
                res -= 5;
                sb.Append(staticRomans[(enkelt*2) - 1].RomanValue);

            }
            if (res < 0)
            {
                sb.Insert(0,staticRomans[(enkelt - 1)*2].RomanValue);
            }
            else
            {
                for (; res > 0; res--)
                {
                    sb.Append(staticRomans[(enkelt - 1)*2].RomanValue);
                }
            }
            return sb.Insert(0, Parse(i/10, ++enkelt)).ToString();

        }
    }
}