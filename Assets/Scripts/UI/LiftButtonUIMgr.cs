using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiftButtonUIMgr : MonoBehaviour
{
    public Transform tfLiftButton;
    public GameObject pfLiftButton;

    private Dictionary<int, LiftButtonUIMgr> dicLiftButton = new Dictionary<int, LiftButtonUIMgr>();

    public Button btnEat;

    public void Init()
    {
        PublicTool.ClearChildItem(tfLiftButton);
        dicLiftButton.Clear();

        



        btnEat.onClick.RemoveAllListeners();
        btnEat.onClick.AddListener(delegate ()
        {

        });

    }

    public void RefreshLiftButton()
    {

    }
}
