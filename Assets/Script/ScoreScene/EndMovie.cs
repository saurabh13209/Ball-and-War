using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndMovie : MonoBehaviour {

	void Start () {
        PlayerPrefs.SetInt("IsFirstTime",1);
        StartCoroutine(WaitForEnd());
	}

    IEnumerator WaitForEnd()
    {
        yield return new WaitForSeconds(15);
        SceneManager.LoadScene(1);
    }


}
