---
sidebar_position: 4
---

# Watching achievements

You can detect achievement changes by watching them. We provide some scripts that make this task easier.

## Using the AchievementWatcher

This script allows you to watch a specific achievement. You only need to attach the `AchievementWatcher` script to a GameObject. Then, use the Unity's Inspector to select the achievement you want to watch. And now you are watching achievement changes!

You will see a list of events in the Inspector. They will be called when the achievement receives changes. See the list below.

- **OnUnlock:** called when the achievement is unlocked.
