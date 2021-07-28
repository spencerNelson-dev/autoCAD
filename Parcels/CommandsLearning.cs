using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Parcels
{
    public partial class Commands
    {
        #region Control the Application Window
        [CommandMethod("PositionApplicationWindow")]
        public static void PositionApplicationWindow()
        {
            Point ptApp = new Point(0, 0);
            Application.MainWindow.DeviceIndependentLocation = ptApp;

            Size szApp = new Size(400, 400);
            Application.MainWindow.DeviceIndependentSize = szApp;
        }

        [CommandMethod("MinMaxApplicationWindow")]
        public static void  MinMaxApplicationWindow()
        {
            Application.MainWindow.WindowState = Window.State.Minimized;
            System.Windows.Forms.MessageBox.Show("Minimized", "MinMax",
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.None,
                System.Windows.Forms.MessageBoxDefaultButton.Button1,
                System.Windows.Forms.MessageBoxOptions.ServiceNotification);

            Application.MainWindow.WindowState = Window.State.Maximized;
            System.Windows.Forms.MessageBox.Show("Maxized", "MinMax");
        }

        [CommandMethod("CurrentWindowState")]
        public static void CurrentWindowState()
        {
            System.Windows.Forms.MessageBox.Show("The application window is " +
                Application.MainWindow.WindowState.ToString(),
                "Window State");
        }

        [CommandMethod("HideWindowState")]
        public static void HideWindowState()
        {
            // Hide Window
            Application.MainWindow.Visible = false;
            System.Windows.Forms.MessageBox.Show("Invisible", "Show/Hide");

            // Show the Application window
            Application.MainWindow.Visible = true;
            System.Windows.Forms.MessageBox.Show("Visible", "Show/Hide");

        }

        #endregion

        #region Control the Drawing Windows

        #region Position and Size the Document Window
        [CommandMethod("SizeDocumentWindow")]
        public static void SizeDocumentWindow()
        {
            Document acDoc = Active.Document;
            acDoc.Window.WindowState = Window.State.Normal;

            Point ptDoc = new Point(0, 0);
            acDoc.Window.DeviceIndependentLocation = ptDoc;

            Size szDoc = new Size(400, 400);
            acDoc.Window.DeviceIndependentSize = szDoc;
        }

        [CommandMethod("MinMaxDocumentWindow")]
        public static void MinMaxDocumentWindow()
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;

            // Minimize the Document window
            acDoc.Window.WindowState = Window.State.Minimized;
            System.Windows.Forms.MessageBox.Show("Minimized", "MinMax");

            // Maximize the Document window
            acDoc.Window.WindowState = Window.State.Maximized;
            System.Windows.Forms.MessageBox.Show("Maximized", "MinMax");
        }

        [CommandMethod("CurrentDocWindowState")]
        public static void CurrentDocWindowState()
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;

            System.Windows.Forms.MessageBox.Show("The document window is " +
            acDoc.Window.WindowState.ToString(), "Window State");
        }
        #endregion

        #region Zoom and Pan the Current View

        #region Manipulate the Current View
        static void Zoom(Point3d pMin, Point3d pMax, Point3d pCenter, double pFactor)
        {
            Document doc = Active.Document;
            Database database = Active.Database;

            int nCurVport = System.Convert.ToInt32(Application.GetSystemVariable("CVPORT"));

            // Get the extents of the current space no points
            // or only a center point is provided
            // check to see if Model space is current
            if (database.TileMode == true)
            {
                if (pMin.Equals(new Point3d()) == true &&
                    pMax.Equals(new Point3d()) == true)
                {
                    pMin = database.Extmin;
                    pMax = database.Extmax;
                }
            }
            else
            {
                // Check to see if Paper space is current
                if (nCurVport == 1)
                {
                    // Get the extents of Paper space
                    if (pMin.Equals(new Point3d()) == true &&
                        pMax.Equals(new Point3d()) == true)
                    {
                        pMin = database.Pextmin;
                        pMax = database.Pextmax;
                    }
                }
                else
                {

                }
            }
        }

        #endregion


        #endregion

        #endregion
    }
}
