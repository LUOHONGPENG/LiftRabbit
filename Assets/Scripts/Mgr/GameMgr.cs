using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameMgr : MonoSingleton<GameMgr>
{
    public MapMgr mapMgr;
    public UIMgr uiMgr;
    public SoundMgr soundMgr;

    private LiftViewMgr liftViewMgr;
    private LevelViewMgr levelViewMgr;
    private HumanViewMgr humanViewMgr;
    private bool isInit = false;

    [HideInInspector]
    public GameData gameData;

    public override void Init()
    {
        gameData = new GameData();
        InitExcelData();
        mapMgr.Init();
        liftViewMgr = mapMgr.liftViewMgr;
        levelViewMgr = mapMgr.levelViewMgr;
        humanViewMgr = mapMgr.humanViewMgr;
        uiMgr.Init();
        soundMgr.Init();
        Debug.Log("InitGameData");

        isInit = true;
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
