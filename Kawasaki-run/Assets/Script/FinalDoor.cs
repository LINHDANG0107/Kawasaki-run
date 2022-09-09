using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoor : MonoBehaviour
{
    public TextMeshProUGUI Talk;
    public GameObject anim;
    public AudioSource audioData;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (GameManager.key == 1)
                {
                    audioData.Play();
                    
                    StartCoroutine(Waiting());
                }
                else
                {
                    Talk.text = "Cửa: Tìm chìa khóa đi";
                }

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
    IEnumerator Waiting()
    {
        anim.GetComponent<Animator>().SetBool("Open",true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Win");
    }
}
