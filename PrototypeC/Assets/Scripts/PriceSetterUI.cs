using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PriceSetterUI : MonoBehaviour
{
    TextMeshProUGUI text;
    public ItemData objectSelling;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.transform.Find("BuyButton").transform.Find("Price").gameObject.GetComponent<TextMeshProUGUI>();
        text.text = objectSelling.costToBuyFromNPC.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
