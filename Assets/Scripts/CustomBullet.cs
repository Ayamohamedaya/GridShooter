using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBullet : MonoBehaviour
{
    [SerializeField] float power = 10;
    [SerializeField] float damage=1;
    public void shoot(bool useImpulse,Vector3 dir)
    {
        if(useImpulse)
        gameObject.GetComponent<Rigidbody>().AddForce(dir*power,ForceMode.Impulse);
        else
            gameObject.GetComponent<Rigidbody>().AddForce(dir * power, ForceMode.VelocityChange);

    }
}
