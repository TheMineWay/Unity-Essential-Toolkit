---
sidebar_position: 1
---

# StorageService API

The `StorageService` class is responsible for managing storage services across the lifecycle of the game.

<table>
    <tr>
        <td colspan="4">
            Static API
        </td>
    </tr>
    <tr>
        <td>**Method**</td>
        <td>**Parameters**</td>
        <td>**Returns**</td>
        <td>**Description**</td>
    </tr>
    <tr>
        <td>SetCurrentSlot</td>
        <td></td>
        <td>
            - `string`: slot name
            - `bool`: update storage instances. By default `true`
        </td>
        <td>Changes the current storage slot. If `updateStorageInstances` is set to `true` all initialized storage instances will get its slot updated.</td>
    </tr>
    <tr>
        <td>GetCurrentSlot</td>
        <td>`string`</td>
        <td></td>
        <td>Gets the current storage slot.</td>
    </tr>
    <tr>
        <td>ClearServices</td>
        <td></td>
        <td></td>
        <td>Removes all initialized services from memory (making them unavailable).</td>
    </tr>
    <tr>
        <td>AddService</td>
        <td>
            - `string`: service name (unique).
            - `StorageService`: storage service instance.
        </td>
        <td></td>
        <td>Adds a `StorageService` instance to the initialized services (makes it available).</td>
    </tr>
    <tr>
        <td>RemoveService</td>
        <td>
            - `string`: service name.
        </td>
        <td></td>
        <td>Removes a service from the available services by its unique name.</td>
    </tr>
    <tr>
        <td>GetService</td>
        <td>
            - `string`: service name.
        </td>
        <td>`StorageService`</td>
        <td>Given a storage service name it returns its corresponding instance form initialized services.</td>
    </tr>
    <tr>
        <td>GetServices</td>
        <td></td>
        <td>`StorageService[]`</td>
        <td>Returns all initialized storage services as an array.</td>
    </tr>
    <tr>
        <td>GetServiceNames</td>
        <td></td>
        <td>`string[]`</td>
        <td>Returns all initialized storage service names as an array.</td>
    </tr>
</table>

<table>
    <tr>
        <td colspan="4">
            Static events API
        </td>
    </tr>
    <tr>
        <td>**Event**</td>
        <td>**Parameters**</td>
        <td>**Returns**</td>
        <td>**Description**</td>
    </tr>
    <tr>
        <td>onSlotChanged</td>
        <td></td>
        <td></td>
        <td>It gets invoken whenever the `currentSlot` gets updated.</td>
    </tr>
</table>
