using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _isOpen = false;
    private bool _isLocked;
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        if (_anim == null)
            Debug.LogError("Animator not found");
    }

    public void Interact()
    {
        if (!_isLocked)
        {
            _isOpen = !_isOpen;
            _anim.SetBool("IsOpen", _isOpen);

            if(TryGetComponent<SpawnLoot>(out SpawnLoot spawnLoot))
            {
                spawnLoot.isSpawned = true;
            }
        }
    }

    public void Activate(bool isActivated)
    {
        _isLocked = isActivated;
    }
}
