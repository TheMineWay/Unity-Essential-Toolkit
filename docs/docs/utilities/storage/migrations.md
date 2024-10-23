---
sidebar_position: 4
---

# Data migrations

You can easily migrate storage service data using the official API.

## Importing/Exporting data

You can choose to import/export data from two different data formats:

- **JSON string:** a `string` value.
- **Any class instance:** a `class` value.

:::info Important to know

When you import/export you will only work with data corresponding to the _current slot_. This means that if you import data when you are in a slot, the data that will be imported belongs only to the current slot. Other slots data will not be imported.

:::

### Importing

If you want to import data you have to use the `Import` method. See the example:

```csharp
/* Importing JSON data */
string jsonData = "{ ... }";
service.Import(jsonData);

/* Importing a class instance */
User user = new User();
service.Import(user);

/* Importing a class instance (a Dictionary)*/
Dictionary<string, string> dict = new Dictionary<string, string>();
service.Import(dict);
```

### Exporting

If you want to export data you have to use the `Export` method. See the example:

```csharp
/* Exporting JSON data */
string jsonData = service.Export();

/* Exporting a class instance */
User user = service.Export();

/* Exporting a class instance (a Dictionary)*/
Dictionary<string, string> dict = service.Export();
```

## Migrate data to another service

If you want to migrate data from a service to another one you can do so with the `CopyTo` method. See the example:

```csharp
var sourceService = StorageService.GetService("sourceService");
var targetService = StorageService.GetService("targetService");

sourceService.CopyTo(targetService);
```

This code **replaces** all the data of the `targetService` with the data of `sourceService`.
