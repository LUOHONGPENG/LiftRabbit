using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameMgr : MonoBehaviour
{
    public MapMgr mapMgr;
    public UIMgr uiMgr;

    private void Start()
    {
        Init();
    }

    private void Init()
    {

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
