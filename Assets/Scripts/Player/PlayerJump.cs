using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // ===== Public Variables =====================================================================

    public Vector3 gravity;
    public Rigidbody rb;
    public KinematicCharacterController.Examples.ExampleCharacterController controller;
    
    // ===== Update ===============================================================================
    
    private void Update ()
    {
        if (!controller.Motor.GroundingStatus.IsStableOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            if (controller.Gravity == Vector3.zero)
            {
                controller.Gravity = gravity;
            }

            else 
            {
                controller.Gravity = Vector3.zero;

                Vector3 v = rb.velocity;
                v.y = 0f;
                rb.velocity = v;
            }
            
        }
    }
}