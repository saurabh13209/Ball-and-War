using UnityEngine;

public class BulletMove : MonoBehaviour {

    public Vector2 speed;
    Rigidbody2D rigidbody;
    public float DestroyDelay;
    public GameObject Fire;

    public PlayerMove GetDataIndex;

    void Start () {
        GetDataIndex = GameObject.FindObjectOfType<PlayerMove>();
        Fire.transform.localScale = new Vector3(GetDataIndex.GetBombIndex()[0], GetDataIndex.GetBombIndex()[1], GetDataIndex.GetBombIndex()[2]);
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = speed;
        Destroy(gameObject , DestroyDelay);
	}
	
	void Update () {
        rigidbody.velocity = speed;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Instantiate(Fire, collision.transform.position, transform.rotation = Quaternion.identity);

        if (collision.gameObject.tag  == "Enemy") {
            Destroy(collision.gameObject);
            //BombText.text = (int.Parse(BombText.text) - 1).ToString();
            FindObjectOfType<AudioManager>().Play("BombBlast");
            PlayerPrefs.SetInt("TotalKillerBomb", PlayerPrefs.GetInt("TotalKillerBomb") - 1);
        }

        
    }
}
