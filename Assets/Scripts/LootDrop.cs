using UnityEngine;

public class LootDrop : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private Vector3 _dropDirection = Vector3.up;
    [SerializeField] private float _force = 5f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (_rb == null)
            Debug.LogError("Rigidbody not found");

        _rb.AddForce(new Vector3(Random.Range(-2f, 2f), _force, Random.Range(-2f, 2f)), ForceMode.Impulse);
        _rb.AddTorque(new Vector3(Random.Range(-0.5f, 0.5f), _force, Random.Range(-0.5f, 0.5f)), ForceMode.Impulse);

    }
}
