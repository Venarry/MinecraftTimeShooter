using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempObject : MonoBehaviour
{
    private float _timeToDeath;

    private void Update()
    {
        _timeToDeath += Time.deltaTime;
        if (_timeToDeath >= 6)
        {
            Destroy(gameObject);
        }
    }
}
