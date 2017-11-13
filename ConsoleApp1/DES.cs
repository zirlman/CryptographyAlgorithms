﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*class DES
    {
        int[] permuttedChoice1, initialMessagePermutation, keyShiftSizes,
            permuttedChoice2, messageExpansion, S1, S2, S3, S4, S5, S6, S7, S8;
        long block;
        int lhs, rhs;
        // Expanded RHS after calling the ExpansionPermutattionBox() method
        long eRhs;
        Key key;
        long myTempKey; // Used for the Permutted Choice iteration
        long kn;

        class Key
        {
            public int cn;
            public int dn;
            Key()
            {
                cn = 0;
                dn = 0;
            }
        }

        DES()
        {
            permuttedChoice1 = new int[]{
                                57, 49,  41, 33,  25,  17,  9,
                                 1, 58,  50, 42,  34,  26, 18,
                                10,  2,  59, 51,  43,  35, 27,
                                19, 11,   3, 60,  52,  44, 36,
                                63, 55,  47, 39,  31,  23, 15,
                                 7, 62,  54, 46,  38,  30, 22,
                                14,  6,  61, 53,  45,  37, 29,
                                21, 13,   5, 28,  20,  12,  4};

            initialMessagePermutation = new int[]{
                                        58, 50, 42, 34, 26, 18, 10, 2,
                                        60, 52, 44, 36, 28, 20, 12, 4,
                                        62, 54, 46, 38, 30, 22, 14, 6,
                                        64, 56, 48, 40, 32, 24, 16, 8,
                                        57, 49, 41, 33, 25, 17,  9, 1,
                                        59, 51, 43, 35, 27, 19, 11, 3,
                                        61, 53, 45, 37, 29, 21, 13, 5,
                                        63, 55, 47, 39, 31, 23, 15, 7};
            keyShiftSizes = new int[] { -1, 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };

            permuttedChoice2 = new int[]{
                                14, 17, 11, 24,  1,  5,
                                 3, 28, 15,  6, 21, 10,
                                23, 19, 12,  4, 26,  8,
                                16,  7, 27, 20, 13,  2,
                                41, 52, 31, 37, 47, 55,
                                30, 40, 51, 45, 33, 48,
                                44, 49, 39, 56, 34, 53,
                                46, 42, 50, 36, 29, 32};

            messageExpansion = new int[]{
                            32,  1,  2,  3,  4,  5,
                             4,  5,  6,  7,  8,  9,
                             8,  9, 10, 11, 12, 13,
                            12, 13, 14, 15, 16, 17,
                            16, 17, 18, 19, 20, 21,
                            20, 21, 22, 23, 24, 25,
                            24, 25, 26, 27, 28, 29,
                            28, 29, 30, 31, 32,  1};

            S1 = new int[]{
            14,  4, 13,  1,  2, 15, 11,  8,  3, 10,  6, 12,  5,  9,  0,  7,
             0, 15,  7,  4, 14,  2, 13,  1, 10,  6, 12, 11,  9,  5,  3,  8,
             4,  1, 14,  8, 13,  6,  2, 11, 15, 12,  9,  7,  3, 10,  5,  0,
            15, 12,  8,  2,  4,  9,  1,  7,  5, 11,  3, 14, 10,  0,  6, 13};

            S2 = new int[]{
            15,  1,  8, 14,  6, 11,  3,  4,  9,  7,  2, 13, 12,  0,  5, 10,
             3, 13,  4,  7, 15,  2,  8, 14, 12,  0,  1, 10,  6,  9, 11,  5,
             0, 14,  7, 11, 10,  4, 13,  1,  5,  8, 12,  6,  9,  3,  2, 15,
            13,  8, 10,  1,  3, 15,  4,  2, 11,  6,  7, 12,  0,  5, 14,  9};

            S3 = new int[]{
            10,  0,  9, 14,  6,  3, 15,  5,  1, 13, 12,  7, 11,  4,  2,  8,
            13,  7,  0,  9,  3,  4,  6, 10,  2,  8,  5, 14, 12, 11, 15,  1,
            13,  6,  4,  9,  8, 15,  3,  0, 11,  1,  2, 12,  5, 10, 14,  7,
             1, 10, 13,  0,  6,  9,  8,  7,  4, 15, 14,  3, 11,  5,  2, 12};

            S4 = new int[]{
             7, 13, 14,  3,  0,  6,  9, 10,  1,  2,  8,  5, 11, 12,  4, 15,
            13,  8, 11,  5,  6, 15,  0,  3,  4,  7,  2, 12,  1, 10, 14,  9,
            10,  6,  9,  0, 12, 11,  7, 13, 15,  1,  3, 14,  5,  2,  8,  4,
             3, 15,  0,  6, 10,  1, 13,  8,  9,  4,  5, 11, 12,  7,  2, 14};

            S5 = new int[]{
             2, 12,  4,  1,  7, 10, 11,  6,  8,  5,  3, 15, 13,  0, 14,  9,
            14, 11,  2, 12,  4,  7, 13,  1,  5,  0, 15, 10,  3,  9,  8,  6,
             4,  2,  1, 11, 10, 13,  7,  8, 15,  9, 12,  5,  6,  3,  0, 14,
            11,  8, 12,  7,  1, 14,  2, 13,  6, 15,  0,  9, 10,  4,  5,  3};

            S6 = new int[]{
            12,  1, 10, 15,  9,  2,  6,  8,  0, 13,  3,  4, 14,  7,  5, 11,
            10, 15,  4,  2,  7, 12,  9,  5,  6,  1, 13, 14,  0, 11,  3,  8,
             9, 14, 15,  5,  2,  8, 12,  3,  7,  0,  4, 10,  1, 13, 11,  6,
             4,  3,  2, 12,  9,  5, 15, 10, 11, 14,  1,  7,  6,  0,  8, 13};

            S7 = new int[]{
             4, 11,  2, 14, 15,  0,  8, 13,  3, 12,  9,  7,  5, 10,  6,  1,
            13,  0, 11,  7,  4,  9,  1, 10, 14,  3,  5, 12,  2, 15,  8,  6,
             1,  4, 11, 13, 12,  3,  7, 14, 10, 15,  6,  8,  0,  5,  9,  2,
             6, 11, 13,  8,  1,  4, 10,  7,  9,  5,  0, 15, 14,  2,  3, 12};

            S8 = new int[]{
             13,  2,  8,  4,  6, 15, 11,  1, 10,  9,  3, 14,  5,  0, 12,  7,
             1, 15, 13,  8, 10,  3,  7,  4, 12,  5,  6, 11,  0, 14,  9,  2,
             7, 11,  4,  1,  9, 12, 14,  2,  0,  6, 10, 13, 15,  3,  5,  8,
             2,  1, 14,  7,  4, 10,  8, 13, 15, 12,  9,  0,  3,  5,  6, 11};
        }

        void InitialPermutation()
        {
            int shifter;
            for (int i = 0; i < 64; ++i)
            {
                shifter = 1;
                int tmp = initialMessagePermutation[i] - 1;
                for (int j = 0; j < tmp; ++j)
                    shifter <<= 1;
                long bit = (block & shifter) != 0 ? 1 : 0;
                SetBitPosition(bit, i, 'i');
            }
        }

        // Splits the 64bit key to C0 and D0 for example, key ABCD will be represented via this method as: 
        // key = 1010 1011 1100 1101 = A B C D
        // key.cn = 1010 1011
        // key.dn = 1100 1101
        void FillTheKey(char[] keyChar)
        {
            long tmpkey = 0;
            for (int i = 0; i < 8; ++i)
            {
                tmpkey |= keyChar[i];
                tmpkey <<= 4;
            }
            int shifter = 1;
            for (int i = 0; i < 64; ++i)
            {
                shifter = 1;
                int tmp = permuttedChoice1[i] - 1;
                for (int j = 0; j < tmp; ++j)
                    shifter <<= 1;
                long bit = (tmpkey & shifter) != 0 ? 1 : 0;
                SetBitPosition(bit, i, 'k');
            }
            key.cn = (int)((tmpkey & 0xffff0000) >> 4);
            key.dn = (int)(tmpkey & 0x0000ffff);
        }

        // n = keyShiftSizes[i] = 1 || 2
        void PerformRotation(int n)
        {
            int shifter = 1;
            int tmp;
            for (int i = 0; i < n; ++i)
            {
                tmp = (key.cn & 0x08000000) != 0 ? 1 : 0;
                key.cn <<= shifter;
                key.cn |= tmp;

                tmp = (key.dn & 0x08000000) != 0 ? 1 : 0;
                key.dn <<= shifter;
                key.dn |= tmp;
            }
        }
        void SetBitPosition(long bit, int pos, char c)
        {
            for (int i = 0; i < pos; ++i)
                bit <<= 1;
            if (c == 'r' || c == 'R')
                eRhs |= bit;
            else if (c == 'i' || c == 'I')
                block |= bit;
            else if (c == 'k' || c == 'K')
                myTempKey |= bit;
        }

        void ExpansionPermutattionBox()
        {
            eRhs = 0;
            for (int i = 0; i < 48; ++i)
            {
                int shifter = 1;
                int tmp = messageExpansion[i] - 1;
                for (int j = 0; j < tmp; ++j)
                    shifter <<= 1;
                int bit = (rhs & shifter) != 0 ? 1 : 0;
                SetBitPosition(bit, i, 'r');
            }
        }

        void KeyNthGenerator(int n)
        {

        }

        /*int Function()
        {
            int m = 4;
        }
        void StartEncription(char[] blockArr)
        {
            long tmpBlock = 0;
            for (int i = 0; i < 8; ++i)
            {
                tmpBlock |= blockArr[i];
                tmpBlock <<= 4;
            }

            block = tmpBlock;
            InitialPermutation();

            lhs = (int)((block & 0xffff0000) >> 4);
            rhs = (int)(block & 0x0000ffff);
            int oldLhs = lhs;
            int oldRhs = rhs;
            for (int i = 1; i < 17; ++i)
            {
                lhs = oldRhs;
                // TODO: XOR-ovati Ln-1 sa rezultatom funkcije f
                //rhs = oldLhs ^
            }
        }

        static void Main(string[] args)
        {
            DES desGenerator = new DES();
            char[] block1 = new char[8];        // Used for plaintext
            char[] block2 = new char[8];        // Used for 64bit key
            string plaintext = "-";
            string keyText = "-";

            Console.WriteLine("Input text to encrypt: ");
            plaintext = Console.ReadLine();
            while (plaintext.Length / 8 != 0)
                plaintext += "X";               // Padding

            while (keyText.Length / 8 != 0)
            {
                Console.WriteLine("Input 8-character key: ");
                keyText = Console.ReadLine();
            }
            block2 = keyText.ToCharArray();
            int j = 8, k = 0;
            for (int i = 0; i < plaintext.Length; ++i)
            {
                while (i < j)
                    block1[k++] = plaintext[i++];
                j += 8;
                desGenerator.StartEncription(block1);
                desGenerator.FillTheKey(block2);
                k = 0;
            }
        }
    }*/

}
