using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMov : MonoBehaviour
{
    public Transform[] Pose;
    public float speed;
    public int ID;
    public int Suma;
    // Start is called before the first frame update
    void Start()
    {
      transform.position = Pose[0].position;  
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == Pose[ID].position){
            ID += Suma;
        }

        if(ID == Pose.Length-1)
        {
            Suma = -1;
        }
        if(ID == 0){
            Suma = 1;
        }
        transform.position = Vector3.MoveTowards(transform.position, Pose[ID].position, speed * Time.deltaTime);
    }
}
