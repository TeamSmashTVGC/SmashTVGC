using UnityEngine;
using System.Collections;

public class DestroyOnExitScreen : MonoBehaviour
{
    public float delay = 3.0f;

    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        //Debug.Log("Camera.main.pixelRect.Contains(screenPoint) " + Camera.main.pixelRect.Contains(screenPoint));
        if (!Camera.main.pixelRect.Contains(screenPoint))
        {
            Destroy(gameObject, delay);
        }
    }
}
