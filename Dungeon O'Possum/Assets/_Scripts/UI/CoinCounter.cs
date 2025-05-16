using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;

    void Update()
    {
        if (Inventory.instance != null)
        {
            coinText.text = Inventory.instance.GetNewCoinCount().ToString();
        }
    }
}
