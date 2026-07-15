using UnityEngine;
using UnityEngine.InputSystem;

public class Elevator : MonoBehaviour, IInteractable
{
    public bool isPoweredUp = false;
    public bool isCalled = false;
    public float elevatorSpeed = 10.0f;
    private Transform _currentLevel;
    public int _nextLevelIndex;
    public Transform[] elevatorLevels;

    public PlayerInput _playerInput;
    public GameObject _elevatorUI;

    private void Awake()
    {
        _playerInput = GameObject.FindWithTag("Player").GetComponent<PlayerInput>();
        _elevatorUI.SetActive(false);
    }

    private void Update()
    {
        if (isCalled)
        {
            float distance = Vector3.Distance(transform.position, elevatorLevels[_nextLevelIndex].position);
            transform.position = Vector3.MoveTowards(transform.position, elevatorLevels[_nextLevelIndex].position, Time.deltaTime * elevatorSpeed);

            if (distance == 0)
            {
                isCalled = false;
                _nextLevelIndex++;
                if(_nextLevelIndex ==  elevatorLevels.Length)
                {
                    _nextLevelIndex = 0;
                }
            }
        }
    }

    public void Activate(bool isActivated)
    {
        isPoweredUp = isActivated;
        
    }

    public void Interact()
    {
        if (isPoweredUp && !isCalled)
        {
            _elevatorUI.SetActive(true);
            _playerInput.SwitchCurrentActionMap("UI");
            //isCalled = true;
        }
    }

    public void ChooseFloor(int floorValue)
    {
        if (isPoweredUp)
        {
            _nextLevelIndex = floorValue;
            _elevatorUI.SetActive(false);
            _playerInput.SwitchCurrentActionMap("Player");
            isCalled = true;
        }
    }
}
