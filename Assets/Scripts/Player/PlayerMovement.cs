using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // ===== Public Variables =====================================================================

    public float walkSpeed;

    // ===== Private Variables =====================================================================

    private Transform t;
    private Transform cameraTransform;

    // ===== Start ================================================================================
    
    private void Start ()
    {
        t = transform;
        cameraTransform = Camera.main.transform;
    }

    // ===== Update ===============================================================================
    
    private void Update ()
    {
        Vector3 v = new Vector3(Input.GetAxisRaw("Vertical"), 0f, Input.GetAxisRaw("Horizontal"));
        v = cameraTransform.TransformDirection(v);
        t.position += v * walkSpeed * Time.deltaTime;
    }
}
