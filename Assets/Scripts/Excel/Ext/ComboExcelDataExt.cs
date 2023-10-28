using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class ComboExcelData
{

    public List<int> CheckWhetherBonus(List<Vector2Int> listEat)
    {
        List<int> listBonus = new List<int>();
        Dictionary<int, int> dicEat = new Dictionary<int, int>();

        dicEat.Clear();
        for (int i = 0; i < listEat.Count; i++)
        {
            Vector2Int eatInfo = listEat[i];
            if (dicEat.ContainsKey(eatInfo.x))
            {
                dicEat[eatInfo.x] = eatInfo.y;
            }
            else
            {
                dicEat.Add(eatInfo.x, eatInfo.y);
            }
        }

        for(int i = 0; i < items.Length; i++)
        {
            ComboExcelItem comboItem = items[i];
            List<Vector2Int> listCondition = comboItem.listComboTypeNum;

            bool isMatch = true;
            for(int j = 0;j < listCondition.Count; j++)
            {
                int type = listCondition[j].x;
                int num = listCondition[j].y;

                if (dicEat.ContainsKey(type))
                {
                    if (dicEat[type] < num)
                    {
                        isMatch = false;
                    }
                }
                else
                {
                    isMatch = false;
                }
            }
            if (isMatch)
            {
                listBonus.Add(items[i].id);
            }
        }

        return listBonus;
    }
}

public partial class ComboExcelItem
{
    public List<Vector2Int> listComboTypeNum
    {
        get
        {
            List<Vector2Int> listCombo = new List<Vector2Int>();

            for(int i = 0; i < listType.Count; i++)
            {
                listCombo.Add(new Vector2Int(listType[i], listNum[i]));
            }
            return listCombo;
        }
    }
}