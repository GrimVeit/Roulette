using UnityEngine;

public class Bet : MonoBehaviour
{
    [SerializeField] private BetType type;
    //[SerializeField] private 
}

public enum BetType
{
    SingleNumber, 
    Even,
    Odd,
    Red,
    Black,
    First12,
    Second12,
    Third12
}
