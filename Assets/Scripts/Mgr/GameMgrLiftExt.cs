using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameMgr
{
    public int curLevel = 1;

    public bool isMoving = false;

    public void SelectLevelEvent(object arg0)
    {
        int tarLevel = (int)arg0;

        if (curLevel == tarLevel)
        {
            //Oh I am here
        }
        else
        {
            if (tarLevel >= 1)
            {
                IE_MoveToTargetLevel(tarLevel);
            }
            else
            {
                IE_EatHuman();
            }
        }
    }

    public IEnumerator IE_MoveToTargetLevel(int level)
    {
        isMoving = true;
        yield return new WaitForSeconds(2);
        curLevel = level;
        isMoving = false;
        yield break;
    }

    public IEnumerator IE_EatHuman()
    {
        isMoving = true;
        yield return new WaitForSeconds(5);
        isMoving = false;
        yield break;
    }
}
