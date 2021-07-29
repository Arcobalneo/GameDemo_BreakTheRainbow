using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRoller : MonoBehaviour
{
    [SerializeField] Vector2 rollVelocity;
    Material material;
    
    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += rollVelocity * Time.deltaTime;
    }
}
