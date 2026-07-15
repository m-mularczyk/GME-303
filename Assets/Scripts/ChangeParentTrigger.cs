using UnityEngine;
using Cinemachine;

public class ChangeParentTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCam;
    private Cinemachine3rdPersonFollow _cinemachine3rdPersonController;
    private Vector3 _vCamDamping;
    private Vector3 _elevatorVCamDamping;
    private float _vCamDistance;
    [SerializeField] private float _elevatorVCamDistance;


    private void Start()
    {
        _cinemachine3rdPersonController = _virtualCam.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
        _vCamDamping = _cinemachine3rdPersonController.Damping;
        _elevatorVCamDamping = new Vector3(_vCamDamping.x, 0, _vCamDamping.z);
        _vCamDistance = _cinemachine3rdPersonController.CameraDistance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);

            _cinemachine3rdPersonController.Damping = _elevatorVCamDamping;
            _cinemachine3rdPersonController.CameraDistance = _elevatorVCamDistance;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);

            _cinemachine3rdPersonController.Damping = _vCamDamping;
            _cinemachine3rdPersonController.CameraDistance = _vCamDistance;
        }
    }
}
