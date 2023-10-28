using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillNodeUIMgr : MonoBehaviour
{
    public GameObject objPopup;

    public Transform tfSkillNode;
    public GameObject pfSkillNode;

    public Button btnClose;

    public void Init()
    {
        PublicTool.ClearChildItem(tfSkillNode);


        btnClose.onClick.RemoveAllListeners();
        btnClose.onClick.AddListener(delegate ()
        {
            objPopup.SetActive(false);
        });
    }

    private void OnEnable()
    {
        EventCenter.Instance.AddEventListener("SkillNodePage", SkillNodePageEvent);
    }

    private void OnDisable()
    {
        EventCenter.Instance.RemoveEventListener("SkillNodePage", SkillNodePageEvent);

    }

    private void SkillNodePageEvent(object arg0)
    {

        objPopup.SetActive(true);
    }


}
