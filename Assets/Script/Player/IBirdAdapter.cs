using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bird
{
    public interface IBirdAdapter
    {
        void Initialize();
        Vector2 GetBirdPos();
    }
}
