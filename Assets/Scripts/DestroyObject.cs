using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
 [SerializeField]   float destroyTime = 1f;
    private void Awake()
    {
        DestroyProjectile();
    }
    public void DestroyProjectile()
    {
        Destroy(gameObject,destroyTime);
    }
}
