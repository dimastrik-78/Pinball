using TMPro;
using UnityEngine;

namespace _Source.UISystem
{
    public class GameUIView : MonoBehaviour
    {
        [SerializeField] private GameObject endPanel;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text ballCountText;

        public void End()
        {
            endPanel.SetActive(true);
        }

        public void Score(int score)
        {
            scoreText.text = score.ToString();
        }

        public void BallCount(int count)
        {
            ballCountText.text = count.ToString();
        }
    }
}