using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{

    public float speed;
    public Vector3 directionVector = Vector3.up;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 mov3 = new Vector3(hAxis * speed, 0 , vAxis * speed);
        
        this.transform.position += mov3 * Time.deltaTime ;
        //transform.rotation = Quaternion.LookRotation(new Vector3(hAxis, 0, vAxis).normalized);

    }
}
