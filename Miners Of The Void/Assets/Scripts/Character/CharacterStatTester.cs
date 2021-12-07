using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatTester : MonoBehaviour
{
    public CharacterStat movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = new CharacterStat(5);
        Debug.Log(movementSpeed.value);
        movementSpeed.AddModifier(new StatModifier(5, this));
        movementSpeed.AddModifier(new StatModifier(15, this));
        Debug.Log(movementSpeed.value);
        movementSpeed.RemoveAllFromSource(this);
        Debug.Log(movementSpeed.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
