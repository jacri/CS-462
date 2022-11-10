using UnityEngine;
using System.Collections;

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
                StartCoroutine(StopNegativeVelocity());
            }
            
        }
    }

    private IEnumerator StopNegativeVelocity ()
    {
        while (controller.lastKnownVelocity.y > 0)
            yield return new WaitForEndOfFrame();

        controller.Gravity = Vector3.zero;

        while (!controller.Motor.GroundingStatus.IsStableOnGround)
        {
            if (controller.Gravity.y > gravity.y)
                controller.Gravity -= new Vector3(0f, 0.01f, 0f);

            yield return new WaitForEndOfFrame();
        }
            
        controller.Gravity = gravity;
    }
}