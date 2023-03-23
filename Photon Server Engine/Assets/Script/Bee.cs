using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    private Vector3 direction;
    private GameObject target;
    private float speed = 5.0f;

    private void Start()
    {
        target = GameObject.Find("Character(Clone)");

        direction = target.transform.position - transform.position;
        transform.LookAt(target.transform);
    }

    private void Update()
    {
        transform.position += direction.normalized * speed * Time.deltaTime;   
    }
}
