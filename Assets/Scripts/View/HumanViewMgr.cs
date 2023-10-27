using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanViewMgr : MonoBehaviour
{
    public Transform tfHuman;
    public GameObject pfHuman;

    private HumanData humanData;

    public void Init()
    {
        PublicTool.ClearChildItem(tfHuman);
    }

    public void AddHumanView(HumanData humanData)
    {
        GameObject objHuman = GameObject.Instantiate(pfHuman, tfHuman);
        HumanViewItem itemHuman = objHuman.GetComponent<HumanViewItem>();
        itemHuman.Init(humanData);
    }

    public void RemoveHumanView(int keyID)
    {

    }
}
