using UnityEngine;

public class PowerCore : MonoBehaviour, IInteractable
{
    public bool isPickedUp;
    private Rigidbody _rb;
    public Transform playerPickupTransform;
    public int powerLevel;
    private Material _powerCoreMaterial;
    public PowerReceiver target;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        isPickedUp = false;
        _powerCoreMaterial = GetComponentInChildren<MeshRenderer>().material;
    }

    public void Interact()
    {
        if (!isPickedUp)
        {
            isPickedUp = true;
            _rb.isKinematic = true;

            transform.position = playerPickupTransform.position;
            transform.rotation = playerPickupTransform.rotation;
            transform.parent = playerPickupTransform;
        }
        else
        {
            isPickedUp = false;
            _rb.isKinematic = false;
            transform.SetParent(null);
        }
    }

    public void Activate(bool isActivated)
    {

    }

    public void ChangeColor()
    {
        Color newEmissionColor;
        if(powerLevel <= 0)
        {
            newEmissionColor = Color.black;
        }
        else if(powerLevel < target.requiredPowerLevel * 0.3f)
        {
            newEmissionColor = Color.magenta * 2f;
        }
        else if (powerLevel < target.requiredPowerLevel * 0.6f)
        {
            newEmissionColor = Color.blue * 2f;
        }
        else if (powerLevel < target.requiredPowerLevel)
        {
            newEmissionColor = Color.cyan * 3f;
        }
        else if (powerLevel == target.requiredPowerLevel)
        {
            newEmissionColor = Color.green * 5f;
        }
        else
        {
            newEmissionColor = Color.red * 10f;
        }
        _powerCoreMaterial.SetColor("_EmissionColor", newEmissionColor);
    }
}
