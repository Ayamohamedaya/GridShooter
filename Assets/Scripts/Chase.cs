using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Chase : MonoBehaviour
{
    public float speed = 10f;
    public float minDistance;
    public Transform target;
    public float jumpPower;
    [SerializeField] bool jump;
    bool isGrounded;
    [SerializeField] GameObject enemyExplosion;
    private void Start()
    {
        if (target==null)
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
    }

    private void FixedUpdate()
    {
        if (target == null)
            return;
        transform.LookAt(target);
        if (jump == false)
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (jump == true)
        {

            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if(isGrounded==true)
            {
                isGrounded = false;
                GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Floor"))
        {
            isGrounded = true;
        }
        if(collision.collider.CompareTag("bullet"))
        {
            Instantiate(enemyExplosion, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
