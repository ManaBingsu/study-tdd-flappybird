using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pipe
{
    public interface IPipeAdapter
    {
        void Initialize();
        Vector2 GetPipePos();
    }
}
