using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameMgr : MonoSingleton<GameMgr>
{
    public MapMgr mapMgr;
    public UIMgr uiMgr;

    [HideInInspector]
    public GameData gameData;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        gameData = new GameData();
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
