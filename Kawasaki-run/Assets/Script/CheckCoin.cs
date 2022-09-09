using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CheckCoin : MonoBehaviour
{
    public TextMeshProUGUI Talk;
    public GameObject posKey;
    
    public void Checkcoin()
    {
        if (GameManager.coins == 30)
        {
            GameObject Key= Instantiate(Resources.Load("Key") as GameObject);
            Key.transform.position = posKey.transform.position;
            GameManager.coins = 0;
            Talk.text = "Quần chúng 1: Đổi thành công";
        }
        else if(GameManager.key == 0)
        {
            Talk.text = "Quần chúng 1: Bạn cần có 30 đồng xu. Bạn có chắc đã tìm hết chưa";
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) {
            if (Input.GetKey(KeyCode.E))
            {
                Checkcoin();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Talk.text = "";
        }
    }
}
