// ##############################################################################
//
// ICECreatureAPEXAdapter.cs
// Version 1.1.21
//
// © Pit Vetterick, ICE Technologies Consulting LTD. All Rights Reserved.
// http://www.ice-technologies.com
// mailto:support@ice-technologies.com
// 
// Unity Asset Store End User License Agreement (EULA)
// http://unity3d.com/legal/as_terms
//
// The ICECreatureAstarAdapter Script based on the default movement script AIPath.cs
// which comes with the A* Pathfinding Project and provides ICECreatureControl to 
// use the powerful navigation of the A* Pathfinding System.
//
// ##############################################################################

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using ICE.World;

using ICE.Creatures;
using ICE.Creatures.Objects;

using Apex.Steering.Components;

namespace ICE.Creatures.Adapter
{
	[RequireComponent(typeof(SteerForPathComponent))]
	[RequireComponent(typeof(ICECreatureControl))]
	public class ICECreatureAPEXAdapter : ICEWorldBehaviour {

		private ICECreatureControl m_Controller = null;
		private SteerForPathComponent m_SteerForPathComponent = null;

		protected Transform m_Transform = null;
	
		// Use this for initialization
		public override void Awake () {

			//just to optimize the transform component lookup
			m_Transform = transform;		


			m_Controller = GetComponent<ICECreatureControl>();
			if( m_Controller != null )
			{
				m_Controller.Creature.Move.OnTargetMovePositionReached += OnTargetMovePositionReached;
				m_Controller.Creature.Move.OnMoveComplete += OnMoveComplete;
				m_Controller.Creature.Move.OnUpdateMovePosition += OnMoveUpdatePosition;
			}

			m_SteerForPathComponent = GetComponent<SteerForPathComponent>();

		}
		// Use this for initialization
		public override void Start () {
		

		}

		public void OnDisable () 
		{
			m_Controller.Creature.Move.OnTargetMovePositionReached -= OnTargetMovePositionReached;
			m_Controller.Creature.Move.OnMoveComplete -= OnMoveComplete;
			m_Controller.Creature.Move.OnUpdateMovePosition -= OnMoveUpdatePosition;
		}
		
		// Update is called once per frame
		public override void Update () {
		
		}

		void OnMoveComplete( GameObject _sender, TargetObject _target  )
		{

		}

		private Vector3 _current_position = Vector3.zero;

		void OnMoveUpdatePosition(  GameObject _sender, Vector3 _origin_position, ref Vector3 _new_position )
		{
			if( m_SteerForPathComponent && _current_position != _new_position )
			{
				_current_position = _new_position;
				m_SteerForPathComponent.MoveTo( _new_position, false );
			}
		}

		void OnTargetMovePositionReached( GameObject _sender, TargetObject _target )
		{
		}
	}
}
