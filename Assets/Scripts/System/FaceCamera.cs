using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    // ===== Private Variables =====================================================================

    private Transform t;

    // ===== Start ================================================================================
    
    private void Start ()
    {
        t = transform;
    }

    private void Update ()
    {
        t.LookAt(Camera.main.transform);
    }
}