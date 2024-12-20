using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerPickUpPages : MonoBehaviour
{
    public Camera mainCamera;
    private LayerMask layerMask;
    private GameObject lookedAt;
    public AudioSource audioSource;
    public AudioClip pickupPageClip;

    public TMP_Text pageCountUI;
    public TMP_Text pagePickup;
    
    void Start()
    {
        layerMask = LayerMask.GetMask("Page");
    }

    // Update is called once per frame
    void Update()
    {
        lookedAt = null;
        detectPage();
        if (globalVariable.currentPages < 4)
        {
            pageCountUI.text = "Pages: " + globalVariable.currentPages + "/4";
        }
        else
        {
            pageCountUI.text = "Pages: " + globalVariable.currentPages + "/4 " + "Escape";
        }
    }

    private void detectPage()
    {
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit, 4, layerMask))
        { 
            lookedAt = hit.collider.gameObject;
        }
        if (lookedAt != null) {
            pagePickup.text = "E - pickup";
        } else
        {
            pagePickup.text = "";
        }
    }

    public void pickupButton(InputAction.CallbackContext ctx)
    {
        if(lookedAt != null)
        {
            Destroy(lookedAt);
            pickupPageClipPlay();
            lookedAt = null;
            globalVariable.currentPages++;
        }
    }

    public void pickupPageClipPlay()
    {
        audioSource.clip = pickupPageClip;
        audioSource.Play();
    }

}
