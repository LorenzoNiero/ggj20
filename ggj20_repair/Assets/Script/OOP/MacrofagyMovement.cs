using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacrofagyMovement : MonoBehaviour
{
    Vector3 DestinationPosition = Vector3.zero;
    Vector3 Direction = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 3)
        {
            Vector3 positionOffset = Direction - new Vector3(0, 5, 0);
            transform.position -= positionOffset;
        }
        else
        {
            if (DestinationPosition == Vector3.zero)
            {
                DestinationPosition = transform.position + new Vector3(UnityEngine.Random.Range(-10, 10), transform.position.y, UnityEngine.Random.Range(-10, 10));
            }
            transform.position = Vector3.Lerp(transform.position, DestinationPosition, Time.deltaTime / 2);

            if ((DestinationPosition - transform.position).magnitude < 1)
            {
                DestinationPosition = Vector3.zero;
            }
        }
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    void OnCollisionEnter(Collision col)
    {
        Bacteria bacteria = col.transform.GetComponent<Bacteria>();
        if (bacteria != null)
        {
            bacteria.KillMe();
        }
    }
}
