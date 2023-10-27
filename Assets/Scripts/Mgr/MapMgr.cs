using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMgr : MonoBehaviour
{
    public LiftViewMgr liftViewMgr;

    public void MoveToLevel(int Level)
    {
        liftViewMgr.MoveToLevel(Level);
    }

    public void MoveToHeaven()
    {
        liftViewMgr.MoveToHeaven();
    }
}
