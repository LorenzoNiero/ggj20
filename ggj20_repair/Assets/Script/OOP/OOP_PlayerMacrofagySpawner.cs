using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOP_PlayerMacrofagySpawner : MonoBehaviour
{
    [SerializeField] GameObject MacrofagyGO;
    public void SpawnMacrofagy()
    {
        GameObject temp = GameObject.Instantiate(MacrofagyGO, transform.position, Quaternion.identity);
        MacrofagyMovement component = temp.GetComponent<MacrofagyMovement>();
        component.SetDirection();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SpawnMacrofagy();
        }
    }
}
