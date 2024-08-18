# DialogImagesProvider

The `DialogImagesProvider` is the class responsible for providing images that will be able to be displayed when necessary.

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
            <td>Unload</td>
            <td></td>
            <td></td>
            <td>Unloads images provided by this provider. Makes those images unavailable (even when global is checked).</td>
        </tr>
    </tbody>
</table>

## Static methods API

<table>
    <tbody>
        <tr>
            <td>**Method**</td>
            <td>**Parameters**</td>
            <td>**Returns**</td>
            <td>**Description**</td>
        </tr>
        <tr>
            <td>GetImage</td>
            <td>`string`: image id</td>
            <td>`Sprite`: image sprite</td>
            <td>Gets the sprite of an image by its id.</td>
        </tr>
        <tr>
            <td>AddImage</td>
            <td>
                - `string`: image id
                - `Sprite`: image sprite
            </td>
            <td></td>
            <td>Adds an image to the loaded images store.</td>
        </tr>
        <tr>
            <td>RemoveImage</td>
            <td>`string`: image id</td>
            <td></td>
            <td>Removes an image from the loaded images store.</td>
        </tr>
        <tr>
            <td>UnloadAllImages</td>
            <td></td>
            <td></td>
            <td>Unloads all images. Makes all images unavailable (even global ones).</td>
        </tr>
    </tbody>
</table>
