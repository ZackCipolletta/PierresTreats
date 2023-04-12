# Pierre's Treats

#### A web application using .NET Core MVC, SQL databases, EF Core, many to many relationships, C# classes, methods, auto-implemented properties and Identity with authorization and authentication.

#### By Zachary Cipolletta

## Technologies Used

* C#
* .Net 6
* HTML
* JavaScript
* JSON
* SQL
* EFCore
* Identity
* Authentication & Authorization

## Description
This web application was created for a bake shop to be able to show users the various different baked treats and flavors the shop has to offer. The site Allows users to see lists of both flavors and treats available. Users are also able to browse each individual treat or flavor and see what flavors a given treat is available in or what treats are available for a given flavor.  Users can register to log into the site and see the buttons to create or delete new items, but only users in the 'Admin' role are able to actually make modifications.

## Setup/Installation Requirements

1. Clone this repo.
2. Open your terminal (e.g., Terminal or GitBash) and navigate to this project's production directory named "PierresTreats".
3. Create a file named ['appsettings.json'] in the production directory (Factory) and include a new database connection string. The string should be as follows:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306[Or-Your-Desired-Port-Number];database=[DATABASE-NAME-HERE];uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];",
  }
}
Create a database name, update username and password to match the username and password of your computer.
4. Enter 'dotnet ef database update' in the terminal inside the production directory (this will create the database schema in MySQL which the application will access later), enter 'dotnet run' or 'dotnet watch run' in the command line to start the project in development mode with a watcher (Optionally, you can run "dotnet build" to compile the app without running it). 
5. Open the browser to https://localhost:5279.
6. Once the page has loaded you will need to first register for the site and log in.
7. Once you are logged in, click the 'Role' button which will take you to the Roles index page.
8. In order to fully access and use the site you must first create an 'Admin' role and add yourself to it. Click the Create a role button.
9. The name must be 'Admin'. Click the create button. This will bring you back to the Roles Index page.
10. Here we will see a table listing all of the roles that have been created.  Click the update button for the Admin role.
11. Click the checkbox to add yourself to the Admin role.
12. Click the home button in the footer of the page to bring you back to the index page. Now you must log out log back in. This will refresh the system and once you log back in you will have full 'Admin' privileges to be able to create, update, and delete items.  The system first checks to see if the role of 'Admin' exists or not. If not The role button is displayed to any user who logs in. Once the Admin role has been created however, it will only be visible to those in the Admin role.


## Known Bugs

* So far I have not been able to implement model validation into the edit pages.  After trying several different solutions I still have not found a way to fix this issue. 
* In the edit page I have a list containing all of the items joined to the current item being edited. The user is not able to delete the first item in the list for some reason.  There is no error message, but the item will not be deleted from the database.  If the list is reordered, the item at the top of the list will not be deleted. I tried using ViewBag to store the items in the join table and I tried performing the Delete action asynchronously but, so far nothing has resolved the issue.
* In the Role Index page the users column does not populate with the list of users who are assigned to the corresponding role. My best guess is that this has to do with the Custom Tag Helper which is supposed to populate the table data, but after trying several different solutions I have not yet been able to resolve the issue. So far I have tried different using directives, I have tried installing Microsoft.AspNetCore.Mvc.TagHelpers package, I have added the Razor Tag Helper service to Program.cs, and I tried to store the list of users with ViewBag, to access them on the Index page.

## License
MIT

Copyright (c) 3/26/2023 Zachary Cipolletta

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
