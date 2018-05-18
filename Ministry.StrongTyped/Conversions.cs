// Copyright (c) 2018 Minotech Ltd.
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
using System.Globalization;

namespace Ministry.StrongTyped
{
    /// <summary>
    /// A static class of methods to convert types which can be used directly or as extensions.
    /// </summary>
    public static class Conversions
    {

        #region | Boolean Conversion Methods |

        #region | ToInt32 |

        /// <summary>
        /// Converts a boolean to an integer value of a specified type.
        /// </summary>
        /// <param name="value">The boolean value to convert from.</param>
        /// <param name="trueValue">The true value.</param>
        /// <param name="falseValue">The false value.</param>
        /// <returns>
        /// The appropriate integer value.
        /// </returns>
        public static int ToInt32(this bool value, int trueValue = 1, int falseValue = 0)
        {
            return (value ? trueValue : falseValue);
        }

        /// <summary>
        /// Converts a boolean to an integer value of a specified type.
        /// </summary>
        /// <param name="value">The boolean value to convert from.</param>
        /// <param name="trueValue">The integer value to return if the boolean value is true.</param>
        /// <param name="falseValue">The false value.</param>
        /// <returns>
        /// The appropriate integer value.
        /// </returns>
        public static int? ToInt32(this bool? value, int trueValue = 1, int falseValue = 0)
        {
            if (value.HasValue)
            {
                return value.Value.ToInt32(trueValue, falseValue);
            }

            return null;
        }

        #endregion

        #region | ToString |

        /// <summary>
        /// Converts a boolean to a string value of a specified type.
        /// </summary>
        /// <param name="value">The boolean value to convert from.</param>
        /// <param name="stringType">Type of the string.</param>
        /// <returns>
        /// The appropriate string value.
        /// </returns>
        /// <remarks>
        /// To convert to 1/0 call ToInt().
        /// </remarks>
        public static string ToString(this bool value, BooleanToStringConversionType stringType)
        {
            switch (stringType)
            {
                case BooleanToStringConversionType.TrueOrFalse:
                    return (value ? "True" : "False");
                case BooleanToStringConversionType.YesOrNo:
                    return (value ? "Yes" : "No");
                case BooleanToStringConversionType.YOrN:
                    return (value ? "Y" : "N");
                default:
                    return String.Empty;
            }
        }

        /// <summary>
        /// Converts a boolean to a string value of a specified type.
        /// </summary>
        /// <param name="value">The boolean value to convert from.</param>
        /// <param name="stringType">Type of the string.</param>
        /// <returns>
        /// The appropriate string value.
        /// </returns>
        /// <remarks>
        /// To convert to 1/0 call ToInt().
        /// </remarks>
        public static string ToString(this bool? value, BooleanToStringConversionType stringType)
        {
            return value.HasValue ? value.Value.ToString(stringType) : String.Empty;
        }

        #endregion

        #endregion

        #region | Integer Conversions |

        /// <summary>
        /// Converts an integer to it's boolean value.
        /// </summary>
        /// <param name="value">The integer to convert from.</param>
        /// <returns>The appropriate boolean value.</returns>
        /// <remarks>Converts 0 False, all else True.</remarks>
        public static bool ToBoolean(this int value)
        {
            return (value > 0);
        }

        #endregion

        #region | String Conversions |

        /// <summary>
        /// Converts a string to it's boolean value.
        /// </summary>
        /// <param name="value">The string to convert from.</param>
        /// <returns>The appropriate boolean value.</returns>
        /// <remarks>Converts 1/0, True/False, Yes/No, etc. Returns nothing otherwise.</remarks>
        /// <exception cref="System.InvalidCastException">Thrown if the string cannot be transformed into a boolean value.</exception>
        public static bool ToBoolean(this string value)
        {
            switch (value.Trim().ToUpper(CultureInfo.InvariantCulture))
            {
                case "1":
                    return true;
                case "0":
                    return false;
                case "-1":
                    return false;
                case "YES":
                    return true;
                case "NO":
                    return false;
                case "TRUE":
                    return true;
                case "FALSE":
                    return false;
                case "Y":
                    return true;
                case "N":
                    return false;
                default:
                    throw new InvalidCastException("The object passed cannot be converted");
            }
        }

        #endregion

    }
}
