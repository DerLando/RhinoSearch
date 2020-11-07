using Eto.Drawing;
using Eto.Forms;
using Rhino;
using RhinoSearch.Library.Calculations;
using RhinoSearch.Library.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhinoSearch.PlugIn.Views
{
    /// <summary>
    /// Main form to enable users to build queries against the <see cref="RhinoSearch"/> library
    /// </summary>
    public class QueryBuilderForm : Form
    {
        #region ui elements

        private Button btn_ExecuteQuery = new Button { Text = "Execute query" };
        private GroupBox gB_Query = new GroupBox { Text = "Query" };
        private EnumDropDown<ObjectModelType> eD_ObjectType = new EnumDropDown<ObjectModelType>();
        private EnumDropDown<NumberOperator> eD_NumberOperator = new EnumDropDown<NumberOperator>(); // TODO: needs to be more generic
        private EnumDropDown<TextOperator> eD_TextOperator = new EnumDropDown<TextOperator>();
        private DropDown dD_PropertyName = new DropDown();
        private TextBox tB_Comparer = new TextBox();

        #endregion

        #region collection datastores

        private string[] objectPropertyNames = PropertyHelper.ObjectModelPropertyNames.ToArray();
        private string[] blockPropertyNames = PropertyHelper.BlockInstanceModelPropertyNames.ToArray();
        private string[] groupPropertyNames = PropertyHelper.ObjectGroupModelPropertyNames.ToArray();

        #endregion

        public QueryBuilderForm()
        {
            #region Initial form setup

            // Set padding
            Padding = new Padding(5);

            // Set title
            Title = "Query builder";

            #endregion

            #region event handlers

            btn_ExecuteQuery.Click += Btn_ExecuteQuery_Click;
            eD_ObjectType.SelectedValueChanged += ED_ObjectType_SelectedValueChanged;
            // TODO: Subscribe to propertyname changes and change list of possible operators accordingly
            #endregion

            #region drop down setup

            dD_PropertyName.DataStore = objectPropertyNames;

            #endregion

            var layout = new DynamicLayout();
            layout.Padding = new Padding(5);
            layout.Spacing = new Size(5, 5);
            layout.AddRow(new Control[] { eD_ObjectType, dD_PropertyName, eD_NumberOperator, tB_Comparer });
            gB_Query.Content = layout;


            layout = new DynamicLayout();
            layout.Padding = new Padding(5);
            layout.Spacing = new Size(5, 5);

            layout.AddRow(gB_Query);
            layout.AddRow(btn_ExecuteQuery);

            layout.Add(null);
            Content = layout;
        }

        private void ED_ObjectType_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (eD_ObjectType.SelectedValue)
            {
                case ObjectModelType.Object:
                    dD_PropertyName.DataStore = objectPropertyNames;
                    break;
                case ObjectModelType.Block:
                    dD_PropertyName.DataStore = blockPropertyNames;
                    break;
                case ObjectModelType.Group:
                    dD_PropertyName.DataStore = groupPropertyNames;
                    break;
            }
        }

        private void Btn_ExecuteQuery_Click(object sender, EventArgs e)
        {
            RhinoApp.WriteLine($"{eD_ObjectType.SelectedValue}_{dD_PropertyName.SelectedValue}_{eD_NumberOperator.SelectedValue}_{tB_Comparer.Text}");
        }
        
    }
}