using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{

    public static AdManager adManager;
    private string store_id = "2901449";
    private string Video_Ad = "rewardedVideo";

    private void Awake()
    {
        if (adManager != null)
        {
            Destroy(gameObject);
        }
        else {
            adManager = this;
            DontDestroyOnLoad(adManager);
        }
    }

    // Use this for initialization
    void Start () {

        Advertisement.Initialize(store_id, false);
    }
	

    public void ShowVideoAdFunction()
    {
        if (Advertisement.IsReady(Video_Ad))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            //ShowAdPlacementContent ad = Monetization.GetPlacementContent(Video_Ad) as ShowAdPlacementContent;
            Advertisement.Show(Video_Ad , options);
        }
        else
        {
            print("NoReady");
        }
    }

    private void HandleShowResult(UnityEngine.Advertisements.ShowResult result)
    {
        switch (result)
        {
            case UnityEngine.Advertisements.ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                break;
            case UnityEngine.Advertisements.ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case UnityEngine.Advertisements.ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }

}
