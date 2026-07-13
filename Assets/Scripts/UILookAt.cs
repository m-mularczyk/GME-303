using UnityEngine;

public class UILookAt : MonoBehaviour
{
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        transform.LookAt(_mainCamera.transform);
    }
}
