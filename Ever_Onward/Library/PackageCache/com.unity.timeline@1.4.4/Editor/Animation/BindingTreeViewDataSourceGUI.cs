using System.Linq;
using UnityEditor.IMGUI.Controls;
using UnityEditorInternal;
using UnityEngine;

namespace UnityEditor.Timeline
{
    class BindingTreeViewGUI : TreeViewGUI
    {
        static readonly float s_RowRightOffset = 10;
        static readonly float s_ColorIndicatorTopMargin = 3;
        static readonly Color s_KeyColorForNonCurves = new Color(0.7f, 0.7f, 0.7f, 0.5f);
        static readonly Color s_ChildrenCurveLabelColor = new Color(1.0f, 1.0f, 1.0f, 0.7f);
        static readonly Color s_PhantomPropertyLabelColor = new Color(0.0f, 0.8f, 0.8f, 1f);

        public BindingTreeViewGUI(TreeViewController treeView)
            : base(treeView, true)
        {
            k_IconWidth = 13.0f;
        }

        public override void OnRowGUI(Rect rowRect, TreeViewItem node, int row, bool selected, bool focused)
        {
            Color originalColor = GUI.color;
            bool leafNode = node.parent != null && node.parent.id != BindingTreeViewDataSource.RootID && node.parent.id != BindingTreeViewDataSource.GroupID;
            GUI.color = Color.white;
            if (leafNode)
            {
                CurveTreeViewNode curveNode = node as CurveTreeViewNode;
                if (curveNode != null && curveNode.bindings.Any() && curveNode.bindings.First().isPhantom)
                    GUI.color = s_PhantomPropertyLabelColor;
                else
                    GUI.color = s_ChildrenCurveLabelColor;
            }

            base.OnRowGUI(rowRect, node, row, selected, focused);

            GUI.color = originalColor;
            DoCurveColorIndicator(rowRect, node as CurveTreeViewNode);
        }

        protected override bool IsRenaming(int id)
        {
            return false;
        }

        public override bool BeginRename(TreeViewItem item, float delay)
        {
            return false;
        }

        static void DoCurveColorIndicator(Rect rect, CurveTreeViewNode node)
        {
            if (node == null)
                return;

            if (Event.current.type != EventType.Repaint)
                return;

            Color originalColor = GUI.color;

            if (node.bindings.Length == 1 && !node.bindings[0].isPPtrCurve)
                GUI.color = CurveUtility.GetPropertyColor(node.bindings[0].propertyName);
            else
                GUI.color = s_KeyColorForNonCurves;

            Texture icon = CurveUtility.GetIconCurve();
            rect = new Rect(rect.xMax - s_RowRightOffset - (icon.width * 0.5f) - 5, rect.yMin + s_ColorIndicatorTopMargin, icon.width, icon.height);

            GUI.DrawTexture(rect, icon, ScaleMode.ScaleToFit, true, 1);

            GUI.color = originalColor;
        }

        protected override Texture GetIconForItem(TreeViewItem item)
        {
            var node = item as CurveTreeViewNode;
            if (node == null)
                return null;

            if (node.bindings == null || node.bindings.Length == 0)
                return null;

            return AssetPreview.GetMiniTypeThumbnail(node.bindings[0].type);
        }
    }
}
