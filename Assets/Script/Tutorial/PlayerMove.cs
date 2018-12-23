using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class PlayerMove : MonoBehaviour {

    public Rigidbody2D Player;
    bool wasWalking = false;
    public int Speed;
    public int Height;
    public int JumpHeight;
    public int StageNumber;
    public bool isGameRunning = true;

    // public changeWepon MenuControl;

    public TextMeshProUGUI GoldText;
    public TextMeshProUGUI BombText;
    public TextMeshProUGUI BulletText;
    public int BombProvided;
    public int BulletProvided;
    public GameObject Fire;
    private Transform FireTransform;

    public float FireX, FireY, FireZ, BulletX, BulletY, BulletZ;

    public GameObject LeftBullet;
    public GameObject RightBullet;
    
    private bool isOne = true;

    private List<GameObject> CollisionList =  new List<GameObject>();

    private void Start()
    {
        PlayerPrefs.SetInt("LastLevelPlayed", StageNumber);
        GoldText = GameObject.Find("GoldText").GetComponent<TextMeshProUGUI>();
        BombText = GameObject.Find("BombText").GetComponent<TextMeshProUGUI>();
        BulletText = GameObject.Find("BulletText").GetComponent<TextMeshProUGUI>();

        Fire.transform.localScale = new Vector3(FireX, FireY, FireZ);
        RightBullet.transform.localScale = new Vector3(BulletX, BulletY, BulletZ);
        LeftBullet.transform.localScale = new Vector3(BulletX, BulletY, BulletZ);


        Player = GetComponent<Rigidbody2D>();
        GoldText.text = "0";
        BombText.text = BombProvided.ToString();
        BulletText.text = BulletProvided.ToString();

    }

    public float[] GetBombIndex() {
        float[] BombIndex = { FireX, FireY, FireZ };
        return BombIndex;
    }

    public void OffGameRunning() {
        isGameRunning = false;
    }

    public void OnGameRunning()
    {
        isGameRunning = true;
    }

    // Update is called once per frame
    void Update() {

        if (Input.touchCount > 0 && isGameRunning)
        {
            Collider2D collider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position));
            if (collider != null)
            {
                if (collider.tag == "Untagged" || collider.tag == "Finish" || collider.tag == "Coin" || 
                    collider.tag == "Wepon" || collider.tag == "WeponEnd" || collider.tag == "SelfDestroy" || collider.tag == "Water") {
                    MovePlayer();
                }
                if (collider.tag == "Destroy" && int.Parse(BombText.text) > 0)
                {
                    Instantiate(Fire, collider.transform.position, transform.rotation = Quaternion.identity);
                    Destroy(collider.gameObject);
                    BombText.text = (int.Parse(BombText.text) - 1).ToString();
                    FindObjectOfType<AudioManager>().Play("BombBlast");


                }

                if (collider.tag == "Enemy" && (int.Parse(BulletText.text) > 0) && isOne)
                {
                    FindObjectOfType<AudioManager>().Play("Missle");
                    BulletText.text = (int.Parse(BulletText.text) - 1).ToString();
                    if (collider.transform.position.x > Player.transform.position.x)
                    {
                        Instantiate(RightBullet, new Vector3(Player.position.x + 2, Player.position.y, 30), transform.rotation = Quaternion.identity);
                    }
                    else {
                        Instantiate(LeftBullet, new Vector3(Player.position.x - 2, Player.position.y, 30), transform.rotation = Quaternion.identity);
                    }
                    isOne = false;

                }
            }
            else
            {
                MovePlayer();
            }
        }
        else
        {
            isOne = true;
            if (wasWalking) {
                Player.velocity = new Vector3(0, 0, 0);
                wasWalking = false;
            }
        }

    }

    private void MovePlayer() {
        if (Input.GetTouch(0).position.x > Screen.width / 2)
        {
            //Player.velocity = new Vector3(300*Time.deltaTime , Player.velocity.y , -10);
            Player.AddForce(new Vector3(Speed * Time.deltaTime, 0, 0));
            print("Player Move : " + Player.transform.position);
        }
        else
        {
            //Player.velocity = new Vector3(-300 * Time.deltaTime, Player.velocity.y, -10);
            Player.AddForce(new Vector3(x: -Speed * Time.deltaTime, y: 0, z: 0));
        }
        wasWalking = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            PlayerPrefs.SetInt("Level_" + StageNumber, int.Parse(GoldText.text));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.gameObject.CompareTag("EndTile")) {
            Player.gameObject.transform.position = new Vector3(Player.gameObject.transform.position.x, Height, Player.gameObject.transform.position.z);
            Player.drag = 5;
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            PlayerPrefs.SetInt("LastGameGold", int.Parse(GoldText.text));
            PlayerPrefs.SetInt("LastGame_Completed", 0);
            StartCoroutine(ClassAd());
           // SceneManager.LoadScene(3);
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin", 0) + 1);
            GoldText.text = (int.Parse(GoldText.text) + 1).ToString();
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Untagged") || collision.gameObject.CompareTag("Destroy") || collision.gameObject.CompareTag("Respawn")) {
            Player.drag = 0;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerPrefs.SetInt("LastGameGold", int.Parse(GoldText.text));
            PlayerPrefs.SetInt("LastGame_Completed", 0);
            StartCoroutine(ClassAd());
            //SceneManager.LoadScene(3);
        }

        if (collision.gameObject.CompareTag("Respawn")) {
            print(Player.velocity.y);
            if (Player.velocity.y <1) {
                Player.AddForce(new Vector3(0, JumpHeight, 0));
            }
             
        }

        if (collision.gameObject.CompareTag("Wepon"))
        {
            PlayerPrefs.SetInt("LastGameGold", int.Parse(GoldText.text));
            StartCoroutine(ClassAd());
        }
        if (collision.gameObject.CompareTag("SelfDestroy")) {
            StartCoroutine(DestroyTile(collision));
        }
    }

    
    IEnumerator ClassAd() {
        yield return new WaitForSeconds(.1f);
        FindObjectOfType<AdManager>().ShowVideoAdFunction();
        SceneManager.LoadScene(3);

    }




    IEnumerator DestroyTile(Collision2D collision) {
        yield return new WaitForSeconds(.2f);
        Instantiate(Fire, collision.transform.position, transform.rotation = Quaternion.identity);
        Destroy(collision.gameObject);
        FindObjectOfType<AudioManager>().Play("BombBlast");

    }


}
