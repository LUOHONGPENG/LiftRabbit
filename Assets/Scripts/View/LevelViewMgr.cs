using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelViewMgr : MonoBehaviour
{
    public Transform tfLevel;
    public GameObject pfLevel;
    public Text codeQueueLimit;

    private GameData gameData;
    private bool isInit = false;
    private Dictionary<int, LevelViewItem> dicLevelView = new Dictionary<int, LevelViewItem>();


    public void Init()
    {
        gameData = PublicTool.GetGameData();
        PublicTool.ClearChildItem(tfLevel);
        dicLevelView.Clear();

        for (int i = 1; i <= gameData.numLevel; i++)
        {
            GameObject objLevel = GameObject.Instantiate(pfLevel, tfLevel);
            objLevel.transform.position = new Vector2(4.65f, PublicTool.ConvertLevelToPosY(i) + GameGlobal.posYLevel);
            LevelViewItem itemLevel = objLevel.GetComponent<LevelViewItem>();
            itemLevel.Init(i);
            dicLevelView.Add(i, itemLevel);
        }
        isInit = true;

    }

    public void RefreshLevel()
    {
        for (int i = 1; i <= gameData.numLevel; i++)
        {
            if (!dicLevelView.ContainsKey(i))
            {
                GameObject objLevel = GameObject.Instantiate(pfLevel, tfLevel);
                objLevel.transform.position = new Vector2(4.65f, PublicTool.ConvertLevelToPosY(i) + GameGlobal.posYLevel);
                LevelViewItem itemLevel = objLevel.GetComponent<LevelViewItem>();
                itemLevel.Init(i);
                dicLevelView.Add(i, itemLevel);
            }
        }
    }

    private void Update()
    {
        if (isInit)
        {
            codeQueueLimit.text = string.Format("队伍长度上限 {0}", gameData.curQueueLimit);
        }
    }
}
