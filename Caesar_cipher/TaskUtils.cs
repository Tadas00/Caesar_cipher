using System;

namespace Caesar_cipher
{
    class TaskUtils
    {
        /// <summary>
        /// Shifts letters to the left by a specified cipher number
        /// according to a Ceasar cipher
        /// </summary>
        /// <param name="cipherNumber">Number, by which to shift letters</param>
        /// <param name="inputText">Input text to cipher</param>
        /// <param name="Floors">Start symbols of cipher windows</param>
        /// <param name="Roofs">End symbols of cipher windows</param>
        /// <param name="windowCount">Number of letters windows</param>
        /// <returns>Ciphered input text as string</returns>
        public static string Cipher(int cipherNumber, string inputText, int[] Floors, int[] Roofs, int windowCount)
        {
            char[] inputSymbols = inputText.ToCharArray();

            for (int i = 0; i < inputSymbols.Length; i++)
            {
                int asciiCode = (int)inputSymbols[i];
                for (int windowIndex = 0; windowIndex < windowCount; windowIndex++)
                    if (asciiCode >= Floors[windowIndex] && asciiCode <= Roofs[windowIndex])
                        inputSymbols[i] = cipherLetter(asciiCode, Floors[windowIndex], Roofs[windowIndex], cipherNumber);
            }

            return new string(inputSymbols);
        }

        /// <summary>
        /// Ciphers one symbol by a specifed cipher number
        /// </summary>
        /// <param name="asciiCode">ASCII code of a symbol to cipher</param>
        /// <param name="floor">Start letter of a window to cipher at</param>
        /// <param name="roof">End letter of a window to cipher at</param>
        /// <param name="cipherNumber">Number by which to shift letter to the left</param>
        /// <returns>Ciphered symbol</returns>
        private static char cipherLetter (int asciiCode, int floor, int roof, int cipherNumber)
        {
            int cipheredCode = asciiCode - floor - cipherNumber;
            if (cipheredCode < 0) cipheredCode = (roof - floor + 1) - Math.Abs(cipheredCode) % (roof - floor + 1);
            return (char)(((cipheredCode) % (roof - floor + 1)) + floor);
        }

        /// <summary>
        /// Shifts letters to the right by a specified cipher number
        /// according to a Ceasar cipher
        /// </summary>
        /// <param name="cipherNumber">Number, by which to shift letters</param>
        /// <param name="inputText">Input text to cipher</param>
        /// <param name="Floors">Start symbols of cipher windows</param>
        /// <param name="Roofs">End symbols of cipher windows</param>
        /// <param name="windowCount">Number of letters windows</param>
        /// <returns>Ciphered input text as string</returns>
        public static string DeCipher(int cipherNumber, string inputText, int[] Floors, int[] Roofs, int windowCount)
        {
            return Cipher(-cipherNumber, inputText, Floors, Roofs, windowCount);
        }
    }
}
