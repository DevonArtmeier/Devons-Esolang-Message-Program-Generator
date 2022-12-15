using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsolangMsgGen
{
    internal class LOLCODE
    {
        /// <summary>
        /// Generate LOLCODE program for displaying a message
        /// </summary>
        /// <param name="message">Message to display</param>
        public static string Generate(string message)
        {
            return "HAI 1.2\r\nCAN HAS STDIO?\r\nVISIBLE \"" +
                message.Replace(":", "::")
                       .Replace("\n", ":)")
                       .Replace("\r", ":>")
                       .Replace("\a", ":o")
                       .Replace("\"", ":\"") +
                "\"\r\nKTHXBYE";
        }
    }
}
