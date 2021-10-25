using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCone : MonoBehaviour
{
    float t = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += 0.1f;
        this.transform.Translate(0, Mathf.Sin(t) / 300, 0);
    }
}
