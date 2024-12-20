using Unity.VisualScripting;
using UnityEngine;

public class speedCollisionMirrorBox : MonoBehaviour
{
    public GameObject monsters;
    public void OnTriggerEnter()
    {
        globalVariable.monsterSpeed = 0;
        for(int i = 0; i < monsters.transform.childCount; i++)
        {
            GameObject monster = monsters.transform.GetChild(i).gameObject;
            monster.GetComponent<AITentakl>().scream();
        }
    }

    public void OnTriggerExit()
    {
        globalVariable.monsterSpeed = 10;
        for(int i = 0; i < monsters.transform.childCount; i++)
        {
            GameObject monster = monsters.transform.GetChild(i).gameObject;
            monster.GetComponent<AITentakl>().walk();
        }
    }
}
