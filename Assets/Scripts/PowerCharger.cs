using UnityEngine;

public class PowerCharger : PowerBase
{
    public PowerLevel powerLevel;

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (collision.gameObject.CompareTag("PowerCore"))
        {
            powerLevel.Apply(collision);
            collision.gameObject.GetComponent<PowerCore>().ChangeColor();

        }
    }

    public override void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("PowerCore"))
        {
            //
        }
    }

}
