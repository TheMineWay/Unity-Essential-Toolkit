# DialogImagesDisplay

The `DialogImagesDisplay` is the class responsible for displaying images when necessary.

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
            <td>DisplayImage</td>
            <td>`string`: image id</td>
            <td></td>
            <td>Displays an image by its id.</td>
        </tr>
        <tr>
            <td>Clear</td>
            <td></td>
            <td></td>
            <td>Stops displaying the image that it is currently displaying.</td>
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
            <td>GetImagesDisplay</td>
            <td>`string`: displayer id</td>
            <td>`DialogImagesDisplay`</td>
            <td>Gets a dialog image displayer by its id.</td>
        </tr>
        <tr>
            <td>DisplayImage</td>
            <td>
                - `string`: image id
                - `string`: target (displayer id)
            </td>
            <td></td>
            <td>Displays an image by image id on a displayer by its id.</td>
        </tr>
        <tr>
            <td>DisplayImages</td>
            <td>
                - `ARegisterDialogEntry.Image[]`: images
                - `bool`: cleanup (default = true)
            </td>
            <td></td>
            <td>Displays a set of images. If cleanup is enabled, unused displayers will reset its display image (this is the default behaviour).</td>
        </tr>
        <tr>
            <td>GetAllDisplayers</td>
            <td></td>
            <td>`DialogImagesDisplay[]`</td>
            <td>Gets all image displayers.</td>
        </tr>
    </tbody>
</table>
