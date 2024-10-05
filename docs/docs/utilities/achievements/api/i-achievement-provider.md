# IAchievementProvider

The `IAchievementProvider` is the interface that acts as the blueprint for any achievement provider. All achievement providers have to implement this interface. Once they do so, they will be available to be used as achievement providers.

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
            <td>GetAchievements</td>
            <td></td>
            <td>`Dictionary<Achievements, Achievement>`</td>
            <td>Returns all achievements that are being provided by the provider.</td>
        </tr>
        <tr>
            <td>IsReady</td>
            <td></td>
            <td>`bool`</td>
            <td>Returns wether the provider is ready or not.</td>
        </tr>
    </tbody>
</table>
