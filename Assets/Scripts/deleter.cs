using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleter : MonoBehaviour
{
    public float TimeDelete;
    void Update()
    {
        TimeDelete += Time.deltaTime;
        if (TimeDelete >= 0.7f)
        {
            Destroy(gameObject);
        }
    }
}
