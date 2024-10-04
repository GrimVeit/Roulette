using System.Collections;
using UnityEngine;

public class RouletteNumber : MonoBehaviour
{
    [SerializeField] private int number;
    [SerializeField] private ParityNumber parity;
    [SerializeField] private ColorNumber color;
    [SerializeField] private RowNumber row;
    [SerializeField] private ColumnNumber column;

    public int Number => number;
    public ParityNumber Parity => parity;
    public ColorNumber Color => color;
    public RowNumber Row => row;
    public ColumnNumber Column => column;

}

public enum ParityNumber
{
    Even, Odd
}

public enum ColorNumber
{
    Red, Black, Green
}

public enum RowNumber
{
    First, Second, Third, None
}

public enum ColumnNumber
{
    First, Second, Third, None
}
