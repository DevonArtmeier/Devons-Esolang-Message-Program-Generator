using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsolangMsgGen
{
    internal class Whitespace
    {
        /// <summary>
        /// Generate Whitespace program for displaying a message
        /// </summary>
        /// <param name="message">Message to display</param>
        public static string Generate(string message)
        {
            StringBuilder sb = new StringBuilder();

            foreach (byte msgByte in Encoding.UTF8.GetBytes(message))
            {
                // Push character onto stack
                sb.Append("   ");
                string chr = "";
                byte b = msgByte;
                while (b != 0)
                {
                    chr = (((b & 1) == 0) ? " " : "\t") + chr;
                    b >>= 1;
                }
                sb.Append(chr + "\n");

                // Pop and display character
                sb.Append("\t\n  ");
            }

            // Program end
            sb.Append("\n\n\n");

            return sb.ToString();
        }
    }
}
