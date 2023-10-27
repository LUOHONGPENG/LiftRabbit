using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiftButtonUIItem : MonoBehaviour
{
    public Button btnLiftButton;

    public void Init(int Level)
    {
        btnLiftButton.onClick.RemoveAllListeners();
        btnLiftButton.onClick.AddListener(delegate ()
        {

        });
    }
}
