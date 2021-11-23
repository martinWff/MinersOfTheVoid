using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Queue<GameObject> queue;
    public GameObject replicate;
    public int capacity = 30;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        queue = new Queue<GameObject>();
        for (int i = 0; i < capacity; i++)
        {
            //if(queue.Count < 30)
            //{
                GameObject copy = Instantiate(replicate, transform);
                copy.AddComponent<PoolElementBehaviour>().pool = this;
                queue.Enqueue(copy);
            //}
           
        }
    }

    public GameObject GetBullet()
    {
        if (queue.Count > 0)
        {
            GameObject element = queue.Dequeue()?.Data;
            if (element != null)
            {
                element.transform.SetParent(null);
                element.SetActive(true);
            }
            return element;
        }
        return null;
    }


    public void RetrieveBullet(GameObject element)
    {
        queue.Enqueue(element);
        element.SetActive(false);
        element.transform.SetParent(transform);
    }

    public int CountBullets()
    {
        return queue.Count;
    }

    
}
