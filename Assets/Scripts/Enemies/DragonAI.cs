using UnityEngine;

public class DragonAI : MonoBehaviour
{
    // ===== Public Variables =====================================================================

    [Header("Movement")]

    public float moveSpeed;
    public float maxTrackingDistance;

    [Space(10)]
    [Header("Attack")]

    public int attackDamage;
    public float attackSpeed;
    public float attackRange;

    // ===== Private Variables =====================================================================

    private Transform t;
    public Transform player;
    private PlayerManager playerManager;

    private Animator anim;
    private RaycastHit hit;
    private float nextAttack = 0f;

    // ===== Start ================================================================================
    
    private void Start ()
    {
        t = transform;
        anim = GetComponent<Animator>();
        playerManager = FindObjectOfType<PlayerManager>();
    }

    // ===== Update ===============================================================================
    
    private void Update ()
    {
        if (player == null)
            player = FindObjectOfType<PlayerHealth>().transform;

        // if (playerManager.instance != null)
        // {
            float dist = Vector3.Distance(t.position, player.position);

            if (dist > attackRange && dist < maxTrackingDistance)
            {
                t.LookAt(player.transform);
                
                if (Physics.Raycast(t.position, t.forward, out hit, maxTrackingDistance) && hit.collider.GetComponent<PlayerHealth>())
                    t.position += t.forward * moveSpeed * Time.deltaTime;
            }
            
            else if (dist < maxTrackingDistance && Time.time > nextAttack)
                Attack();
        //}
    }

    // ===== Private Functions =====================================================================

    private void Attack ()
    {
        if (player != null)
        {
            nextAttack = Time.time + attackSpeed;
            anim.SetTrigger("Attack");
            player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }

}
