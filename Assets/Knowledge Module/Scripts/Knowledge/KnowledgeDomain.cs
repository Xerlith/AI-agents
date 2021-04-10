using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Knowledge Module/Knowledge/Domain")]
public class KnowledgeDomain : ScriptableObject
{
    public List<KnowledgeEntry> domainObjects;

    public List<SmartObject> GetKnownObjects(float knowledgeLevel) => domainObjects
        .Where(entry => entry.knowledgeLevelRequired > knowledgeLevel)
        .ToList()
        .SelectMany(ke => ke.entity.Items)
        .ToList();
}
