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

    public void RefreshHumanPosInLift(int keyID,Transform tf,int posID)
    {
        HumanViewItem humanView = dicHumanView[keyID];
        humanView.RefreshPosLift(tf, posID);
    }

    public IEnumerator IE_RefreshHumanPosArrive(int keyID)
    {
        HumanViewItem humanView = dicHumanView[keyID];
        humanView.RefreshPosArrive();
        yield return new WaitForSeconds(1.5F);
        RemoveHumanView(keyID);
    }

    public IEnumerator IE_RefreshHumanPosEscape(int keyID)
    {
        HumanViewItem humanView = dicHumanView[keyID];
        EventCenter.Instance.EventTrigger("EffectPenaltyText", new EffectPenaltyTextInfo("ÈËÆø-1", humanView.transform.position));

        humanView.RefreshPosEscape();
        yield return new WaitForSeconds(1.5F);
        RemoveHumanView(keyID);
    }

    public void RemoveHumanView(int keyID)
    {
        HumanViewItem humanView = dicHumanView[keyID];
        dicHumanView.Remove(keyID);
        Destroy(humanView.gameObject);
    }

    public void RefreshWaitTime(int keyID)
    {
        if (dicHumanView.ContainsKey(keyID))
        {
            HumanViewItem humanView = dicHumanView[keyID];
            humanView.RefreshWaitUI();
        }

    }
}
