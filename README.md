# improc-petrsu-webapi
An API for the improc-petrsu library, written using .NET Core and ASP.NET Core.

It utilizes the [`improc-petrsu`](https://gitlab.com/geext/improc-petrsu) library written in Rust and wrapped in a NuGet package. 

To build the project, it's enough to just invoke `dotnet build` in the root directory. A .NET Core SDK is required to build the project. The project targets .NET 5, so at least .NET 5.0 SDK is required.

The API is deployed to Heroku and can be accessed via this link: https://improc-petrsu-backend.herokuapp.com/swagger/index.html (needs some time to wake up as it uses the Free dyno only).
