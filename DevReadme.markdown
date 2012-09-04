This file contains more info about developers who plan to contribute to the project.

The solution for the OpenPhoto .NET library contains a class library project and a sample Console application, which consumes the class library API.

RestSharp is used to make REST requests to the actual OpenPhoto API. For more info on RestSharp, see http://restsharp.org/.

The solution is setup with enabled package restore. This means that NuGet packages are not checked in, and will be downloaded/updated when each developer builds the solution locally. Thus we skip checking in DLLs for third-party libraries. For more information, please read http://docs.nuget.org/docs/workflows/using-nuget-without-committing-packages/.