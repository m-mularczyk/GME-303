using System.Collections.Generic;
using UnityEngine;

public class PowerReceiver : PowerBase
{
    public int requiredPowerLevel = 50;
    public bool isActivated = false;

    public GameObject[] targets;

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (collision.gameObject.CompareTag("PowerCore"))
        {
            int powerCoreValue = collision.gameObject.GetComponent<PowerCore>().powerLevel;

            if (powerCoreValue == requiredPowerLevel)
            {
                Debug.Log("Sufficient power");
                isActivated = true;

                foreach (GameObject target in targets)
                {
                    if (target.TryGetComponent<IInteractable>(out IInteractable interactable))
                    {
                        interactable.Activate(isActivated);
                    }

                }
            }
            else if (powerCoreValue > requiredPowerLevel)
            {
                Debug.Log("Too much power");
            }
            else
            {
                Debug.Log("Insufficient power");
            }

        }
    }

    public override void OnCollisionExit(Collision collision)
    {
        base.OnCollisionExit(collision);
        if (collision.gameObject.CompareTag("PowerCore"))
        {
            isActivated = false;

            foreach (GameObject target in targets)
            {
                if (target.TryGetComponent<IInteractable>(out IInteractable interactable))
                {
                    interactable.Activate(isActivated);
                }

            }
        }
    }
    
}
