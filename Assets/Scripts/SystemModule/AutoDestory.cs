using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestory : MonoBehaviour
{
    WaitForSeconds waitLifeTime;
    [SerializeField] bool destoryGameObj = true;
    [SerializeField] float lifeTime = 3f;
    private void Awake()
    {
        waitLifeTime = new WaitForSeconds(lifeTime);
    }

    private void OnEnable()
    {
        StartCoroutine(DestoryCoroutine());
    }
    IEnumerator DestoryCoroutine()
    {
        yield return waitLifeTime;

        if (destoryGameObj)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
