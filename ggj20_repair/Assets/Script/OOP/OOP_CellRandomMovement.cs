using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOP_CellRandomMovement : MonoBehaviour
{
    Vector3 DestinationPosition = Vector3.zero;
    float CellQuote = 0;

    void FixedUpdate()
    {
        if (CellQuote == 0) CellQuote = transform.position.y;

        if (DestinationPosition == Vector3.zero)
        {
            DestinationPosition = transform.position + new Vector3(UnityEngine.Random.Range(-10, 10), CellQuote, UnityEngine.Random.Range(-10, 10));
        }
        transform.position = Vector3.Lerp(transform.position, DestinationPosition, Time.deltaTime / 2);

        if ((DestinationPosition - transform.position).magnitude < 1)
        {
            DestinationPosition = Vector3.zero;
        }
    }
}
