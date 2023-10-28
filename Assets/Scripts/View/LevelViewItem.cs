using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelViewItem : MonoBehaviour
{
    public Text codeLevel;
    public void Init(int level)
    {
        codeLevel.text = level.ToString();
    }
}
