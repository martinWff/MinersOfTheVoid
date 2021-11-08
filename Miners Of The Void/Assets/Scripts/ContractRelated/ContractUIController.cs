using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContractUIController : MonoBehaviour
{
    private Goal goal;
    private int currentAmountCached = -1;
    [SerializeField]private Text goalText;
    [SerializeField]private Text goalProgressText;
    [SerializeField]private Image goalBar;
    [SerializeField]private Image goalSprite;
    // Start is called before the first frame update
    void Awake()
    {
      /*  goalText = GetComponentInChildren<Text>();
        goalBar = transform.Find("ProgressBar").GetComponent<Image>();*/
    }

    // Update is called once per frame
    void Update()
    {
       if (goal != null && currentAmountCached != goal.currentAmount)
        {
            float progressValue = ((float)goal.currentAmount/ (float)goal.requiredAmount);
            goalBar.fillAmount = progressValue;

            if (goal.completed)
            {
                goalProgressText.color = Color.green;
            } else
            {
                goalProgressText.color = Color.white;
            }

            goalProgressText.text = $"{goal.currentAmount}/{goal.requiredAmount}";
            currentAmountCached = goal.currentAmount;
        }
    }

    public void SetGoal(Goal g)
    {
        goal = g;

        if (goal != null) {
            goalText.text = goal.description;
            goalSprite.sprite = goal.sprite;
         }

    }

}
