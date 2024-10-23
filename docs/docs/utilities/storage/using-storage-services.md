---
sidebar_position: 3
---

# Using storage services

Once you initialized all storage services you can start using its API.

## Getting a storage service instance

Each storage service is stored in memory as an individual `StorageService` instance. You can easily get an instance by using the `StorageService.GetService` method. This method allows you to get a `StorageService` instance only by providing its name as a string value (this is why service names must be unique).

For example:

```csharp
void Start() {
    var service = StorageService.GetService("my-service-name");

    /* You can have multiple storage services if you need it */
    var anotherService = StorageService.GetService("another-service-name");
}
```

:::info Remember

Before accessing a `StorageService` it has to be initialized. If it is not, an error will be thrown.

:::

## Performing I/O operations

Once you have the `StorageService` instance you are able to start interacting with the data.

Currently the list of available datatypes you can store/read is:

- `string`: simple text value.
- `int`: simple integer value.
- `float`: simple decimal value.
- `bool`: boolean value.
- `T (custom class)`: JSON data.

### Writing data

To write data to a storage service you need to use the `Write` method.

Example:

```csharp
service.Write("your-data-key", "your-value"); // Storing a string value
service.Write("your-data-key", 123); // Storing an int value
service.Write("your-data-key", 123.456); // Storing a float value
service.Write("your-data-key", true); // Storing a boolean value
```

Also, you can store class instances using the `WriteObject` method.

Example:

```csharp
Dictionary<string, string> dict = new Dictionary<string, string>();
dict["some-data-key"] = "Hello!";
dict["another-data-key"] = "Bye!";

service.WriteObject("your-data-key", dict); // Storing the `dict` object
```

### Reading data

To read data from a storage service you need to use some methods. When reading you will not be able to use a uniquely named method as you can when writing data.

If the key does not correspond to any data it will return `null`.

Example:

```csharp
string textData = service.ReadString("your-data-key"); // Reading a string value
int integerData = service.ReadInt("your-data-key"); // Reading an int value
float decimalData = service.ReadFloat("your-data-key"); // Reading a float value
bool booleanData = service.ReadBool("your-data-key"); // Reading a boolean value
```

Also, you can store class instances using the `WriteObject` method.

Example:

```csharp
Dictionary<string, string> dict = service.ReadObject("your-data-key"); // Reading the `dict` object
```

### Removing a key

When you want to remove data you can use the `Clear` method. You have to provide the data key that you want to remove.

Example:

```csharp
service.Clear("your-data-key");
```
