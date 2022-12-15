using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsolangMsgGen
{
    internal class Boolfk
    {
        /// <summary>
        /// Generate Boolf**k program for displaying a message
        /// </summary>
        /// <param name="message">Message to display</param>
        public static string Generate(string message)
        {
            StringBuilder sb = new StringBuilder();
            bool curBit = false;

            foreach (byte msgByte in Encoding.UTF8.GetBytes(message))
            {
                for (int i = 0; i < 8; ++i)
                {
                    bool bit = ((msgByte >> i) & 1) == 1;
                    if (curBit != bit)
                        sb.Append("+");
                    curBit = bit;
                    sb.Append(";");
                }
            }

            return sb.ToString();
        }
    }
}
