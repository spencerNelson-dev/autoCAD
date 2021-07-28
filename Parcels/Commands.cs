using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcels
{
    public partial class Commands
    {
        [CommandMethod("PS_HELLO")]
        public void Hello()
        {
            var document = Application.DocumentManager.MdiActiveDocument;
            var editor = document.Editor;

            editor.WriteMessage("Hello World");
        }

        [CommandMethod("PS_CreateParcelLayer")]
        public void CreateLayer()
        {
            var creator = new ParcelLayer();
            creator.Create();
        }

        [CommandMethod("PS_CountParcels")]
        public void CountParcels()
        {
            var cmd = new ParcelCounter();
            var summary = cmd.Count();

            var summarizer = new ParcelSummarizer();

            summary.Write(summarizer, new AutocadMessageWriter());

            var myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            summary.Write(new TextParcelSummarizer(summarizer),
                new TextMessageWriter(Path.Combine(myDocuments, "ParcelSummary.txt"), true));

            summary.Write(new HtmlParcelSummarizer(),
                new TextMessageWriter(Path.Combine(myDocuments, "ParcelSummary.html"), false));
        }

        [CommandMethod("VE_ReadCustomProp")]
        public void GetCustomProp()
        {
            var document = Active.Document;
            var database = Active.Database;

            var properties = database.SummaryInfo.CustomProperties;

            var writer = new AutocadMessageWriter();

            while (properties.MoveNext())
            {
                writer.WriteMessage("\n- Custom Prop: " + properties.Key + " = " + properties.Value);
            }

        }

    }
}
