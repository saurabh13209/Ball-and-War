using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StoryMode : MonoBehaviour {

	void Start () {
        PlayerPrefs.SetInt("IsFirstTime",1);
        StartCoroutine(WaitForEnd());
	}

    IEnumerator WaitForEnd()
    {
        yield return new WaitForSeconds(54);
        SceneManager.LoadScene(8);
    }


}
