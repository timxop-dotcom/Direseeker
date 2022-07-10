using System;
using UnityEngine;

namespace DireseekerMod.Components
{
	public class DireseekerController : MonoBehaviour
	{
		public void StartRageMode()
		{
			bool flag = this.rageFlame;
			if (flag)
			{
				this.rageFlame.Play();
			}
		}

		public void FlameBurst()
		{
			bool flag = this.burstFlame;
			if (flag)
			{
				this.burstFlame.Play();
			}
		}

		public ParticleSystem burstFlame;
		public ParticleSystem rageFlame;
	}
}
