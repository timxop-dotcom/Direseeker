using System;
using RoR2;
using UnityEngine;

namespace DireseekerMod.Components
{
	public class DireseekerButtonController : MonoBehaviour
	{
		public bool isPressed { get; private set; }

		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.isPressed = false;
			this.overlapSphereRadius = 1.5f;
			this.overlapSphereFrequency = 5f;
			this.enableOverlapSphere = true;
		}

		private void FixedUpdate()
		{
			bool flag = this.enableOverlapSphere;
			if (flag)
			{
				this.overlapSphereStopwatch += Time.fixedDeltaTime;
				bool flag2 = this.overlapSphereStopwatch >= 1f / this.overlapSphereFrequency;
				if (flag2)
				{
					this.overlapSphereStopwatch -= 1f / this.overlapSphereFrequency;
					bool flag3 = Physics.OverlapSphere(base.transform.position, this.overlapSphereRadius, LayerIndex.defaultLayer.mask | LayerIndex.fakeActor.mask, QueryTriggerInteraction.UseGlobal).Length != 0;
					bool flag4 = flag3;
					if (flag4)
					{
						this.Pressed();
					}
				}
			}
		}

		private void Pressed()
		{
			bool flag = !this.isPressed;
			if (flag)
			{
				this.isPressed = true;
				this.enableOverlapSphere = false;
				bool flag2 = this.animator;
				if (flag2)
				{
					this.animator.SetBool("pressed", true);
				}
				Util.PlaySound("Play_item_proc_bandolierSpawn", base.gameObject);
			}
		}

		private bool enableOverlapSphere;
		private float overlapSphereRadius;
		private float overlapSphereStopwatch;
		private float overlapSphereFrequency;
		private Animator animator;
	}
}
