using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GameManager.instance.isGameStart = true;
            gameObject.SetActive(false);
        }
    }
}
