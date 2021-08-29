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
            go.transform.Translate(new Vector3(GameConfig.BACK_GROUND_MOVE_SPEED, 0, 0));
            if(go.transform.position.x < -19)
            {
                go.transform.SetPositionAndRotation(new Vector3(38f, go.transform.position.y, 0),Quaternion.identity);

            }
        }
    }
}
