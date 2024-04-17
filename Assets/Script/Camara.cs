using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject Vikingo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = Vikingo.transform.position.x;
        position.y = Vikingo.transform.position.y;
        transform.position = position;
    }
}
