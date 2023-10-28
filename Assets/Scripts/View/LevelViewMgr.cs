using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelViewMgr : MonoBehaviour
{
    public Transform tfLevel;
    public GameObject pfLevel;

    private GameData gameData;
    private bool isInit = false;
    public void Init()
    {
        gameData = PublicTool.GetGameData();
        PublicTool.ClearChildItem(tfLevel);

        for(int i = 1; i <= gameData.numLevel; i++)
        {
            GameObject objLevel = GameObject.Instantiate(pfLevel, tfLevel);
            objLevel.transform.position = new Vector2(4.65f, PublicTool.ConvertLevelToPosY(i) + GameGlobal.posYLevel);
            LevelViewItem itemLevel = objLevel.GetComponent<LevelViewItem>();
            itemLevel.Init(i);
        }
        isInit = true;

    }

    public void RefreshLevel()
    {

    }


}
