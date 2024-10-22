---
sidebar_position: 1
---

# Introduction

This utility allows you to easily perform I/O operations to different storages like PlayerPrefs easily.

## Features

Why you might want to use this package?

This package uses a standard I/O interface that allows you to use one single API to interact with different storages (official ones provided by the package or customs created by you). Also, it provides storage division by slots so you can create and switch to a different storage slot that is fully independent of the others. This can help build games that allow multiple game save spaces.

## Understanding Storage Services

This utility uses what's called a **Storage Service**. A storage service is a class that provides the developer with a standard API to interact with a data storage system (for example PlayerPrefs).
When a `StorageService` instance is created it can get a `storageConnector` as a constructor parameter. The `storageConnector` needs to be an object that extends the `AStorageConnector` abstract class. The connector is used internally to interact with the storage system, for example, to be able to interact with `PlayerPrefs`, there is a connector that comes within the package named `PlayerprefsStorageConnector`. This connector translates I/O operations from the `StorageService` to be understood by the `PlayerPrefs` class.

Within the package there are some official storage connectors:

- `PlayerprefsStorageConnector`: Stores data in the PlayerPrefs storage. Data is not lost when the game is closed.
- `InMemoryStorageConnector`: Stores data in memory. Data is lost when the game is closed.
- `LocalFileStorageConnector`: (refered as JSON file). It stores data in a custom file in the game directory (recommended only for desktop developments).

You can always create your own storage connectors. You can do so by creating a class that extends the `AStorageConnector` abstract class.

## Understanding slots

Sometimes you might want to allow your game to store, for exmaple, multiple game progresses. This could be a hard functionality to provide, but this utility is here to help.
By using the slots functionality you can switch to a different storage space with no effort and go back whenever you want. There are no slot limits.
Each slot is identified by a unique name, and it is configured when the `StorageService` instance is created, but you can change it at any moment without needing to reinitialize anything.

Even thougth you can have initialized at the same time multiple storage services with different slots, you might want to have some of them coordinated. You can achieve this by using the `currentSlot`. The `currentSlot` is a static slot name stored inside the `StorageService`. This slot name is used by the managed storage service instances.

## Managed instances

You can create as much instances of `StorageService` as you want using code. This allows you to create and destroy them at any time. But as storage service instances will usually be kept alive as long as the game runs it is not a performant solution to create and destory instances multiple times.
Because of this, this package delivers a solution: you can use the `StorageService` API to register `StorageService` instances that are kept alive and accessible during the game`s lifecycle.

Whenever the `currentSlot` changes, all managed instances update their own slot to match this new `currentSlot` value. So, if you are using these managed instances you can be sure they will always be accessing the `currentSlot`.
