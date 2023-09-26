using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;

namespace AlternativeString
{
    public class CustomString
    {
        private readonly char[] _chars;

        public CustomString(char[] chars)
        {
            _chars = new char[chars.Length];
            Array.Copy(chars, _chars, chars.Length);
        }

        public CustomString(string str)
        {
            _chars = str.ToCharArray();
        }
       
        public bool Equals(CustomString other)
        {
            var result = true;

            if (other._chars.Length == _chars.Length)
            {
                for (int i = 0; i < _chars.Length; i++)
                {
                    if(_chars[i] != other._chars[i])
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        public char[] ConcatString(CustomString other)
        {
            var newStr = new char[_chars.Length + other._chars.Length];
            
            for (int i = 0; i <_chars.Length; i++)
            {
                newStr[i] = _chars[i];
            }

            for (int j = 0; j < other._chars.Length; j++)
            {
                newStr[_chars.Length + j] = other._chars[j];
            }
            return newStr;
        }

        public int IndexOf(char symbol)
        {
            var ind = 0;

            for(int i = 0; i < _chars.Length; i++)
            {
                if (_chars[i] == symbol)
                {
                    ind = i; 
                    break;
                }

                if (_chars[i] != symbol)
                {
                    ind = -1;
                }
            }
            return ind;
        }

        public char[] ToCharArray()
        {
            return (char[])_chars.Clone();
        }

        public string FindVowelsCount()
        {
            char[] vowelLetters = { 'А', 'У', 'О', 'Ы', 'И', 'Э', 'Я', 'Ю', 'Ё', 'Е', 'а', 'у', 'о', 'ы', 'и', 'э', 'я', 'ю', 'ё', 'е', 'A', 'E', 'I', 'O', 'U', 'Y', 'a', 'e', 'i', 'o', 'u', 'y' };
            var numberLetters = 0;

            foreach(var c in vowelLetters) 
            {
                if (_chars.Contains(c))
                {
                    numberLetters++;
                }
            }

            return numberLetters.ToString();
        }

        public string DeleteVowelLetters()
        {
            char[] vowelLetters = { 'А', 'У', 'О', 'Ы', 'И', 'Э', 'Я', 'Ю', 'Ё', 'Е', 'а', 'у', 'о', 'ы', 'и', 'э', 'я', 'ю', 'ё', 'е', 'A', 'E', 'I', 'O', 'U', 'Y', 'a', 'e', 'i', 'o', 'u', 'y' };
            var strWithoutVowels = "";

            for (int i = 0; i < _chars.Length; i++)
            {
                if (!vowelLetters.Contains(_chars[i]))
                {
                    strWithoutVowels += _chars[i];
                }
            }

            return strWithoutVowels;
        }
    }
}
