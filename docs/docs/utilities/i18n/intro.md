---
sidebar_position: 1
---

# Introduction

You might want your game to be available in multiple languages. This goal can be achieved easily by using the **i18n** package.

## How it works

All texts will be stored in JSON files. To use a translation you will have provide the path to the text. See the example:

This is file is located in `locales/en_US/common.json`.

```json
{
  "dialogs": {
    "hello-world": "Hello world!",
    "another-translation": "Bye world!"
  },
  "some-other": "Hello :D"
}
```

If you wanted to get the **Hello world!** text you'll need to use the path `dialogs.hello-world`.

You are able to have more than translation file per language, so you will also provide the file code along with the translation path.

You will be able to translate the JSON files by using any external tool like:

- [Crowdin](https://crowdin.com/)
- [Localazy](https://localazy.com/)

At the end you will have files following the same structure but in different languages. The **i18n** package will take care of loading your translations efficiently for you.

Now, let's see how to get this done!
