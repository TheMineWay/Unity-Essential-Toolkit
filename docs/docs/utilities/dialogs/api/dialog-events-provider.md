# DialogEventsProvider

The `DialogEventsProvider` class is responsible for declaring dialog events that will be available to be invoked. It can be attached to a GameObject to enable the developer to use a friendly UI when declaring events. Also it provides an API to declare programatic events.

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
            <td>Invoke</td>
            <td>`string`: event id</td>
            <td></td>
            <td>Invokes all events that this provider has registered with this id.</td>
        </tr>
    </tbody>
</table>

## Static methods API

<table>
    <tbody>
        <tr>
            <td>**Method**</td>
            <td>**Parameters**</td>
            <td>**Returns**</td>
            <td>**Description**</td>
        </tr>
        <tr>
            <td>InvokeEvent</td>
            <td>`string`: event id</td>
            <td></td>
            <td>Invokes all events that all loaded providers have registered with this id.</td>
        </tr>
        <tr>
            <td>InvokeEvents</td>
            <td>`string[]`: event ids</td>
            <td></td>
            <td>Invokes all events that all loaded providers have registered with those ids.</td>
        </tr>
    </tbody>
</table>

## Static events

<table>
    <tbody>
        <tr>
            <td>**Event**</td>
            <td>**Parameters**</td>
            <td>**Description**</td>
        </tr>
        <tr>
            <td>onDialogEventCalled</td>
            <td>`string`: event id</td>
            <td>Gets invoked when any event is invoked. It provides the eventId.</td>
        </tr>
    </tbody>
</table>
