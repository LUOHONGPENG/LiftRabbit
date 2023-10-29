using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectUIMgr : MonoBehaviour
{
    public Transform tfEffect;
    public Transform tfPenalty;

    public GameObject pfMoneyTip;

    public List<Transform> listTfMoney;

    public void Init()
    {

    }

    private void OnEnable()
    {
        EventCenter.Instance.AddEventListener("EffectMoneyText", EffectMoneyEvent);
        EventCenter.Instance.AddEventListener("EffectPenaltyText", EffectPenaltyEvent);

    }


    private void OnDisable()
    {
        EventCenter.Instance.RemoveEventListener("EffectMoneyText", EffectMoneyEvent);
        EventCenter.Instance.RemoveEventListener("EffectPenaltyText", EffectPenaltyEvent);

    }

    private void EffectMoneyEvent(object arg0)
    {
        EffectMoneyTextInfo info = (EffectMoneyTextInfo)arg0;
        GameObject objMoneyTip = GameObject.Instantiate(pfMoneyTip, tfEffect);
        EffectUIItem itemMoneyTip = objMoneyTip.GetComponent<EffectUIItem>();

        int childCount = tfEffect.childCount;
        objMoneyTip.transform.position = listTfMoney[childCount-1].position;
        itemMoneyTip.Init(info.content);
    }

    private void EffectPenaltyEvent(object arg0)
    {
        EffectPenaltyTextInfo info = (EffectPenaltyTextInfo)arg0;
        GameObject objMoneyTip = GameObject.Instantiate(pfMoneyTip, tfPenalty);
        EffectUIItem itemMoneyTip = objMoneyTip.GetComponent<EffectUIItem>();
        objMoneyTip.transform.position = info.pos;
        itemMoneyTip.Init(info.content);
    }

}
public struct EffectMoneyTextInfo
{
    public string content;
    public Vector2 pos;

    public EffectMoneyTextInfo(string content, Vector2 pos)
    {
        this.content = content;
        this.pos = pos;
    }
}

public struct EffectPenaltyTextInfo
{
    public string content;
    public Vector2 pos;

    public EffectPenaltyTextInfo(string content, Vector2 pos)
    {
        this.content = content;
        this.pos = pos;
    }
}
