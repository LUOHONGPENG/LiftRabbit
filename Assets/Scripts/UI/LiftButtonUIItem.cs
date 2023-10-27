using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiftButtonUIItem : MonoBehaviour
{
    public Button btnLiftButton;
    public Text codeLiftLevel;

    public void Init(int Level)
    {
        codeLiftLevel.text = Level.ToString();

        btnLiftButton.onClick.RemoveAllListeners();
        btnLiftButton.onClick.AddListener(delegate ()
        {
            EventCenter.Instance.EventTrigger("SelectLevel", Level);
        });
    }
}
