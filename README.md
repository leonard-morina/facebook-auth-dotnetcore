-----------------------------------
LeonardMorina.FacebookAuthDotNetCore
-----------------------------------

The purpose of this package is to create a wrapper over Facebook Api for Authentication.

### Installation

LeonardMorina.FacebookAuthDotNetCore on [NuGet](https://www.nuget.org/packages/LeonardMorina.FacebookAuthDotNetCore/).


### Basic usage

The following code demonstrates basic usage of EF Core. For a full tutorial configuring the `DbContext`, defining the model, and creating the database, see [getting started](https://docs.microsoft.com/ef/core/get-started/) in the docs.

```cs
// Initialization of the Authentication Model
var facebookAuthentication = new FacebookAuthentication(new FacebookAppSettings 
{
    AppId = "<AppId>",
    AppSecret = "<AppSecret>"
});

//Usage via the facebook token
var user = await facebookAuthentication.GetAuthenticatedUserInformationAsync("<accessToken>", "id, email, firstName, lastName");
```