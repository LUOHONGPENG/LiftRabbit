using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PublicTool
{
    public static void ClearChildItem(UnityEngine.Transform tf)
    {
        foreach (UnityEngine.Transform item in tf)
        {
            UnityEngine.Object.Destroy(item.gameObject);
        }
    }

    public static List<int> DrawNum(int num, List<int> listPool, List<int> listDelete)
    {
        List<int> listTemp = new List<int>();
        List<int> listDraw = new List<int>(listPool);
        if (listDelete != null)
        {
            for (int i = 0; i < listDelete.Count; i++)
            {
                listDraw.Remove(listDelete[i]);
            }
        }

        for (int i = 0; i < num; i++)
        {
            int index = Random.Range(0, listDraw.Count);
            listTemp.Add(listDraw[index]);
            listDraw.RemoveAt(index);
        }
        return listTemp;
    }
}
