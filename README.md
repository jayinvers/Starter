# Starter

Starter is a new project template for ASP.NET 6, it includes Admin Panel, API and Foreground. In addition, it has sample code, including a user management using Identity, an admin panel, and a one-to-many Entity Model relationship.

## Install & Run

1. Download the code and open **Starter.sln** with VS2022

2. Open the **Package Manager Console** and execute

   ```bash
   Add-migration Initial
   Update-database
   ```

3. run

## How to rename the project

If you want to rename the project, just modify the **Starter** folder and **Starter.sln** in the root directory. 

Next, using the **text replacement tool**, replace **Starter** in the entire project with **your project name**.



## Notes

If you want to use this project as your new project template, please **delete** the **.git** folder in the root directory before doing so (it is a **hidden folder** by default).