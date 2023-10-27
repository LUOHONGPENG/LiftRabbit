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

    #region Lift
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
    #endregion

    #region Level

    public void AddLevel()
    {

    }

    #endregion

    #region Human

    public void AddHuman(HumanData humanData)
    {
        humanViewMgr.AddHumanView(humanData);
    }

    public void HumanLeave()
    {

    }

    public void HumanKill()
    {

    }
    #endregion

}
