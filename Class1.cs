using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Threading.Tasks;



namespace HLO
{

    [Transaction(TransactionMode.Manual)]
    public class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiapp = commandData.Application;
            var uidoc = uiapp.ActiveUIDocument;
            var app = uiapp.Application;
            var doc = uidoc.Document;

            // FOR ONE ELEMENT ONLY
            /* var element = uidoc.Selection.GetElementIds().Select(x => doc.GetElement(x)).First();
             var value = element.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).AsString(); */

            Form1 form1 = new Form1(commandData);
            form1.worksetName = "Enter workset";
            form1.ShowDialog();
            string worksetName = form1.worksetName;

            // OBTAIN WORKSET ID FROM WORKSET NAME

            FilteredWorksetCollector col = new FilteredWorksetCollector(doc);
            Workset workset = col.FirstOrDefault<Workset>(e => e.Name.Equals(worksetName));
            WorksetTable worksetTable = doc.GetWorksetTable();
            WorksetId worksetId = new WorksetId(workset.Id.IntegerValue);
            /* WorksetTable worksetTable = doc.GetWorksetTable();
            FilteredWorksetCollector collector = new FilteredWorksetCollector(doc);
            ICollection<WorksetId> worksetIds = collector.ToWorksetIds();

            WorksetId worksetId = null;

           foreach (WorksetId id in worksetIds)
            {
                Workset workset = worksetTable.GetWorkset(id);
                if (workset.Name.ToLower() == worksetName.ToLower())
                {
                    worksetId = id;
                    break;
                }
            } */
            
           
            
            var familyIds = uidoc.Selection.GetElementIds();
            var families = new List<Element>();
            using (var transaction = new Transaction(doc, "Set Values"))
            {
                transaction.Start();
                foreach (var familyId in familyIds)
                {
                    doc.GetElement(familyId).get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM).Set(worksetId.IntegerValue);
                }
                transaction.Commit();
            }
            

            
            


            


            /* using (var transaction = new Transaction(doc, "Set Values"))
            {
                transaction.Start();
                element.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM).Set(worksetId);
                transaction.Commit();
            }
            TaskDialog.Show("Message", "Successfully set workset"); */

            /* var familyInstanceFilter = new ElementClassFilter(typeof(FamilyInstance));

            var colsCategoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_StructuralColumns);
            var logicalAndFilter = new LogicalAndFilter(familyInstanceFilter, colsCategoryFilter);

            var collector = new FilteredElementCollector(doc).WherePasses(logicalAndFilter);
            var familyIds = uidoc.Selection.GetElementIds();

            var families = new List<Element>();
            foreach (var familyId in familyIds)
            {
                families.Add(doc.GetElement(familyId));
            }

            SimpleForm simpleForm = new SimpleForm(collector);
            simpleForm.ShowDialog(); */


            return Result.Succeeded;
        }

        
    }
}