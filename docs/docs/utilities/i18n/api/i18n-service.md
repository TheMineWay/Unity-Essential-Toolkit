---
sidebar_position: 1
---

# I18nService API

The `I18nService` class is responsible for managing internationalization (i18n) in the application. It handles language settings, loading translations, and replacing translation placeholders.

<table>
    <tbody>
        <tr>
            <td>**Method**</td>
            <td>**Parameters**</td>
            <td>**Returns**</td>
            <td>**Description**</td>
        </tr>
        <tr>
            <td>SetLanguage</td>
            <td>`Language`</td>
            <td></td>
            <td>Changes the current display language.</td>
        </tr>
        <tr>
            <td>GetLanguage</td>
            <td></td>
            <td>`Language`</td>
            <td>Gets the current display language.</td>
        </tr>
        <tr>
            <td>GetLanguageAsset</td>
            <td>`Language`</td>
            <td>`LanguageAsset`</td>
            <td>Given a language identifier it returns the corresponding language asset from loaded translation files.</td>
        </tr>
        <tr>
            <td>GetI18nTextSubscriptionsHandler</td>
            <td></td>
            <td>`I18nTextSubscriptionsHandler`</td>
            <td>Gets the current `I18nTextSubscriptionsHandler` instance.</td>
        </tr>
        <tr>
            <td>AssetsHaveBeenLoaded</td>
            <td></td>
            <td>`bool`</td>
            <td>Returns wether i18n translation files have been loaded or not.</td>
        </tr>
        <tr>
            <td>SceneAssetsHaveBeenLoaded</td>
            <td></td>
            <td>`bool`</td>
            <td>Returns wether i18n scene translations have been loaded.</td>
        </tr>
        <tr>
            <td>SceneManagerHasBeenLoaded</td>
            <td></td>
            <td>`bool`</td>
            <td>Returns wether the i18n scene manager has been loaded in the scene.</td>
        </tr>
        <tr>
            <td>LoadTranslations</td>
            <td>`TranslationSets[]`</td>
            <td></td>
            <td>Given an array of `TranslationSets` it replaces in-memory translations with the provided array.</td>
        </tr>
        <tr>
            <td>Translate</td>
            <td>
                - `string`: path.
                - `TranslationSets`: translation `Dictionary<string string>` (replacements)
            </td>
            <td>`string`</td>
            <td>
                Given a translation path and a translation set it searches in the translation set for the translation corresponding to the path.
                If a translation is found, it tries to replace defined variables with those passed as a Dictionary (dictionary key is variable, and value is the variable value).
                It returns a string representing the translated and replaced value.
            </td>
        </tr>
        <tr>
            <td>ReplaceTranslationPlaceholders</td>
            <td>
                - `string`: translation entry.
                - `Dictionary<string, string>`: replacements
            </td>
            <td>`string`</td>
            <td>Given a translated string that can contain replacement variables, it returns it with variables replaced with the values from the dictionary.</td>
        </tr>
        <tr>
            <td>GetGlobalReplacements</td>
            <td></td>
            <td>
                `Dictionary<string, string>`
            </td>
            <td>It returns the global replacements dictionary.</td>
        </tr>
        <tr>
            <td>SetGlobalReplacement</td>
            <td>
                - `string`: replacement key.
                - `string`: replacement value.
            </td>
            <td></td>
            <td>Given a replacement key and a value, it adds it to the global replacements.</td>
        </tr>
        <tr>
            <td>RemoveGlobalReplacement</td>
            <td>
                - `string`: replacement key.
            </td>
            <td></td>
            <td>Given a replacement key, it removes it.</td>
        </tr>
        <tr>
            <td>ClearGlobalReplacements</td>
            <td></td>
            <td></td>
            <td>Removes all global replacements.</td>
        </tr>
        <tr>
            <td>AppendGlobalReplacements</td>
            <td></td>
            <td></td>
            <td>Appends a dictionary to the current global replacements.</td>
        </tr>
    </tbody>
</table>
