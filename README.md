# Ministry.StrongTyped #
This project is set up to provide base classes for generating strongly typed access to traditionally simple object or string type stores, such as ASP.Net Session state and the matching interfaces and test fakes to enable simple unit testing scenarios for the same.

## Parameter Checking ##
As coders we frequently find ourselves writing the same code over and over again to check the validity of passed parameters to a method. Using the CheckParameter static class in the Ministry.StrongTyped library you can replace this...

    if (myParameter == null) throw new ArgumentNullException("myParameter");

with

    CheckParameter.IsNotNull(myParameter, "myParameter");

or, for Strings and StringBuilders, this...

    if (myParameter == null) throw new ArgumentNullException("myParameter");
    if (myParameter == String.Empty) throw new ArgumentException("The parameter 'myParameter' cannot be empty", myParameter );

with

    CheckParameter.IsNotNullOrEmpty(myParameter, "myParameter");

There is also a method for passing in your own criteria matching function.

## String Manipulations ##
The library adds a suite of extension methods to Strings...

- **AddSpacesByCasing** - Adds spaces between ProperCased words.
- **AddCharactersByCasing** - Adds characters between ProperCased words.
- **IsNullOrEmpty** - Returns true if the string is null or empty.
- **IsNotNullOrEmpty** - Returns true if the string is not null or empty.
- **RemoveFromEnd** - Removes a given number of characters from the end of the string.
- **RemoveFromStart** - Removes a given number of characters from the start of the string.
- **Split** - Converts a delimited string into an array.

And also to StringBuilders...

- **AppendIfEmpty** - Appends to the builder only if it is currently empty.
- **AppendIfNotEmpty** - Appends to the builder only if it is currently not empty.
- **AppendLineIfEmpty** - Appends a line to the builder only if it is currently empty.
- **AppendLineIfNotEmpty** - Appends a line to the builder only if it is currently not empty.
- **RemoveFromEnd** - Removes a given number of characters from the end.
- **RemoveFromStart** - Removes a given number of characters from the start.

And to collections...

- **Delimit** - Converts an IEnumerable of strings or KeyValuePairs into a single delimited string.
- **List** - Converts an IEnumerable of strings or KeyValuePairs into a single, line terminator delimited list.

## Conversions ##
A selection of extension methods to provide easy conversion between some of the primary data types.

- **Boolean.ToInt32** - Converts a boolean value to an integer with optional parameters to specify the translated true and false values.
- **Boolean.ToString** - Takes a defined type of conversion to convert a bool value into either True / False, Yes / No or Y / N strings.
- **Int32.ToBoolean** - Converts an integer greater than 0 into true.
- **String.ToBoolean** - Converts any valid string to a representative boolean value. The conversion is case insensitive and will take either 1 / 0 / -1, Yes / No, True / False or Y / N as valid input strings.

## WebSession ##
### Using Session State in your Application ###
Use a WebSessionBase class. Recommended usage is to inherit from this class in your application and use that class to access session state. You can then swap out your session wrapper with any other implementation of IWebSession to enable testing of components that previously would have been extremely hard to test because of a dependency on session state.

### Faking WebSession ###
The IWebSession interface provides an in-memory alternative to Session that can be used within your tests to remove a dependency on session state by using the IWebSession interface instead.

## The Ministry of Technology Open Source Products ##
Welcome to The Ministry of Technology open source products. All open source Ministry of Technology products are distributed under the MIT License for maximum re-usability. Details on more of our products and services can be found on our website at http://www.minotech.co.uk

Our other open source repositories can be found here...

* [https://github.com/ministryotech](https://github.com/ministryotech)
* [https://github.com/tiefling](https://github.com/tiefling)

Most of our content is stored on both Github and Bitbucket.

### Where can I get it? ###
You can download the package for this project from any of the following package managers...

- **NUGET** - [https://www.nuget.org/packages/Ministry.StrongTyped](https://www.nuget.org/packages/Ministry.StrongTyped)

### Contribution guidelines ###
If you would like to contribute to the project, please contact me.

The source code can be used in a simple text editor or within Visual Studio using NodeJS Tools for Visual Studio.

### Who do I talk to? ###
* Keith Jackson - keith@minotech.co.uk
