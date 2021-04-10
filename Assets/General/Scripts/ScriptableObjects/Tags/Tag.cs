using System.Collections.Generic;
using UnityEngine;

namespace SOTags
{
	[CreateAssetMenu(menuName = "SOTags/Tag")]
#if ODIN_INSPECTOR
	[AssetSelector, Required]
#endif
	public sealed class Tag : ScriptableObject
	{
#if ODIN_INSPECTOR
		[ShowInInspector, ReadOnly]
#endif
		private HashSet<int> m_entities = new HashSet<int>();
		public void Add(int entity) =>
			m_entities.Add(entity);
		public void Remove(int entity) =>
			m_entities.Remove(entity);

		public bool HasEntity(int entity) =>
			m_entities.Contains(entity);
	}
}