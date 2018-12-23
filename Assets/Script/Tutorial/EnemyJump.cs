using UnityEngine;

public class EnemyJump : MonoBehaviour {

    public Rigidbody2D Player;
    public int Height;

    private void Start()
    {
        Player = GetComponent<Rigidbody2D>();   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Respawn") {
            Player.AddForce(new Vector3(0,Height,0));
        }
        if (collision.gameObject.tag == "Destroy") {
            Player.AddForce(new Vector3(0,Height,0));
        }
        if (collision.gameObject.tag == "Untagged") {
            Player.AddForce(new Vector3(0,Height,0));
        }
    }
}
