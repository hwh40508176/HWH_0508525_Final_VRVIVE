using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class GameManager : MonoBehaviour
{
    [Header("躲避球數量")]
    public Text textBallCount;
    [Header("分數")]
    public Text textScore;

    int ballCount = 5;
    int score;

    public void UseBall(GameObject ball)
    {
        Destroy(ball.GetComponent<Throwable>());
        Destroy(ball.GetComponent<Interactable>());

        ballCount--;

        textBallCount.text = "躲避球數量：" + ballCount + " / 5";
    }

    private void OnTriggerEnter(Collider other)
    {
        score += 2;
        textScore.text = "分數：" + score;
    }

}

