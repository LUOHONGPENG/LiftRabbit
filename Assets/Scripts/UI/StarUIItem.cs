using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarUIItem : MonoBehaviour
{
    public Image imgStar;
    public List<Sprite> listSpStar = new List<Sprite>();

    public void RefreshStarView(bool isReach)
    {
        if (isReach)
        {
            imgStar.sprite = listSpStar[0];
        }
        else
        {
            imgStar.sprite = listSpStar[1];
        }
    }

}
