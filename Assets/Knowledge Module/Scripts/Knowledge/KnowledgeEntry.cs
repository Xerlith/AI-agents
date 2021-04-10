using UnityEngine;

[CreateAssetMenu(menuName = "Knowledge Module/Knowledge/Entry")]
public class KnowledgeEntry : ScriptableObject
{
    public SmartObjectData entity;
    public float knowledgeLevelRequired;
}
