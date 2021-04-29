using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public int PowerWeight;
    public int SpeedWeight;
    public int TechWeight;

    public void ApplyValues(int power, int speed, int tech)
    {
        PowerWeight = power;
        SpeedWeight = speed;
        TechWeight = tech;
    }

}
