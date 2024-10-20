---
sidebar_position: 2
---

# Get started

Create your translation files structure and initialize the utility.

## Files hierarchy

First of all, you need to create a folder where all translations will be stored. There are no rules for naming and folders structure, but it is recommended to create a folder named **locales** containing one folder per available language (names should follow standard language codes like en_US, es_ES or ca_ES. [See the list](https://www.localeplanet.com/icu/)).

Inside each language folder you will create the translation JSON files. If the game is big enough it is recommended to create nested folders to ensure organization.
It is highly recommended (almost compliant) to keep the same files hierarchy across all languages, specially if you are going to use translation tools to manage translations.

See here an example of translations hierarchy:

```
locales
├── en_US
│   ├── common.json
│   └── scenes
│       ├── scene-1.json
│       └── scene-2.json
└── es_ES
    ├── common.json
    └── scenes
        ├── scene-1.json
        └── scene-2.json
```

## Translations file structure

Translations are stored as JSON files. You can nest translations as much as you want. All end values must be strings, that means that all paths must lead to a text (not a number, boolean or empty object). You cannot incorporate arrays in the translation file.

<table>
    <tbody>
        <tr>
            <td>Valid translation file</td>
            <td>Invalid translation file</td>
        </tr>
        <tr>
            <td>
            ```json
            {
                "times": "2",
                "greeting": "Hello!",
                "nested-translations": {
                    "dialog-1": "Once upon a time...",
                    "dialog-2": "It's been so long"
                }
            }
            ```
            </td>
            <td>
            ```jsonc
            {
                "times": 2, ❌ You cannot use numbers (use "2")
                "something": true, ❌ You cannot use booleans
                "dialogs": {}, ❌ Empty object
                "more-dialogs": [], ❌ You cannot use arrays
                "greeting": "Hello!", ❌ Trailing comma
            }
            ```
            </td>
        </tr>
    </tbody>
</table>

Following up with the hierarchy example, as you can imagine, the **common.json** file inside the en_US folder has its Spanish translation in the **common.json** file inside the es_ES folder. Both files **MUST** have the same JSON structure.

For example:

<table>
    <tbody>
        <tr>
            <td>en_US/common.json</td>
            <td>es_ES/common.json</td>
        </tr>
        <tr>
            <td>
                ```json
                {
                    "title": "My game title",
                    "subtitle": "Made by me",
                    "actions": {
                        "exit": "Exit game",
                        "share": "Share"
                    }
                }
                ```
            </td>
            <td>
                ```json
                {
                    "title": "Título de mi juego",
                    "subtitle": "Hecho por mí",
                    "actions": {
                        "exit": "Salir del juego",
                        "share": "Compartir"
                    }
                }
                ```
            </td>
        </tr>
    </tbody>
</table>

As you can see the i18n utility will be able to find translations across languages by using the same path. Example: `actions.exit` will resolve in _Exit game_, but in Spanish it will be _Salir del juego_.

## Declare languages and translations

As you have seen, this utility can handle multiple languages and translation files per language. Two enums are used to declare available languages and translation files. You can modify both of them to add or remove values:

- Languages: **package-folder**/Modifiable/Core/Languages.cs
- Translations: **package-folder**/Modifiable/I18n/TranslationSets.cs

Those files can be modified at any time. If you remove or rename values remember that you might have references in the project.

## Initialize translations

During the game startup you should initialize the i18n utility (this has to be done before using translations in any way. Usually, you create a startup scene that loads utilities like this one).

Initializing i18n can be easily achieved by using the **I18nInitializer**. This script needs to be attached to an active GameObject present in the scene. If **Initialization mode** is set to _Awake_ or _Start_ the initialization process will be started automatically on scene startup.

This script will require you to provide all translation files for each language. This is used internally to keep an organized reference to each translation file.

:::warning Keep in mind

This initialization script has to be called only once. There is no need to recall it as translation references are kept in memory as long as the game runs, no matter how many times scene is changed.

:::
