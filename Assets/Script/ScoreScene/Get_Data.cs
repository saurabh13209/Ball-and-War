using UnityEngine;
using TMPro;

public class Get_Data : MonoBehaviour {

    public TextMeshProUGUI GoldCountText;
    public bool Task;
    public static bool Once = true;
    

    private void Start()
    {
        if (!Task)
        {
            LoadGold();
        }
        else {
            ShowGold();
        }
    }

    public void ShowGold()
    {
        int GameGold = PlayerPrefs.GetInt("TotalCoin", 0);
        
        GoldCountText.text = GameGold.ToString();
    }

    public void LoadGold() {
        if (Once ==false) {
            Once = true;
            return;
        }
        Once = false;
        int LastGameGold = PlayerPrefs.GetInt("LastGame_Gold",0);
        print(PlayerPrefs.GetInt("LastGame_Gold", 0));
        GoldCountText.text = LastGameGold.ToString();

        PlayerPrefs.SetInt("Total_Gold",PlayerPrefs.GetInt("Total_Gold",0)+PlayerPrefs.GetInt("LastGame_Gold",0));
        PlayerPrefs.SetInt("Total_Bomb",PlayerPrefs.GetInt("Total_Bomb",0)+(PlayerPrefs.GetInt("LastGame_ProvidedBomb",0) - PlayerPrefs.GetInt("LastGame_Bomb",0)));

        print("s");

    }
}
