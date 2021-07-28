using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;

namespace AU.MySoftware
{
    class Initialization : IExtensionApplication
    {
        public void Initialize()
        {

        }

        public void Terminate()
        {

        }

        [CommandMethod("MyFirstCommand")]
        public void MyFirstCommand()
        {
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage("\nI have created my first command");
        }
    }
}
