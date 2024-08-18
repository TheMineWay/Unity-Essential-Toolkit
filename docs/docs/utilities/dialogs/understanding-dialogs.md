---
sidebar_position: 3
---

# Understanding dialogs

## Dialog properties

All dialogs end up being composed by some properties (it does not matter the origin of those dialogs, they all end up being the same).

<table>
    <tbody>
        <tr>
            <td>**Property**</td>
            <td>**Type**</td>
            <td>**Description**</td>
        </tr>
        <tr>
            <td>text</td>
            <td>`string`</td>
            <td>It stores the text that is being displayed.</td>
        </tr>
        <tr>
            <td>speaker</td>
            <td>`string`</td>
            <td>It stores the speaker.</td>
        </tr>
        <tr>
            <td>images</td>
            <td>`Image[]`</td>
            <td>It stores the images that will be displayed along the dialog.</td>
        </tr>
        <tr>
            <td>locked</td>
            <td>`bool`</td>
            <td>It stores wether the dialog will be locked (it means the dialog cannot be skipped using managed dialog controls).</td>
        </tr>
        <tr>
            <td>events</td>
            <td>`string[]`</td>
            <td>It stores event codes that get called when the dialog is displayed.</td>
        </tr>
    </tbody>
</table>

Each dialog provider has its own strategy that generates dialogs following this format. For example, the `SimpleDialogProvider` simply maps provided dialogs (as they have almost the same format). In the other hand, the `I18nDialogProvider` cannot map directly provided dialogs because they don't have the _text_ property. I18n dialogs have a _key_ property that refers to a translation entry. When this provider generates the dialogs it needs to create the _text_ property, so it gets the translation using the key and creates the text property from the translation result.
