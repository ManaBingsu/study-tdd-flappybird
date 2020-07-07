using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;

namespace Pipe
{
    public class PipeCollided : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameManager._instance.SetState(SystemDefine.EGameState.Fall);
            }
        }
    }
}

