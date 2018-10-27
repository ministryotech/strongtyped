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
using System.Linq;
using System.Text;

// TODO: Add any missing methods to FluentGuard

namespace Ministry.StrongTyped
{
    /// <summary>
    /// Methods for checking the state of parameters
    /// </summary>
    [Obsolete("Use the Ministry.FluentGuard library instead")]
    public static class CheckParameter
    {
        /// <summary>
        /// Determines whether the specified parameter is null and, if so, throws an ArgumentNullException.
        /// </summary>
        /// <typeparam name="T">The type of the object</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <exception cref="System.ArgumentNullException">The parameter is null.</exception>
        public static void IsNotNull<T>(T parameter, string parameterName)
        {
            // ReSharper disable once CompareNonConstrainedGenericWithNull
            if (parameter == null) throw new ArgumentNullException(parameterName);
        }

        /// <summary>
        /// Determines whether the specified parameter is null or empty and, if so, throws an ArgumentNullException or ArgumentException, as appropriate.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <exception cref="System.ArgumentNullException">The parameter is null.</exception>
        /// <exception cref="System.ArgumentException"></exception>
        public static void IsNotNullOrEmpty(string parameter, string parameterName)
        {
            if (parameter == null) throw new ArgumentNullException(parameterName);
            if (parameter == String.Empty) throw new ArgumentException(String.Format("The parameter '{0}' cannot be empty", parameterName), parameterName);
        }

        /// <summary>
        /// Determines whether the specified parameter is null or empty and, if so, throws an ArgumentNullException or ArgumentException, as appropriate.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <exception cref="System.ArgumentNullException">The parameter is null.</exception>
        /// <exception cref="System.ArgumentException"></exception>
        public static void IsNotNullOrEmpty(StringBuilder parameter, string parameterName)
        {
            if (parameter == null) throw new ArgumentNullException(parameterName);
            if (parameter.Length == 0) throw new ArgumentException(String.Format("The parameter '{0}' cannot be empty", parameterName), parameterName);
        }

        /// <summary>
        /// Determines whether the specified parameter matches the criteria of a specific function and, if so, throws an ArgumentNullException.
        /// </summary>
        /// <typeparam name="T">The type of the object</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="function">The function to assess.</param>
        /// <param name="failMessage">The fail message.</param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException">The parameter is null.</exception>
        public static void MatchesSpecificCriteria<T>(T parameter, string parameterName, Func<T, bool> function, string failMessage)
        {
            if (function(parameter)) throw new ArgumentException(failMessage, parameterName);
        }
    }
}
