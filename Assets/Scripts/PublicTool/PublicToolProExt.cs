using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PublicTool
{

    public static GameData GetGameData()
    {
        return GameMgr.Instance.gameData;
    }


    public static float ConvertLevelToPosY(int Level)
    {
        return -2f + Level;
    }

    public static HumanDataExcelItem GetHumanItem(int ID)
    {
        return GameMgr.Instance.humanExcelData.GetExcelItem(ID);
    }
}
