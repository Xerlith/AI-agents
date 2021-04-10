#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;

namespace SOTags
{
	[CreateAssetMenu(menuName = "SOTags/Tags Container")]
#if ODIN_INSPECTOR
	[AssetSelector, Required]
#endif
	public sealed class TagsContainer : ScriptableObject
	{
		[SerializeField] private Tag[] m_tags = null;

		public bool HasEntity(GameObject entity, bool allRequired) =>
			entity.HasTags(m_tags, allRequired);
	}
}