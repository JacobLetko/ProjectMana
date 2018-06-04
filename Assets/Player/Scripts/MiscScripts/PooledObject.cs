﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    BulletScript bulletScript;
    public float rotationSpeed = 360;
    public float damage;
    public ObjectPool myPool;
    public float evaluationScale = 4;
    public float speed =10;
    public float timeLimmit = 5;
    public float deviation = 1;
    float timer = 0;
    Vector3 deviationVect;
    public AnimationCurve curve;

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
        transform.parent = myPool.transform;
        myPool.pool.Push(gameObject);
        Debug.Log("pushed");
    }

    private void OnEnable()
    {
        curve.postWrapMode = WrapMode.Loop;
        
        deviationVect = new Vector3(Random.Range(-deviation, deviation), Random.Range(-deviation, deviation), Random.Range(-deviation, deviation));
        myPool = FindObjectOfType<ObjectPool>();
        
    }
    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        float offset = curve.Evaluate(Time.time/evaluationScale);
        //Debug.Log(offset);
        if (timer >= timeLimmit)
        {
            timer = 0;
            ReturnToPool();
        }
        transform.Translate(((Vector3.forward + deviationVect) + (Vector3.right * offset)) * speed * Time.deltaTime);
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime, Space.Self);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.transform.tag == "Wall")
        {
            timer = 0;
            ReturnToPool();
        }

        if (collision.collider.GetComponent<AIMovment>() != null)
        {
            timer = 0;
            ReturnToPool();
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.transform.tag == "Wall")
    //    {
    //        timer = 0;
    //        ReturnToPool();
    //    }

    //    if (other.GetComponent<AIMovment>() != null)
    //    {
    //        timer = 0;
    //        ReturnToPool();
    //    }
    //    //else if (other.transform.tag == "Ground") 
    //    //{

    //        //timer = 0;
    //        //returnToPool();
    //    //}
    //}
}