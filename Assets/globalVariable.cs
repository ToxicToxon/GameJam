using UnityEngine;

public class globalVariable : MonoBehaviour
{
    public static float monsterSpeed = 10.0f;
    public static int currentPages = 0;
    public static int maxPages = 10;
    public static int gameState = 0; //0 - in progress, 1 - loss, 2 - win

    void Update()
    {
        if(currentPages == maxPages)
        {
            //open exit
        }
    }
}
