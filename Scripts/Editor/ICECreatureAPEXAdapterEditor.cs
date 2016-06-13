// ##############################################################################
//
// ICECreatureAPEXAdapterEditor.cs
// Version 1.1.21
//
// © Pit Vetterick, ICE Technologies Consulting LTD. All Rights Reserved.
// http://www.ice-technologies.com
// mailto:support@ice-technologies.com
// 
// Unity Asset Store End User License Agreement (EULA)
// http://unity3d.com/legal/as_terms
//
// ##############################################################################

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.AnimatedValues;

using ICE;
using ICE.World;
using ICE.World.EditorUtilities;
using ICE.World.EditorInfos;

namespace ICE.Creatures.Adapter
{
	[CustomEditor(typeof(ICECreatureAPEXAdapter))]
	public class ICECreatureAPEXAdapterEditor : ICEWorldBehaviourEditor {

		public override void OnInspectorGUI()
		{
			ICECreatureAPEXAdapter _target = DrawDefaultHeader<ICECreatureAPEXAdapter>();

			DrawDefaultFooter( _target );
		}
	}
}
