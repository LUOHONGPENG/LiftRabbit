using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameGlobal
{
    public static float posYLift = -8.4f;

    public static float posYLevel = -3.5f;

    public static float posYHuman = -3f;

    public static float skillNodeSpacingX = 120f;
    public static float skillNodeSpacingY = 240f;

    public static List<int> listLevelUp = new List<int> {0, 120, 750, 1550, 3000 };

    public static List<Vector2> listLiftPos = new List<Vector2> 
    { new Vector2(-1.1f, 0), new Vector2(-0.5f, 0.4f), new Vector2(0f, 0.5f)
        ,new Vector2(-0.2f, -0.3f),new Vector2(0.5f, -0.2f),new Vector2(1f, 0.2f)};
}
