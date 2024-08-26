using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Dice", menuName = "Dice")]
public class Dice : ScriptableObject
{
    public Color color = Color.white;
    public List<Outcome> outcomes;
    public float staminaCost = 10f; // stamina cost of performing a roll, lets use that instead of cooldown just because i have that implemented already
    public float speed = 100f; //how fast dice is traveling
    public bool ready = true;

    public Outcome Roll() //picking random outcome
    {
        return outcomes[Random.Range(0, outcomes.Count)];
    }
}
