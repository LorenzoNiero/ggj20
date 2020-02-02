using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOP_PlayerMacrofagySpawner : MonoBehaviour
{
    [SerializeField] GameObject MacrofagyGO;
    public void SpawnMacrofagy(Vector3 direction)
    {
        GameObject temp = GameObject.Instantiate(MacrofagyGO, transform.position, Quaternion.identity);
        MacrofagyMovement component = temp.GetComponent<MacrofagyMovement>();
        component.SetDirection(direction);
    }

    public void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Camera.main.WorldToScreenPoint(transform.position));
            SpawnMacrofagy(ray.direction);
        }
    }
}
