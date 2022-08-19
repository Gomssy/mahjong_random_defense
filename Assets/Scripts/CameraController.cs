using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void Start()
    {
        ModifyCameraScale();
    }

    private void ModifyCameraScale()
    {
        var cam = GetComponent<Camera>();
        float scaleHeight = (float)Screen.height / Screen.width;
        if (scaleHeight >= 2f)
        {
            float camHeight = 5.2f * scaleHeight;
            cam.orthographicSize = camHeight;
            transform.position = new Vector3(5f, 16f - camHeight, -10f);
        }
        else
        {
            cam.orthographicSize = 10f;
            transform.position = new Vector3(5f, 6f, -10f);
        }
    }
}
