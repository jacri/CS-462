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
    private PlayerManager playerManager;

    // ===== Start ================================================================================
    
    private void Start ()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

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
            playerManager.respawnPosition = transform.position;
            playerManager.respawnRotation = transform.rotation;
            playerManager.SpawnInstance();

            shipMainCamera.enabled = false;
            shipControlScript.enabled = false;
        }
           
        else
        {
            shipMainCamera.enabled = true;
            shipControlScript.enabled = true;

            playerManager.respawnRotation = playerInstance.transform.rotation;
            playerManager.DestroyInstance();
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
