using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameData
{
    public List<int> listUnlockSkillNode = new List<int>();

    public void UnlockSkillNode(int skillID)
    {
        if (!listUnlockSkillNode.Contains(skillID))
        {
            listUnlockSkillNode.Add(skillID);
        }
    }

    public bool CheckSkillNode(int skillID)
    {
        if (listUnlockSkillNode.Contains(skillID))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private float speedLift = 1f;
    public float curSpeedLift
    {
        get
        {
            float speed = speedLift;
            if (CheckSkillNode(2001))
            {
                speed += 0.4f;
            }
            if (CheckSkillNode(2002))
            {
                speed += 0.6f;
            }
            return speed;
        }
    }

    private float speedGenerateHuman = 1f;
    public float curSpeedGenerateHuman
    {
        get
        {
            float speed = speedLift;
            float speedBonus = 0;
            float rate = 0.05f;
            if (Popularity > 50)
            {
                speedBonus = 50 * rate;
            }
            else
            {
                speedBonus = Popularity * rate;
            }

            speed += speedBonus;
            return speed;
        }
    }

    private int queueLimit = 3;
    public int curQueueLimit
    {
        get
        {
            int temp = queueLimit;
            if (CheckSkillNode(3001))
            {
                temp++;
            }
            if (CheckSkillNode(3002))
            {
                temp++;
            }
            return temp;
        }
    }

    //LiftCapacity
    private int capacity = 4;
    public int curCapacity
    {
        get
        {
            int temp = capacity;
            if (CheckSkillNode(1001))
            {
                temp++;
            }
            if (CheckSkillNode(1002))
            {
                temp++;
            }
            return temp;
        }
    }

    private float eatSpeed = 1f;
    public float EatSpeed
    {
        get
        {
            float temp = eatSpeed;
            if (CheckSkillNode(4001))
            {
                temp *= 0.7f;
            }
            if (CheckSkillNode(4002))
            {
                temp *= 0.7f;
            }
            return temp;
        }
    }


    public int curLiftLoad
    {
        get
        {
            if (listHumanInLift != null)
            {
                return listHumanInLift.Count;
            }
            else
            {
                return 0;
            }
        }
    }



}
