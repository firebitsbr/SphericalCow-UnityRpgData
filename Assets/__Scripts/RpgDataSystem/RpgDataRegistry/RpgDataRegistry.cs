﻿using UnityEngine;
using Guid = System.Guid;
using System.Collections.Generic;

namespace SphericalCow
{
	/// <summary>
	/// 	The "database" of all RPG Data Types (XpProgressors, Stats, and Abilities).
	/// 	This does NOT contain data concerning RpgCharacters, only stores read-only data.
	/// 	Meant to be a singleton script attached to a persistent GameObject 
	/// </summary>
	public class RpgDataRegistry : MonoBehaviour 
	{
		[SerializeField] private XpProgressor[] xpProgressors;
		[SerializeField] private BaseStat[] baseStats;
		[SerializeField] private SecondaryStat[] secondaryStats;
		[SerializeField] private SkillStat[] skillStats;
		[SerializeField] private Ability[] abilties;
		
		
		
		/// <summary>
		/// 	The name of the prefab holding the RpgDataRegistry script
		/// </summary>
		public const string RpgRegistryPrefabName = "RpgDataRegistryObject";
		
		private static RpgDataRegistry instance = null;
		
		
		
		
		/// <summary>
		/// 	Singeton access to RpgDataRegistry
		/// </summary>
		public static RpgDataRegistry Instance
		{
			get
			{
				if(RpgDataRegistry.instance == null)
				{
					GameObject registryObject = GameObject.Instantiate(Resources.Load<GameObject>(RpgDataRegistry.RpgRegistryPrefabName));
					GameObject.DontDestroyOnLoad(registryObject);
					RpgDataRegistry newRegistry = registryObject.GetComponent<RpgDataRegistry>();
					if(newRegistry == null)
					{
						Debug.LogError("RpgDataRegistry script is missing from the prefab " + RpgDataRegistry.RpgRegistryPrefabName);
						return null;
					}
					RpgDataRegistry.instance = newRegistry;
					newRegistry.Init();
				}
				
				return RpgDataRegistry.instance;
			}
		}
		
		
		
		// Called before Start()
		void Awake()
		{
			if(RpgDataRegistry.instance != null)
			{
				Debug.LogError("There are multiple instances of RpgDataRegistry running!", this);
			}
		}
		
		
		
		/// <summary>
		/// 	Intialization code for the registry
		/// </summary>
		private void Init()
		{
			
		}
		
		
		
		/// <summary>
		/// 	Search for an XpProgressor by ID
		/// </summary>
		public XpProgressor SearchXpProgressor(Guid byId)
		{
			XpProgressor foundObject = null;
			
			foreach(XpProgressor entry in this.xpProgressors)
			{
				if(entry.Id.Equals(byId))
				{
					foundObject = entry;
					break;
				}
			}
			
			return foundObject;
		}
		
		
		/// <summary>
		/// 	Search for an XpProgressor by name (not filename)
		/// </summary>
		public XpProgressor SearchXpProgressor(string byName)
		{
			XpProgressor foundObject = null;
			
			foreach(XpProgressor entry in this.xpProgressors)
			{
				if(entry.Name.Equals(byName))
				{
					foundObject = entry;
					break;
				}
			}
			
			return foundObject;
		}
		
		
		
		
		
		/// <summary>
		/// 	Search for a BaseStat by ID
		/// </summary>
		public BaseStat SearchBaseStat(Guid byId)
		{
			BaseStat foundObject = null;
			
			foreach(BaseStat entry in this.baseStats)
			{
				if(entry.Id.Equals(byId))
				{
					foundObject = entry;
					break;
				}
			}
			
			return foundObject;
		}
		
		/// <summary>
		/// 	Search for a BaseStat by name (not filename)
		/// </summary>
		public BaseStat SearchBaseStat(string byName)
		{
			BaseStat foundObject = null;
			
			foreach(BaseStat entry in this.baseStats)
			{
				if(entry.Name.Equals(byName))
				{
					foundObject = entry;
					break;
				}
			}
			
			return foundObject;
		}
		
		
		
		
		
		
		
		
		
		
		
		
		/// <summary>
		/// 	Search for a SecondaryStat by ID
		/// </summary>
		public SecondaryStat SearchSecondaryStat(Guid byId)
		{
			SecondaryStat foundObject = null;
			
			foreach(SecondaryStat entry in this.secondaryStats)
			{
				if(entry.Id.Equals(byId))
				{
					foundObject = entry;
					break;
				}
			}
			
			return foundObject;
		}
		
		
		/// <summary>
		/// 	Search for a SecondaryStat by name (not filename)
		/// </summary>
		public SecondaryStat SearchSecondaryStat(string byName)
		{
			SecondaryStat foundObject = null;
			
			foreach(SecondaryStat entry in this.secondaryStats)
			{
				if(entry.Name.Equals(byName))
				{
					foundObject = entry;
					break;
				}
			}
			
			return foundObject;
		}
		
		
		
		
		
		/// <summary>
		/// 	Search for a SkillStat by ID
		/// </summary>
		public SkillStat SearchSkillStat(Guid byId)
		{
			SkillStat foundObject = null;
			
			foreach(SkillStat entry in this.skillStats)
			{
				if(entry.Id.Equals(byId))
				{
					foundObject = entry;
					break;
				}
			}
			
			return foundObject;
		}
		
		
		/// <summary>
		/// 	Search for a SkillStat by name (not filename)
		/// </summary>
		public SkillStat SearchSkillStat(string byName)
		{
			SkillStat foundObject = null;
			
			foreach(SkillStat entry in this.skillStats)
			{
				if(entry.Name.Equals(byName))
				{
					foundObject = entry;
					break;
				}
			}
			
			return foundObject;
		}
		
		
		
		
		/// <summary>
		/// 	Search for an Ability by ID
		/// </summary>
		public Ability SearchAbility(Guid byId)
		{
			Ability foundObject = null;
			
			foreach(Ability entry in this.abilties)
			{
				if(entry.Id.Equals(byId))
				{
					foundObject = entry;
					break;
				}
			}
			
			return foundObject;
		}
		
		
		/// <summary>
		/// 	Search for an Ability by name (not filename)
		/// </summary>
		public Ability SearchAbility(string byName)
		{
			Ability foundObject = null;
			
			foreach(Ability entry in this.abilties)
			{
				if(entry.Name.Equals(byName))
				{
					foundObject = entry;
					break;
				}
			}
			
			return foundObject;
		}
		
		
		
		// The following block will only run in the Unity Editor. Not meant for game code
		
		#if UNITY_EDITOR
			
			/// <summary>
			/// 	Adds an XpProgressor into the registry.
			/// 	Only to be called by RpgDataAssetUtility in the editor!
			/// </summary>
			public void AddRpgDataObject(RpgRegistryUtility.AdderOfXpProgressor newXpProgressor)
			{
				// Resize array
				int oldArraySize = this.NumberOfXpProgressors;
				System.Array.Resize<XpProgressor>(ref this.xpProgressors, oldArraySize + 1);
				
				Debug.Assert(this.NumberOfXpProgressors == oldArraySize + 1, "XpProgressor array resize failed!");
				Debug.Assert(newXpProgressor.xpProgressor != null, "Cannot add null XpProgressor to registry!");
				
				// Add new item
				this.xpProgressors[oldArraySize] = newXpProgressor.xpProgressor;
			}
			
			
			/// <summary>
			/// 	Adds a BaseStat into the registry.
			/// 	Only to be called by RpgDataAssetUtility in the editor!
			/// </summary>
			public void AddRpgDataObject(RpgRegistryUtility.AdderOfBaseStat newBaseStat)
			{
				// Resize array
				int oldArraySize = this.NumberOfBaseStats;
				System.Array.Resize<BaseStat>(ref this.baseStats, oldArraySize + 1);
				
				Debug.Assert(this.NumberOfBaseStats == oldArraySize + 1, "BaseStat array resize failed!");
				Debug.Assert(newBaseStat.baseStat != null, "Cannot add null BaseStat to registry!");
				
				// Add new item
				this.baseStats[oldArraySize] = newBaseStat.baseStat;
			}
			
			
			/// <summary>
			/// 	Adds a SecondaryStat into the registry.
			/// 	Only to be called by RpgDataAssetUtility in the editor!
			/// </summary>
			public void AddRpgDataObject(RpgRegistryUtility.AdderOfSecondaryStat newSecondaryStat)
			{
				// Resize array
				int oldArraySize = this.NumberOfSecondaryStats;
				System.Array.Resize<SecondaryStat>(ref this.secondaryStats, oldArraySize + 1);
				
				Debug.Assert(this.NumberOfSecondaryStats == oldArraySize + 1, "SecondaryStat array resize failed!");
				Debug.Assert(newSecondaryStat.secondaryStat != null, "Cannot add null SecondaryStat to registry!");
				
				// Add new item
				this.secondaryStats[oldArraySize] = newSecondaryStat.secondaryStat;
			}
			
			
			/// <summary>
			/// 	Adds a SkillStat into the registry.
			/// 	Only to be called by RpgDataAssetUtility in the editor!
			/// </summary>
			public void AddRpgDataObject(RpgRegistryUtility.AdderOfSkillStat newSkillStat)
			{
				// Resize array
				int oldArraySize = this.NumberOfSkillStats;
				System.Array.Resize<SkillStat>(ref this.skillStats, oldArraySize + 1);
				
				Debug.Assert(this.NumberOfSkillStats == oldArraySize + 1, "SkillStat array resize failed!");
				Debug.Assert(newSkillStat.skillStat != null, "Cannot add null SkillStat to registry!");
				
				// Add new item
				this.skillStats[oldArraySize] = newSkillStat.skillStat;
			}
			
			
			/// <summary>
			/// 	Adds an Ability into the registry.
			/// 	Only to be called by RpgDataAssetUtility in the editor!
			/// </summary>
			public void AddRpgDataObject(RpgRegistryUtility.AdderOfAbility newAbility)
			{
				// Resize array
				int oldArraySize = this.NumberOfAbilities;
				System.Array.Resize<Ability>(ref this.abilties, oldArraySize + 1);
				
				Debug.Assert(this.NumberOfAbilities == oldArraySize + 1, "Ability array resize failed!");
				Debug.Assert(newAbility.ability != null, "Cannot add null Ability to registry!");
				
				// Add new item
				this.abilties[oldArraySize] = newAbility.ability;
			}
			
		#endif
		
		// End UNITY_EDITOR
		
		
		
		
		
		
		public XpProgressor[] XpProgressors
		{
			get
			{
				return this.xpProgressors;
			}
		}
		
		
		public BaseStat[] BaseStats
		{
			get
			{
				return this.baseStats;
			}
		}
		
		
		public SecondaryStat[] SecondaryStats
		{
			get
			{
				return this.secondaryStats;
			}
		}
		
		
		public SkillStat[] SkillStats
		{
			get
			{
				return this.skillStats;
			}
		}
		
		
		public Ability[] Abilities
		{
			get
			{
				return this.abilties;
			}
		}
		
		
		public int NumberOfXpProgressors
		{
			get
			{
				return this.xpProgressors.Length;
			}
		}
		
		
		public int NumberOfBaseStats
		{
			get
			{
				return this.baseStats.Length;
			}
		}
		
		
		public int NumberOfSecondaryStats
		{
			get
			{
				return this.secondaryStats.Length;
			}
		}
		
		
		public int NumberOfSkillStats
		{
			get
			{
				return this.skillStats.Length;
			}
		}
		
		
		public int NumberOfAbilities
		{
			get
			{
				return this.abilties.Length;
			}
		}
		
		
	}
}
