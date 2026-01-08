using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 moveOffset;
    private Vector3 startPos;
    private Vector3 targetPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        targetPos = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if(transform.position == targetPos)
        {
            if(targetPos == startPos)
            {
                targetPos = startPos + moveOffset;
            } 
            else
            {
                targetPos = startPos;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().GameOver();
        }
    }
}
