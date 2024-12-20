using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AITentakl : MonoBehaviour
{
    public Transform playerTransform;
    public NavMeshAgent monsterAI;
    private Animator monsterAnim;
    private GameObject playerCameraObj;
    public AudioSource audioSource;
    public AudioClip walkClip;
    public AudioClip screamClip;
    public GameObject playerAudioGO;
    public GameObject monsters;
    private float originalLength;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        monsterAI = gameObject.GetComponent<NavMeshAgent>();
        monsterAnim = gameObject.GetComponent<Animator>();
        playerCameraObj = playerTransform.GetChild(0).gameObject;
        originalLength = audioSource.maxDistance;
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
            monsterAnim.SetBool("jumpscare", true);
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
            jumpscare();
            Debug.Log("test of trigger");
        }
    }

    public void jumpscare()
    {
        for(int i = 0; i < monsters.transform.childCount; i++)
            monsters.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.layer = 0;
        audioSource.Stop();
        playerAudioGO.GetComponent<PlayAudio>().jumpscare();
        Invoke("backToMenu", 2f);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void scream()
    {
        audioSource.clip = screamClip;
        Vector3 length = transform.position - playerAudioGO.transform.position;
        audioSource.maxDistance = length.magnitude;
        audioSource.loop = false;
        audioSource.Play();
    }
    public void walk()
    {
        audioSource.clip = walkClip;
        audioSource.maxDistance = originalLength;
        audioSource.loop = true;
        audioSource.Play();
    }
}
