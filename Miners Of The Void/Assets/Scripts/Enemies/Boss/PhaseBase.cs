using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PhaseBase : MonoBehaviour
{
    public abstract void OnPhaseBegan();

    public abstract void OnTick();

    public abstract void OnPhaseFinished();
}
