using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : MonoBehaviour
{
    public void KillMe()
    {
        GameObject.Destroy(this);
    }
}
