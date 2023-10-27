using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class LiftButtonUIMgr : MonoBehaviour
{
    public Transform tfLiftButton;
    public GameObject pfLiftButton;

    private Dictionary<int, LiftButtonUIItem> dicLiftButton = new Dictionary<int, LiftButtonUIItem>();

    public Button btnEat;

    private GameData gameData;

    private void Update()
    {
        if (GameMgr.Instance.isMoving)
        {
            btnEat.interactable = false;
        }
        else
        {
            btnEat.interactable = true;
        }
    }

    public void Init()
    {
        gameData = PublicTool.GetGameData();

        PublicTool.ClearChildItem(tfLiftButton);
        dicLiftButton.Clear();

        for(int i = 1;i <= gameData.numLevel; i++)
        {
            GameObject objLiftButton = GameObject.Instantiate(pfLiftButton, tfLiftButton);
            LiftButtonUIItem itemLiftButton = objLiftButton.GetComponent<LiftButtonUIItem>();
            itemLiftButton.Init(i);
            dicLiftButton.Add(i, itemLiftButton);
        }

        btnEat.onClick.RemoveAllListeners();
        btnEat.onClick.AddListener(delegate ()
        {
            EventCenter.Instance.EventTrigger("SelectLevel", -99);
        });

    }

    public void RefreshLiftButton()
    {

    }
}
