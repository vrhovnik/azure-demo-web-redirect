# Azure demo app for testing out web redirects with Azure FrontDoor

Demo for redirect rules for Azure Web Apps, when you use a container as a solution. Solution is deployed to [Azure Web App for Containers](https://azure.microsoft.com/en-us/services/app-service/containers/). In front of web app there is [Azure FrontDoor](https://docs.microsoft.com/en-us/azure/frontdoor/front-door-overview) with rewrite rules. 

# Solution Structure

App consists out of web api and console application, which calls the REST API to do test scenarios. In order to simulate this in [Azure](https://azure.com), you will need working account. 

# CREDITS

In this demo, we used the following 3rd party libraries and solutions:
- [Spectre Console](https://github.com/spectresystems/spectre.console/)
