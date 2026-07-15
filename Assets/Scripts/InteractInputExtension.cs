using StarterAssets;
using UnityEngine;

public class InteractInputExtension : MonoBehaviour
{
    private StarterAssetsInputs _starterAssetsInputs;

    private void Awake()
    {
        _starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    private void LateUpdate()
    {
        _starterAssetsInputs.interact = false;
    }
}
