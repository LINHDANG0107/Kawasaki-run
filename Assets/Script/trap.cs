using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    public GameObject posSpawn;
    // T?o m?t gameObject l� v? tr� mu?n quay l?i
    // k�o obj n�y v�o obj ch?a script n�y
    PlayerMovement player;
    // PlayerMoverment thay b?ng t�n script ?i?u khi?n nh�n v?t
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = posSpawn.transform.position;        
        }
    }
}
