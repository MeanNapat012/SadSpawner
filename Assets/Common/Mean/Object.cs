using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    
    void Update()
    {
        transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
    }
    
}
