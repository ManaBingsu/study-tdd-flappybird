using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V2
{ 
    public interface IInputSystem
    {
        KeyCode SystemResetGameKey { get; }
        KeyCode SystemMenuKey { get; }
    }
}
