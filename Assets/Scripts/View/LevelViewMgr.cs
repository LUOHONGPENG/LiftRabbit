using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelViewMgr : MonoBehaviour
{
    public Transform tfLevel;
    public GameObject pfLevel;

    private GameData gameData;

    public void Init()
    {
        gameData = PublicTool.GetGameData();
        PublicTool.ClearChildItem(tfLevel);

        for(int i = 1; i <= gameData.numLevel; i++)
        {
            GameObject objLevel = GameObject.Instantiate(pfLevel, tfLevel);
            objLevel.transform.position = new Vector2(1f, PublicTool.ConvertLevelToPosY(i)-0.2f);
        }
    }

    public void RefreshLevel()
    {

    }
}
