using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShowStar : MonoBehaviour {

    public TextMeshProUGUI Text;
    
	// Use this for initialization
	void Start () {
        int GoldCount = PlayerPrefs.GetInt("LastGameGold", 0);
        Text.text = GoldCount + "";

        
	}
}
