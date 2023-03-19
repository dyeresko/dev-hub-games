using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SkillChanger : MonoBehaviour
{
    public Shoot shooter;
    private const int NUM_ELEMENTS = 2;
    private Element[] elements = new Element[3];
    private readonly Element[] deadBall = { Element.Fire, Element.Ice, Element.Wind };
    private readonly Element[] fireBall = { Element.Fire, Element.Fire, Element.Fire };
    private readonly Element[] iceBall = { Element.Ice, Element.Ice, Element.Ice };
    private readonly Element[] windBall = { Element.Wind, Element.Wind, Element.Wind };
    public GameObject deadBallPrefab;

    public GameObject iceBallPrefab;
    public GameObject fireBallPrefab;
    public GameObject windBallPrefab;

    private void Start()
    {
        elements = new Element[3];

    }

    public void AddElement(Element element)
    {
        elements[0] = elements[1];
        elements[1] = elements[2];
        elements[2] = element;
        Debug.Log(elements[0]);
        Debug.Log(elements[1]);
        Debug.Log(elements[2]);
    }

    public void AddFire()
    {
        AddElement(Element.Fire);
    }
    public void AddIce()
    {
        AddElement(Element.Ice);
    }
    public void AddWind()
    {
        AddElement(Element.Wind);
    }

    public void ChangeSkill()
    {
        Array.Sort(elements);
        if (elements[0] == deadBall[0] && elements[1] == deadBall[1] && elements[2] == deadBall[2])
        {
            shooter.ChangeProjectile(deadBallPrefab);
            Debug.Log("DEADBALL");
        }
        else
        if (elements[0] == fireBall[0] && elements[1] == fireBall[1] && elements[2] == fireBall[2])
        {
            shooter.ChangeProjectile(fireBallPrefab);
        }
        else
        if (elements[0] == iceBall[0] && elements[1] == iceBall[1] && elements[2] == iceBall[2])
        {
            shooter.ChangeProjectile(iceBallPrefab);
        }
        else
        if (elements[0] == windBall[0] && elements[1] == windBall[1] && elements[2] == windBall[2])
        {
            shooter.ChangeProjectile(windBallPrefab);
        }
    }
    public enum Element
    {
        Fire,
        Ice,
        Wind
    }
}
