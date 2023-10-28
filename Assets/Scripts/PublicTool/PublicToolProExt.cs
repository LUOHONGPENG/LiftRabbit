using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PublicTool
{

    public static GameData GetGameData()
    {
        return GameMgr.Instance.gameData;
    }


    public static float ConvertLevelToPosY(int Level)//Lift -7
    {
        return Level;
    }

    public static float ConvertColumnToPosX(int ColumnID)//Lift -7
    {
        return ColumnID + 1.2f;
    }

    public static HumanDataExcelItem GetHumanItem(int ID)
    {
        return GameMgr.Instance.humanExcelData.GetExcelItem(ID);
    }
}
