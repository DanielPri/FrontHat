using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBackGroundSet",
    menuName = "ScriptableObjects/BackGroundSet", order = 2)]
public class BackGroundSet : ScriptableObject
{
    public List<GameObject> bgElements;

    public GameObject GetRandom()
    {
        return bgElements[Random.Range(0, bgElements.Count)];
    }

}
