using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject CellPref;
    [SerializeField] int CellCounts = 2;
    [SerializeField] Camera MainCamera;
    [SerializeField] int DistanceToCamera = 100;

    void Start()
    {
        // Create entity prefab from the game object hierarchy once
        var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
        var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(CellPref, settings);
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        for (var x = 0; x < CellCounts; x++)
        {
            // Efficiently instantiate a bunch of entities from the already converted entity prefab
            var instance = entityManager.Instantiate(prefab);

            var r1 = UnityEngine.Random.value;
            var r2 = UnityEngine.Random.value;
            var _posXZ = MainCamera.ViewportToWorldPoint(new Vector3(r1 , r2, DistanceToCamera));
            entityManager.SetComponentData(instance, new Translation { Value = _posXZ });

            var _rotx = UnityEngine.Random.Range(0, 20);
            var _rotY = UnityEngine.Random.Range(0, 360);
            var _rotz = UnityEngine.Random.Range(0, 20);
            entityManager.SetComponentData(instance, new Rotation { Value = Quaternion.Euler(_rotx, _rotY, _rotz) });
        }
    }
}
