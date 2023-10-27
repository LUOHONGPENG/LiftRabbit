using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LiftViewMgr : MonoBehaviour
{
    public Transform tfLift;

    public void MoveToLevel(int Level)
    {
        tfLift.DOMoveY(-2f + Level,1f);
    }
    
    public void MoveToHeaven()
    {
        tfLift.DOMoveY(50f, 1f);

    }
}
