using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerCamra : MonoBehaviour
{
    GameObject player;
    public void LookAtPlayer()
    {
        player = GameObject.FindWithTag("Player"); 
        GetComponent<CinemachineVirtualCamera>().Follow=player.transform;
    }
}
