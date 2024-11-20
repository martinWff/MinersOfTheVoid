using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    //number
    private int currentPhase = 0;
    private int previousPhase = -1;

    public List<PhaseBase> phases = new List<PhaseBase>();



    void Start()
    {
        ProgressPhase();
    }


    public void ProgressPhase()
    {

        GoToPhase(currentPhase++);

    }

    public void GoToPhase(int phase)
    {
        currentPhase = phase;
        if (currentPhase >= phases.Count)
        {
            currentPhase = 0;
        }

        if (previousPhase > -1 && previousPhase < phases.Count)
        {
            phases[previousPhase].OnPhaseFinished();
        }

        phases[currentPhase].OnPhaseBegan();


        previousPhase = currentPhase;
    }

    public int GetPhase()
    {
        return currentPhase;
    }


    private void Update()
    {
        if (currentPhase >= 0 && currentPhase < phases.Count) {
            PhaseBase b = phases[currentPhase];
            b.OnTick();
        }
    }

    public void Stop()
    {
        if (currentPhase >= 0 && currentPhase < phases.Count)
        {
            PhaseBase b = phases[currentPhase];
            b.OnPhaseFinished();
        }
        currentPhase = -1;

    }



}
