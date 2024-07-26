---
sidebar_position: 4
---

# Text replacements

Sometimes you want to inject text variables in a translation. You can do so with text replacements.

## Declaring replacements in translations

In your translation file you can declare a translation that uses a text replacement variable by adding `{variableName}` within the translation value. See the example:

```json
{
  "dialog-1": "Hi {userName}!",
  "dialog-2": "Hi {userName}, today is {weekday}"
}
```

- dialog-1: Will be converted to "Hi Alan!" if userName is set to "Alan".
- dialog-2: Will be converted to "Hi Alan, today is Monday" if userName is set to "Alan" and weekday is set to "Monday".

## Setting variable values

Variable values are set where the translation is going to be used.

On a **I18nTextObject** instance you can specify through the Unity's Inspector values for text replacement variables. These replacements will be applied only on that instance.
