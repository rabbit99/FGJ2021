using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    public GameObject[] backGrounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var go in backGrounds)
        {
            go.transform.Translate(new Vector3(-1, 0, 0));
        }
    }
}
