using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LockStage : MonoBehaviour {

    public int LevelNumber;
    public GameObject[] LockBord;
    public Sprite NoStarPoint ,  OneStarPoint , TwoStarPoint , ThreeStarPoint ;

    private void Start()
    {
        int i = 0;
        for (i=0; i<5; i++) {
            int temp = (LevelNumber * 5) + i + 1;
            LockBord[i].GetComponent<Image>().sprite = NoStarPoint;
            if (PlayerPrefs.GetInt("Level_" + temp, 0) == 0) {
                LockBord[i].GetComponent<Image>().sprite = NoStarPoint;
                temp--;
                if ((PlayerPrefs.GetInt("Level_"+temp,0)!=0) || ++temp == 1)
                {
                    i++;
                }
                break;
            }

            if (PlayerPrefs.GetInt("Level_" + temp, 0) == 1)
            {
                LockBord[i].GetComponent<Image>().sprite = TwoStarPoint;
               // LockBord[i].GetComponent<Button>().onClick = null;
            }
            else if (PlayerPrefs.GetInt("Level_" + temp, 0) >= 2)
            {
                LockBord[i].GetComponent<Image>().sprite = ThreeStarPoint;
                //LockBord[i].GetComponent<Button>().onClick = null;
            }
            

        }

        for (i=i ; i<5; i++) {
            LockBord[i].GetComponent<Button>().onClick = null;
        }
        
    }
}
