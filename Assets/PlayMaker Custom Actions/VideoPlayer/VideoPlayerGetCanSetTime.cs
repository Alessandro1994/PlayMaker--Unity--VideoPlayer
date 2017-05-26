// (c) Copyright HutongGames, LLC 2010-2017. All rights reserved.

#if UNITY_5_6_OR_NEWER

using UnityEngine;
using UnityEngine.Video;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VideoPlayer")]
	[Tooltip("Check whether current time can be changed using the time or timeFrames property on a VideoPlayer. (Read Only)")]
	public class VideoPlayerGetCanSetTime : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VideoPlayer))]
		[Tooltip("The GameObject with an VideoPlayer component.")]
		public FsmOwnerDefault gameObject;

		[Tooltip("The Value")]
		[UIHint(UIHint.Variable)]
		public FsmBool canSetTime;

		[Tooltip("Event sent if time can be set")]
		public FsmEvent canSetTimeEvent;

		[Tooltip("Event sent if time can not be set")]
		public FsmEvent canNotSetTimeEvent;


		GameObject go;

		VideoPlayer _vp;


		public override void Reset()
		{
			gameObject = null;
			canSetTime = null;
			canSetTimeEvent = null;
			canNotSetTimeEvent = null;
		
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
				canSetTime.Value = _vp.canSetTime;
				Fsm.Event(_vp.canSetTime?canSetTimeEvent:canNotSetTimeEvent);
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