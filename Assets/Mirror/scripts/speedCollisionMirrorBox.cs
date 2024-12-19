using Unity.VisualScripting;
using UnityEngine;

public class speedCollisionMirrorBox : MonoBehaviour
{
    public void OnTriggerEnter()
    {
        globalVariable.monsterSpeed = 0;
    }

    public void OnTriggerExit()
    {
        globalVariable.monsterSpeed = 10;
    }
}
