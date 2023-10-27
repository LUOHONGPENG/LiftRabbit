using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameMgr : MonoSingleton<GameMgr>
{
    public MapMgr mapMgr;
    public UIMgr uiMgr;

    [HideInInspector]
    public GameData gameData;

    public override void Init()
    {
        gameData = new GameData();
        mapMgr.Init();
        uiMgr.Init();
        Debug.Log("InitGameData");
    }

    private void OnEnable()
    {
        EventCenter.Instance.AddEventListener("SelectLevel", SelectLevelEvent);
    }

    private void OnDisable()
    {
        EventCenter.Instance.RemoveEventListener("SelectLevel", SelectLevelEvent);
    }
}
