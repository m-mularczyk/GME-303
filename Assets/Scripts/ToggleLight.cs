using UnityEngine;

public class ToggleLight : MonoBehaviour, IInteractable
{
    private Material _emissiveMaterial;
    [SerializeField] private bool _isOn;
    [SerializeField] private float _emissionPower = 5f;

    void Start()
    {
        _emissiveMaterial = GetComponent<MeshRenderer>().materials[1];

        if (_isOn)
            _emissiveMaterial.SetColor("_EmissionColor", Color.white * _emissionPower);
        else
            _emissiveMaterial.SetColor("_EmissionColor", Color.black);
    }

    public void Interact()
    {
        // Turn light on/off
        _isOn = !_isOn;

        if (_isOn)
            _emissiveMaterial.SetColor("_EmissionColor", Color.white * _emissionPower);
        else
            _emissiveMaterial.SetColor("_EmissionColor", Color.black);
    }

    public void Activate(bool isActivated)
    {
        //throw new System.NotImplementedException();
    }

}
