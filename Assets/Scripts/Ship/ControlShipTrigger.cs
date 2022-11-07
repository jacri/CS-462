using UnityEngine;
using Cinemachine;
using System.Collections;

public class ControlShipTrigger : MonoBehaviour
{
    // ===== Public Variables =====================================================================

    public GameObject playerFollow;
    public GameObject playerMainCamera;
    public StarterAssets.ThirdPersonController playerControlScript;

    public GameObject shipFollow;
     public GameObject shipMainCamera;
    public StarterAssets.ThirdPersonController shipControlScript;

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
            playerFollow.SetActive(true);
            playerMainCamera.SetActive(true);
            playerControlScript.enabled = true;

            shipFollow.SetActive(false);
            shipMainCamera.SetActive(false);
            //shipControlScript.enabled = false;
        }
           
        else
        {
            playerFollow.SetActive(false);
            playerMainCamera.SetActive(false);
            playerControlScript.enabled = false;

            shipFollow.SetActive(true);
            shipMainCamera.SetActive(true);
            //shipControlScript.enabled = true;
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
