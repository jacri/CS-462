using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // ===== Status Screens =========================================================================

    public void ShowWinScreen ()
    {
        transform.GetChild(2).gameObject.SetActive(true);
    }

    public void ShowDeathScreen ()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
