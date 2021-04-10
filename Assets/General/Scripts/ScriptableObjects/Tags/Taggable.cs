#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;


namespace SOTags
{
	[DisallowMultipleComponent, DefaultExecutionOrder(-9000), ExecuteInEditMode]
	public sealed class Taggable : MonoBehaviour
	{
#if ODIN_INSPECTOR
		[Required, AssetList]
#endif
		[SerializeField] private Tag[] m_tags = default;

		private static Tag[] m_all = null;
		private int m_hash = 0;

		private void Awake()
		{
#if UNITY_EDITOR
			SetupEditorData();
#endif

			m_hash = gameObject.GetHashCode();
			AddAll();
		}

		private void OnDestroy() =>
			RemoveAll();

		private void AddAll()
		{
			for (int i = 0; i < m_tags.Length; i++)
				m_tags[i].Add(m_hash);
		}

		private void RemoveAll()
		{
			for (int i = 0; i < m_tags.Length; i++)
				m_tags[i].Remove(m_hash);
		}

#if UNITY_EDITOR
		public void AddTagInEditor(Tag tag)
		{
			if (!ArrayUtility.Contains(m_tags, tag))
				ArrayUtility.Add(ref m_tags, tag);
		}

		public void RemoveTagInEditor(Tag tag)
		{
			if (ArrayUtility.Contains(m_tags, tag))
				ArrayUtility.Remove(ref m_tags, tag);
		}

		// Handle Inspector Changes
		private void OnValidate()
		{
			SetupEditorData();
			var obj = gameObject;
			AddAll();

			for (int i = 0; i < m_all.Length; i++)
			{
				var tag = m_all[i];

				if (ArrayUtility.Contains(m_tags, tag))
				{
					if (!obj.HasTag(tag))
						obj.AddTag(tag);
				}
				else
				{
					if (obj.HasTag(tag))
						obj.RemoveTag(tag);
				}
			}
		}

		private void SetupEditorData()
		{
			if (m_all == null)
				m_all = Resources.FindObjectsOfTypeAll<Tag>();

			if (m_tags == null)
			{
				m_tags = new Tag[0];
			}
			else
			{
				for (int i = m_tags.Length - 1; i >= 0; i--)
				{
					var tag = m_tags[i];

					if (tag == null)
						ArrayUtility.RemoveAt(ref m_tags, i);
				}
			}

			if (m_hash == 0)
				m_hash = gameObject.GetHashCode();
		}
#endif
	}
}