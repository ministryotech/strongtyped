﻿// Copyright (c) 2014 Minotech Ltd.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files
// (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, 
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do 
// so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE 
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION 
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Ministry.StrongTyped
{
    public static class StringHelper
    {
        /// <summary>
        /// Adds spaces into a string where capital letters occur.
        /// </summary>
        /// <param name="value">The string to change.</param>
        /// <returns>The altered string.</returns>
        /// <remarks>As an example TheQuickBrownFox would become The Quick Brown Fox.</remarks>
        public static string AddSpacesByCasing(this string value)
        {
            return value.AddCharactersByCasing(" ");
        }

        /// <summary>
        /// Adds characters into a string where capital letters occur.
        /// </summary>
        /// <param name="value">The string to change.</param>
        /// <param name="insertCharacters">The characters to insert.</param>
        /// <returns>The altered string.</returns>
        /// <remarks>As an example TheQuickBrownFox would become The|Quick|Brown|Fox, should '|' be used as the insert character.</remarks>
        public static string AddCharactersByCasing(this string value, string insertCharacters)
        {
            var retVal = new StringBuilder();
            foreach (var stringVal in value.Select(c => c.ToString(CultureInfo.InvariantCulture)))
            {
                if ((stringVal == stringVal.ToUpper(CultureInfo.InvariantCulture)) && (retVal.ToString().IsNotNullOrEmpty())) retVal.Append(insertCharacters);
                retVal.Append(stringVal);
            }
            return retVal.ToString();
        }

        /// <summary>
        /// Appends a value to the StringBuilder if it is currently empty.
        /// </summary>
        /// <param name="value">The stringbuilder to append to.</param>
        /// <param name="appendValue">The value to append.</param>
        /// <returns>The completed builder.</returns>
        /// <exception cref="System.ArgumentNullException">Either the StringBuilder or value to append are null.</exception>
        public static StringBuilder AppendIfEmpty(this StringBuilder value, string appendValue)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (appendValue == null) throw new ArgumentNullException("appendValue");

            if (value.Length == 0) value.Append(appendValue);
            return value;
        }

        /// <summary>
        /// Appends a value to the StringBuilder if it is not currently empty.
        /// </summary>
        /// <param name="value">The stringbuilder to append to.</param>
        /// <param name="appendValue">The value to append.</param>
        /// <returns>The completed builder.</returns>
        /// <exception cref="System.ArgumentNullException">Either the StringBuilder or value to append are null.</exception>
        public static StringBuilder AppendIfNotEmpty(this StringBuilder value, string appendValue)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (appendValue == null) throw new ArgumentNullException("appendValue");

            if (value.Length > 0) value.Append(appendValue);
            return value;
        }

        /// <summary>
        /// Appends a line terminator after a value to the StringBuilder if it is currently empty.
        /// </summary>
        /// <param name="value">The stringbuilder to append to.</param>
        /// <param name="appendValue">The value to append.</param>
        /// <returns>The completed builder.</returns>
        /// <exception cref="System.ArgumentNullException">Either the StringBuilder or value to append are null.</exception>
        public static StringBuilder AppendLineIfEmpty(this StringBuilder value, string appendValue)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (appendValue == null) throw new ArgumentNullException("appendValue");

            if (value.Length == 0) value.AppendLine(appendValue);
            return value;
        }

        /// <summary>
        /// Appends line terminator after a value to the StringBuilder if it is not currently empty.
        /// </summary>
        /// <param name="value">The stringbuilder to append to.</param>
        /// <param name="appendValue">The value to append.</param>
        /// <returns>The completed builder.</returns>
        /// <exception cref="System.ArgumentNullException">Either the StringBuilder or value to append are null.</exception>
        public static StringBuilder AppendLineIfNotEmpty(this StringBuilder value, string appendValue)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (appendValue == null) throw new ArgumentNullException("appendValue");

            if (value.Length > 0) value.AppendLine(appendValue);
            return value;
        }

        /// <summary>
        /// Appends a line terminator to the StringBuilder if it is currently empty.
        /// </summary>
        /// <param name="value">The stringbuilder to append to.</param>
        /// <returns>The completed builder.</returns>
        /// <exception cref="System.ArgumentNullException">Either the StringBuilder or value to append are null.</exception>
        public static StringBuilder AppendLineIfEmpty(this StringBuilder value)
        {
            if (value == null) throw new ArgumentNullException("value");

            if (value.Length == 0) value.AppendLine();
            return value;
        }

        /// <summary>
        /// Appends line terminator to the StringBuilder if it is not currently empty.
        /// </summary>
        /// <param name="value">The stringbuilder to append to.</param>
        /// <returns>The completed builder.</returns>
        /// <exception cref="System.ArgumentNullException">Either the StringBuilder or value to append are null.</exception>
        public static StringBuilder AppendLineIfNotEmpty(this StringBuilder value)
        {
            if (value == null) throw new ArgumentNullException("value");

            if (value.Length > 0) value.AppendLine();
            return value;
        }

        /// <summary>
        /// Determines if this instance is Null or Empty.
        /// </summary>
        /// <param name="value">The string to evaluate.</param>
        /// <returns>A flag to indicate the result.</returns>
        /// <remarks>This uses the static String.IsNullOrEmpty method.</remarks>
        public static bool IsNullOrEmpty(this string value)
        {
            return String.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Determines if this instance is Null or Empty.
        /// </summary>
        /// <param name="value">The string to evaluate.</param>
        /// <returns>A flag to indicate the result.</returns>
        /// <remarks>This uses the static String.IsNullOrEmpty method.</remarks>
        public static bool IsNotNullOrEmpty(this string value)
        {
            return !value.IsNullOrEmpty();
        }

        /// <summary>
        /// Removes a set number of characters from the end of a string.
        /// </summary>
        /// <param name="value">The string to change.</param>
        /// <param name="characterCount">The number of characters to remove.</param>
        /// <returns>The altered string.</returns>
        /// <exception cref="System.ArgumentNullException">The string passed to the value parameter is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The characterCount parameter must be non-negative and less than value.Length.</exception>
        public static string RemoveFromEnd(this string value, int characterCount)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (characterCount < 0) throw new ArgumentOutOfRangeException("characterCount");
            if (characterCount > value.Length) throw new ArgumentOutOfRangeException("characterCount");

            return value.Remove(value.Length - (characterCount), characterCount);
        }

        /// <summary>
        /// Removes a set number of characters from the end of a StringBuilder.
        /// </summary>
        /// <param name="value">The StringBuilder to change.</param>
        /// <param name="characterCount">The number of characters to remove.</param>
        /// <returns>The altered StringBuilder.</returns>
        /// <exception cref="System.ArgumentNullException">The StringBuilder passed to the value parameter is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The characterCount parameter must be non-negative and less than value.Length.</exception>
        public static StringBuilder RemoveFromEnd(this StringBuilder value, int characterCount)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (characterCount < 0) throw new ArgumentOutOfRangeException("characterCount");
            if (characterCount > value.Length) throw new ArgumentOutOfRangeException("characterCount");

            if (value.Length > 0)
            {
                return value.Length - characterCount > 0 
                    ? value.Remove(value.Length - (characterCount), characterCount) 
                    : new StringBuilder(string.Empty);
            }

            return value;
        }

        /// <summary>
        /// Removes a set number of characters from the start of a string.
        /// </summary>
        /// <param name="value">The string to change.</param>
        /// <param name="characterCount">The number of characters to remove.</param>
        /// <returns>The altered string.</returns>
        /// <exception cref="System.ArgumentNullException">The string passed to the value parameter is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The characterCount parameter must be non-negative and less than value.Length.</exception>
        public static string RemoveFromStart(this string value, int characterCount)
        {
            if (value == null) throw new ArgumentNullException("value");
            return value.Remove(0, characterCount);
        }

        /// <summary>
        /// Removes a set number of characters from the start of a StringBuilder.
        /// </summary>
        /// <param name="value">The StringBuilder to change.</param>
        /// <param name="characterCount">The number of characters to remove.</param>
        /// <returns>The altered StringBuilder.</returns>
        /// <exception cref="System.ArgumentNullException">The StringBuilder passed to the value parameter is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The characterCount parameter must be non-negative and less than value.Length.</exception>
        public static StringBuilder RemoveFromStart(this StringBuilder value, int characterCount)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (characterCount < 0) throw new ArgumentOutOfRangeException("characterCount");
            if (characterCount > value.Length) throw new ArgumentOutOfRangeException("characterCount");

            if (value.Length > 0)
            {
                return value.Length - characterCount > 0 
                    ? value.Remove(0, characterCount) 
                    : new StringBuilder(string.Empty);
            }
            
            return value;
        }

        /// <summary>
        /// Converts a string to an array.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns>An array of strings.</returns>
        /// <exception cref="System.ArgumentNullException">The string provided to the 'value' parameter is null.</exception>
        /// <exception cref="System.ArgumentException">The string delimiter provided must be at least 1 character long.</exception>
        public static string[] Split(this string value, string delimiter)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (delimiter.IsNullOrEmpty()) throw new ArgumentException("The delimiter specified was invalid", "delimiter");

            var delim = ':';

            if (value.Contains(":"))
            {
                if (!value.Contains("|"))
                {
                    delim = '|';
                }
                else if (!value.Contains("^"))
                {
                    delim = '^';
                }
                else if (!value.Contains("="))
                {
                    delim = '=';
                }
                else if (!value.Contains("/"))
                {
                    delim = '/';
                }
                else if (!value.Contains("-"))
                {
                    delim = '-';
                }
                else
                {
                    delim = delimiter[0];
                }
            }

            var tmp = value.Replace(delimiter, delim.ToString(CultureInfo.InvariantCulture));
            return tmp.Split(delim);
        }

        /// <summary>
        /// Delimits the specified collection.
        /// </summary>
        /// <param name="col">The collection.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns>A delimited string representation of the collection.</returns>
        public static string Delimit(this IEnumerable<string> col, string delimiter)
        {
            var builder = new StringBuilder();

            foreach (var item in col)
            {
                builder.AppendIfNotEmpty(delimiter);
                builder.Append(item);
            }

            return builder.ToString();
        }

        /// <summary>
        /// Delimits the specified collection.
        /// </summary>
        /// <typeparam name="T">The type of the value item in the KeyValuePair</typeparam>
        /// <param name="col">The collection.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="keyValueSeparator">The key value separator.</param>
        /// <returns>
        /// A delimited string representation of the collection.
        /// </returns>
        public static string Delimit<T>(this IEnumerable<KeyValuePair<string, T>> col, string delimiter, string keyValueSeparator)
        {
            var builder = new StringBuilder();

            foreach (var item in col)
            {
                builder.AppendIfNotEmpty(delimiter);
                builder.Append(item.Key);
                builder.Append(keyValueSeparator);
                builder.Append(item.Value);
            }

            return builder.ToString();
        }

        /// <summary>
        /// Lists the specified collection.
        /// </summary>
        /// <param name="col">The collection.</param>
        /// <returns>A listed string representation of the collection.</returns>
        public static string List(this IEnumerable<string> col)
        {
            var builder = new StringBuilder();

            foreach (var item in col)
            {
                builder.AppendLineIfNotEmpty();
                builder.Append(item);
            }

            return builder.ToString();
        }

        /// <summary>
        /// Lists the specified collection.
        /// </summary>
        /// <typeparam name="T">The type of the value item in the KeyValuePair</typeparam>
        /// <param name="col">The collection.</param>
        /// <param name="keyValueSeparator">The key value separator.</param>
        /// <returns>
        /// A listed string representation of the collection.
        /// </returns>
        public static string List<T>(this IEnumerable<KeyValuePair<string, T>> col, string keyValueSeparator)
        {
            var builder = new StringBuilder();

            foreach (var item in col)
            {
                builder.AppendLineIfNotEmpty();
                builder.Append(item.Key);
                builder.Append(keyValueSeparator);
                builder.Append(item.Value);
            }

            return builder.ToString();
        }
    }
}
