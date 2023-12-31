using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

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

    public IEnumerator IE_RefreshHumanPosEscape(int keyID,bool penalty)
    {
        HumanViewItem humanView = dicHumanView[keyID];

        if (penalty)
        {
            PublicTool.GetGameData().Popularity--;
            EventCenter.Instance.EventTrigger("EffectPenaltyText", new EffectPenaltyTextInfo("����-1", humanView.transform.position));

            int ran = Random.Range(0, 2);
            if (ran == 0)
            {
                PublicTool.PlaySound(SoundType.Slow1);
            }
            else
            {
                PublicTool.PlaySound(SoundType.Slow2);
            }
        }


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
