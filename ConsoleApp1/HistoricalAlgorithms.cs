using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyAlgorithms
{
    class HistoricalAlgorithm
    {
        // Returns a coded message using the Atbash algorithm
        // Applying the method twice will return the decoded message 
        public static string AtbashEncodeAndDecode(string msg)
        {
            string encoded = "";
            int tmp = 0;
            foreach (char c in msg)
                if (c >= 'A' && c <= 'Z')
                {
                    tmp = (c - 25 - 'A') % 26;
                    tmp = tmp >= 0 ? tmp : tmp * (-1);
                    encoded += (char)('A' + tmp);
                }
                else if (c >= 'a' && c <= 'z')
                {
                    tmp = (c - 25 - 'a') % 26;
                    tmp = tmp >= 0 ? tmp : tmp * (-1);
                    encoded += (char)('a' + tmp);
                }
                else
                    encoded += c;
            return encoded;
        }

        // Returns a coded message using the Rotation algorithm
        // or a human readable message using the Rotation algorithm
        // It depends from the flag ( e for encode, d for decode )
        public static string RotationEncodeAndDecode(string msg, int step, char flag)
        {
            string returnMessage = "";
            int tmp = 0;
            foreach (char c in msg)
                if (c >= 'A' && c <= 'Z')
                {
                    if (flag == 'e' || flag == 'E')
                        tmp = (c + step - 'A') % 26;
                    else if (flag == 'd' || flag == 'D')
                    {
                        tmp = (c - step - 'A') % 26;
                        // U slucaju da je broj negativan predstavi  ga kao pozitivan moduo ( -3 <=> 23 )
                        tmp = tmp >= 0 ? tmp : tmp + 26;
                    }
                    returnMessage += (char)('A' + tmp);
                }
                else if (c >= 'a' && c <= 'z')
                {
                    if (flag == 'e' || flag == 'E')
                        tmp = (c + step - 'A') % 26;
                    else if (flag == 'd' || flag == 'D')
                    {
                        tmp = (c - step - 'a') % 26;
                        // U slucaju da je broj negativan predstavi  ga kao pozitivan moduo ( -3 <=> 23 )
                        tmp = tmp >= 0 ? tmp : tmp + 26;
                    }
                    returnMessage += (char)('a' + tmp);
                }
                else
                    returnMessage += c;
            return returnMessage;
        }

        // Returns either a coded message using the Rotation algorithm and the Serbian alphabet
        // or a human readable message using the Rotation algorithm and the Serbian alphabet
        // It depends from the flag ( e for encode, d for decode )
        // U PITANJU JE JEBENA AZBUKA JER DJURIC PISE AZBUKU LATINICNIM SLOVIMA
        public static string SerbianAlphabetRotationEncodeAndDecode(string msg, int step, char flag)
        {
            //ArrayList alphabetLowerCase = new ArrayList(new string[] { "a", "b", "c", "č", "ć", "d", "dž", "đ", "e", "f", "g", "h", "i", "j", "k", "l", "lj", "m", "n", "nj", "o", "p", "r", "s", "š", "t", "u", "v", "z", "ž" });
            ArrayList alphabetLowerCase = new ArrayList(new string[] { "a", "b", "v", "g", "d", "đ", "e", "ž", "z", "i", "j", "k", "l", "lj", "m", "n", "nj", "o", "p", "r", "s", "t", "ć", "u", "f", "h", "c", "č", "dž", "š" });
            ArrayList alphabetUpperCase = new ArrayList();
            string returnMessage = "";
            int index = 0;
            foreach (string s in alphabetLowerCase)
                alphabetUpperCase.Add(s.ToUpper());

            for (int i = 0; i < msg.Length; ++i)
            {
                if (alphabetUpperCase.Contains(msg[i].ToString()))
                {
                    if ((i + 1) < msg.Length &&
                       ((msg[i].Equals('D') && msg[i + 1].Equals('Ž')) || (msg[i].Equals('L') && msg[i + 1].Equals('J')) || (msg[i].Equals('N') && msg[i + 1].Equals('J'))))
                        index = alphabetUpperCase.IndexOf(msg[i].ToString() + msg[++i].ToString());
                    else
                        index = alphabetUpperCase.IndexOf(msg[i].ToString());
                    if (flag == 'e' || flag == 'E')
                        index = (index + step) % 30;
                    else if (flag == 'd' || flag == 'D')
                    {
                        index = (index - step) % 30;
                        index = index >= 0 ? index : index + 30;
                    }
                    returnMessage += alphabetUpperCase[index];
                }
                else if (alphabetLowerCase.Contains(msg[i].ToString()))
                {
                    if ((i + 1) < msg.Length &&
                        ((msg[i].Equals('d') && msg[i + 1].Equals('ž')) || (msg[i].Equals('l') && msg[i + 1].Equals('j')) || (msg[i].Equals('n') && msg[i + 1].Equals('j'))))
                        index = alphabetLowerCase.IndexOf(msg[i].ToString() + msg[++i].ToString());
                    else
                        index = alphabetLowerCase.IndexOf(msg[i].ToString());
                    if (flag == 'e' || flag == 'E')
                        index = (index + step) % 30;
                    else if (flag == 'd' || flag == 'D')
                    {
                        index = (index - step) % 30;
                        index = index >= 0 ? index : index + 30;
                    }
                    returnMessage += alphabetLowerCase[index];
                }
                else
                    returnMessage += msg[i];
            }
            return returnMessage;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string msg1 = "ETFUKZALRVRPIOLIESNOVST";
            string msg2 = "ŠŽJPTHDRAORŽŽNJDRŽIDŽODŽIRDOJNEŽLJIDEDŽNJOŽPRTNJ";
            string msg3 = "ŠIARIZIPETKRKELZNEARSUJGSATOKPTE";
            string msg4 = "DVKST LSZPS EONIS PNAET JLIRU OJLZU SAOAP";
            string msg5 = "WKHVHYHQWKFKDUDFWHURIWKHSDVVZRUGLVU";
            string msg6 = "GSVVRTSGSXSZIZXGVILUGSVKZHHDLIWRHL";
            string[] msgs = new string[] { msg1, msg2, msg3, msg4, msg5, msg6 };
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            //string msg = "ABCČĆDDŽĐEFGHIJKLLJMNNJOPRSŠTUVZŽ";
            //msg = msg.ToLower();
            //int i = 3;
            //Console.WriteLine("Message: {0}\n", msg);
            for (int i = 0; i < 10; ++i)
            {
                int j = 4;
                string decoded = RotationEncodeAndDecode(msgs[j], i, 'd');
                string encoded = RotationEncodeAndDecode(decoded, i, 'e');
                Console.WriteLine("ROT{2}:\nEncoded message: {1}\nDecoded message  {0}", encoded, decoded, i);
                Console.WriteLine("--------------------------------");
            }
            for (int i = 0; i < 8; ++i)
                Console.Write(msg3[i] + "   ");
            Console.Write("\n ");
            for (int i = 8; i < 24; ++i)
                Console.Write(msg3[i] + " ");
            Console.Write("\n  ");
            for (int i = 24; i < 32; ++i)
                Console.Write(msg3[i] + "   ");

            Console.ReadLine();
        }

    }
}
