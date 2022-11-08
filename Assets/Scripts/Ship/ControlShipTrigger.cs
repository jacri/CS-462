using UnityEngine;

public class ControlShipTrigger : MonoBehaviour
{
    // ===== Public Variables =====================================================================

    [Header("Player Controller Information")]

    public Camera playerMainCamera;
    public KinematicCharacterController.Examples.ExamplePlayer playerControlScript;

    [Space(10)]
    [Header("Ship Controller Information")]

    public Camera shipMainCamera;
    public KinematicCharacterController.Examples.ShipPlayer shipControlScript;

    [Space(10)]
    [Header("Transforms")]

    public Transform playerTransform;
    public GameObject playerController;
    public Transform shipPlayerParentTransform;

    // ===== Private Variables =====================================================================

    private bool inTrigger = false;
    private bool followingPlayer = true;
    private Vector3 pos;

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
            playerMainCamera.enabled = true;
            playerControlScript.enabled = true;

            shipMainCamera.enabled = false;
            shipControlScript.enabled = false;

            Vector3 pos = playerController.transform.position;
            playerTransform.SetParent(null);
            playerController.AddComponent<Rigidbody>().isKinematic = true;
            playerController.GetComponent<Rigidbody>().MovePosition(transform.position);
            playerController.GetComponent<KinematicCharacterController.Examples.ExampleCharacterController>().enabled = true;
            playerController.GetComponent<KinematicCharacterController.KinematicCharacterMotor>().enabled = true;
            playerController.transform.position = pos;
        }
           
        else
        {
            playerMainCamera.enabled = false;
            playerControlScript.enabled = false;

            shipMainCamera.enabled = true;
            shipControlScript.enabled = true;

            playerController.GetComponent<KinematicCharacterController.Examples.ExampleCharacterController>().enabled = false;
            playerController.GetComponent<KinematicCharacterController.KinematicCharacterMotor>().enabled = false;
            Destroy(playerController.GetComponent<Rigidbody>());
            playerTransform.SetParent(shipPlayerParentTransform);
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
