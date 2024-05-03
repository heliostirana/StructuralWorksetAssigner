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
using Autodesk.Revit.DB.Structure;
using System.Diagnostics;



namespace HLO
{

    [Transaction(TransactionMode.Manual)]
    public class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // main variables declared
            var uiapp = commandData.Application;
            var uidoc = uiapp.ActiveUIDocument;
            var app = uiapp.Application;
            var doc = uidoc.Document;

            // user input called

            Form1 form1 = new Form1(commandData);
            form1.ShowDialog();
            if (!form1.fail)
            {
                return Result.Cancelled;
            }

            // FAMILY NAMES
            string colName = "S_COLUMN";
            string wallName = "S_WALL";
            string slabName = "S_SLAB";
            string framingName = "S_BEAM";
            string foundName = "S_FOUNDATION";
            string shaftName = "S_SHAFT";
            string stairName = "S_STAIR";


            // OBTAIN WORKSET ID FROM WORKSET NAME

            FilteredWorksetCollector collector = new FilteredWorksetCollector(doc);

            using (var transaction = new Transaction(doc, "Set Worksets"))
            {
                transaction.Start();
                if (form1.column)
                {
                    var colWorkset = collector.FirstOrDefault<Workset>(e => e.Name.Equals(colName));
                    var columnWorkId = new WorksetId(colWorkset.Id.IntegerValue);

                    FilteredElementCollector colCollector = new FilteredElementCollector(doc);
                    ElementCategoryFilter columnFilter = new ElementCategoryFilter(BuiltInCategory.OST_StructuralColumns);

                    IList<Element> columns = colCollector.WherePasses(columnFilter).WhereElementIsNotElementType().ToElements();

                    foreach (var col in columns)
                    {
                        ElementId familyId = col.Id;
                        string famName = doc.GetElement(familyId).get_Parameter(BuiltInParameter.ELEM_CATEGORY_PARAM).AsValueString();
                        int prop = doc.GetElement(familyId).get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM).AsInteger();
                        FamilyInstance fi = col as FamilyInstance;
                        if ((famName.StartsWith("Structural") && form1.column)) // COLUMN ASSIGN
                        {
                            Parameter wsparam = col.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM);
                            wsparam.Set(columnWorkId.IntegerValue);

                        }
                    }

                }

                if (form1.wall)
                {
                    var waWorkset = collector.FirstOrDefault<Workset>(e => e.Name.Equals(wallName));
                    var wallWorkId = new WorksetId(waWorkset.Id.IntegerValue);

                    FilteredElementCollector wallCollector = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Walls);

                    foreach (var wall in wallCollector) // swap out with familyIds
                    {
                        ElementId familyId = wall.Id;
                        string famName = doc.GetElement(familyId).get_Parameter(BuiltInParameter.ELEM_TYPE_PARAM).AsValueString();

                        if (famName.ToUpper().StartsWith("SSA")) // WALL
                        {
                            doc.GetElement(familyId).get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM).Set(wallWorkId.IntegerValue);
                        }
                    }

                }

                if (form1.slab)
                {
                    var slWorkset = collector.FirstOrDefault<Workset>(e => e.Name.Equals(slabName));
                    var slabWorkId = new WorksetId(slWorkset.Id.IntegerValue);

                    FilteredElementCollector slabCollector = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors);

                    foreach (var slab in slabCollector)
                    {
                        string famName = doc.GetElement(slab.Id).get_Parameter(BuiltInParameter.ELEM_TYPE_PARAM).AsValueString();
                        if ((famName.ToUpper().StartsWith("SSA") && form1.slab)) // SLAB ASSIGN
                        {
                            doc.GetElement(slab.Id).get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM).Set(slabWorkId.IntegerValue);
                        }
                    }

                }
                if (form1.framing)
                {
                    var frWorkset = collector.FirstOrDefault<Workset>(e => e.Name.Equals(framingName));
                    var framWorkId = new WorksetId(frWorkset.Id.IntegerValue);

                    FilteredElementCollector framCollector = new FilteredElementCollector(doc);
                    ElementCategoryFilter framingFilter = new ElementCategoryFilter(BuiltInCategory.OST_StructuralFraming);

                    IList<Element> framing = framCollector.WherePasses(framingFilter).WhereElementIsNotElementType().ToElements();

                    foreach (var beam in framing)
                    {

                        string famName = doc.GetElement(beam.Id).get_Parameter(BuiltInParameter.ELEM_CATEGORY_PARAM).AsValueString();
                        if (famName.StartsWith("Structural") && form1.framing) // FRAMING
                        {
                            Parameter wsparam = beam.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM);
                            wsparam.Set(framWorkId.IntegerValue);
                        }
                    }
                }

                if (form1.foundation)
                {
                    var foundWorkset = collector.FirstOrDefault<Workset>(e => e.Name.Equals(foundName));
                    var foundWorkId = new WorksetId(foundWorkset.Id.IntegerValue);

                    FilteredElementCollector foundCollector = new FilteredElementCollector(doc);
                    ElementCategoryFilter foundationFilter = new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation);

                    IList<Element> foundations = foundCollector.WherePasses(foundationFilter).WhereElementIsNotElementType().ToElements();

                    foreach (var foundation in foundations)
                    {
                        string famName = doc.GetElement(foundation.Id).get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString();
                        string categName = doc.GetElement(foundation.Id).get_Parameter(BuiltInParameter.ELEM_CATEGORY_PARAM).AsValueString();
                        if ((famName.ToUpper().StartsWith("SSA") || categName.ToUpper().StartsWith("STRUCTURAL")) && form1.foundation)
                        {
                            Parameter wsparam = foundation.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM);
                            wsparam.Set(foundWorkId.IntegerValue);
                        }
                    }
                }

                if (form1.shaft)
                {
                    var shaftWorkset = collector.FirstOrDefault<Workset>(e => e.Name.Equals(shaftName));
                    var shaftWorkId = new WorksetId(shaftWorkset.Id.IntegerValue);

                    FilteredElementCollector shaftCollector = new FilteredElementCollector(doc);
                    ElementCategoryFilter shaftFilter = new ElementCategoryFilter(BuiltInCategory.OST_ShaftOpening);

                    IList<Element> shafts = shaftCollector.WherePasses(shaftFilter).WhereElementIsNotElementType().ToElements();

                    foreach (var shaft in shafts)
                    {
                        string categName = doc.GetElement(shaft.Id).get_Parameter(BuiltInParameter.ELEM_CATEGORY_PARAM).AsValueString();
                        if (form1.shaft)
                        {
                            Parameter wsparam = shaft.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM);
                            wsparam.Set(shaftWorkId.IntegerValue);
                        }
                    }
                }

                if (form1.stairs)
                {
                    var stairWorkset = collector.FirstOrDefault<Workset>(e => e.Name.Equals(stairName));
                    var stairWorkId = new WorksetId(stairWorkset.Id.IntegerValue);

                    FilteredElementCollector stairCollector = new FilteredElementCollector(doc);
                    ElementCategoryFilter stairFilter = new ElementCategoryFilter(BuiltInCategory.OST_Stairs);

                    IList<Element> stairs = stairCollector.WherePasses(stairFilter).WhereElementIsNotElementType().ToElements();

                    foreach (var stair in stairs)
                    {
                        if (form1.stairs)
                        {
                            Parameter wsparam = stair.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM);
                            wsparam.Set(stairWorkId.IntegerValue);
                        }
                    }
                }

                transaction.Commit();
                TaskDialog.Show("Alert", "Success");

            }


            // tick

            return Result.Succeeded;
        }


            

        
    }
}