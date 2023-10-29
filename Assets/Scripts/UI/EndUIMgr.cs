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
                codeTitle.text = "查封结局";
                codeDesc.text = "你怎能在我的奶茶里加如此污秽之物";
                imgEnd.sprite = listSp[0];
                break;
            case EndType.GoodEnd:
                codeTitle.text = "五星结局";
                codeDesc.text = "您就是大名鼎鼎的奶茶王";
                imgEnd.sprite = listSp[1];
                break;
        }
        objPopup.SetActive(true);
    }



}
