---
sidebar_position: 4
---

# Understanding providers

Dialog providers are used to feed the `DialogController` with dialog entries. There can be different dialog origins (translation files, etc) so you can use any script that implements the `IDialogProvider` interface (even create your own). This dialog provider script has to be attached to the same GameObject as the `DialogController`.

## Dialogs feed flow

See the diagram to understand the data feed process.

![Feed flow](./assets/dialog-provider-feed-flow.drawio.png)

## Official providers

Learn about each official dialogs provider.

### Simple dialogs provider

This is the simplest dialog. You configure directly the text that is going to be displayed. It also allows you to provide the dialog basics.

Here is a JSON file example (and the [JSON schema](https://github.com/TheMineWay/Unity-Essential-Toolkit/tree/main/schemas/dialogs/simple-dialog-schema.json))

```json
{
  "$schema": "",
  "i-1": {
    "text": "Hello from example",
    "speaker": "",
    "images": [
      {
        "image": "image-1",
        "target": ""
      }
    ]
  },
  "i-2": {
    "text": "Second sentence",
    "speaker": "",
    "images": [
      {
        "image": "image-1",
        "target": "1"
      }
    ]
  },
  "i-3": {
    "text": "Third sentence",
    "speaker": "",
    "images": []
  },
  "i-4": {
    "text": ":D",
    "speaker": "",
    "images": []
  }
}
```

### I18n dialogs provider

This dialog provider is used when you want to use i18n keys on dialogs. Instead of providing the text that will be displayed you provide the _I18n key_ and the _I18n translation set_. The key must be available on the scene in order to be able to display the translation (this means following all [I18n initialization steps](/docs/utilities/i18n/using-translations)).

Here is a JSON file example (and the [JSON schema](https://github.com/TheMineWay/Unity-Essential-Toolkit/tree/main/schemas/dialogs/i18n-dialog-schema.json))

```json
{
  "i-1": {
    "key": "test1",
    "speaker": "",
    "images": []
  },
  "i-2": {
    "key": "test3",
    "speaker": "",
    "images": [
      {
        "image": "image-1",
        "target": ""
      }
    ]
  },
  "i-3": {
    "key": "test4",
    "speaker": "",
    "images": []
  },
  "i-4": {
    "key": "test5",
    "speaker": "",
    "images": [
      {
        "image": "image-1",
        "target": "1"
      }
    ],
    "locked": true
  },
  "i-5": {
    "key": "test10.text",
    "speaker": "",
    "images": []
  }
}
```
