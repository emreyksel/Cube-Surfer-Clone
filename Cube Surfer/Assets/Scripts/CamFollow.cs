using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private Transform target;
    private Vector3 offset;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private float rotateSpeed;


    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;       
    }

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        if (GameManager.instance.isGameOver || !GameManager.instance.isGameStart)
        {
            return;
        }

        if (GameManager.instance.isGameWin)
        {
            transform.RotateAround(target.transform.position, Vector3.up, -rotateSpeed * Time.deltaTime);
        }
        else if (GameManager.instance.isFinish)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * lerpSpeed);
        }

        if (!GameManager.instance.isGameOver && !GameManager.instance.isGameWin)
        {
            transform.Translate(Vector3.forward * PlayerMove.instance.speed * Time.deltaTime, Space.World);
        }        
    }
}
