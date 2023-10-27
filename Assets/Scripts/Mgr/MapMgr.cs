using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMgr : MonoBehaviour
{
    public LiftViewMgr liftViewMgr;
    public LevelViewMgr levelViewMgr;

    public void Init()
    {
        liftViewMgr.Init();
        levelViewMgr.Init();
    }

    public void MoveToLevel(int Level)
    {
        liftViewMgr.MoveToLevel(Level);
    }

    public void MoveToHeaven()
    {
        liftViewMgr.MoveToHeaven();
    }

    public void BackToLevel(int Level)
    {
        liftViewMgr.BackToLevel(Level);
    }
}
