using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalControllerBoard : MonoBehaviour
{
    Goal goal;

    public Text goalName;
    public Image goalImage;

    public Text goalAmountText;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void SetGoal(Goal g)
    {
        goal = g;
        SetupText();
    }

    public void SetupText()
    {
        goalName.text = goal.description;
        goalImage.sprite = goal.sprite;
        goalAmountText.text = goal.currentAmount.ToString() + "/" + goal.requiredAmount.ToString();
    }
}
