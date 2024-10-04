---
sidebar_position: 1
---

# Introduction

You might want to add achievements to your game. If that is the case, this is the utility you want to use. The Achievements module allows you to display and register achievements easily. You will only care about triggering the achievement and the rest lays on the package.

## How it works

You have to provide all available achievements on game startup (or at least before using the Achievements utility). Once they are initialized you will be able to use the Achievements API to unlock achievements for the user.

:::info Important to know

Achievements are stored using the [Storage](/docs/category/storage) utility. This means that at some point you will need to follow Storage initialization steps.

:::
