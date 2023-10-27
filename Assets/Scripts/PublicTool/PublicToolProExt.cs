using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PublicTool
{

    public static GameData GetGameData()
    {
        return GameMgr.Instance.gameData;
    }

}
