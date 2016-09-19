using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ASSISTME
{
    public class MyDelegates
    {
        private static TreeView treeViewBackPropagation;

        private static PictureBox pct;

        public static TreeView TreeViewBackPropagation
        {
            get { return MyDelegates.treeViewBackPropagation; }
            set { MyDelegates.treeViewBackPropagation = value; }
        }

        delegate void SetEnableControlTHandler(Control ctrl, bool value);
        public static void SetEnableControl(Control ctrl,bool value)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.BeginInvoke(new SetEnableControlTHandler(SetEnableControl), ctrl, value);
                return;
            }

            try
            {
                ctrl.Enabled = value;
            }
            catch (Exception) { }
        }

        delegate void SetPCTHandler(PictureBox ctrl, Bitmap value);
        public static void SetPCTValue(PictureBox ctrl, Bitmap value)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.BeginInvoke(new SetPCTHandler(SetPCTValue), ctrl, value);
                return;
            }

            try
            {
                ctrl.Image = value;
            }
            catch (Exception) { }
        }

        delegate void SetBMPHandler(Control ctrl, Bitmap value);
        public static void SetBMPValue(Control ctrl, Bitmap value)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.BeginInvoke(new SetBMPHandler(SetBMPValue), ctrl, value);
                return;
            }

            try
            {
                ctrl.BackgroundImage = value;
            }
            catch (Exception) { }
        }

        delegate void SetControlTextHandler(Control ctrl, string value);
        public static void SetTextValue(Control ctrl, string value)
        {
            if (ctrl.InvokeRequired)
                ctrl.BeginInvoke(new SetControlTextHandler(SetTextValue), ctrl, value);
            else
                ctrl.Text = value;
        }


        delegate void SetLineValueHandler(TextBox ctrl, string value);
        public static void SetLineValue(TextBox ctrl, string value)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.BeginInvoke(new SetLineValueHandler(SetLineValue), ctrl, value);
                return;
            }
            try
            {
                ctrl.Text = value;
            }
            catch (Exception) { }
        }

        delegate void AddLineValueHandler(TextBox ctrl, string value);
        public static void AddLineValue(TextBox ctrl, string value)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.BeginInvoke(new SetLineValueHandler(AddLineValue), ctrl, value);
                return;
            }
            try
            {
                ctrl.AppendText(value + "\r\n");
            }
            catch (Exception) { }
        }

        delegate void AddProgressValueHandler(ProgressBar ctrl, int value);
        public static void AddProgressValue(ProgressBar ctrl, int value)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.BeginInvoke(new AddProgressValueHandler(AddProgressValue), ctrl, value);
                return;
            }

            try
            {
                ctrl.Value = value;
            }

            catch (Exception) { }
        }

        delegate void AddImageTrainHandler(Bitmap value);
        public static void AddImageTrainValue(Bitmap value)
        {
            if (treeViewBackPropagation.InvokeRequired)
            {
                treeViewBackPropagation.BeginInvoke(new AddProgressValueHandler(AddProgressValue), value);
                return;
            }

            try
            {
                TreeNode tmpNode = new TreeNode(value.Tag.ToString());
                tmpNode.Tag = value;
                treeViewBackPropagation.Nodes.Add(tmpNode);
                treeViewBackPropagation.Refresh();
            }

            catch (Exception) { }
        }
    }
}
