using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Coin : MonoBehaviour
{
    public int getcoin;//��ʼ���
    public TextMeshProUGUI coinnum;//�����ʾ
    public static int cur_coin;//��ǰ���
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
