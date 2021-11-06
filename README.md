# Gradient To Texture
#### Summary
Example project of how to write Unity gradient data to a Unity UI image texture during runtime.

#### Details
I was working on a game like the Sims. In this game, the characters have status bars with gradient backgrounds to depict the "good" and "bad" levels. I was too lazy to create a bunch of custom gradient images in Photoshop and so I decided to do it programmatically. The game has status configurations where each status has its own gradient to represent itself with in the UI. Using nothing but the gradient and a UI image, I was able to apply the gradient directly to the image.

This code shows how to manipulate the pixels of a `Texture2D` by evaluating the `x` and `y` coordinate for any given pixel relative to a position on a Unity `Gradient` object. 

![Example](https://i.imgur.com/aWAZCEL.png)

#### Supported Directions
- Horizontal
    - Left to Right
    - Right to Left
- Vertical
    - Top to Bottom
    - Bottom to Top

#### Todo
- Diagonal presets
- Custom angle 
- Random 
- Noise based

# Usage
#### Automatic
You can add the `GradientDisplayBehaviour` to a `GameObject` that has an `Image` component on it. 
![GDB](https://i.imgur.com/wQcC4X4.png)

#### Manual
Call `GradientToTexture.CreateSprite(...)` to convert a gradient into a `Sprite`. 
```c#
// (1) Gather needed components
Gradient gradient;
Image image;
GradientDirectionType direction = GradientDirectionType.HorizontalLeftToRight;

// (2) Create a sprite
Sprite sprite = GradientToTexture.CreateSprite(gradient, image.pixelsPerUnit, image.rectTransform.rect, direction);

// (3) Apply the sprite to the image
image.sprite = sprite;
```

See these files:
- GradientToTexture.cs
- GradientDisplayBehaviour.cs

# Pitfalls
- Updating the size of the texture may require you to recalculate the gradient image. 
- This code cannot be called in `Start()`, it must be called in the frame afterwards. Something about not being able to do certain `Gradient` calls/operations at this stage of the playback.