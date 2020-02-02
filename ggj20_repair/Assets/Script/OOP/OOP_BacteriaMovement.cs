using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOP_BacteriaMovement : MonoBehaviour
{
    Vector3 DestinationPosition = Vector3.zero;
    float BacteriaQuote = 0;

    bool MustStop = false;

    // Update is called once per frame
    void Update()
    {
        if (!MustStop)
        {
            if (BacteriaQuote == 0) BacteriaQuote = transform.position.y;


            if (DestinationPosition == Vector3.zero)
            {
                DestinationPosition = new Vector3(0, BacteriaQuote, 0);
            }
            transform.LookAt(DestinationPosition);
            transform.position = Vector3.Lerp(transform.position, DestinationPosition, Time.deltaTime / 20);

            if ((DestinationPosition - transform.position).magnitude < 1)
            {
                DestinationPosition = Vector3.zero;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Cell cell = col.transform.GetComponent<Cell>();
        if (cell.NearBacteriaCount < 3)
        {
            cell.OnCellDestroyed += () => { MustStop = false; };
            cell.NearBacteriaCount++;
            MustStop = true;
        }      
    }
}
