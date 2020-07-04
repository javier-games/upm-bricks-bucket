using BricksBucket.Core.Attributes;
using BricksBucket.Core.Attributes.Editor;
using UnityEditor;
using UnityEngine;

namespace BricksBucket.Core.Editor
{
	// ReSharper disable CommentTypo
	/// <!-- BrickBucketScriptableObjectEditor -->
	/// 
	/// <summary>
	///
	/// <para>
	/// Override Editor for a general Scriptable Object. Adds the functionality
	/// to display methods as buttons that use the <see
	/// cref="ButtonAttribute"/> on inspector.
	/// </para>
	///
	/// <para>
	/// This class is canceled by OdinInspector, do not use both together.
	/// </para>
	/// 
	/// </summary>
	///
	/// <seealso cref="ButtonAttribute"/>
	///
	/// <!-- By Javier García | @jvrgms | 2020 -->
	// ReSharper restore CommentTypo
	[CustomEditor (typeof (ScriptableObject), true), CanEditMultipleObjects]
	public class BrickBucketScriptableObjectEditor : UnityEditor.Editor
	{
		#region Class Members

		/// <summary>
		/// Current target.
		/// </summary>
		private ScriptableObject _target;

		/// <summary>
		/// Handler for methods.
		/// </summary>
		private ButtonAttributeHandler _handler;

		#endregion


		#region Editor Methods

		/// <summary> Called on enable. </summary>
		private void OnEnable ()
		{
			_target = target as ScriptableObject;
			if (_target == null) return;

			_handler = new ButtonAttributeHandler (_target);
		}

		#endregion


		#region Editor Overrides

		/// <summary> Called on inspector GUI </summary>
		public override void OnInspectorGUI ()
		{
			base.OnInspectorGUI ();
			_handler?.OnInspectorGUI ();
		}

		#endregion
	}
}