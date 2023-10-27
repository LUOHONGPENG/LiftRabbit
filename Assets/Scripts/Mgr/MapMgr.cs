using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMgr : MonoBehaviour
{
    public LiftViewMgr liftViewMgr;
    public LevelViewMgr levelViewMgr;
    public HumanViewMgr humanViewMgr;

    public void Init()
    {
        liftViewMgr.Init();
        levelViewMgr.Init();
        humanViewMgr.Init();
    }



    public void AddLevel()
    {

    }


}
