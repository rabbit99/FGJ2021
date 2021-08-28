using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoodyGirlfriend : MonoBehaviour
{
    public GameObject poorYou;
    public float followSpeed;

    Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        if (!poorYou) poorYou = GameObject.Find("Player");
        distance = transform.position - poorYou.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //float interpolatedPosition = Mathf.Lerp(poorYou.transform.position.y, this.transform.position.y, Time.deltaTime * followSpeed);
        //this.transform.SetPositionAndRotation(new Vector3(transform.position.x, interpolatedPosition, 0), Quaternion.identity);
        this.transform.position = Vector3.Lerp(transform.position, poorYou.transform.position + distance, followSpeed);

    }

    private void FixedUpdate()
    {

    }
}
