---
sidebar_position: 2
---

# Getting started

Let's start using the Storage utility.

## Initializating storage services

You can create your own `StorageService` instances and that is fine, but in the case you want to reuse them during the lifecycle of the game, it is a good idea to use the official instance initialization utility.

We will use the `StorageInitializer` script. This script needs to be attached to a GameObject in the initialization scene (or any scene that gets loaded at game startup).
In the Unity's inspector, we should see some configurable parameters.

- Initialization mode: You can decide when to initialize teh script (or disable autoinitialization).
- Default slot name: This indicates the slot name that will be in use in all storage services.
- Storage instances: A list of all storage services that will be initialized automatically. You have to specify a unique name and the storage connector.

All these storage services will be initialized as **Managed Storage Services**. This means they are kept in memory the whole lifecycle of the game and can be accessed by using static methods of the [StorageService API](/docs/utilities/storage/api/storage-service).

Also, when the `currentSlot` changes in the `StorageService` all those storage services update their own slot to match the `currentSlot` value (as said in the introduction).
