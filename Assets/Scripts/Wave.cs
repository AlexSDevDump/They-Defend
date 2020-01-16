using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Wave", menuName = "Enemies/New Wave", order = 1)]
public class Wave : ScriptableObject
{
    public List<EnemySO> enemyTypes = new List<EnemySO>();

    public List<int> enemyQuantities = new List<int>();
}
