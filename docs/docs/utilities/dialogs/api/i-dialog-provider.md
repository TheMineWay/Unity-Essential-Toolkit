---
sidebar_position: 2
---

# IDialogProvider

The `IDialogProvider` is the interface that acts as the blueprint for any dialog provider. All dialog providers have to implement this interface. Once they do so, they will be available to be used as dialog providers.

## Methods API

<table>
    <tbody>
        <tr>
            <td>**Method**</td>
            <td>**Parameters**</td>
            <td>**Returns**</td>
            <td>**Description**</td>
        </tr>
        <tr>
            <td>IsReady</td>
            <td></td>
            <td>`bool`: ready state</td>
            <td>Checks if the provider is ready to start feeding dialogs.</td>
        </tr>
        <tr>
            <td>GetEntries</td>
            <td></td>
            <td>`DialogEntry[]`: dialogs</td>
            <td>Gets all dialogs as `DialogEntry[]`.</td>
        </tr>
    </tbody>
</table>

## Events

<table>
    <tbody>
        <tr>
            <td>**Event**</td>
            <td>**Parameters**</td>
            <td>**Description**</td>
        </tr>
        <tr>
            <td>onDialogProviderDataChange</td>
            <td></td>
            <td>Called by the dialog provider whenever the dialogs provider data is updated.</td>
        </tr>
    </tbody>
</table>
