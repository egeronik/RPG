using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDataController : MonoBehaviour
{
    public static float[] teamHP = new float[10];
    public static bool dialogWindowAlive = false;
    public static float playerX = 7.362f;
    public static float playerY = 0f;
    public static bool isFirstStart = true;
    public static string Biome = "Forest";
    public static int[] teamHp = new int[4];
    public static int[] teamMaxHp = new int[4] {100,100,100,100};
    public static bool teamHealthIsFull = true;


}
