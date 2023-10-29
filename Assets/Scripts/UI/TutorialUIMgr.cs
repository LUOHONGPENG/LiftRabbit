using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TutorialStep
{
    Text,
    TextImg,
    End
}

public enum TutorialGroup
{
    Star0,
    Star1,
    Star2,
    Star3,
    Star4
}


public class TutorialUIMgr : MonoBehaviour
{
    public GameObject objPopup;

    public Button btnContinue;
    public Button btnSkip;


    public Text codeTutorial;
    public Image imgTutorial;

    private List<TutorialExcelItem> listTutorial;
    private int curIndex = -1;

    public void Init()
    {

        btnContinue.onClick.RemoveAllListeners();
        btnContinue.onClick.AddListener(delegate ()
        {
            Continue();
        });

        btnSkip.onClick.RemoveAllListeners();
        btnSkip.onClick.AddListener(delegate ()
        {
            Close();
        });

    }

    private void OnEnable()
    {
        EventCenter.Instance.AddEventListener("TutorialStart", TutorialStartEvent);
    }

    private void OnDisable()
    {
        EventCenter.Instance.RemoveEventListener("TutorialEnd", TutorialStartEvent);

    }

    private void TutorialStartEvent(object arg0)
    {
        curIndex = -1;

        TutorialGroup group = (TutorialGroup)arg0;

        if (GameMgr.Instance.tutorialExcelData.dicTutorial.ContainsKey(group))
        {
            listTutorial = GameMgr.Instance.tutorialExcelData.dicTutorial[group];
            Continue();
            objPopup.SetActive(true);
            btnSkip.gameObject.SetActive(true);
        }

    }

    private void ReadTutorial(TutorialExcelItem item)
    {
        codeTutorial.text = item.strContent;
        switch (item.step)
        {
            case TutorialStep.Text:

                break;
            case TutorialStep.End:
                Close();
                break;
        }
    }

    private void Continue()
    {
        curIndex++;
        ReadTutorial(listTutorial[curIndex]);
    }

    private void Close()
    {
        objPopup.SetActive(false);
        btnSkip.gameObject.SetActive(false);
    }
}
