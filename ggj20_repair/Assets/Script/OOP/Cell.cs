using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int NearBacteriaCount = 0;
    public event System.Action OnCellDestroyed;

    int Life = 100;
    int SecForLife = 1;

    float TimeLeft;

    private void Update()
    {
        TimeLeft += Time.deltaTime;
        if ((TimeLeft - SecForLife) > 0)
        {
            TimeLeft = 0;
            Life -= 5 * NearBacteriaCount;
            if (Life < 0)
            {
                OnCellDestroyed?.Invoke();
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}
