using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TutorialStep
{
    Text,
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

    public Text codeTutorial;

    public void Init()
    {

        btnContinue.onClick.RemoveAllListeners();
        btnContinue.onClick.AddListener(delegate ()
        {
            Continue();
        });

    }

    private void Continue()
    {

    }
}
