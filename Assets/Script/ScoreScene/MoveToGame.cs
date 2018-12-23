using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToGame : MonoBehaviour {

	void Start () {
        StartCoroutine(Shift());	
	}

    IEnumerator Shift() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
}
