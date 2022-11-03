using UnityEngine;
using Cinemachine;

public class ControlShipTrigger : MonoBehaviour
{
    // ===== Public Variables =====================================================================

    public Transform shipCameraTarget;
    public MonoBehaviour shipControlScript;

    public Transform playerCameraTarget;
    public StarterAssets.ThirdPersonController playerControlScript;

    public CinemachineVirtualCamera cam;

    // ===== Private Variables =====================================================================

    private bool inTrigger = false;
    private bool followingPlayer = true;

    // ===== Update ===============================================================================
    
    private void Update ()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.E))
        {
            SwitchTarget();
        }
    }

    // ===== Private Functions =====================================================================

    private void SwitchTarget ()
    {
        followingPlayer = !followingPlayer;

        if (followingPlayer)
        {
            cam.Follow = playerCameraTarget;
            playerControlScript.enabled = true;
        }
           

        else
        {
            cam.Follow = shipCameraTarget;
            playerControlScript.enabled = false;
        }
            
    }

    // ===== Trigger ================================================================================

    private void OnTriggerEnter (Collider other)
    {
        inTrigger = other.tag == "Player";
    }

    private void OnTriggerExit (Collider other) 
    {
        inTrigger = false;
    } 
}
