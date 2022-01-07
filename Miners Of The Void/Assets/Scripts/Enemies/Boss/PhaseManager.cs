using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    //number
    private int randomNumber = 0;
    private int previousPhase = 0;

    //phases
    public PhaseI phaseI;
    public PhaseII phaseII;
    public PhaseIII phaseIII;



    void Start()
    {
        RandomNumber();
    }


    public void RandomNumber()
    {
        if (previousPhase == 1) phaseI.PhaseEnd();
        if (previousPhase == 2) phaseII.PhaseEnd();
        if (previousPhase == 3) phaseIII.PhaseEnd();

        randomNumber++;
        Debug.Log("Random number " + randomNumber);


        if (randomNumber == 1 && previousPhase != 1) phaseI.enabled = true;
        if (randomNumber == 2 && previousPhase != 2) phaseII.enabled = true;
        if (randomNumber == 3 && previousPhase != 3) phaseIII.enabled = true;

        previousPhase = randomNumber;
    }




}
