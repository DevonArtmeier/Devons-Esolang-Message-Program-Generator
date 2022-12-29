using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsolangMsgGenWPF
{
    internal class LoveLang
    {
        private static byte[][] heartBytes = new byte[][]
        {
            new byte[] { 0xE2, 0x9D, 0xA4, 0xEF, 0xB8, 0x8F },  // Red
            new byte[] { 0xF0, 0x9F, 0xA7, 0xA1 },              // Orange
            new byte[] { 0xF0, 0x9F, 0x92, 0x9B },              // Yellow
            new byte[] { 0xF0, 0x9F, 0x92, 0x9A },              // Green
            new byte[] { 0xF0, 0x9F, 0x92, 0x99 },              // Blue
            new byte[] { 0xF0, 0x9F, 0x92, 0x9C },              // Purple
            new byte[] { 0xF0, 0x9F, 0xA4, 0x8E },              // Brown
            new byte[] { 0xF0, 0x9F, 0x96, 0xA4 },              // Black
            new byte[] { 0xF0, 0x9F, 0xA4, 0x8D },              // White
        };

        /// <summary>
        /// Generate LoveLang program for displaying a message
        /// </summary>
        /// <param name="message">Message to display</param>
        public static string Generate(string message)
        {
            List<byte> codeBytes = new List<byte>();
            foreach (byte msgByte in Encoding.UTF8.GetBytes(message))
            {
                // Copy number in temporary cell
                codeBytes.AddRange(heartBytes[0]);

                // Number
                bool gotLead = false;
                for (int i = 7; i >= 0; --i)
                {
                    int bit = (msgByte >> i) & 1;
                    if (gotLead || (!gotLead && bit == 1))
                    {
                        gotLead = true;
                        codeBytes.AddRange(heartBytes[bit + 7]);
                    }
                }

                // Copy temporary cell to output stream
                codeBytes.AddRange(heartBytes[0]);
                codeBytes.AddRange(heartBytes[5]);
            }
            return Encoding.UTF8.GetString(codeBytes.ToArray());
        }
    }
}
