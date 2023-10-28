using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpUIMgr : MonoBehaviour
{
    public GameObject objPopup;

    public Button btnOK;

    public List<StarUIItem> listStar;

    public void Init()
    {
        btnOK.onClick.RemoveAllListeners();
        btnOK.onClick.AddListener(delegate ()
        {
            objPopup.SetActive(false);
        });

    }

    private void OnEnable()
    {
        EventCenter.Instance.AddEventListener("LevelUpPage", LevelUpEvent);
    }

    private void OnDisable()
    {
        EventCenter.Instance.RemoveEventListener("LevelUpPage", LevelUpEvent);

    }

    private void LevelUpEvent(object arg0)
    {

        RefreshStar();

        objPopup.SetActive(true);

    }

    public void RefreshStar()
    {
        int StarLevel = (int)PublicTool.GetGameData().curStarLevel;

        for (int i = 0; i < 5; i++)
        {
            if (i < StarLevel)
            {
                listStar[i].RefreshStarView(true);
            }
            else
            {
                listStar[i].RefreshStarView(false);
            }
        }
    }

}
