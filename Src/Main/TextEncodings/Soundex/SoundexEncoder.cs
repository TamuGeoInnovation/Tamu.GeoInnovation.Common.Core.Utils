using System;
using System.Text;

namespace USC.GISResearchLab.Common.Core.TextEncodings.Soundex
{
    public class SoundexEncoder
    {
        public static string ComputeEncoding(string word)
        {
            return ComputeEncoding(word, 4);
        }

        public static string ComputeEncoding(string word, int length)
        {
            // Value to return
            string value = "";
            // Size of the word to process
            int size = word.Length;
            // Make sure the word is at least two characters in length
            if (size > 1)
            {
                // Convert the word to all uppercase
                word = word.ToUpper();

                // Convert the word to character array for faster processing
                char[] chars = word.ToCharArray();

                // Buffer to build up with character codes
                StringBuilder buffer = new StringBuilder();

                buffer.Length = 0;

                // The current and previous character codes
                int prevCode = 0;
                int currCode = 0;

                // Append the first character to the buffer
                buffer.Append(chars[0]);

                // Loop through all the characters and convert them to the proper character code
                for (int i = 1; i < size; i++)
                {
                    switch (chars[i])
                    {
                        case 'A':
                            currCode = 0;
                            break;
                        case 'E':
                            currCode = 0;
                            break;
                        case 'I':
                            currCode = 0;
                            break;
                        case 'O':
                            currCode = 0;
                            break;
                        case 'U':
                            currCode = 0;
                            break;
                        case 'H':
                            currCode = 0;
                            break;
                        case 'W':
                            currCode = 0;
                            break;
                        case 'Y':
                            currCode = 0;
                            break;
                        case 'B':
                            currCode = 1;
                            break;
                        case 'F':
                            currCode = 1;
                            break;
                        case 'P':
                            currCode = 1;
                            break;
                        case 'V':
                            currCode = 1;
                            break;
                        case 'C':
                            currCode = 2;
                            break;
                        case 'G':
                            currCode = 2;
                            break;
                        case 'J':
                            currCode = 2;
                            break;
                        case 'K':
                            currCode = 2;
                            break;
                        case 'Q':
                            currCode = 2;
                            break;
                        case 'S':
                            currCode = 2;
                            break;
                        case 'X':
                            currCode = 2;
                            break;
                        case 'Z':
                            currCode = 2;
                            break;
                        case 'D':
                            currCode = 3;
                            break;
                        case 'T':
                            currCode = 3;
                            break;
                        case 'L':
                            currCode = 4;
                            break;
                        case 'M':
                            currCode = 5;
                            break;
                        case 'N':
                            currCode = 5;
                            break;
                        case 'R':
                            currCode = 6;
                            break;
                    }


                    // Check to see if the current code is the same as the last one
                    if (currCode != prevCode)
                    {
                        // Check to see if the current code is 0 (a vowel); do not process vowels
                        if (currCode != 0)
                        {
                            buffer.Append(currCode);

                            // Set the new previous character code
                            prevCode = currCode;
                        }
                    }

                    // Set the new previous character code
                    prevCode = currCode;

                    // If the buffer size meets the length limit, then exit the loop
                    if (buffer.Length == length)
                        break;
                }


                // Pad the buffer, if required
                size = buffer.Length;

                if (size < length)
                {
                    buffer.Append('0', (length - size));
                }

                // Set the value to return
                value = buffer.ToString();
            }
            // Return the value
            return value;

        }

        public static string ComputeEncodingOld(string word)
        {
            return ComputeEncodingOld(word, 4);
        }

        public static string ComputeEncodingOld(string word, int length)
        {
            string value = "";

            if (!String.IsNullOrEmpty(word))
            {
                int size = word.Length;

                word = word.ToUpper();
                char[] characters = word.ToCharArray();

                //create a buffer to store the array of characters
                StringBuilder buffer = new StringBuilder();

                int current = 0;
                int previous = 0;
                buffer.Length = 0;

                char previousChar = characters[0];
                char currentChar;

                //Append the first character to the buffer
                buffer.Append(characters[0]);

                //start the loop to convert the other characters to numbers
                for (int i = 1; i < size; i++)
                {
                    current = 0;
                    currentChar = characters[i];

                    switch (currentChar)
                    {

                        case 'B':
                            current = 1;
                            break;
                        case 'F':
                            current = 1;
                            break;
                        case 'P':
                            current = 1;
                            break;
                        case 'V':
                            current = 1;
                            break;
                        case 'C':
                            current = 2;
                            break;
                        case 'G':
                            current = 2;
                            break;
                        case 'J':
                            current = 2;
                            break;
                        case 'K':
                            current = 2;
                            break;
                        case 'Q':
                            current = 2;
                            break;
                        case 'S':
                            current = 2;
                            break;
                        case 'X':
                            current = 2;
                            break;
                        case 'Z':
                            current = 2;
                            break;
                        case 'D':
                            current = 3;
                            break;
                        case 'T':
                            current = 3;
                            break;
                        case 'L':
                            current = 4;
                            break;
                        case 'M':
                            current = 5;
                            break;
                        case 'N':
                            current = 5;
                            break;
                        case 'R':
                            current = 6;
                            break;
                    }


                    // drop vowels, w, and h
                    if (current != 0)
                    {
                        // drop double characters 'ss'
                        if (currentChar != previousChar)
                        {
                            // drop double codes 'cs' -> 22
                            if (current != previous)
                            {
                                previous = current;
                                buffer.Append(current);//Append the current code to the buffer
                            }
                        }

                        if (buffer.Length == length)
                            break;
                    }


                    previousChar = currentChar;
                }

                size = buffer.Length;

                if (size < length)
                {
                    buffer.Append('0', length - size);
                }

                value = buffer.ToString();
            }

            return value;
        }
        public static string ComputeEncodingNew(string word)
        {
            return ComputeEncodingNew(word, 4);
        }

        public static string ComputeEncodingNew(string word, int length)
        {
            string value = "";

            if (!String.IsNullOrEmpty(word))
            {
                int size = word.Length;

                word = word.ToUpper();
                char[] characters = word.ToCharArray();

                //create a buffer to store the array of characters
                StringBuilder buffer = new StringBuilder();

                int current = 0;
                int previous = 0;
                buffer.Length = 0;

                char previousChar = characters[0];
                char currentChar;

                //Append the first character to the buffer
                buffer.Append(characters[0]);
                switch (previousChar)
                {

                    case 'B':
                        previous = 1;
                        break;
                    case 'F':
                        previous = 1;
                        break;
                    case 'P':
                        previous = 1;
                        break;
                    case 'V':
                        previous = 1;
                        break;
                    case 'C':
                        previous = 2;
                        break;
                    case 'G':
                        previous = 2;
                        break;
                    case 'J':
                        previous = 2;
                        break;
                    case 'K':
                        previous = 2;
                        break;
                    case 'Q':
                        previous = 2;
                        break;
                    case 'S':
                        previous = 2;
                        break;
                    case 'X':
                        previous = 2;
                        break;
                    case 'Z':
                        previous = 2;
                        break;
                    case 'D':
                        previous = 3;
                        break;
                    case 'T':
                        previous = 3;
                        break;
                    case 'L':
                        previous = 4;
                        break;
                    case 'M':
                        previous = 5;
                        break;
                    case 'N':
                        previous = 5;
                        break;
                    case 'R':
                        previous = 6;
                        break;
                    case 'A':
                        previous = 7;
                        break;
                    case 'E':
                        previous = 7;
                        break;
                    case 'I':
                        previous = 7;
                        break;
                    case 'O':
                        previous = 7;
                        break;
                    case 'U':
                        previous = 7;
                        break;
                    case 'Y':
                        previous = 7;
                        break;
                    case 'H':
                        previous = 8;
                        break;
                    case 'W':
                        previous = 8;
                        break;

                }

                //start the loop to convert the other characters to numbers
                for (int i = 1; i < size; i++)
                {
                    current = 0;
                    currentChar = characters[i];

                    switch (currentChar)
                    {

                        case 'B':
                            current = 1;
                            break;
                        case 'F':
                            current = 1;
                            break;
                        case 'P':
                            current = 1;
                            break;
                        case 'V':
                            current = 1;
                            break;
                        case 'C':
                            current = 2;
                            break;
                        case 'G':
                            current = 2;
                            break;
                        case 'J':
                            current = 2;
                            break;
                        case 'K':
                            current = 2;
                            break;
                        case 'Q':
                            current = 2;
                            break;
                        case 'S':
                            current = 2;
                            break;
                        case 'X':
                            current = 2;
                            break;
                        case 'Z':
                            current = 2;
                            break;
                        case 'D':
                            current = 3;
                            break;
                        case 'T':
                            current = 3;
                            break;
                        case 'L':
                            current = 4;
                            break;
                        case 'M':
                            current = 5;
                            break;
                        case 'N':
                            current = 5;
                            break;
                        case 'R':
                            current = 6;
                            break;
                        case 'A':
                            current = 7;
                            break;
                        case 'E':
                            current = 7;
                            break;
                        case 'I':
                            current = 7;
                            break;
                        case 'O':
                            current = 7;
                            break;
                        case 'U':
                            current = 7;
                            break;
                        case 'Y':
                            current = 7;
                            break;
                        case 'H':
                            current = 8;
                            break;
                        case 'W':
                            current = 8;
                            break;

                    }


                    // drop vowels, w, and h
                    if (current != 0)
                    {
                        // drop double characters 'ss'
                        if (current != 8)
                        {
                            if (current != 7)
                            {
                                // drop double codes 'cs' -> 22
                                if (current != previous)
                                {
                                    buffer.Append(current);//Append the current code to the buffer
                                }
                            }

                            if (buffer.Length == length)
                                break;

                            previous = current;
                            previousChar = currentChar;

                        }
                    }



                }

                size = buffer.Length;

                if (size < length)
                {
                    buffer.Append('0', length - size);
                }

                value = buffer.ToString();
            }

            return value;
        }
    }
}
