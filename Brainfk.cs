using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsolangMsgGenWPF
{
    internal class Brainfk
    {
        /// <summary>
        /// Addition/subtraction operations
        /// </summary>
        private static string[] addOps = new string[256];
        private static string[] subOps = new string[256];

        /// <summary>
        /// Generate addition/subtraction operations
        /// </summary>
        public static void GenOperations()
        {
            addOps[0] = "";
            subOps[0] = "";
            addOps[1] = "+";
            subOps[1] = "-";

            for (int i = 2; i < 256; ++i)
            {
                // Get all divisible numbers
                List<int> div = new List<int>();
                for (int j = 1; j <= i; ++j)
                {
                    if (i % j == 0)
                        div.Add(j);
                }

                // Get smallest set of divisible numbers
                int num1 = ((div.Count & 1) == 0) ? div[(div.Count / 2)] : div[div.Count / 2];
                int num2 = ((div.Count & 1) == 0) ? div[(div.Count / 2) - 1] : div[div.Count / 2];

                // Find shortest operation
                string addOp = ">" + new string('+', num1) + "[<" + new string('+', num2) + ">-]";
                string subOp = ">" + new string('+', num1) + "[<" + new string('-', num2) + ">-]";

                for (int j = 1; j < i; ++j)
                {
                    string addOpChk = addOps[j] + addOps[i - j];
                    if (addOpChk.Length < addOp.Length)
                    {
                        addOp = addOpChk;
                        subOp = subOps[j] + subOps[i - j];
                    }
                }

                addOps[i] = addOp;
                subOps[i] = subOp;
            }

            // Add print operators
            for (int i = 0; i < 256; ++i)
            {
                if (addOps[i].Length > 0 && addOps[i].Last() == ']')
                {
                    addOps[i] += '<';
                    subOps[i] += '<';
                }
                addOps[i] += '.';
                subOps[i] += '.';
            }
        }

        /// <summary>
        /// Generate Brainf**k program for displaying a message
        /// </summary>
        /// <param name="message">Message to display</param>
        public static string Generate(string message)
        {
            StringBuilder sb = new StringBuilder();
            byte curByte = 0;

            foreach (byte msgByte in Encoding.UTF8.GetBytes(message))
            {
                sb.Append((msgByte < curByte) ?
                    subOps[curByte - msgByte] :
                    addOps[msgByte - curByte]);
                curByte = msgByte;
            }

            return sb.ToString();
        }
    }
}
