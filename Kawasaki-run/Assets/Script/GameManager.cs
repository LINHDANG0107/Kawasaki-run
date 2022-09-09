using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int coins = 0;
    public static int key = 0;
    public TextMeshProUGUI coinText,Key;


    private void Update()
    {
        coinText.text = coins.ToString();
        Key.text = key.ToString();
    }
}
