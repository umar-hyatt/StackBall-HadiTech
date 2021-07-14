using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BzKovSoft.ObjectSlicer;
using System.Diagnostics;

namespace BzKovSoft.ObjectSlicerSamples
{
	/// <summary>
	/// This script will invoke slice method of IBzSliceableAsync interface if knife slices this GameObject.
	/// The script must be attached to a GameObject that have rigidbody on it and
	/// IBzSliceable implementation in one of its parent.
	/// </summary>
	[DisallowMultipleComponent]
	public class KnifeSliceableAsync : MonoBehaviour
	{
		IBzSliceableAsync _sliceableAsync;
		public Rigidbody rb;
		// public ParticleSystem particleSystem;
		private int x=0;
		public GameObject[] col;
		
		void Start()
		{
			_sliceableAsync = GetComponentInParent<IBzSliceableAsync>();
		}

		void OnTriggerEnter(Collider other)
		{
			var knife = other.gameObject.GetComponent<BzKnife>();
			if (knife == null)
				return;

			StartCoroutine(Slice(knife));
			rb.useGravity= true;
			other.GetComponent<Rigidbody>().AddTorque(5f, 5f, 5, ForceMode.Impulse);
		}
		private IEnumerator Slice(BzKnife knife)
		{
			// The call from OnTriggerEnter, so some object positions are wrong.
			// We have to wait for next frame to work with correct values
			yield return null;

			Vector3 point = GetCollisionPoint(knife);
			Vector3 normal = Vector3.Cross(knife.MoveDirection, knife.BladeDirection);
			Plane plane = new Plane(normal, point);

			if (_sliceableAsync != null)
			{
				_sliceableAsync.Slice(plane, knife.SliceID, null);
				col[0].SetActive(true);

				// particleSystem.transform.position = knife.GetComponent<Transform>().position;
				// particleSystem.Play();
				// if(x<=1)
				// {
				// col[0].SetActive(true);
				// col[1].SetActive(false);
				// col[2].SetActive(false);
				// col[3].SetActive(false);
				// x++;
				// }
				// if(x<=2)
				// {
				// col[0].SetActive(false);
				// col[1].SetActive(true);
				// col[2].SetActive(false);
				// col[3].SetActive(false);
				// x++;
				// }
				// if(x<=3)
				// {
				// col[0].SetActive(false);
				// col[1].SetActive(false);
				// col[2].SetActive(true);
				// col[3].SetActive(false);
				// x++;
				// }
				// if(x<=4)
				// {
				// col[0].SetActive(false);
				// col[1].SetActive(false);
				// col[2].SetActive(false);
				// col[3].SetActive(true);
				// x=0;
				// }
				
				
			}
		}

		private Vector3 GetCollisionPoint(BzKnife knife)
		{
			Vector3 distToObject = transform.position - knife.Origin;
			Vector3 proj = Vector3.Project(distToObject, knife.BladeDirection);

			Vector3 collisionPoint = knife.Origin + proj;
			return collisionPoint;
		}
	}
}