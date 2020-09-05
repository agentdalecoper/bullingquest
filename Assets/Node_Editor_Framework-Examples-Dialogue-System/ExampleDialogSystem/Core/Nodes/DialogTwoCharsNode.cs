using System;
using NodeEditorFramework;
using UnityEditor;
using UnityEngine;

namespace ExampleDialogSystem.Core.Nodes
{
    [Node(false, "Dialog/Dialog two chars Node", new Type[] {typeof(DialogNodeCanvas)})]
    public class DialogTwoCharsNode : DialogNode
    {
        public Sprite LeftCharPortrait;
        public Sprite RightCharPortrait;
        
        public override string GetID { get { return "TwoCharsId"; } }

        public override void NodeGUI()
        {
            LeftCharPortrait = (Sprite) EditorGUILayout.ObjectField(LeftCharPortrait, typeof(Sprite), false, GUILayout.Width(65f), GUILayout.Height(65f));
            RightCharPortrait = (Sprite) EditorGUILayout.ObjectField(RightCharPortrait, typeof(Sprite), false, GUILayout.Width(65f), GUILayout.Height(65f));

            base.NodeGUI();
        }
    }
}