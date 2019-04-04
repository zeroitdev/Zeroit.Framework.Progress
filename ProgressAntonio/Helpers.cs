// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 10-27-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 12-30-2017
// ***********************************************************************
// <copyright file="ProgressAntonio.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Imports

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Text;
using System.Data;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{
    
    #region Tables
    #region BrushTable
    /// <summary>
    /// A class collection for a brush table.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.GraphicTable" />
    public class BrushTable : GraphicTable
    {
        /// <summary>
        /// Gets or sets the <see cref="Brush"/> with the specified key.
        /// </summary>
        /// <param name="Key">The key.</param>
        /// <returns>Brush.</returns>
        public new Brush this[string Key]
        {
            get
            {
                if (base[Key] == null)
                    return null;
                return (Brush)base[Key];
            }
            set
            {
                base[Key] = value;
            }
        }
    }
    #endregion

    #region GraphicTable
    /// <summary>
    /// A class collection for creating a Graphic table.
    /// </summary>
    /// <seealso cref="object" />
    public class GraphicTable : Dictionary<string, object>
    {
        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> with the specified key.
        /// </summary>
        /// <param name="Key">The key.</param>
        /// <returns>System.Object.</returns>
        public new object this[string Key]
        {
            get
            {
                if (!ContainsKey(Key))
                    return null;
                return (object)base[Key];
            }
            set
            {
                if (this[Key] != null)
                {
                    if (this[Key].GetType().GetInterface("System.IDisposable") != null)
                        ((System.IDisposable)this[Key]).Dispose();
                    base[Key] = value;
                }
                else
                    Add(Key, value);
            }
        }
        /// <summary>
        /// Disposes all.
        /// </summary>
        public void DisposeAll()
        {
            foreach (object xObj in Values)
            {
                if (xObj.GetType().GetInterface("System.IDisposable") != null)
                    ((System.IDisposable)xObj).Dispose();
            }
        }

    }
    #endregion

    #region PenTable
    /// <summary>
    /// A class collection for creating a Pen Table.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.GraphicTable" />
    public class PenTable : GraphicTable
    {
        /// <summary>
        /// Gets or sets the <see cref="Pen"/> with the specified key.
        /// </summary>
        /// <param name="Key">The key.</param>
        /// <returns>Pen.</returns>
        public new Pen this[string Key]
        {
            get
            {
                if (base[Key] == null)
                    return null;
                return (Pen)base[Key];
            }
            set
            {
                base[Key] = value;
            }
        }
    }
    #endregion
    #endregion

    #region BaseForm
    #region PropertyGrid

    #region Control
    /// <summary>
    /// Class PropertyGridForm.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class PropertyGridForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyGridForm"/> class.
        /// </summary>
        public PropertyGridForm()
        {
            InitializeComponent();
        }

        //        private System.Collections.Generic.Dictionary<string, Control> xDic = new Dictionary<string, Control>();
        /// <summary>
        /// Handles the Load event of the PropertyGridForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void PropertyGridForm_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles the ControlAdded event of the panelForControls control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ControlEventArgs"/> instance containing the event data.</param>
        private void panelForControls_ControlAdded(object sender, ControlEventArgs e)
        {
            e.Control.DoubleClick += new EventHandler(Control_DoubleClick);
        }

        /// <summary>
        /// Handles the DoubleClick event of the Control control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void Control_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Control xControl = (Control)sender;
                if (xControl.Name == pControl.Name)
                    return;
                propertyGrid.SelectedObject = sender;
                cbControl.SelectedItem = xControl.Name;
            }
            catch (Exception EX)
            {

            }
        }

        /*
                private void panelForControls_ControlAdded(object sender, ControlEventArgs e)
                {
                    if(xDic.ContainsKey(e.Control.Name))
                        xDic[e.Control.ToString()]=e.Control;
                    else
                        xDic.Add(e.Control.ToString(),e.Control);
                    PopulateCombo();
                }

                private void panelForControls_ControlRemoved(object sender, ControlEventArgs e)
                {
                    if(xDic.ContainsKey(e.Control.Name))
                        xDic.Remove(e.Control.Name);
                    PopulateCombo();
                }
        */
        /// <summary>
        /// Populates the combo.
        /// </summary>
        protected void PopulateCombo()
        {
            DataTable xTable = new DataTable();
            xTable.Columns.Add("Name", System.Type.GetType("System.String"));
            xTable.Columns.Add("Control", new Control().GetType());
            //            foreach (string Key in xDic.Keys)
            foreach (Control xControl in panelForControls.Controls)
            {
                if (xControl.Name == pControl.Name)
                    continue;
                DataRow xRow = xTable.NewRow();
                xRow["Name"] = xControl.Name;
                xRow["Control"] = xControl;
                xTable.Rows.Add(xRow);
            }
            cbControl.DataSource = xTable;
            cbControl.DisplayMember = "Name";
            cbControl.ValueMember = "Control";
            if (cbControl.Items.Count > 0)
            {
                cbControl.SelectedIndex = 0;
                cbControl_SelectedIndexChanged(null, null);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cbControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cbControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            propertyGrid.SelectedObject = cbControl.SelectedValue;
        }


    }
    #endregion

    #region Designer Generated Code
    partial class PropertyGridForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panelForControls = new System.Windows.Forms.Panel();
            this.pControl = new System.Windows.Forms.Panel();
            this.cbControl = new System.Windows.Forms.ComboBox();
            this.lControl = new System.Windows.Forms.Label();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.lControl2 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelForControls.SuspendLayout();
            this.pControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.splitContainer);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(699, 463);
            this.panelMain.TabIndex = 1;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panelForControls);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AutoScroll = true;
            this.splitContainer.Panel2.Controls.Add(this.propertyGrid);
            this.splitContainer.Size = new System.Drawing.Size(699, 463);
            this.splitContainer.SplitterDistance = 475;
            this.splitContainer.TabIndex = 1;
            // 
            // panelForControls
            // 
            this.panelForControls.AutoScroll = true;
            this.panelForControls.Controls.Add(this.pControl);
            this.panelForControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForControls.Location = new System.Drawing.Point(0, 0);
            this.panelForControls.Name = "panelForControls";
            this.panelForControls.Size = new System.Drawing.Size(475, 463);
            this.panelForControls.TabIndex = 0;
            this.panelForControls.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.panelForControls_ControlAdded);
            // 
            // pControl
            // 
            this.pControl.Controls.Add(this.cbControl);
            this.pControl.Controls.Add(this.lControl2);
            this.pControl.Controls.Add(this.lControl);
            this.pControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pControl.Location = new System.Drawing.Point(0, 415);
            this.pControl.Name = "pControl";
            this.pControl.Size = new System.Drawing.Size(475, 48);
            this.pControl.TabIndex = 0;
            // 
            // cbControl
            // 
            this.cbControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbControl.FormattingEnabled = true;
            this.cbControl.Location = new System.Drawing.Point(109, 18);
            this.cbControl.Name = "cbControl";
            this.cbControl.Size = new System.Drawing.Size(188, 21);
            this.cbControl.TabIndex = 1;
            this.cbControl.SelectedIndexChanged += new System.EventHandler(this.cbControl_SelectedIndexChanged);
            // 
            // lControl
            // 
            this.lControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lControl.Location = new System.Drawing.Point(3, 11);
            this.lControl.Name = "lControl";
            this.lControl.Size = new System.Drawing.Size(100, 32);
            this.lControl.TabIndex = 0;
            this.lControl.Text = "Select Control From Combo";
            this.lControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(220, 463);
            this.propertyGrid.TabIndex = 0;
            // 
            // lControl2
            // 
            this.lControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lControl2.Location = new System.Drawing.Point(303, 11);
            this.lControl2.Name = "lControl2";
            this.lControl2.Size = new System.Drawing.Size(111, 30);
            this.lControl2.TabIndex = 0;
            this.lControl2.Text = "or DoubleClick on it";
            this.lControl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PropertyGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 463);
            this.Controls.Add(this.panelMain);
            this.Name = "PropertyGridForm";
            this.Text = "PropertyGridForm";
            this.Load += new System.EventHandler(this.PropertyGridForm_Load);
            this.panelMain.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.panelForControls.ResumeLayout(false);
            this.pControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The panel main
        /// </summary>
        private System.Windows.Forms.Panel panelMain;
        /// <summary>
        /// The split container
        /// </summary>
        private System.Windows.Forms.SplitContainer splitContainer;
        /// <summary>
        /// The property grid
        /// </summary>
        private System.Windows.Forms.PropertyGrid propertyGrid;
        /// <summary>
        /// The panel for controls
        /// </summary>
        public System.Windows.Forms.Panel panelForControls;
        /// <summary>
        /// The p control
        /// </summary>
        private System.Windows.Forms.Panel pControl;
        /// <summary>
        /// The l control
        /// </summary>
        private System.Windows.Forms.Label lControl;
        /// <summary>
        /// The cb control
        /// </summary>
        private System.Windows.Forms.ComboBox cbControl;
        /// <summary>
        /// The l control2
        /// </summary>
        private System.Windows.Forms.Label lControl2;
    }
    #endregion
    #endregion

    #endregion

    #region LogPanel

    #region Control
    /// <summary>
    /// Class ZeroitLogPanel.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [Designer(typeof(ZeroitLogPanelDesigner))]
    public partial class ZeroitLogPanel : UserControl
    {
        #region Private Fields
        /// <summary>
        /// Occurs when [text box full].
        /// </summary>
        [Category("Buffer")]
        public event EventHandler TextBoxFull = null;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLogPanel"/> class.
        /// </summary>
        public ZeroitLogPanel()
        {
            InitializeComponent();


            textBoxLog.Clear();
        }
        #endregion

        #region Public Properties

        #region New Line After Message
        /// <summary>
        /// The add line
        /// </summary>
        public bool AddLine = true;
        /// <summary>
        /// The clear on full
        /// </summary>
        private bool ClearOnFull = false;

        /// <summary>
        /// Gets or sets a value indicating whether [new line after message].
        /// </summary>
        /// <value><c>true</c> if [new line after message]; otherwise, <c>false</c>.</value>
        [Category("LogDesign")]
        public bool NewLineAfterMessage
        {
            get
            {
                return AddLine;
            }
            set
            {
                AddLine = true;
            }
        }
        #endregion

        #region Length
        /// <summary>
        /// Gets or sets the maximum length.
        /// </summary>
        /// <value>The maximum length.</value>
        [Category("LogDesign")]
        public int MaxLength
        {
            get
            {
                return textBoxLog.MaxLength;
            }
            set
            {
                textBoxLog.MaxLength = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic clear on full].
        /// </summary>
        /// <value><c>true</c> if [automatic clear on full]; otherwise, <c>false</c>.</value>
        [Category("LogDesign")]
        public bool AutoClearOnFull
        {
            get
            {
                return ClearOnFull;
            }
            set
            {
                ClearOnFull = value;
            }
        }
        #endregion

        #region Title
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [Category("LogDesign")]
        public string Title
        {
            get
            {
                return labelLog.Text;
            }
            set
            {
                labelLog.Text = value;
                labelLog.Visible = (value != String.Empty);
            }
        }
        #endregion

        #endregion

        #region Logger
        /// <summary>
        /// Delegate LogMessageCallback
        /// </summary>
        /// <param name="Message">The message.</param>
        delegate void LogMessageCallback(string Message);

        /// <summary>
        /// Logs the message.
        /// </summary>
        /// <param name="Message">The message.</param>
        [System.Diagnostics.DebuggerStepThrough()]
        public void LogMessage(string Message)
        {
            if (Message == "")
                return;
            if (textBoxLog.InvokeRequired)
            {
                LogMessageCallback Temp = new LogMessageCallback(LogMessage);
                textBoxLog.Invoke(Temp, new object[] { Message });
            }
            else
            {
                if (textBoxLog.Text.Length + Message.Length >= textBoxLog.MaxLength)
                {
                    if (TextBoxFull != null)
                        TextBoxFull(this, new EventArgs());
                    if (AutoClearOnFull)
                        textBoxLog.Clear();
                }
                textBoxLog.AppendText(Message);
                if (AddLine)
                    textBoxLog.AppendText(Environment.NewLine);
            }
        }
        #endregion

        #region LogClear
        /// <summary>
        /// Delegate LogClearCallback
        /// </summary>
        delegate void LogClearCallback();

        /// <summary>
        /// Logs the clear.
        /// </summary>
        [System.Diagnostics.DebuggerStepThrough()]
        public void LogClear()
        {
            if (textBoxLog.InvokeRequired)
            {
                LogClearCallback Temp = new LogClearCallback(LogClear);
                textBoxLog.Invoke(Temp, null);
            }
            else
            {
                textBoxLog.Clear();
            }
        }
        #endregion
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitLogPanelDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitLogPanelDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        /// <summary>
        /// The action lists
        /// </summary>
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu.
        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new ZeroitLogPanelSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitLogPanelSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitLogPanelSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitLogPanel colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLogPanelSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitLogPanelSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitLogPanel;

            // Cache a reference to DesignerActionUIService, so the 
            // DesigneractionList can be refreshed. 
            this.designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        // Helper method to retrieve control properties. Use of GetProperties enables undo and menu updates to work properly.
        /// <summary>
        /// Gets the name of the property by.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        /// <returns>PropertyDescriptor.</returns>
        /// <exception cref="ArgumentException">Matching ColorLabel property not found!</exception>
        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(colUserControl)[propName];
            if (null == prop)
                throw new ArgumentException("Matching ColorLabel property not found!", propName);
            else
                return prop;
        }

        #region Properties that are targets of DesignerActionPropertyItem entries.

        /// <summary>
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor
        {
            get
            {
                return colUserControl.BackColor;
            }
            set
            {
                GetPropertyByName("BackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get
            {
                return colUserControl.ForeColor;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [new line after message].
        /// </summary>
        /// <value><c>true</c> if [new line after message]; otherwise, <c>false</c>.</value>
        public bool NewLineAfterMessage
        {
            get
            {
                return colUserControl.NewLineAfterMessage;
            }
            set
            {
                GetPropertyByName("NewLineAfterMessage").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum length.
        /// </summary>
        /// <value>The maximum length.</value>
        public int MaxLength
        {
            get
            {
                return colUserControl.MaxLength;
            }
            set
            {
                GetPropertyByName("MaxLength").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic clear on full].
        /// </summary>
        /// <value><c>true</c> if [automatic clear on full]; otherwise, <c>false</c>.</value>
        public bool AutoClearOnFull
        {
            get
            {
                return colUserControl.AutoClearOnFull;
            }
            set
            {
                GetPropertyByName("AutoClearOnFull").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get
            {
                return colUserControl.Title;
            }
            set
            {
                GetPropertyByName("Title").SetValue(colUserControl, value);
            }
        }




        #endregion

        #region DesignerActionItemCollection

        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Appearance"));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("NewLineAfterMessage",
                                 "New Line After Message", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("MaxLength",
                                 "Max Length", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("AutoClearOnFull",
                                 "Auto Clear On Full", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("Title",
                                 "Title", "Appearance",
                                 "Type few characters to filter Cities."));


            //Create entries for static Information section.
            StringBuilder location = new StringBuilder("Product: ");
            location.Append(colUserControl.ProductName);
            StringBuilder size = new StringBuilder("Version: ");
            size.Append(colUserControl.ProductVersion);
            items.Add(new DesignerActionTextItem(location.ToString(),
                             "Information"));
            items.Add(new DesignerActionTextItem(size.ToString(),
                             "Information"));

            return items;
        }

        #endregion




    }

    #endregion

    #endregion

    #endregion

    #region Designer Generated Code
    partial class ZeroitLogPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.Panel();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.labelLog = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.textBoxLog);
            this.panel.Controls.Add(this.labelLog);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(150, 150);
            this.panel.TabIndex = 0;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLog.Location = new System.Drawing.Point(0, 23);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(150, 127);
            this.textBoxLog.TabIndex = 1;
            // 
            // labelLog
            // 
            this.labelLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLog.Location = new System.Drawing.Point(0, 0);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(150, 23);
            this.labelLog.TabIndex = 0;
            this.labelLog.Text = "Log";
            this.labelLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogPanel
            // 
            this.Controls.Add(this.panel);
            this.Name = "LogPanel";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        /// <summary>
        /// The panel
        /// </summary>
        private System.Windows.Forms.Panel panel;
        /// <summary>
        /// The label log
        /// </summary>
        private System.Windows.Forms.Label labelLog;
        /// <summary>
        /// The text box log
        /// </summary>
        private System.Windows.Forms.TextBox textBoxLog;
    }
    #endregion
    #endregion
}
