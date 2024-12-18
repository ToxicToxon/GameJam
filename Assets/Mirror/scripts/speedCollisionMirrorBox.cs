using Unity.VisualScripting;
using UnityEngine;

public class speedCollisionMirrorBox : MonoBehaviour
{
    public void OnTriggerEnter()
    {
        globalVariable.monsterSpeed = 0;
        Debug.Log("collision");
    }

    public void OnTriggerExit()
    {
        globalVariable.monsterSpeed = 10;
        Debug.Log("no collision");
    }
}
