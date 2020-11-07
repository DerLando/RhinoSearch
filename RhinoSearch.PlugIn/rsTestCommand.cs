using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using RhinoSearch.Library.Data;
using RhinoSearch.Library.Models;
using RhinoSearch.PlugIn.Views;

namespace RhinoSearch.PlugIn
{
    public class rsTestCommand : Command
    {
        private QueryBuilderForm form { get; set; }

        public rsTestCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static rsTestCommand Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "rsTestCommand"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            RhinoApp.WriteLine("The {0} command is under construction.", EnglishName);

            if(null == form)
            {
                form = new QueryBuilderForm();
                form.Closed += Form_Closed;
                form.Show();
            }


            // DEBUG
            var testQuery = new QueryGroupModel
            {
                Gate = LogicGate.And
            };

            var lhs = new NumberExpressionModel
            {
                Operator = NumberOperator.Equal,
                PropertyName = "Area",
                Rhs = 25.0
            };

            testQuery.Lhs = lhs;

            var nestedLhs = new TextExpressionModel
            {
                Operator = TextOperator.Equals,
                PropertyName = "Name",
                Rhs = "Test"
            };

            testQuery.Rhs = new QueryGroupModel { Lhs = nestedLhs };

            var result = ObjectTable.ExecuteQuery(doc, testQuery, ObjectModelType.Object);
            // TODO: Next step is to flesh out the QueryObjectTable and run queries against i


            return Result.Success;




        }

        private void Form_Closed(object sender, EventArgs e)
        {
            form.Dispose();
            form = null;
        }
    }
}
