using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour {

    // Use this for initialization
    public int Gold = 150;
    public Text currency;
	
	// Update is called once per frame
	void Update ()
    {
        currency.text = Gold.ToString();

	}
    public void UseMoney(int amount)
    {
        Gold -= amount;
    }
    public void GetMoney(int amount)
    {
        Gold += amount;
    }
}
