using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour {

    public static int Task = 0;
    

    public void WelcomePage() {
        Task = 0;
        PlayerPrefs.SetInt("LastGame_Gold", 0);
        SceneManager.LoadScene(1);
    }

    public void StagePage() {
        Task = 1;
        PlayerPrefs.SetInt("LastGame_Gold", 0);
        if (PlayerPrefs.GetInt("LastLevelPlayed", 1) <= 5)
        {
            SceneManager.LoadScene(5);
        }
        else if (PlayerPrefs.GetInt("LastLevelPlayed", 1) <= 10)
        {
            SceneManager.LoadScene(6);
        }
        else
        {
            SceneManager.LoadScene(7);
        }

        // To make stage as upto how much completed;
        // Default setting as 13;
    }

    public void Stage1Page()
    {
        Task = 1;
        PlayerPrefs.SetInt("LastGame_Gold", 0);
        SceneManager.LoadScene(5);
    }
    public void Stage2Page() {

        Task = 1;
        PlayerPrefs.SetInt("LastGame_Gold", 0);
        SceneManager.LoadScene(6);
    }
    
    public void Stage3Page() {
        Task = 1;
        PlayerPrefs.SetInt("LastGame_Gold", 0);
        SceneManager.LoadScene(7);

    }
    public void Stage4Page() { 

        Task = 1;
        PlayerPrefs.SetInt("LastGame_Gold", 0);
        SceneManager.LoadScene(8);
    }

    public void Level1_1()
    {
        PlayerPrefs.SetInt("LastGame_Gold", 0);
        if (PlayerPrefs.GetInt("IsFirstTime", 0) == 0)
        {
            SceneManager.LoadScene(4);
        }
        else {
            SceneManager.LoadScene(8);
        }
        Task = 2;
    }


    public void Level1_2() {
        Task = 2;
        PlayerPrefs.SetInt("LastGame_Gold", 0);
        SceneManager.LoadScene(9);
    }

    public void Level1_3()
    {
        Task = 2;
        PlayerPrefs.SetInt("LastGame_Gold", 0);
        SceneManager.LoadScene(10);
    }

    public void Level1_4()
    {
        Task = 2;
        PlayerPrefs.SetInt("LastGame_Gold", 0);
        SceneManager.LoadScene(11);
    }

    public void Level1_5()
    {
        PlayerPrefs.SetInt("LastGame_Gold",0);
        Task = 2;
        SceneManager.LoadScene(12);
    }

    public void Level2_1()
    {
        Task = 2;
        PlayerPrefs.SetInt("LastGame_Gold", 0);
        SceneManager.LoadScene(13);
    }


    public void Level2_2()
    {
        Task = 2;
        PlayerPrefs.SetInt("LastGame_Gold", 0);
        SceneManager.LoadScene(14);
    }

    public void Level2_3()
    {
        Task = 2;
        PlayerPrefs.SetInt("LastGame_Gold", 0);
        SceneManager.LoadScene(15);
    }

    public void Level2_4()
    {
        Task = 2;
        PlayerPrefs.SetInt("LastGame_Gold", 0);
        SceneManager.LoadScene(16);
    }

    public void Level2_5()
    {
        PlayerPrefs.SetInt("LastGame_Gold", 0);
        Task = 2;
        SceneManager.LoadScene(17);
    }

    public void Level3_1()
    {
        PlayerPrefs.SetInt("LastGame_Gold", 0);
        Task = 2;
        SceneManager.LoadScene(18);
    }

    public void Level3_2()
    {
        PlayerPrefs.SetInt("LastGame_Gold", 0);
        Task = 2;
        SceneManager.LoadScene(19);
    }

    public void Level3_3()
    {
        PlayerPrefs.SetInt("LastGame_Gold", 0);
        Task = 2;
        SceneManager.LoadScene(20);
    }

    public void Level3_4()
    {
        PlayerPrefs.SetInt("LastGame_Gold", 0);
        Task = 2;
        SceneManager.LoadScene(21);
    }

    public void Level3_5()
    {
        PlayerPrefs.SetInt("LastGame_Gold", 0);
        Task = 2;
        SceneManager.LoadScene(22);
    }
    

    public void StoreShop() {
        Task = 3;
        SceneManager.LoadScene(2);
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (Task == 1) {
                Task = 0;
                SceneManager.LoadScene(1);
            }
            else if (Task == 2) {
                Task = 1;
                StagePage();
            }
            else if (Task==3) {
                Task = 0;
                SceneManager.LoadScene(1);
            }
        }
    }

    public void ReloadScript() {
        SceneManager.LoadScene(((int)PlayerPrefs.GetInt("LastLevelPlayed",0))+7);
    }

}
