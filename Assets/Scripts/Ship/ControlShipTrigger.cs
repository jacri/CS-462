using UnityEngine;

public class ControlShipTrigger : MonoBehaviour
{
    // ===== Public Variables =====================================================================

    [Header("Player Controller Information")]

    public GameObject playerPrefab;
    public GameObject playerInstance;

    [Space(10)]
    [Header("Ship Controller Information")]

    public Camera shipMainCamera;
    public KinematicCharacterController.Examples.ShipPlayer shipControlScript;

    // ===== Private Variables =====================================================================

    private bool inTrigger = false;
    private bool followingPlayer = true;
    private Quaternion playerRot;

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
            playerInstance = Instantiate(playerPrefab, transform.position, playerRot);

            shipMainCamera.enabled = false;
            shipControlScript.enabled = false;
        }
           
        else
        {
            shipMainCamera.enabled = true;
            shipControlScript.enabled = true;

            playerRot = playerInstance.transform.rotation;
            Destroy(playerInstance);
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
