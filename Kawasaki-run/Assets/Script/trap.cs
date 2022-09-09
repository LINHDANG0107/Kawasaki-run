using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    public GameObject posSpawn;
    // T?o m?t gameObject là v? trí mu?n quay l?i
    // kéo obj này vào obj ch?a script này
    PlayerMovement player;
    // PlayerMoverment thay b?ng tên script ?i?u khi?n nhân v?t
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = posSpawn.transform.position;        
        }
    }
}
