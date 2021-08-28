using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectionItemController : MonoBehaviour
{
    public GameObject CollectionItemPrefab;
    public GameObject ObstacleItemPrefab;
    public Transform[] CollectionItemRoot;

    public float spawnTime = 1f;

    public UnityEvent TriggerObstacleAction;

    private List<GameObject> collectionItems = new List<GameObject>();
    private List<GameObject> obstacleItems = new List<GameObject>();

    private CooldownTimer cooldownTimer_Collection;
    // Start is called before the first frame update
    void Start()
    {
        cooldownTimer_Collection = new CooldownTimer(spawnTime,true);
        cooldownTimer_Collection.TimerCompleteEvent += SpwanCollectionItem;
        cooldownTimer_Collection.Start();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer_Collection.Update(Time.deltaTime);
    }

    public void SpwanCollectionItem()
    {
        int spwanRootIndex = Random.Range(0, 100);
        if (spwanRootIndex < 20)
        {
            GameObject go = Instantiate(ObstacleItemPrefab, CollectionItemRoot[0]);
            go.GetComponent<ObstacleItem>().onHit = () => { TriggerObstacleAction?.Invoke(); };
            if (go) obstacleItems.Add(go);
        }
        else
        {
            spwanRootIndex = Random.Range(0, 2);
            GameObject go = Instantiate(CollectionItemPrefab, CollectionItemRoot[spwanRootIndex]);
            if (go) collectionItems.Add(go);
        }
    }

    public void SwitchSpawn(bool value)
    {
        if (value)
        {
            cooldownTimer_Collection.Start();
        }
        else
        {
            cooldownTimer_Collection.Pause();
        }

    }
}
