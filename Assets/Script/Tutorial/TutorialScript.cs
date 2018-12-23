using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour {

    public int StageNumber;
    public Rigidbody2D Player;

    public GameObject TilesToBlast;
    public GameObject TilesToBlast2;

    private bool PlayerPosition;

    public SpriteRenderer[] Sprites;
    private int Task = 0;

    public GameObject Button;
    


    private void Start()
    {
        PlayerPosition = false;
    }


    void Update () {
        if (StageNumber == 1) {
            if (PlayerPosition && Task ==0)
            {
                StartCoroutine(WaitForSec(Sprites[0], Sprites[1]));
            }
            if (PlayerPosition && Task == 1) {
                StartCoroutine(WaitForSec(Sprites[1], Sprites[2]));
            }
            if (TilesToBlast == null ) {
                StartCoroutine(WaitForSec(Sprites[2], Sprites[3]));
            }

            if (TilesToBlast2 == null)
            {
                StartCoroutine(WaitForSec(Sprites[3], Sprites[4]));
            }
            
        }

        if (StageNumber == 3) {
            if (TilesToBlast == null && Task==0) {
                StartCoroutine(CountImage());
            }
        }
    }


    IEnumerator CountImage() {
        yield return new WaitForSeconds(1);
        Sprites[0].gameObject.SetActive(false);
        Sprites[1].gameObject.SetActive(true);
        StartCoroutine(CountImage1());
        Task++;
    }

    IEnumerator CountImage1()
    {
        yield return new WaitForSeconds(3);
        Sprites[1].gameObject.SetActive(false);
        Sprites[2].gameObject.SetActive(true);
        StartCoroutine(CountImage2());
    }


    IEnumerator CountImage2()
    {
        yield return new WaitForSeconds(8);
        Sprites[2].gameObject.SetActive(false);
        Sprites[3].gameObject.SetActive(true);
        StartCoroutine(CountImage3());
    }


    IEnumerator CountImage3()
    {
        yield return new WaitForSeconds(3);
        Sprites[3].gameObject.SetActive(false);
        Sprites[4].gameObject.SetActive(true);
        StartCoroutine(CountImage4());
    }

    IEnumerator CountImage4()
    {
        yield return new WaitForSeconds(10);
        Sprites[4].gameObject.SetActive(false);
        Sprites[5].gameObject.SetActive(true);
        StartCoroutine(CountImage5());
    }

    IEnumerator CountImage5()
    {
        yield return new WaitForSeconds(8);
        Sprites[5].gameObject.SetActive(false);
        Sprites[6].gameObject.SetActive(true);
        StartCoroutine(CountImage6());
    }


    IEnumerator CountImage6()
    {
        yield return new WaitForSeconds(3);
        Sprites[6].gameObject.SetActive(false);
        Sprites[7].gameObject.SetActive(true);
        StartCoroutine(CountImage7());
    }


    IEnumerator CountImage7()
    {
        yield return new WaitForSeconds(4);
        Sprites[7].gameObject.SetActive(false);
    }

    IEnumerator WaitForSec(SpriteRenderer WorkingSprite , SpriteRenderer NextSprite)
    {
        yield return new WaitForSeconds(1);
        WorkingSprite.gameObject.SetActive(false);
        NextSprite.gameObject.SetActive(true);
        Task++;
    }

    public void SetPlayerPosition(bool Direction) {
        print(Direction);
        PlayerPosition = Direction;
        Button.gameObject.SetActive(false);
    }
}
