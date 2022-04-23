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

Note that there are two endpoints provided, with and without HTTPS. Depending on your OS you may be asked to accept the self signed certificate or continue "at your own risk" through the browser, or you may just be able to use the non-secured endpoint.

By navigating to `http://localhost:{PORT}/swagger` you will get a simple UI presenting the available APIs.