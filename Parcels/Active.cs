﻿using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcels
{
    public static class Active
    {
        public static Document Document => Application.DocumentManager.MdiActiveDocument;

        public static Editor Editor => Document.Editor;

        public static Database Database => Document.Database;

        public static void UsingTransaction(Action<Transaction> action)
        {
            using (Transaction transaction = Active.Database.TransactionManager.StartTransaction())
            {
                action(transaction);

                transaction.Commit();
            }
        }
    }
}
