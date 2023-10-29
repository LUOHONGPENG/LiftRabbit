using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameGlobal
{
    public static float posYLift = -8.4f;

    public static float posYLevel = -3.5f;

    public static float posYHuman = -3f;

    public static float skillNodeSpacingX = 180f;
    public static float skillNodeSpacingY = 200f;


    public static List<Vector2> listLiftPos = new List<Vector2> 
    { new Vector2(-1.1f, 0), new Vector2(-0.85f, 0.4f), new Vector2(-0.5f, 0.7f), new Vector2(0f, 0.8f),new Vector2(0.5f, 0.6f),new Vector2(0.85f, 0.3f),new Vector2(1.1f, -0.05f),
    new Vector2(0.6f, -0.2f)};
}
