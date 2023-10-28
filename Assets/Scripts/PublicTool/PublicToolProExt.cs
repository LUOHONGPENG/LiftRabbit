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

    public static HumanExcelItem GetHumanItem(int ID)
    {
        return GameMgr.Instance.humanExcelData.GetExcelItem(ID);
    }

    public static ComboExcelItem GetComboItem(int ID)
    {
        return GameMgr.Instance.comboExcelData.GetExcelItem(ID);
    }

    public static void PlaySound(SoundType sound)
    {
        EventCenter.Instance.EventTrigger("PlaySound", sound);
    }

    public static List<int> CheckCombo(List<Vector2Int> listEat)
    {
        return GameMgr.Instance.comboExcelData.CheckWhetherBonus(listEat);
    }

    public static float CalculateLiftMoveTime(int curLevel,int tarLevel)
    {
        float timeMove = 1f;
        if (curLevel < 0)
        {
            timeMove = timeMove / GetGameData().curSpeedLift;
        }
        else
        {
            timeMove = Mathf.Abs(curLevel - tarLevel) * 0.5f;
            timeMove = timeMove / GetGameData().curSpeedLift;
        }
        return timeMove;
    }
}
