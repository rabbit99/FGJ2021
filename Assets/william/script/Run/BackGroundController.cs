using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    public GameObject[] backGrounds;
    public float back_ground_move_speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var go in backGrounds)
        {
            go.transform.Translate(new Vector3(back_ground_move_speed, 0, 0));
            if(go.transform.position.x < -27)
            {
                go.transform.SetPositionAndRotation(new Vector3(53.8f,0,0),Quaternion.identity);
            }
        }
    }
}
