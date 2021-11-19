# ContactsMobileBFF
An ASP.NET Core API which provides data for mobile clients displaying contacts listings.

## Usage
Put something here

## TestApp
Just run this from Visual Studio

## Localisation
Localisation is supported through culture setting. Currently this is done via the query string parameter `culture`. For example `culture=es`.

### Build
To build this application just run `dotnet build ContactsMobileBFF.csproj` at the command line.

### Run
To run this application just run `dotnet run ContactsMobileBFF.csproj` at the command line.

## TODO
* Create unit tests which verify that every resource file contains an entry for every resource string we require
* Come up with a custom request culture provider that uses the users settings rather than relying on the query parameter