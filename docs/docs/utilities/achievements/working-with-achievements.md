---
sidebar_position: 3
---

# Working with achievements

Once we have done the achievements setup we can start detecting when achievements are unlocked.

## Using the AchievementsSceneController

This script manages basic achievement events, allowing us to simply provide GameObjects that will display the unlocked achievement data with 0 coding. It can be connected to an `Animator` instance to automatically trigger animations.

:::info Information

You can have more than one `AchievementsSceneController` per scene, but there are very few scenarios where you want that.
Before having multiple scene controller instances check out the [AchievementsSceneObject](#using-achievements-scene-object) utility, it might provide a better solution.

:::

### UI fields

You have some UI fields available for you to setup:

- **Title:** a `TextObject` instance that will display the achievement's title.
- **Subtitle:** a `TextObject` instance that will display the achievement's subtitle _(optional)_.
- **Image:** a Unity's UI `Image` that will display the achievement's image _(optional)_.

Once you setup those fields, whenever an achievement is unlocked each assigned instance will show the achievement's value.

### Animator instance

You are able to provide a Unity's `Animator` instance to the scene controller. This instance will be fully managed by the script, launching animator triggers when achievement events happen. See the triggers name list below.

<table>
    <tbody>
        <tr>
            <th>
                Trigger name
            </th>
            <th>
                When it gets called
            </th>
        </tr>
        <tr>
            <td>
                unlock
            </td>
            <td>
                When any achievement is unlocked.
            </td>
        </tr>
    </tbody>
</table>

### Events

The script also provides you with some `UnityEvent`'s:

- **OnAchievementUnlocked:** called whenever any achievement is unlocked. It provides the unlocked achievement code when called.

## Using the AchievementSceneObject {#using-achievements-scene-object}

This script allows you to perform actions to a specific event easily (like unlocking it). It also has events that get called when some actions are performed.
When attached to a GameObject you are able to select the achievement you want to work with. This is done by selecting the achievement on the **Achievement** field.

### Unlocking achievements

This script has a public method named `UnlockAchievement`. When called, it will unlock the achievement.

### Events

You have some events in the Unity's Inspector. See the list below.

- **OnUnlocked:** called when the achievement is unlocked for the first time.
- **OnUnlockCall:** called when the achievement unlock is called. It gets called even if the achievement was previously unlocked.
- **BeforeUnlockCall**: called when the achievement unlock is called, but before triggering the unlockment process. It gets called even if the achievement was previously unlocked.

Those events are only called when actions happen via this script. This means that if, for example, an achievement is unlocked from another script, this events will not be called.
