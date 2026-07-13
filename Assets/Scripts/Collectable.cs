using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Interactable lauched by OnTrigerEnter");

            Destroy(gameObject);
        }
    }

}
