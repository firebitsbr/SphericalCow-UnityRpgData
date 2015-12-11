﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections.ObjectModel;	// for ReadOnlyCollection<>


namespace SphericalCow
{
	[System.Serializable]
	public class AbilityInstance 
	{
		private List<AbilityModifierInstance> abilityModifierInstances;
		private string abilityName = "";
		[System.NonSerialized] private Ability abilityRef;
		[System.NonSerialized] private RpgCharacterData character;

		//
		// Constructor (Never runs in deserialization)
		//

		public AbilityInstance(Ability abilityReference, RpgCharacterData characterData)
		{
			this.abilityRef = abilityReference;
			this.character = characterData;
			this.abilityName = abilityRef.AbilityName;

			this.abilityModifierInstances = new List<AbilityModifierInstance>();

			// Create ability modifier instances
			foreach(var abilityModifierRef in this.abilityRef.AbilityModifiers)
			{
				this.abilityModifierInstances.Add(new AbilityModifierInstance(abilityModifierRef, this.character, this));
			}
		}



		//
		// Methods
		//

		public void ApplyAbility()
		{
			// TODO: Implement ability application
		}

		public void UnApplyAbility()
		{
			// TODO: Implement ability de-application
			
		}



		//
		// Getters
		//

		/// <summary>
		/// 	The name of this AbilityInstance, based off its corresonding Ability
		/// </summary>
		public string AbilityName
		{
			get
			{
				return this.abilityName;
			}
		}

		/// <summary>
		/// 	Return a read-only list of the local instances of AbilityModifiers for this AbilityInstance
		/// </summary>
		public ReadOnlyCollection<AbilityModifierInstance> AbilityModifierInstances
		{
			get
			{
				return this.abilityModifierInstances.AsReadOnly();
			}
		}

		/// <summary>
		/// 	Get the RPG Character that exibits this Ability
		/// </summary>
		/// <value>The character.</value>
		public RpgCharacterData Character
		{
			get
			{
				return this.character;
			}
		}
	}
}