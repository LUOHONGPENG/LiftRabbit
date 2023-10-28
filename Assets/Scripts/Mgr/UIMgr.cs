using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    public LiftButtonUIMgr liftButtonUIMgr;
    public ResourceUIMgr resourceUIMgr;
    public EffectUIMgr effectUIMgr;

    public void Init()
    {
        liftButtonUIMgr.Init();
        resourceUIMgr.Init();
    }
}
