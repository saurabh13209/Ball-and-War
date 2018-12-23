using UnityEngine;
using UnityEngine.SceneManagement;

public class WeponFalling : MonoBehaviour {

    public Rigidbody2D Player;
    public int Height;

    private void Start()
    {
        Player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EndTile")
        {
            Player.gameObject.transform.position = new Vector3(Player.gameObject.transform.position.x, Height, Player.gameObject.transform.position.z);
        }
        if (collision.gameObject.tag == "Player") {
            PlayerPrefs.SetInt("LastGame_Completed", 0);
            SceneManager.LoadScene(3);
        }

    }
}
