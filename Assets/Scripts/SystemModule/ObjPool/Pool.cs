using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Pool 
{
    [SerializeField]GameObject prefab;
    public GameObject Prefab => prefab;

    Queue<GameObject> queue;

    public int Size => size;
    [SerializeField]int size = 5;
    public int RuntimeSize => queue.Count;

    Transform parent;

    public void Init(Transform parent)
    {
        queue = new Queue<GameObject>();
        this.parent = parent;
        for(var i = 0;i < size; i++)
        {
            queue.Enqueue(Copy());
        }
    }


    GameObject Copy()
    {
        var copy = GameObject.Instantiate(prefab,parent);
        copy.SetActive(false);
        return copy;
    }

    GameObject AvailableObj()
    {
        GameObject availableObj = null;
        if(queue.Count > 0 && !queue.Peek().activeSelf)
        {
            availableObj = queue.Dequeue();
        }
        else
        {
            availableObj = Copy();
        }

        queue.Enqueue(availableObj);

        return availableObj;
    }

    public GameObject GetPreparedObj()
    {
        GameObject obj = AvailableObj();
        obj.SetActive(true);

        return obj;
    }

    public GameObject GetPreparedObj(Vector3 pos)
    {
        GameObject obj = AvailableObj();
        obj.SetActive(true);
        obj.transform.position = pos;
        return obj;
    }

    public GameObject GetPreparedObj(Vector3 pos, Quaternion rot)
    {
        GameObject obj = AvailableObj();
        obj.SetActive(true);
        obj.transform.position = pos;
        obj.transform.rotation = rot;

        return obj;
    }

    public GameObject GetPreparedObj(Vector3 pos, Quaternion rot, Vector3 scale)
    {
        GameObject obj = AvailableObj();
        obj.SetActive(true);
        obj.transform.position = pos;
        obj.transform.rotation = rot;
        obj.transform.localScale = scale;

        return obj;
    }

}
