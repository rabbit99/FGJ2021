using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionItem : MonoBehaviour
{
    private string name1;
    // Start is called before the first frame update
    void Start()
    {
        name1 = GameConfig.PLAYER_NAME;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(GameConfig.BACK_GROUND_MOVE_SPEED, 0, 0));
    }

   public virtual void Hit(string name)
    {
        Debug.Log("����"+ name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hit(collision.gameObject.name);

        Destroy(this.gameObject);
    }
}
