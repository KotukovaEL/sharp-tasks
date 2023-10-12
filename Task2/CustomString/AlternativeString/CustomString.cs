using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
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
        private static HashSet<char> Vowels = new HashSet<char>() { 'А', 'У', 'О', 'Ы', 'И', 'Э', 'Я', 'Ю', 'Ё', 'Е', 'а', 'у', 'о', 'ы', 'и', 'э', 'я', 'ю', 'ё', 'е', 'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u' };
        private readonly char[] _chars;

        public int Length => _chars.Length;

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
                    throw new ArgumentOutOfRangeException("index");
            }
            set
            {
                if (index >= 0 && index < _chars.Length)
                    _chars[index] = value;
            }
        }

        public override string ToString()
        {
            return new string(_chars);
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

        public CustomString Concat(CustomString other)
        {
            var newStr = new char[_chars.Length + other._chars.Length];
            Array.Copy(_chars, newStr, _chars.Length);
            Array.Copy(other._chars, 0, newStr, _chars.Length, other._chars.Length);

            return new CustomString(newStr);
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

        public int IndexOf(CustomString entry)
        {
            return IndexOf(entry._chars);
        }


        public int IndexOf(string entry)
        {
            return IndexOf(entry.ToCharArray());
        }

        private int IndexOf(char[] entry)
        {
            for (int i = 0; i < _chars.Length; i++)
            {
                bool isContains = true;

                for (int j = 0; j < entry.Length; j++)
                {
                    if (_chars[i + j] != entry[j])
                    {
                        isContains = false;
                        break;
                    }
                }

                if (isContains)
                {
                    return i;
                }
            }

            return -1;
        }

        private int IndexOf(CustomString entry, int startIndex)
        {
            for (int i = startIndex; i < _chars.Length; i++)
            {
                bool isContains = true;

                for (int j = 0; j < entry.Length; j++)
                {
                    if (_chars[i + j] != entry[j])
                    {
                        isContains = false;
                        break;
                    }
                }

                if (isContains)
                {
                    return i;
                }
            }

            return -1;
        }

        public int LastIndexOf(char symbol)
        {
            for (int i = _chars.Length - 1; i >= 0; i--)
            {
                if (_chars[i] == symbol)
                {
                    return i;
                }
            }
            return -1;
        }

        public int LastIndexOf(CustomString entry)
        {
            for (int i = _chars.Length - 1; i >= 0; i--)
            {
                bool isContains = true;

                for (int j = 0; j < entry.Length; j++)
                {
                    if (_chars[i + j] != entry[j])
                    {
                        isContains = false;
                        break;
                    }
                }

                if (isContains)
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

            foreach (var c in _chars)
            {
                if (Vowels.Contains(c))
                {
                    vowelsCount++;
                }
            }

            return vowelsCount;
        }

        public CustomString DeleteVowels()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < _chars.Length; i++)
            {
                if (!Vowels.Contains(_chars[i]))
                {
                    sb.Append(_chars[i]);
                }
            }

            return new CustomString(sb);
        }

        public int CompareTo(CustomString other)
        {
            if (_chars.Length > other._chars.Length)
            {
                return 1;
            }
            else if (_chars.Length < other._chars.Length)
            {
                return -1;
            }

            for (int i = 0; i < _chars.Length; i++)
            {
                if (_chars[i] > other._chars[i])
                {
                    return 1;
                }
                else if (_chars[i] < other._chars[i])
                {
                    return -1;
                }
            }

            return 0;
        }

        public CustomString Substring(int startIndex)
        {
            if (startIndex < 0 || startIndex >= _chars.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            var sb = new StringBuilder();

            for (int i = startIndex; i < _chars.Length; i++)
            {
                sb.Append(_chars[i]);
            }
            
            return new CustomString(sb);
        }

        public CustomString Substring(int startIndex, int length)
        {
            if (startIndex < 0 || startIndex >= _chars.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (length > _chars.Length || length + startIndex > _chars.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            var newChars = new char[length];
            Array.Copy(_chars, startIndex, newChars, 0, length);
            return new CustomString(newChars);
        }


        public CustomString Replace(char oldChar, char newChar)
        {
            var sb = new StringBuilder();
            
            for (int i = 0; i < _chars.Length; i++)
            {
                if (_chars[i] == oldChar)
                {
                    sb.Append(newChar);
                }
                else 
                {
                    sb.Append(_chars[i]); 
                }
            }

            return new CustomString(sb);
        }

        public CustomString Replace(CustomString oldValue, CustomString newValue)
        {
            if (oldValue == newValue)
            {
                return new CustomString(_chars);
            }

            var sb = new StringBuilder();

            for (int i = 0; i < _chars.Length; i++)
            {
                int index = IndexOf(oldValue, i);

                if (index != -1)
                {
                    while (i < index)
                    {
                        sb.Append(_chars[i]);
                        i++;
                    }

                    sb.Append(newValue);
                    i += oldValue.Length - 1;

                }
                else
                {
                    sb.Append(_chars[i]);
                }
            }

            return new CustomString(sb);
        }

        public CustomString ToLower()
        {
            char[] result = new char[_chars.Length];
            for (var i = 0; i < _chars.Length; i++)
            {
                result[i] = char.ToLower(_chars[i]);
            }
            
            return new CustomString(result);
        }

        public CustomString ToUpper()
        {
            char[] result = new char[_chars.Length];
            for (var i = 0; i < _chars.Length; i++)
            {
                result[i] = char.ToUpper(_chars[i]);
            }

            return new CustomString(result);
        }

        public bool Contains(char value)
        {
            for (int i = 0; i < _chars.Length; i++)
            {
                if (_chars[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Contains(CustomString value)
        {

            for (int i = 0; i < _chars.Length; i++)
            {
                bool isContains = true;

                for (int j = 0; j < value.Length; j++)
                {
                    if (i + j >= _chars.Length)
                    {
                        return false;
                    }

                    if (_chars[i + j] != value[j])
                    {
                        isContains = false;
                        break;
                    }
                }

                if (isContains)
                {
                    return true;
                }
            }

            return false;
        }

        public CustomString CopyTo(int sourceIndex, int destinationIndex, int length)
        {
            char[] result = new char[length];
            Array.Copy(_chars, sourceIndex, result, destinationIndex, length);
            return new CustomString(result);
        }

        public bool StartsWith(CustomString entry)
        {
            for (var i = 0; i < entry.Length; i++)
            {
                if (entry[i] != _chars[i])
                {
                    return false;
                }
            }
            return true;
        }

        public bool EndsWith(CustomString entry)
        {
            for (int i = _chars.Length - 1, j = entry.Length - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (entry[j] != _chars[i])
                {
                    return false;
                }
            }
            return true;
        }

        public CustomString Insert(int index, char value)
        {
            var newChars = new char[_chars.Length + 1];
            newChars[index] = value;
            Array.Copy(_chars, 0, newChars, 0, index);
            Array.Copy(_chars, index, newChars, index+1, newChars.Length - index -1);
            return new CustomString(newChars);
        }

        public CustomString Remove(int startIndex)
        {
            var newChars = new char[startIndex];
            Array.Copy(_chars, 0, newChars, 0, startIndex);
            return new CustomString(newChars);
        }

        public CustomString Remove(int startIndex, int count)
        {
            var newChars = new char[_chars.Length - count ];
            Array.Copy(_chars, 0, newChars, 0, startIndex);
            Array.Copy(_chars, startIndex + count, newChars, startIndex,  _chars.Length - count - startIndex);
            return new CustomString(newChars);
        }

        public CustomString TrimStart()
        {
            var sb = new StringBuilder();
            var count = 0;

            while(char.IsWhiteSpace(_chars[count]))
            { 
                count++;
            }

            for (int i = count; i < _chars.Length; i++)
            {
                sb.Append(_chars[i]);
            }
            
            return new CustomString(sb);
        }

        public CustomString TrimEnd()
        {
            var sb = new StringBuilder();
            var count = _chars.Length - 1;

            while (char.IsWhiteSpace(_chars[count]))
            {
                count--;
            }

            for (int i = 0; i <= count; i++)
            {
                sb.Append(_chars[i]);
            }

            return new CustomString(sb);
        }

        public CustomString Trim()
        {
            var trimed = TrimStart();
            trimed = trimed.TrimEnd();
            return trimed;
        }

        public List<CustomString> Split(char[] separators)
        {
            var separatorsSet = separators.ToHashSet();
            var splitedList = new List<CustomString>();
            var sb = new StringBuilder();

            for (int i = 0; i < _chars.Length; i++)
            {
                if (separatorsSet.Contains(_chars[i]))
                {
                    TryAddSplitedString(splitedList, sb);
                }
                else
                {
                    sb.Append(_chars[i]);
                }
            }

            TryAddSplitedString(splitedList, sb);

            return splitedList;
        }

        private void TryAddSplitedString(List<CustomString> splitedList, StringBuilder sb)
        {
            if (sb.Length == 0)
            {
                return;
            }

            var customstring = new CustomString(sb);
            splitedList.Add(customstring);
            sb.Clear();
        }

        public static CustomString operator +(CustomString str1, CustomString str2)
        {
            return str1.Concat(str2);
        }

        public static bool operator ==(CustomString str1, CustomString str2)
        {
            return str1.Equals(str2);
        }

        public static bool operator !=(CustomString str1, CustomString str2)
        {
            return !str1.Equals(str2);
        }

        public static explicit operator char[](CustomString other)
        {
            return other.ToCharArray();
        }
    }
}
