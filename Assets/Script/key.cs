using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class key : MonoBehaviour
{
    public int _rotationSpeed = 70;
    void Update()
    {
        transform.Rotate(_rotationSpeed * Time.deltaTime ,0,0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.key = 1;

            Destroy(gameObject, 0.1f);

        }
    }
}
