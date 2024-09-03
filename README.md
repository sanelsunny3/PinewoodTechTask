This is a ASP.Net Core Web project to demonstrate CRUD operation of Customer details. It consist of two solutions:

1. CustomerWebAPI:
   It is a ASP.NET Core WebAPI project which act as backend of the Customer details CRUD operations.
   Note:
   Implemented swagger documentation for API reference.
   This WebAPI uses In-Memory database for storing data, so no need to configure any database source.

   Steps to run the application:
   1. Clone this repo into local machine.
   2. Open CustomerWebAPI solution in Visual Studio.
   3. Run CustomerWebAPI application.
   4. Access the url - https://localhost:7166/swagger/index.html


2. CustomerUI:
   This is a ASP.Net Razor Page application which is the frontend that performs simple CRUD operation of Customers.
   This application consume RestFul API from CustomerWebAPI solution to Create, Read, Update and Delete Customer details.

   Note:
   Before running this application, you must run CustomerWebAPI which is its dependency API.

   Steps to run the application:
   1. Open CustomerUI solution in Visual Studio.
   2. Run CustomerUI application.
   3. When the web app opens in browser, navigate to Customer Page.
   4. Add new Customer details.
   5. Created Customers will be displayed in the same page.





