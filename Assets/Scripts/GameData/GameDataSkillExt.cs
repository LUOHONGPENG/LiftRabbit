using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameData
{
    private float speedLift = 1f;
    public float curSpeedLift
    {
        get
        {
            float speed = speedLift;


            return speed;
        }
    }

    private float speedGenerateHuman = 1f;
    public float curSpeedGenerateHuman
    {
        get
        {
            float speed = speedLift;
            float speedBonus = Popularity * 0.025f;
            speed += speedBonus;
            return speed;
        }
    }

    private int queueLimit = 4;
    public int curQueueLimit
    {
        get
        {
            int temp = queueLimit;

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
