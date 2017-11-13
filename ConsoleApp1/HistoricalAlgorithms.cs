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
            foreach (int c in msg)
                if (c >= 'A' && c <= 'Z')
                {
                    tmp = (c - 25 - 'A') % 26;
                    tmp = tmp >= 0 ? tmp : tmp * (-1);
                    encoded += (int)('A' + tmp);
                }
                else if (c >= 'a' && c <= 'z')
                {
                    tmp = (c - 25 - 'a') % 26;
                    tmp = tmp >= 0 ? tmp : tmp * (-1);
                    encoded += (int)('a' + tmp);
                }
                else
                    encoded += c;
            return encoded;
        }

        // Returns a coded message using the Rotation algorithm
        // or a human readable message using the Rotation algorithm
        // It depends from the flag ( e for encode, d for decode )
        public static string RotationEncodeAndDecode(string msg, int step, int flag)
        {
            string returnMessage = "";
            int tmp = 0;
            foreach (int c in msg)
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
                    returnMessage += (int)('A' + tmp);
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
                    returnMessage += (int)('a' + tmp);
                }
                else
                    returnMessage += c;
            return returnMessage;
        }

        // Returns either a coded message using the Rotation algorithm and the Serbian alphabet
        // or a human readable message using the Rotation algorithm and the Serbian alphabet
        // It depends from the flag ( e for encode, d for decode )
        // U PITANJU JE JEBENA AZBUKA JER DJURIC PISE AZBUKU LATINICNIM SLOVIMA
        public static string SerbianAlphabetRotationEncodeAndDecode(string msg, int step, int flag)
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

        static void Main1(string[] args)
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

    class RC4
    {
        int[] s;
        int[] k;
        int[] plainText;
        int[] cipherText;

        RC4(int sLength, string[] kArray)
        {
            s = new int[sLength];
            k = new int[kArray.Length];

            for (int i = 0; i < s.Length; ++i)
                s[i] = i;
            for (int j = 0; j < kArray.Length; ++j)
                k[j] = int.Parse(kArray[j]);
        }

        public void KSA(char[] pText)
        {
            plainText = new int[pText.Length];
            cipherText = new int[pText.Length];

            for (int i = 0; i < pText.Length; ++i)
                plainText[i] = pText[i];

            int j = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                j = (j + s[i] + k[i % k.Length]) % s.Length;
                Swap(i, j);
            }

            Console.Write("KSA: S[");
            foreach (int i in s)
                Console.Write(i + " ");
            Console.WriteLine("]");
        }

        public void PRGA()
        {
            int i, j, k;
            i = j = k = 0;
            int output = -1;
            while (output != 0)
            {
                i = (i + 1) % s.Length;
                j = (j + s[i]) % s.Length;
                Swap(i, j);
                output = (int)(s[(s[i] + s[j]) % s.Length]);
                // Encription
                cipherText[k] = plainText[k] ^ output;
                // Decription
                plainText[k] = cipherText[k++] ^ output;
            }

            Console.Write("PRGA: S[");
            foreach (int m in s)
                Console.Write(m + " ");
            Console.WriteLine("]");

            Console.Write("Plaintext: ");
            foreach (int m in plainText)
                Console.Write((char)m);
            Console.WriteLine();

            Console.Write("Ciphertext: ");
            foreach (int m in cipherText)
                Console.Write((char)m);
            Console.WriteLine();
        }

        private void Swap(int i, int j)
        {
            int tmp = s[i];
            s[i] = s[j];
            s[j] = tmp;
        }

        /*static void Main(string[] args)
        {
            int sn;
            string tmp;
            string[] kn;
            char[] tmpArr;
            try
            {
                Console.Write("Vector size: ");
                sn = int.Parse(Console.ReadLine());

                Console.Write("Key: ");
                tmp = Console.ReadLine();
                kn = tmp.Split(' ');

                Console.Write("Enter plaintext: ");
                tmpArr = Console.ReadLine().ToCharArray();

                RC4 rc4Generator = new RC4(sn, kn);
                rc4Generator.KSA(tmpArr);
                rc4Generator.PRGA();
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }*/
    }

    class Monosubtitution
    {
        char[] cipher;
        byte[] visited;

        Monosubtitution(char[] cipher, int flag)
        {
            this.cipher = new char[cipher.Length];
            this.cipher = cipher;
            visited = new byte[cipher.Length];
            // flag = 1 use Cyrilic input
            if (flag == 1)
            {
                Console.InputEncoding = Encoding.Unicode;
                Console.OutputEncoding = Encoding.Unicode;
            }
        }

        void ReplaceCharacter(char old, char newChar)
        {
            for (int i = 0; i < cipher.Length; ++i)
            {
                // This prevents changing characters that are already changed
                // If the character isn't already changed, change it
                if (visited[i] == 0 && cipher[i].Equals(old))
                {
                    visited[i] = 1;
                    cipher[i] = newChar;
                }
            }
        }

        void StartDecription()
        {
            string input;
            string[] arr;
            Console.WriteLine(cipher);
            Console.Write("Replace: ");
            input = Console.ReadLine();
            while (!input.Equals("КРАЈ"))
            {
                // Input format: А,Б
                arr = input.Split(',');
                ReplaceCharacter(arr[0].ToCharArray()[0], arr[1].ToCharArray()[0]);
                Console.Clear();
                Console.WriteLine(cipher);
                Console.Write("Replace: ");
                input = Console.ReadLine();

            }
        }
        public static void Main(string[] args)
        {
            string text = @"РЏКСЦЂЊР ШЗЦР ХЦХ РЏКСЦЂЊ ЖЂГРД ЏС БСЖРЦАХ ЖЂГРД ЕРОГРУСА АР БРГЕЂЊХБ ВЂЧХБР З ВРГХТЗ Х ЋРАРЕ ЏС ТАРБСАХЖЂЕЖ Х ЕХБПЂЦ ВРГХТР. ЕРОГРУСАР ЏС ШГРЏСБ ЋСЊСЖАРСЕЖЂО ЊСШР ШРЂ СШЕВЂАРЖ ТР ЕЊСЖЕШЗ ХТЦЂФПЗ ВЂЊЂЋЂБ ВГЂЕЦРЊС ЕЖЂОЂЋХЉДХМС КГРАМЗЕШС ГСЊЂЦЗМХЏС. ЋЂ ЖГХЋСЕСЖХИ ОЂЋХАР ЋЊРЋСЕСЖЂО ЊСШР ЏС ПХЦР АРЏЊСЈС ТЋРДС АР ЕЊСЖЗ ЕР ЕЊЂЏХИ ЖГХЕЖЂ БСЖРГР ЊХЕХАС. 
ХБС ЏС ЋЂПХЂ ВЂ ХАФСДСГЗ ШЂЏХ ОР ЏС ВГЂЏСШЖЂЊРЂ ОХЕЖРЊЗ РЏКСЦЗ. ЋРАРЕ ЏС ТАРНРЏАР ЖЗГХЕЖХНШР РЖГРШМХЏР ЕР ВГСШЂ ВСЖ БХЦХЂАР ВЂЕСЖХЦРМР ОЂЋХЉДС. ЖЂГРД ЏС ОГРУСА ЋЊС ОЂЋХАС Х ВЂЕЦЗФХЂ ЏС ШРЂ ОЦРЊАР ШРВХЏР ТР ЗЦРТ АР ЕЊСЖЕШЗ ХТЦЂФПЗ. ЕЖГЗШЖЗГР ЏС ЕРЕЖРЊЧСАР ЂЋ ЂЕРБАРСЕЖ ИХЧРЋР ЋСЦЂЊР ЂЋ ЦХЊСАЂО ОЊЂФУР, ЗТ ВЂБЂЈ ЋЊР Х ВЂ БХЦХЂАР ТРШЂЊХМР. ЕЖГЗШЖЗГАХ ВГЂГРНЗА ЏС ЗГРЋХЂ БЂГХЕ ШСЉЦСА. 
ТР ЊГСБС ХТОГРЋДС, ТРИЊРЧЗЏЗЈХ БСГРБР ПСТПСЋАЂЕЖХ ШЂЏС ЏС РЏКСЦ ЗЊСЂ, ВЂОХАЗЂ ЏС ЕРБЂ ЏСЋРА ГРЋАХШ, ЉЖЂ ЏС ТР ЖЂ ЊГСБС ПХЦЂ ХТЗТСЖАЂ ЋЂЕЖХОАЗЈС. ЂЋГФРЊРДС ЖЂГДР ЕС ЕРЕЖЂЏХ З АРАЂЉСДЗ ВГСБРТР АР МСЦЗ ЕЖГЗШЖЗГЗ ЂЋ ВСЋСЕСЖ ЖЂАР ПЂЏС ЕЊРШХИ ЕСЋРБ ОЂЋХАР ГРЋХ ТРЉЖХЖС ЂЋ ШЂГЂТХЏС.
ВЂЊГСБСАЂ ЕС ПЂЏР БСДР. ЖГСАЗЖАЂ ЏС ЖЂГРД ЕБСУС ПЂЏС. ТРЊХЕАЂ ЂЋ ЊГСБСАЕШХИ ЗЕЦЂЊР ЊГИ ЖЂГДР БЂФС ЋР ЂЋЕЖЗВХ ЂЋ ЊСГЖХШРЦС ЋЂ ЂЕРБ ЕРАЖХБСЖРГР З ЕЖГРАЗ ЂЋ ЕЗАМР. ВЂБСГРДС АРЕЖРЏС ТПЂО АСГРЊАЂБСГАЂО ТРОГСЊРДР БСЖРЦР АР ЕЗАНРАЂЏ Х АР ЕЖГРАХ З ЕСАМХ. ШРЋР ЏС ЖЂГРД ЕРОГРУСА, АСШХ ВРГХФРАХ ЕЗ ЕБРЖГРЦХ ЋР ЏС ГЗОЦЂ Х ЋР ОР ЖГСПР ВЂГЗЉХЖХ. ЋРАРЕ ЕС ЕБРЖГР ТР ЏСЋАЂ ЂЋ ГСБСШ ЋСЦР РГИХЖСШЖЗГС З ЕЊСЖЗ.";
            Monosubtitution ms = new Monosubtitution(text.ToCharArray(), 1);
            ms.StartDecription();
        }
    }
}
