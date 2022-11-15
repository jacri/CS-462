using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // ===== Private Variables =====================================================================

#if UNITY_EDITOR
    private bool paused = true;
#else
    private bool paused = false;
#endif

    // ===== Update ===============================================================================
    
    /*
    private void Update ()
    {
        if (Input.GetButtonDown("Cancel"))
            TogglePause();

        if (paused && Input.GetMouseButtonDown(0))
            Unpause();
    } */

    // ===== Cursor ===============================================================================
    
    public void LockCursor ()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UnlockCursor () 
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // ===== Status Screens =========================================================================

    public void ShowWinScreen ()
    {
        transform.GetChild(2).gameObject.SetActive(true);
    }

    public void ShowDeathScreen ()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ReturnToMainMenu ()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    // ===== Pause ================================================================================

    public void Pause () 
    {
        paused = true;
        UnlockCursor();
        Time.timeScale = 0f;
    }

    public void Unpause ()
    {
        paused = false;
        LockCursor();
        Time.timeScale = 1f;
    }

    private void TogglePause () 
    {
        if (paused)
            Unpause();

        else
            Pause();
    }
}
