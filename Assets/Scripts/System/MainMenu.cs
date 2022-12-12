using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // ===== Public Variables =====================================================================

    public Vector3 rotationSpeed;

    // ===== Private Variables ====================================================================

    private Transform t;

    // ===== Start ================================================================================

    private void Start ()
    {
        t = transform;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // ===== Update ===============================================================================

    void Update()
    {
        t.Rotate(rotationSpeed * Time.deltaTime);
    }

    // ===== Public Functions =====================================================================

    public void Play ()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit () 
    {
        Application.Quit();
    }
}