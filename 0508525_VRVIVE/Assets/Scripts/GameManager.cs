using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class GameManager : MonoBehaviour
{
    [Header("躲避球數量")]
    public Text textBallCount;
    [Header("分數")]
    public Text textScore;
    [Header("一分音效")]
    public AudioClip soundone;
    [Header("三分音效")]
    public AudioClip soundthree;

    public AudioSource aud;
    int ballCount = 5;
    public static int score;

    private ThreePoint threePoint;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
        threePoint = FindObjectOfType<ThreePoint>();
    }
    public void UseBall(GameObject ball)
    {
        Destroy(ball.GetComponent<Throwable>());
        Destroy(ball.GetComponent<Interactable>());

        ballCount--;

        textBallCount.text = "躲避球數量：" + ballCount + " / 5";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="enemy")
        if(threePoint.inThreePoint)
        {
            score += 3;
            aud.PlayOneShot(soundthree, 1.5f);
        }
        else
        { 
            score += 1;
            aud.PlayOneShot(soundone, 1.5f);
        }
        textScore.text = "分數：" + score;
    }

    public void Replay()
    {
        Destroy(FindObjectOfType<Player>().gameObject);
        SceneManager.LoadScene("躲避球");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
