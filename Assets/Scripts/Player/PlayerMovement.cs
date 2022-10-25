using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    // ===== Public Variables =====================================================================

    public float walkSpeed;
    public float jumpForce;

    // ===== Private Variables =====================================================================

    private Transform t;
    private Rigidbody rb;
    private Animator anim;
    private Transform cameraTransform;

    // ===== Start ================================================================================
    
    private void Start ()
    {
        t = transform;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
    }

    // ===== Update ===============================================================================
    
    private void Update ()
    {
        Vector3 v = new Vector3(Input.GetAxisRaw("Vertical"), 0f, Input.GetAxisRaw("Horizontal"));
        v = cameraTransform.TransformDirection(v);
        t.position += v * walkSpeed * Time.deltaTime;

        anim.SetFloat("Velocity", v.magnitude);

        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(Jump());
    }

    // ===== Jump ==================================================================================

    private IEnumerator Jump () 
    {
        rb.AddForce(Vector3.up * jumpForce);

        while (rb.velocity.y >= 0f)
            yield return new WaitForEndOfFrame();

        rb.useGravity = false;
        rb.velocity += new Vector3(0f, -rb.velocity.y, 0f);

        while (Input.GetKey(KeyCode.Space))
            yield return new WaitForEndOfFrame();

        rb.useGravity = true;
    }
}
