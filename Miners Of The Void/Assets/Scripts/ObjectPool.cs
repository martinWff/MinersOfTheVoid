using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Queue<GameObject> queue;
    public GameObject replicate;
    public int capacity = 15;
    // Start is called before the first frame update
    void Start()
    {
        queue = new Queue<GameObject>();
        for (int i = 0; i < capacity; i++)
        {
            GameObject copy = Instantiate(replicate, transform);
           copy.AddComponent<PoolElementBehaviour>().pool = this;
           queue.Enqueue(copy);
        }
    }

    public GameObject GetBullet()
    {
        GameObject element = queue.Dequeue()?.Data;
        element.transform.SetParent(null);
        element.SetActive(true);
        return element;
    }


    public void RetrieveBullet(GameObject element)
    {
        queue.Enqueue(element);
        element.SetActive(false);
        element.transform.SetParent(transform);
    }
}
