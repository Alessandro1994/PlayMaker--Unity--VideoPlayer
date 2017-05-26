// (c) Copyright HutongGames, LLC 2010-2017. All rights reserved.

#if UNITY_5_6_OR_NEWER

using UnityEngine;
using UnityEngine.Video;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VideoPlayer")]
	[Tooltip("Check whether the player skips frames to catch up with current time. (Read Only)")]
	public class VideoPlayerGetCanSkipOnDrop : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VideoPlayer))]
		[Tooltip("The GameObject with an VideoPlayer component.")]
		public FsmOwnerDefault gameObject;

		[Tooltip("The Value")]
		[UIHint(UIHint.Variable)]
		public FsmBool canSetSkipOnDrop;

		[Tooltip("Event sent if SkipOnDrop can be set")]
		public FsmEvent canSetSkipOnDropEvent;

		[Tooltip("Event sent if SkipOnDrop can not be set")]
		public FsmEvent canNotSetSkipOnDropEvent;


		GameObject go;

		VideoPlayer _vp;


		public override void Reset()
		{
			gameObject = null;
			canSetSkipOnDrop = null;
			canSetSkipOnDropEvent = null;
			canNotSetSkipOnDropEvent = null;
		
		}

		public override void OnEnter()
		{
			GetVideoPlayer ();
		
			ExecuteAction ();

			Finish ();
		}
			

		void ExecuteAction()
		{
			if (_vp != null)
			{
				canSetSkipOnDrop.Value = _vp.canSetSkipOnDrop;
				Fsm.Event(_vp.canSetTime?canSetSkipOnDropEvent:canNotSetSkipOnDropEvent);
			}
		}

		void GetVideoPlayer()
		{
			go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go != null)
			{
				_vp = go.GetComponent<VideoPlayer>();
			}
		}
	}
}

#endif