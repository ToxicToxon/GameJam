using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AITentakl : MonoBehaviour
{
    public Transform playerTransform;
    public NavMeshAgent monsterAI;
    private Animator monsterAnim;
    private GameObject playerCameraObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        monsterAI = gameObject.GetComponent<NavMeshAgent>();
        monsterAnim = gameObject.GetComponent<Animator>();
        playerCameraObj = playerTransform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(globalVariable.gameState == 1)
        {
            monsterAI.speed = 0;
            playerCameraObj.transform.position = transform.GetChild(2).gameObject.transform.position;
            Vector3 lookAtPosition = transform.position;
            lookAtPosition.y = transform.GetChild(2).gameObject.transform.position.y;
            playerCameraObj.transform.LookAt(lookAtPosition);
        }
        else
        {
            monsterAI.destination = playerTransform.position;
            monsterAI.speed = globalVariable.monsterSpeed;
        }
        if(globalVariable.monsterSpeed == 0)
            monsterAnim.SetBool("isRunning", false);
        else
            monsterAnim.SetBool("isRunning", true);
        Debug.Log(monsterAI.speed);
    }

    public void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.layer + "this is collision");
        if(collision.gameObject.layer == 6)
        {
            if(globalVariable.gameState == 1)
                return;
            else
                globalVariable.gameState = 1;
            monsterAnim.SetBool("jumpscare", true);
            jumpscare();
            Debug.Log("test of trigger");
        }
    }

    public void jumpscare()
    {
        gameObject.layer = 0;
        Invoke("backToMenu", 1.5f);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
    }
}
