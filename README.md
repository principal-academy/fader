# Fader
Fade animation library for Unity game engine

## Installation

1. Open your Unity project.
2. Select Assets -> Import Package -> Custom Package.
3. Choose `fader.unitypackage` from the root folder of this repo and click import.

## Usage

Use the `Fader` class to fade your screen in and out. Use the first parameter to specify your direction and the second parameter as a callback. Here is an example:

```csharp
Fader.Fade (FadeDirection.In, () => {
    // Put your callback code here.
    // It is triggered at the end of the fade animation.
});
```

## How it works

Fader works by creating a game object in your scene that draws a texture with variable alpha. The game object is created at the beginning of your animation and it is destroyed after the animation is finished.

## Development

Fader is free, open source and fully tested 🖖. If you would like to make changes, send us a pull request 🙌

## License

Fader is distributed under the [MIT License](LICENSE)
