using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform instantiatePoint;
    CustomBullet customBullet;
    bool useImpulse;
    [SerializeField] float offset;
    Ray mousePositio;
    Camera cam;
    
    private void Start()
    {
        cam = Camera.main;
        
    }
    public Vector3 GetBulletDirection()
    {
        mousePositio = cam.ScreenPointToRay(Input.mousePosition);
        float factor = (transform.position.y-mousePositio.origin.y)/mousePositio.direction.y;
        Vector3 target = mousePositio.direction * factor + mousePositio.origin;
        Vector3 targetDir = target - transform.position;
        Debug.DrawLine(transform.position,target,Color.green);
        return targetDir.normalized;
    }
    void Update()
    {
        Vector3 bulletDir = GetBulletDirection();
        if(Input.GetButtonDown("Fire1"))
        {
            if(projectile)
            {
                useImpulse = true;
                GameObject projSpawn = Instantiate(projectile, instantiatePoint.position 
                    + bulletDir*offset, Quaternion.identity);
                projSpawn.GetComponent<CustomBullet>().shoot(useImpulse,bulletDir);
            }
        } 
        if(Input.GetButtonDown("Fire2"))
        {
            if(bullet)
            {
                useImpulse = false;
                GameObject bulletSpawn = Instantiate(bullet, instantiatePoint.position 
                    + bulletDir*offset, Quaternion.identity);
                bulletSpawn.GetComponent<CustomBullet>().shoot(useImpulse,bulletDir);
            }
        }
    }

}
