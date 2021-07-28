using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using System;

namespace Parcels
{
    public class ParcelLayer
    {
        public void Create()
        {
            var layerName = "Parcels";
            var document = Application.DocumentManager.MdiActiveDocument;
            var database = document.Database;

            using (Transaction transaction = database.TransactionManager.StartTransaction())
            {
                var layerTable = (LayerTable)transaction.GetObject(database.LayerTableId, OpenMode.ForRead);
                LayerTableRecord layer;
                if (!layerTable.Has(layerName))
                {
                    layer = new LayerTableRecord
                    {
                        Name = layerName,
                        Color = Color.FromColorIndex(ColorMethod.ByAci, 161)
                    };

                    layerTable.UpgradeOpen();
                    layerTable.Add(layer);
                    transaction.AddNewlyCreatedDBObject(layer, true);
                }
                database.Clayer = layerTable[layerName];
                transaction.Commit();
            }
        }
    }
}