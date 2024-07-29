---
sidebar_position: 1
---

# Channeled audio service

This service is in charge of coordinating all audio components linked to channeled audio scripts.

<table>
    <tr>
        <td>**Method**</td>
        <td>**Parameters**</td>
        <td>**Returns**</td>
        <td>**Description**</td>
    </tr>
    <tr>
        <td>SetAudioChannelVolume</td>
        <td>
            - `AudioChannels`: audio channel to modify.
            - `float`: volume value.
        </td>
        <td></td>
        <td>Modifies the volume of a specific audio channel.</td>
    </tr>
    <tr>
        <td>GetVolumeByAudioChannel</td>
        <td>
            - `AudioChannels`: audio channel to retrieve.
        </td>
        <td>`float`: channel volume</td>
        <td>Gets the volume of an specific audio channel.</td>
    </tr>
    <tr>
        <td>GetAllAudioChannels</td>
        <td></td>
        <td>`AudioChannels[]`: array of audio channels</td>
        <td>Gets all audio channels.</td>
    </tr>
</table>
