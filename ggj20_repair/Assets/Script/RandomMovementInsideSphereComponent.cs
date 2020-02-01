using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;
using System.Collections.Generic;

public class RandomMovementInsideSphereComponent : ComponentSystem
{
    Dictionary<Entity, Vector3> NewPositions = new Dictionary<Entity, Vector3>();
    float CellQuote = 0;

    protected override void OnUpdate()
    {
        Entities.WithAll<CellRandomMovement>().ForEach((Entity entity, ref Translation translation) =>
        {
            if (CellQuote == 0) CellQuote = translation.Value.y;
            Vector3 _currentPosition = new Vector3(translation.Value.x, CellQuote, translation.Value.z);
            if (NewPositions.ContainsKey(entity))
            {
                if (NewPositions[entity] == Vector3.zero)
                {
                    NewPositions[entity] = _currentPosition + new Vector3(UnityEngine.Random.Range(-10, 10), CellQuote, UnityEngine.Random.Range(-10, 10));
                }
                translation.Value = Vector3.Lerp(translation.Value, NewPositions[entity], Time.DeltaTime / 2);
            }
            else
            {
                NewPositions[entity] = Vector3.zero;
            }

            if ((NewPositions[entity] - _currentPosition).magnitude < 1)
            {
                NewPositions[entity] = Vector3.zero;
            }
            /*Vector3 _newPosition = translation.Value;
            _newPosition.x += 5 * Time.DeltaTime;
            _newPosition.y = translation.Value.y;
            translation.Value = _newPosition;*/
        });
    }
}
