# Ministry.StrongTyped #
This project is set up to provide base classes for generating strongly typed access to traditionally simple object or string type stores, such as ASP.Net Session state and the matching interfaces and test fakes to enable simple unit testing scenarios for the same.

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
