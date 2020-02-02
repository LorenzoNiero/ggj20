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
        
        this.transform.position += mov3 * Time.deltaTime;

        float v = Mathf.Round(vAxis);
        float h = Mathf.Round(hAxis);

        float angle=90;
        if (v > 0 && h == 0) { angle += 0; } //top
        if (v > 0 && h > 0) { angle += 45; } //top-right
        if (v == 0 && h > 0) { angle += 90; } //right
        if (v < 0 && h > 0) { angle += 135; }  //bot-right
        if (v < 0 && h == 0) { angle += 180; } //bot
        if (v < 0 && h < 0) { angle += 225; } //bot-left
        if (v == 0 && h < 0) { angle += 270; } //bot-left
        if (v > 0 && h < 0) { angle += 315; } //bot-left


        if ( Mathf.Abs(vAxis) > 0 && Mathf.Abs(vAxis) > 0 )
        {
            transform.rotation = Quaternion.Euler(-90, 0, angle);
        }
    }
}
