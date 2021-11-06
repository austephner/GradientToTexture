using System;
using UnityEngine;

public static class GradientToTexture
{
    public static Sprite CreateSprite(
        Gradient gradient, 
        float pixelsPerUnit, 
        Rect rect, 
        GradientDirectionType directionType = GradientDirectionType.HorizontalLeftToRight)
    {
        // (1) Create a new texture from the given rect's height and width relative to the given pixels per unit.
        
        var texture = new Texture2D(
            (rect.width.Abs() * pixelsPerUnit).RoundToInt(), 
            (rect.height.Abs() * pixelsPerUnit).RoundToInt());

        // (2) Set pixels left-to-right on the texture in relation to their x position in the gradient. 

        SetPixelsToGradient(texture, gradient, directionType);
        
        // (3) Create a new sprite from the texture.

        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }

    public static void SetPixelsToGradient(Texture2D texture, Gradient gradient, GradientDirectionType directionType)
    {
        if (directionType == GradientDirectionType.HorizontalLeftToRight ||
            directionType == GradientDirectionType.HorizontalRightToLeft ||
            directionType == GradientDirectionType.VerticalTopToBottom ||
            directionType == GradientDirectionType.VerticalBottomToTop)
        {
            var rightToLeft = directionType == GradientDirectionType.HorizontalRightToLeft;
            var bottomToTop = directionType == GradientDirectionType.VerticalBottomToTop;
            var horizontalFocus = rightToLeft || directionType == GradientDirectionType.HorizontalLeftToRight;

            for (int x = 0; x < texture.width; x++)
            {
                for (int y = 0; y < texture.height; y++)
                {
                    var actualX = rightToLeft ? texture.width - x : x;
                    var actualY = bottomToTop ? texture.height - y : y;
                    var gradientValue = horizontalFocus
                        ? gradient.Evaluate((float)actualX / texture.width)
                        : gradient.Evaluate((float)actualY / texture.height);
                    
                    texture.SetPixel(actualX, actualY, gradientValue);
                }
            }
        }
        else
        {
            throw new NotImplementedException($"Direction type not yet implemented: {directionType}");
        }

        texture.Apply();
    }
}