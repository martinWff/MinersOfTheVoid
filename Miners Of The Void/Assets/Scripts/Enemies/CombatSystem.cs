using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class CombatSystem
{
    public static Action<string,bool> onDied;

    public static Action<float,string,bool> onDamageDealt;
}
