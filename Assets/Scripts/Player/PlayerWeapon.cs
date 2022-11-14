using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    // ===== Public Variables =====================================================================

    public int damage;
    public PlayerAnimator anim;
    
    public Vector2 aimingOffset;
    public float aimingDistance;
    public float neutralDistance;
    public KinematicCharacterController.Examples.ExampleCharacterCamera cam;

    // ===== Update ===============================================================================

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            StartAiming();

        if (Input.GetMouseButtonUp(1))
            StopAiming();
    }

    // ===== Private Functions ====================================================================

    private void StartAiming ()
    {
        anim.StartAiming();
        
        cam.FollowPointFraming = aimingOffset;

        cam.MinDistance = aimingDistance;
        cam.DefaultDistance = aimingDistance;
        cam.MaxDistance = aimingDistance;
    }

    private void StopAiming ()
    {
        anim.StopAiming();
        
        cam.FollowPointFraming = Vector2.zero;
        
        cam.MinDistance = neutralDistance;
        cam.DefaultDistance = neutralDistance;
        cam.MaxDistance = neutralDistance;
    }
}