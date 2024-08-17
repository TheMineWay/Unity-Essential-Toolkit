---
sidebar_position: 1
---

# Introduction

You might want to add dialogs to your game, so we provide you with a generic solution that can make the development of your game faster and easier. As always, you can create your own dialogs system using (or not) utilities provided by this package.

This dialogs utility is highly customizable by using events and its API.

## How it works

You will define dialogs (optionally along with the speaker, images to be shown and events to be run) and they will be automatically managed by this utility. This package has official scripts that integrate the Dialogs system with the I18n utility, so you can display dialogs loaded from i18n translation files.

Dialogs can be specified officially by two ways:

- Unity's Inspector: directly in any dialog provider there is an interface where you can write dialogs.
- JSON files: on all dialog providers there is a slot where you can provide a _Text Asset_ (a JSON file). This file must be a well structured JSON file.

## Can I have more than one dialog per scene?

Yes you can! You can have as much `DialogControllers` as you need in each scene. You just need to ensure each one is well-initialized. You can do so by following this documentation 😺.
