using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Destruction part1;
    public Destruction part2;
    public Destruction part3;
    public int maxPieces;
    public int pieces;
    public Text hpR;
    public int hpRemaining = 1000;
    public int maxHP;
    // Start is called before the first frame update
    void Start()
    {
        maxPieces = part1.numOfCubes + part2.numOfCubes + part3.numOfCubes;
        pieces = maxPieces;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CountHP()
    {
        hpRemaining = (pieces * 1000) / maxPieces;
        hpR.text = hpRemaining.ToString();

    }
}
