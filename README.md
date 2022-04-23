# MakerSight Assignment

## Requirements
.Net version 6.0 was used for developing this code base. Please make sure the .Net SDK for that version is intalled on your machine in order to successfully run this application. Use the following command to ensure your .Net Version:
```
dotnet --version
```

## Build & Execution

In the root folder, restore the nuget packages:

```
dotnet restore
```

Build the solution:
```
dotnet build
```

Execute the unit tests:
```
dotnet test
```

Run the application:
```
dotnet run --project ./MakerSight.API
```

When running the application, the resulting output in your console looks something like the following:
```
info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
      Entity Framework Core 6.0.4 initialized 'AppDbContext' using provider 'Microsoft.EntityFrameworkCore.InMemory:6.0.4' with options: StoreName=MakerSightDb 
info: Microsoft.EntityFrameworkCore.Update[30100]
      Saved 2 entities to in-memory store.
info: Microsoft.EntityFrameworkCore.Update[30100]
      Saved 4 entities to in-memory store.
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7228
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5259
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /home/behrooz/projects/MakerSight/MakerSight.API/
```

**Important**: Note that there are two endpoints provided, with and without HTTPS (Port number will vary on your machine). Depending on your OS you may be asked to accept the self signed certificate or continue "at your own risk" through the browser.

By navigating to `http://localhost:{PORT}/swagger` you will get a simple UI presenting the available APIs.

### Notes

Two endpoints have been implemented inside the `ProductsController.cs`, and some comments have been left near the end of it regarding the other endpoints that could be added.
## Database & Seed Data
In order to ease the delivery of this assignment and eliminate the dependency to an actual database, an "In-Memory" database has been used. 
Inside `./MakerSight.API/Infrastructure/SeedDataCreator.cs` file, you will find a set of hard coded Guids for both `Brand` and `Product` entities used across the application.

In case you plan to test out the APIs yourself, you can use those to your advantage, for example a GET request to the following endpoint will return the relevant products:
```
https://localhost:{PORT}/brand/17cff5bb-3f4c-4676-ab1b-a177fd9aca25/products
```

## Observations
I have some observations and had there been enough time, they could be dived into a bit deeper, which I present in the following.
### Data Volume
The implemented endpoint for return all products of a certain brand assumes all filtering and pagination occures on the frontend, hence only filtering by brand. In case of potentially massive data, that would be inefficient and serverside filtering and pagination needs to be added. 
Filtering criteria could also a quite fluid subject and it would to be thought out based on the specifics (possibly filtering by price, creation date, etc.)

### Parent/Child Products
As seen in `./MakerSight.Domain/Product.cs`, the product entity has been defined to allow a parent-child relationship within itself by proving a nullable self-reference. This, while allows for the requirement specified in the assignment, also allows for multi-level hierarchy in the future, should the requirements change. It will also call for careful error handling from the developers; and had there been more time, I could have thought of implementing it differently.

### Images
Due to lack of time, I have taken a simplified path of treating images just as urls to a presumably publicly accessible hosted image. In reality, this will be quite of its own challenge to solve, uploading images, building mechanisms to only allow certain users to access them, etc.

## Bonus
If each brand has its own properties, we could have an entity (aka DB table) called `BrandProperty` in which we could have a one-to-many relationship between a brand and its own set of properties. Then another entity, called `ProductProperty` where each property can set individual properties, based on what properties are available to it according to the product's brand.

I will include a simple ERD diagram in my submission email.
 
