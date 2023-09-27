using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace AlternativeString
{
    public class CustomString
    {
        private readonly char[] _chars;
        private static HashSet<char> Vowels = new HashSet<char>() { 'А', 'У', 'О', 'Ы', 'И', 'Э', 'Я', 'Ю', 'Ё', 'Е', 'а', 'у', 'о', 'ы', 'и', 'э', 'я', 'ю', 'ё', 'е', 'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u' };

        public CustomString(char[] chars)
        {
            _chars = new char[chars.Length];
            Array.Copy(chars, _chars, chars.Length);
        }

        public CustomString(string str)
        {
            _chars = str.ToCharArray();
        }

        public CustomString(StringBuilder sb)
        {
            _chars = sb.ToString().ToCharArray();
        }

        public char this[int index]
        {
            get
            {
                if (index >= 0 && index < _chars.Length)
                {
                    return _chars[index];
                }
                     
                else
                    throw new ArgumentOutOfRangeException("Specified argument was out of the range of valid values"); 
            }
            set
            {
                if (index >= 0 && index < _chars.Length)
                    _chars[index] = value;
            }
        }

        public bool Equals(CustomString other)
        {
            if (other._chars.Length != _chars.Length)
            {
                return false;
            }

            for (int i = 0; i < _chars.Length; i++)
            {
                if (_chars[i] != other._chars[i])
                {
                    return false;
                }
            }

            return true;
        }

        public char[] Concat(CustomString other)
        {
            var newStr = new char[_chars.Length + other._chars.Length];
            Array.Copy(_chars, newStr, _chars.Length);
            Array.Copy(other._chars, 0, newStr, _chars.Length, other._chars.Length);

            return newStr;
        }

        public int IndexOf(char symbol)
        {
            for (int i = 0; i < _chars.Length; i++)
            {
                if (_chars[i] == symbol)
                {
                    return i;
                }
            }
            return -1;
        }

        public char[] ToCharArray()
        {
            return (char[])_chars.Clone();
        }

        public int FindVowelsCount()
        {
            var vowelsCount = 0;

            foreach (var c in Vowels)
            {
                if (_chars.Contains(c))
                {
                    vowelsCount++;
                }
            }

            return vowelsCount;
        }

        public string DeleteVowelLetters()
        {
            var strWithoutVowels = "";

            for (int i = 0; i < _chars.Length; i++)
            {
                if (!Vowels.Contains(_chars[i]))
                {
                    strWithoutVowels += _chars[i];
                }
            }

            return strWithoutVowels; // спросить про метод
        }

        public int CompareTo(CustomString other)
        {
            if(_chars is null ||  other._chars is null)
            {
                throw new ArgumentException("One of the objects is empty");
            }
            if (Equals(other))
            {
                return 0;
            }

            if(_chars.Length > other._chars.Length)
            {
                return 1;
            }

            return -1;
        }

        public int LastIndexOf(char symbol)
        {
            for (int i = _chars.Length - 1; i >=0 ; i--)
            {
                if (_chars[i] == symbol)
                {
                    return i;
                }
            }
            return -1;
        }

        public static char[] operator + (CustomString str1, CustomString str2)
        {
            var newStr = new char[str1._chars.Length + str2._chars.Length];
            Array.Copy(str1._chars, newStr, str1._chars.Length);
            Array.Copy(str2._chars, 0, newStr, str1._chars.Length, str2._chars.Length);

            return newStr;
        }

        public static bool operator == (CustomString str1, CustomString str2)
        {
            return str1.Equals(str2);
        }

        public static bool operator !=(CustomString str1, CustomString str2)
        {
            return !str1.Equals(str2);
        }

        public static explicit operator int(CustomString other)
        {
            return int.Parse(other._chars);
        }

        public static implicit operator CustomString(char[] chars)
        {
            return new CustomString(new string(chars));
        }
        //cпросить



    }
}
