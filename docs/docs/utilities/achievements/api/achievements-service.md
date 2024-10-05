# AchievementsService

The `AchievementsService` is the class responsible for managing achievements.

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
            <td>UnlockAchievement</td>
            <td>`Achievements`</td>
            <td></td>
            <td>Unlocks an achievement.</td>
        </tr>
        <tr>
            <td>LockAchievement</td>
            <td>`Achievements`</td>
            <td></td>
            <td>Locks an achievement.</td>
        </tr>
        <tr>
            <td>ClearAchievements</td>
            <td></td>
            <td></td>
            <td>Clears all achievements data (it locks all achievements).</td>
        </tr>
        <tr>
            <td>HasAchievement</td>
            <td>`Achievements`</td>
            <td>`bool`</td>
            <td>Returns wether an achievement is unlocked or not.</td>
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
            <td>OnAchievementUnlocked</td>
            <td>`Achievements`</td>
            <td>Called when an achievement is unlocked. It provides the unlocked Achievement code.</td>
        </tr>
    </tbody>
</table>
