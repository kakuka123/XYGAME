using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Coin : MonoBehaviour
{
    public int getcoin;//初始金币
    public TextMeshProUGUI coinnum;//金币显示
    public static int cur_coin;//当前金币
    // Start is called before the first frame update
    void Start()
    {
        cur_coin = getcoin;
    }

    // Update is called once per frame
    void Update()
    {
        coinnum.text = cur_coin.ToString();
    }
}
