using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    // ===== Public Variables =====================================================================

    public Animator anim;
    public KinematicCharacterController.Examples.ExampleCharacterController controller;

    // ===== Update ===============================================================================

    private void Update ()
    {
        Vector3 v = controller.lastKnownVelocity;
        v.y = 0f;
        anim.SetFloat("Speed", v.sqrMagnitude);

        if (controller.Motor.GroundingStatus.IsStableOnGround && Input.GetKeyDown(KeyCode.Space))
            anim.SetTrigger("StartJump");
    }

    // ===== Public Functions =====================================================================

    public void Land () => anim.SetTrigger("Land");
    public void StartAiming () => anim.SetBool("Aiming", true);
    public void StopAiming () => anim.SetBool("Aiming", false);
}