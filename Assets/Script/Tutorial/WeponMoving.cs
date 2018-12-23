using UnityEngine;

public class WeponMoving : MonoBehaviour {

    public Rigidbody2D Player;
    private bool Direction = true;

	// Use this for initialization
	void Start () {
        Player.velocity = new Vector3(5,0,-10);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WeponEnd") {
            if (Direction)
            {
                Player.velocity = new Vector3(-5, 0, -10);
                Direction = false;
            }
            else
            {
                Player.velocity = new Vector3(5, 0, -10);
                Direction = true;

            }
        }
    }
    
}
