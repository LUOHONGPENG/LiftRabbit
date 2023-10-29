using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EndType
{
    BadEnd,
    GoodEnd
}


public class EndUIMgr : MonoBehaviour
{
    public GameObject objPopup;
    public Text codeTitle;
    public Text codeDesc;
    public Image imgEnd;
    public List<Sprite> listSp = new List<Sprite>();

    public void Init()
    {

    }

    private void OnEnable()
    {
        EventCenter.Instance.AddEventListener("EndEvent", EndEvent);
    }

    private void OnDisable()
    {
        EventCenter.Instance.RemoveEventListener("EndEvent", EndEvent);
    }

    private void EndEvent(object arg0)
    {
        EndType endType = (EndType)arg0;

        switch (endType)
        {
            case EndType.BadEnd:
                codeTitle.text = "�����";
                codeDesc.text = "���������ҵ��̲��������ۻ�֮��";
                imgEnd.sprite = listSp[0];
                break;
            case EndType.GoodEnd:
                codeTitle.text = "���ǽ��";
                codeDesc.text = "�����Ǵ����������̲���";
                imgEnd.sprite = listSp[1];
                break;
        }
        objPopup.SetActive(true);
    }



}
