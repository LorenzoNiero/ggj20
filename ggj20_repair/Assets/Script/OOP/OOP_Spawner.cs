using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOP_Spawner : MonoBehaviour
{
    [SerializeField] Camera MainCamera;
    [Header("Cell")]
    [SerializeField] GameObject CellPref;
    [SerializeField] int CellCounts = 2;
    [SerializeField] int CellDistanceToCamera = 100;
    [SerializeField] Transform CellParent;
    [Header("Bacteria")]
    [SerializeField] GameObject BacteriaPref;
    [SerializeField] int BacteriaCount;
    [SerializeField] int BacteriaDistanceToCamera = 80;
    [SerializeField] Transform BacteriaParent;


    // Start is called before the first frame update
    void Start()
    {
        for (var x = 0; x < CellCounts; x++)
        {
            var instance = GameObject.Instantiate(CellPref, CellParent);

            var r1 = UnityEngine.Random.value;
            var r2 = UnityEngine.Random.value;
            var _posXZ = MainCamera.ViewportToWorldPoint(new Vector3(r1, r2, CellDistanceToCamera));
            instance.transform.position = _posXZ ;

            var _rotx = UnityEngine.Random.Range(0, 20);
            var _rotY = UnityEngine.Random.Range(0, 360);
            var _rotz = UnityEngine.Random.Range(0, 20);
            instance.transform.rotation = Quaternion.Euler(_rotx, _rotY, _rotz);
        }

        for (var x = 0; x < BacteriaCount; x++)
        {

            var instance = GameObject.Instantiate(BacteriaPref, BacteriaParent);

            int area = Random.Range(0, 4);

            Vector2 pos = Vector2.zero;
            if (area == 0)
            {
                pos.x += Random.Range(1, 1.5f);
                pos.y += Random.Range(0,1.0f);
            }
            if (area == 1)
            {
                pos.x += Random.Range(0,1.0f);
                pos.y += Random.Range(0, -0.5f);
            }
            if (area == 2)
            {
                pos.x += Random.Range(0,-0.5f);
                pos.y += Random.Range(0,1.0f);
            }
            if (area == 3)
            {
                pos.x += Random.Range(0,1.0f);
                pos.y += Random.Range(1, 1.5f);
            }
            var _posXZ = MainCamera.ViewportToWorldPoint(new Vector3(pos.x, pos.y, BacteriaDistanceToCamera));
            instance.transform.position = _posXZ = _posXZ ;
        }
    }


}
