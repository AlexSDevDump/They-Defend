using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Type", menuName = "Enemies/New Enemy Type", order = 1)]
public class EnemySO : ScriptableObject
{
    public float maxHealth = 5;
    public float speed = 5;

}
