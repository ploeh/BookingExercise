# Booking refactoring exercise

This repository contains the C# start code for simple [refactoring](http://amzn.to/YPdQDf) exercises.

The scenario is an HTTP-based API that serves as a back-end for a restaurant booking system. When a client wishes to book a table at this particular restaurant, it'll POST a JSON document to the API, and [the `ReservationsController.Post` method](https://github.com/ploeh/BookingExercise/blob/master/BookingApi/ReservationsController.cs#L14-L44) is invoked in order to handle the request.

The implementation given here is tightly coupled, containing input validation, business logic, and data access all in the single `Post` method. 

## Exercise: unit test

Get the `Post` method under unit test.

In this exercise, a unt test is defined as:

> A unit test is a fully automated, deterministic test that verifies the behaviour of a unit in isolation from its dependencies.

The `Post` method is currently tightly coupled to the SQL Server database (via Entity Framework), so at the very least, you should find a way to decouple the `Post` method from the database. This will enable you to run unit tests without involving any database.

The `Post` method has three branches, so you should **define at least three test cases:** one for each branch. You may add more than three tests if you want.

You are free to choose the test framework and tools you prefer. If you need inspiration, you may consider [xUnit.net](https://xunit.github.io) as your basic unit testing framework. If you need a dynamic mocking library, you may consider [Moq](https://github.com/Moq/moq4).

The unit tests you write should reside in a separate Visual Studio project and *not* rely on [the `[InternalsVisibleTo]` attribute](https://msdn.microsoft.com/en-us/library/system.runtime.compilerservices.internalsvisibletoattribute).

## Manual testing

*(Optional)*

If you want to manually test the code as given, you can. This could be valuable if you need to understand what the code does.

In order to do this, you must have the free [SQL Server 2014 Express LocalDB](https://msdn.microsoft.com/en-us/sqlserver2014express) installed. The database is a local file included in the `App_Data` folder, but you must have the database engine on your computer in order to use the database file.

If that prerequisite is met, you should be able to run the application from Visual Studio by hitting *F5* or *Ctrl + F5*. Take note of the HTTP port on which it starts listening.

### Post

Make an HTTP POST request like this (make sure to use the correct HTTP port):

```
POST http://localhost:51948/reservations HTTP/1.1
Content-Type: application/json

{
    "date": "2015-10-30",
    "name": "Jane Doe",
    "email": "jane@example.com",
    "quantity": 3
}
```

If you need an HTTP client, you can e.g. use *curl* if you have it installed:

```
$ curl -v -H "Content-Type: application/json" -d '{ "date": "2015-10-30", "name": "Jane Doe", "email": "jane@example.com", "quanti
ty": 3 }' http://localhost:51948/reservations
```

Other tools options for posting over HTTP could be [Fiddler](http://www.telerik.com/fiddler) or [Postman](https://www.getpostman.com).

### Verification

If you receive a `200 OK` response from the API, the request ought to be written to the database. If you want to look in the database to see what was written, you can use Visual Studio. Simply double-click `App_Data/BookingDatabase.mdf` file in Solution Explorer. This should bring up your *Server Explorer* window, which you can now use to expand *Tables* to find the *Reservations* table. Right-click on the *Reservations* table and click *Show Table Data*. You should then see a table window with the written data.

Updating the database changes the `App_Data/BookingDatabase.mdf` file and its associated log file. If you want to reset the database, you can reset the Git repository:

```
$ git reset --hard
```

If your Visual Studio *Server Explorer* is still connected to the database file, it will have a lock on the file, so you'll only be able to reset the repository if you close that (and any other) open connection(s).