using UnityEngine;
using UnityEngine.AI;

public class AITentakl : MonoBehaviour
{
    public Transform playerTransform;
    public NavMeshAgent monsterAI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        monsterAI = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        monsterAI.destination = playerTransform.position;
        monsterAI.speed = globalVariable.monsterSpeed;
        Debug.Log(monsterAI.speed);

    }
}
