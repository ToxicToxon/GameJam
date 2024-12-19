using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickUpPages : MonoBehaviour
{
    public Camera mainCamera;
    private LayerMask layerMask;
    private GameObject lookedAt;
    
    void Start()
    {
        layerMask= LayerMask.GetMask("Page");
    }

    // Update is called once per frame
    void Update()
    {
        lookedAt = null;
        detectPage();
    }

    private void detectPage()
    {
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        { 
            lookedAt = hit.collider.gameObject;
        }
    }

    public void pickupButton(InputAction.CallbackContext ctx)
    {
        if(lookedAt != null)
        {
            Destroy(lookedAt);
            lookedAt = null;
            globalVariable.currentPages++;
        }
    }
}
