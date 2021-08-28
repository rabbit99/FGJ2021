using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionItemController : MonoBehaviour
{
    public GameObject CollectionItemPrefab;
    public Transform[] CollectionItemRoot;

    public float spawnTime = 1f;

    private List<GameObject> collectionItems = new List<GameObject>();
    private CooldownTimer cooldownTimer;
    // Start is called before the first frame update
    void Start()
    {
        cooldownTimer = new CooldownTimer(spawnTime,true);
        cooldownTimer.TimerCompleteEvent += SpwanCollectionItem;
        cooldownTimer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer.Update(Time.deltaTime);
    }

    public void SpwanCollectionItem()
    {
        int spwanRootIndex = Random.Range(0, 2);
        GameObject go = Instantiate(CollectionItemPrefab, CollectionItemRoot[spwanRootIndex]);
        if (go) collectionItems.Add(go);
    }

    public void SwitchSpawn(bool value)
    {
        if (value)
        {
            cooldownTimer.Start();
        }
        else
        {
            cooldownTimer.Pause();
        }

    }
}
