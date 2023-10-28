using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUIMgr : MonoBehaviour
{
    public Text codeMoney;
    public Text codePopularity;

    private bool isInit = false;
    public void Init()
    {
        isInit = true;
    }

    private void Update()
    {
        if (isInit)
        {
            RefreshResource();
        }   
    }

    public void RefreshResource()
    {
        codeMoney.text = PublicTool.GetGameData().money.ToString();

        codePopularity.text = PublicTool.GetGameData().popularity.ToString();

    }
}
