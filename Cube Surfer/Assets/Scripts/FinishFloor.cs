using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishFloor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stacked"))
        {
            other.transform.parent = null;
            PlayerMove.instance.cubes.Remove(other.gameObject);
            Destroy(other.gameObject, 2f);

            if (PlayerMove.instance.cubes.Count == 0)
            {
                GameManager.instance.isGameWin = true;
                PlayerMove.instance.anim.SetTrigger("GameWin");
                GameManager.instance.WinPanel();
            }
        }
    }
}
