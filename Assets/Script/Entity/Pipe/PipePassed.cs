using UnityEngine;

namespace Pipe
{
    public class PipePassed : MonoBehaviour
    {
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PipeManager._instance.PassPipe();
            }
        }
    }
}

