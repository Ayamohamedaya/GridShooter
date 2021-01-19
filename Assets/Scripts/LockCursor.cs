using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCursor : MonoBehaviour
{
    private void Start()
    {
        Lock();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Lock();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            unLock();
        }
    }
    public void Lock()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void unLock()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
