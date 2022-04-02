using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    private Transform player;    
    [SerializeField] private float waitOnAir;
    [SerializeField] private float fallSpeed;
    private static bool isHit = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isHit)
        {
            StartCoroutine(HitUpdate());

            int indexNum = other.transform.GetSiblingIndex() - 3; // playerýn ilk 3 childý iskelet ile alakalý
            int listCount = PlayerMove.instance.cubes.Count; 

            for (int i = indexNum; i < listCount; i++)
            {
                PlayerMove.instance.cubes[indexNum].transform.parent = null;
                PlayerMove.instance.cubes.RemoveAt(indexNum);
            }

            if (PlayerMove.instance.cubes.Count == 0)
            {
                GameManager.instance.isGameOver = true;
                PlayerMove.instance.anim.SetTrigger("GameOver");
                GameManager.instance.FailPanel();
            }
            else
            {
                StartCoroutine(Gravity(listCount - indexNum));
            }           
        }
    }

    private IEnumerator Gravity(int height)
    {
        yield return new WaitForSeconds(waitOnAir);
        player.DOMoveY(PlayerMove.instance.cubes.Count, fallSpeed*height); 
    }

    private IEnumerator HitUpdate()
    {
        isHit = true;
        yield return new WaitForSeconds(1.5f);
        isHit = false;
    }
}
