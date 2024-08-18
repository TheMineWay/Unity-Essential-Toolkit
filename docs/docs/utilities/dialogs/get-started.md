---
sidebar_position: 2
---

# Get started

This Utility does not require any specific initialization.

## Create the Dialog Controller

Attach to a GameObject the `DialogController` script. This script will be responsible for managing the dialog you want to display. It will handle dialog state and will provide an API and Unity Events that you can use to create custom behaviours.

The dialog controller displays dialogs on a `TextObject`. You need to provide one on the **Dialog text display** property.

## Providing dialogs

Once we have the `DialogController` present in our scene it is time to provide some dialogs. Dialogs can be provided by two different ways:

- Unity's inspector: using the Unity's Inspector UI to create dialogs.
- JSON files: using JSON files to define dialogs (recommended).

In order to provide dialogs we need to use a script that implements `IDialogProvider`. Within the package two dialog providers are included:

- `SimpleDialogProvider`: used when your game has no translations. You specify directly the text of the dialog.
- `I18DialogProvider`: used when your game is available in multiple languages. You don't define the display text but a i18n key that must be available in the scene.

Once you decided wich dialog provider you will be using, you have to attach the provider to the same _GameObject_ as the `DialogController` the provider is going to feed.

Now using the Unity Inspector or a JSON file you can configure the Dialogs Provider.
