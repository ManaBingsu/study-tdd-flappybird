using GameSystem;
using UnityEngine;

namespace Pipe
{
    public class PipePassed : MonoBehaviour
    {
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("get");
                int currentScore = ScoreManager._instance.GetCurrentScore();
                ScoreManager._instance.SetCurrentScore(currentScore + 1);
            }
        }
    }
}

