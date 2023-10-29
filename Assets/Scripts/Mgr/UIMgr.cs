using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    public LiftButtonUIMgr liftButtonUIMgr;
    public ResourceUIMgr resourceUIMgr;
    public EffectUIMgr effectUIMgr;
    public SkillNodeUIMgr skillNodeUIMgr;
    public LevelUpUIMgr levelUpMgr;
    public TutorialUIMgr tutorialUIMgr;
    public EndUIMgr endUIMgr;


    public void Init()
    {
        liftButtonUIMgr.Init();
        resourceUIMgr.Init();
        effectUIMgr.Init();
        skillNodeUIMgr.Init();
        levelUpMgr.Init();
        tutorialUIMgr.Init();
        endUIMgr.Init();
    }

    public void AddLevelRefresh()
    {
        liftButtonUIMgr.RefreshLiftButton();
    }
}
