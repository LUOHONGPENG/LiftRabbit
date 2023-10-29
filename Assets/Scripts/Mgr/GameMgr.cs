using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private bool isStart = false;

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

        StartCoroutine(IE_Start());
        isInit = true;
        
    }

    public IEnumerator IE_Start()
    {
        yield return new WaitForSeconds(1f);
        isStart = true;
        EventCenter.Instance.EventTrigger("TutorialStart", TutorialGroup.Star0);

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
