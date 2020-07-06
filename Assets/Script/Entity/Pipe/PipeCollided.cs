using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pipe
{
    public class PipeCollided : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PipeManager._instance.CollidedPipe();
            }
        }
    }
}

