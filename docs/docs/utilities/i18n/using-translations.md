---
sidebar_position: 3
---

# Using translations

Now you can start using translations in your scene.

## Identifying necessary translation files

Having all translation files initialized does not mean that they are all loaded in memory (that would be very inefficient).
So, if you want to use some translations in a scene you have to select which ones you are going to use (what translation files will be available).

<table>
    <tbody>
        <tr>
            <td>Example</td>
        </tr>
        <tr>
            <td>
            If you have three translation files (common.json, scene-1.json and scene-2.json) and you are on the scene 1 you might want to load _common.json_ and _scene-1.json_.
            <br/>_scene-2.json_ will not be loaded because you are not using any of its translations (if you wanted so, you had to load it as well).
            </td>
        </tr>
    </tbody>
</table>

## Load scene translations

Now that you know what translation files need to be loaded in this scene we assign the **i18nSceneManager** script to an active GameObject in the scene.
This script will load in memory all necessary translation files for us, we only need to indicate the translation file codes using the Unity's Inspector.

If **Initialization mode** is set to _Awake_ or _Start_ the initialization process will be started automatically on scene startup.

Every time you load a scene you need to use this initializer to load the new translation files and unload obsolete ones.

## Displaying translations

Now you can use translations in this scene.

To do so, you can use the **I18nTextObject**. It is a script that gets attached to a TMProText GameObject and allows you to specify a translation path and the translation file.
If the translation path is correct the text gets updated to its corresponding translation value.

If you update the language while the game is running you don't need to reload the scene, all texts are automatically updated to its new value.
