---
sidebar_position: 1
---

# DialogController

The `DialogController` is the class responsible for managing dialogs display. It stores the current display state and displays dialogs as desired (calling respective events when necessary).

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
            <td>SetDialog</td>
            <td>`string`: dialog code</td>
            <td></td>
            <td>Sets the current dialog by dialog code.</td>
        </tr>
        <tr>
            <td>SetDialog</td>
            <td>`int`: dialog index</td>
            <td></td>
            <td>Sets the current dialog by dialog index.</td>
        </tr>
        <tr>
            <td>GetEntry</td>
            <td>`string`: dialog code</td>
            <td>`DialogEntry`</td>
            <td>Retrieves a loaded dialog entry by dialog code.</td>
        </tr>
        <tr>
            <td>GetEntry</td>
            <td>`int`: dialog index</td>
            <td>`DialogEntry`</td>
            <td>Retrieves a loaded dialog entry by dialog index.</td>
        </tr>
        <tr>
            <td>GetEntryIndex</td>
            <td>`string`: dialog code</td>
            <td>`int`</td>
            <td>Gets the dialog index of a dialog by its code.</td>
        </tr>
        <tr>
            <td>StartDialog</td>
            <td>`int`: initial dialog index (default = 0)</td>
            <td></td>
            <td>Begins displaying dialogs.</td>
        </tr>
        <tr>
            <td>MoveDialog</td>
            <td>
                - `int` (steps): dialogs amount (default = 1)
                - `bool` (bypassLock): wether to move even when dialog is locked or not (default = false)
            </td>
            <td></td>
            <td>Moves the currentDialog state a certain amount of dialogs count.</td>
        </tr>
        <tr>
            <td>NextDialog</td>
            <td>`bool`: wether to move even when dialog is locked or not (default = false)</td>
            <td></td>
            <td>Moves to the next dialog.</td>
        </tr>
        <tr>
            <td>PrevDialog</td>
            <td>`bool`: wether to move even when dialog is locked or not (default = false)</td>
            <td></td>
            <td>Moves to the previous dialog.</td>
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
            <td>onSpeaker</td>
            <td>`string`: speaker value</td>
            <td>Called every time the current dialog changes along with the speaker value. Called even when speaker did not change.</td>
        </tr>
        <tr>
            <td>onImage</td>
            <td>`ARegisterDialogEntry.Image[]`: images</td>
            <td>Called every time the current dialog changes along with dialog images. Called even when images do not change.</td>
        </tr>
        <tr>
            <td>onDialogChange</td>
            <td></td>
            <td>Called every time the current dialog changes.</td>
        </tr>
        <tr>
            <td>onDialogsEnd</td>
            <td></td>
            <td>Called when the last dialog is skipped.</td>
        </tr>
    </tbody>
</table>
