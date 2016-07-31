# NumbersToWordsSolution

This is a class library created with .NET Core 1.3 dependency compatible with all the modern .NET Framework releases including .NET Framework 4.x and .NET Core.
FYI The .NET Core class libraries are superior than the old Portable Class Libraries which can be considered obsolete.

It converts a decimal number (for example 123) to a string "centoventitre/00".
The string is commonly used on cheques for financial projects.

*Warning: At the moment only the italian language is supported.*

## DecimalExtensions
Is a static class containing the extension method for decimal types
An overload allows specifying the CultureInfo for the language used for the conversion and the number of decimals.

## INumberToWords
Is an interface used to abstract the languages
The signature of the method to make the conversion is the following:
string Convert(decimal number, System.Globalization.NumberFormatInfo numberFormatInfo);

## NumbersToWordsItalian
The implementation of INumberToWords in Italian language
This is called from the DecimalExtensions class

### Notes
In order to use this class library you should create the nuget package first.
Please create an issue if you want me to publish the packet.
