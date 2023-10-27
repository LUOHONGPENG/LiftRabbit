using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanViewMgr : MonoBehaviour
{
    public Transform tfHuman;
    public GameObject pfHuman;

    private HumanData humanData;
    private Dictionary<int, HumanViewItem> dicHumanView = new Dictionary<int, HumanViewItem>();

    public void Init()
    {
        PublicTool.ClearChildItem(tfHuman);
        dicHumanView.Clear();
    }

    public void AddHumanView(HumanData humanData)
    {
        GameObject objHuman = GameObject.Instantiate(pfHuman, tfHuman);
        HumanViewItem itemHuman = objHuman.GetComponent<HumanViewItem>();
        itemHuman.Init(humanData);
        dicHumanView.Add(humanData.keyID, itemHuman);
    }

    public void RefreshHumanPosInQueue(int keyID, int columnID)
    {
        HumanViewItem humanView = dicHumanView[keyID];
        humanView.RefreshPosInQueue(columnID);
    }

    public void RefreshHumanPosInLift(int keyID,Transform tf)
    {
        HumanViewItem humanView = dicHumanView[keyID];
        humanView.RefreshPosLift(tf);
    }

    public void RemoveHumanView(int keyID)
    {

    }
}
