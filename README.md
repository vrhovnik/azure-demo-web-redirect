# Azure demo app for testing out web redirects with Azure FrontDoor

Demo for redirect rules for Azure Web Apps for containers or native . Solution is deployed
to [Azure Web App for Containers](https://azure.microsoft.com/en-us/services/app-service/containers/) and uses [Azure FrontDoor](https://docs.microsoft.com/en-us/azure/frontdoor/front-door-overview) with rewrite rules to handle redirections.

# Solution Structure and how to run the app

App consists out of web api, console and NUnit test application. Console and NUnit are meant for testing redirection
locally and in the cloud.

In order to simulate this in [Azure](https://azure.com) you will need:

1. working [Microsoft Azure](https://portal.azure.com) account
2. [Microsoft Azure Web App for container](https://azure.microsoft.com/en-us/services/app-service/containers/)
   or [Microsoft Azure Web App for Linux](https://docs.microsoft.com/en-us/azure/app-service/overview) - you can
   follow [this tutorial](https://docs.microsoft.com/en-us/azure/app-service/quickstart-dotnetcore?tabs=net50&pivots=development-environment-vs)
   to set up the app from start to finish
3. [Microsoft Azure FrontDoor](https://docs.microsoft.com/en-us/azure/frontdoor/quickstart-create-front-door) service

To run the application (you can follow [this tutorial](https://azure.microsoft.com/en-us/get-started/web-app/)), clone the app, open [solution](https://github.com/vrhovnik/azure-demo-web-redirect/blob/main/RedirectApiSLN/RedirectApiSLN.sln) in your favorite editor, pick solution and run it.
If you will run console application or tests, you will need the API running behind the scenes as the app interacts with it. 
By default it calls the app on https://localhost:5005. If you want to change default URL, define environment variable with key [BaseURL](https://github.com/vrhovnik/azure-demo-web-redirect/blob/main/RedirectApiSLN/RedirectClientCalls/Program.cs#L14).

# CREDITS

In this demo I have used the following 3rd party libraries and solutions:

- [Spectre Console](https://github.com/spectresystems/spectre.console/)
- [Nunit](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit)
