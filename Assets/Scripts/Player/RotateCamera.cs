using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // ===== Public Variables =====================================================================

    [Header("Sensitivity")]

    public float hSen;
    public float vSen;

    [Space(10)]
    [Header("System")]

    public bool canLook = false;

    // ===== Private Variables =====================================================================

    private Transform player;
    private Vector3 playerDelta;

    private Transform cameraBoom;
    private Vector3 cameraBoomDelta;

    // ===== Start ================================================================================
    
    private void Start ()
    {
        player = transform;
        playerDelta = Vector3.zero;

        cameraBoom = player.GetChild(0);
        cameraBoomDelta = Vector3.zero;
    }

    // ===== Update ===============================================================================
    
    private void Update ()
    {
        if (canLook)
        {
            playerDelta.y = Input.GetAxisRaw("Horizontal") * vSen * Time.deltaTime;
            player.Rotate(playerDelta);

            cameraBoomDelta.x = Input.GetAxisRaw("Vertical") * hSen * Time.deltaTime;
            cameraBoom.Rotate(cameraBoomDelta);
        }
    }
}