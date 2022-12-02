using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerWeapon : MonoBehaviour
{
    // ===== Public Variables =====================================================================

    [Header("Settings")]

    public int energy;
    public int maxEnergy;
    public int energyPerShot;
    public float attackSpeed;
    public float regenRate;
    public float startRegenDelay;

    [Space(10)]
    [Header("Projectile Settings")]

    public Transform hand;
    public GameObject projectile;
    public float projectileSpeed;
    public Vector3 projectileSpawnOffset;

    [Space(10)]
    [Header("Camera Settings")]

    public Vector2 aimingOffset;
    public float aimingDistance;
    public float neutralDistance;

    [Space(10)]
    [Header("HUD")]

    public GameObject hud;
    public Slider energySlider;

    [Space(10)]
    [Header("Components")]

    public PlayerAnimator anim;
    public AudioSource attackSoundEffect;
    public KinematicCharacterController.Examples.ExampleCharacterCamera camController;
    public KinematicCharacterController.Examples.ExampleCharacterController playerController;


    // ===== Private Variables =====================================================================

    private Camera cam;
    private RaycastHit hit;
    private bool aiming = false;
    private float nextShot = 0f;
    private float startRegen = 0f;

    // ===== Update ===============================================================================

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            StartAiming();

        if (Input.GetMouseButtonUp(1))
            StopAiming();

        if (Input.GetMouseButtonDown(0) && aiming)
            Shoot();

        if (Time.time > startRegen && energy < maxEnergy)
        {
            energy++;
            startRegen = Time.time + regenRate;
            energySlider.value = energy;
        }
    }

    // ===== Private Functions ====================================================================

    private void StartAiming ()
    {
        aiming = true;
        anim.StartAiming();
        cam = Camera.main;
        
        camController.FollowPointFraming = aimingOffset;

        camController.MinDistance = aimingDistance;
        camController.DefaultDistance = aimingDistance;
        camController.MaxDistance = aimingDistance;
        playerController.OrientationMethod = KinematicCharacterController.Examples.OrientationMethod.TowardsCamera;

        hud.SetActive(true);
    }

    private void Shoot ()
    {
        if (Time.time >= nextShot && energy >= energyPerShot)
        {
            if (attackSoundEffect != null)
                attackSoundEffect.Play();

            energy -= energyPerShot;
            energySlider.value = energy;

            Ray r = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            Vector3 destination = Physics.Raycast(r, out hit, 1 << 6) ? hit.point : r.GetPoint(1000);

            Rigidbody rb = Instantiate(projectile, hand.position + transform.forward, Quaternion.identity).GetComponent<Rigidbody>();
            rb.transform.LookAt(destination);
            rb.velocity = rb.transform.forward * projectileSpeed;//* Time.deltaTime;

            nextShot = Time.time + attackSpeed;
            startRegen = Time.time + startRegenDelay;
        }
    }

    private void StopAiming ()
    {
        aiming = false;
        anim.StopAiming();
        
        camController.FollowPointFraming = Vector2.zero;
        
        camController.MinDistance = neutralDistance;
        camController.DefaultDistance = neutralDistance;
        camController.MaxDistance = neutralDistance;
        playerController.OrientationMethod = KinematicCharacterController.Examples.OrientationMethod.TowardsMovement;

        hud.SetActive(false);
    }
}