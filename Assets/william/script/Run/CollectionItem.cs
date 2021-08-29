using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionItem : MonoBehaviour
{
    public delegate void OnHit();
    public OnHit onHit;
    public GameObject hitEffect;
    public Transform hitEffectRoot;
    private string name1;
    // Start is called before the first frame update
    void Start()
    {
        name1 = GameConfig.PLAYER_NAME;
        Invoke("Recycle", 15);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(GameConfig.BACK_GROUND_MOVE_SPEED, 0, 0));
    }

   public virtual void Hit(string name)
    {
        Debug.Log("¼²¨ì"+ name);
        switch (name)
        {
            case "Player":
                if (hitEffect)
                {
                    GameObject go = Instantiate(hitEffect);
                    go.transform.position = hitEffectRoot.position;
                }
                onHit();
     
                break;
            case "GirlFriend":
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hit(collision.gameObject.name);

        Destroy(this.gameObject);
    }

    private void Recycle()
    {
        Destroy(this.gameObject);
    }
}
