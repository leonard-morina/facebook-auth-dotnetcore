-----------------------------------
LeonardMorina.FacebookAuthDotNetCore
-----------------------------------

The purpose of this package is to create a wrapper over Facebook Api for Asp Net Core Web API.

### Installation

LeonardMorina.FacebookAuthDotNetCore on [NuGet](https://www.nuget.org/packages/LeonardMorina.FacebookAuthDotNetCore/).


### Basic usage

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
