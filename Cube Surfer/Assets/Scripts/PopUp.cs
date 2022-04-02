using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Vector3.forward * PlayerMove.instance.speed * Time.deltaTime, Space.World);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
