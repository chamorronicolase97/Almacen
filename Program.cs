using Almacen.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen
{

        internal static class Program
        {
            /// <summary>
            ///  The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
            License.LicenseKey = "IRONSUITE.CHAMO.NICO.97.GMAIL.COM.6681-8ED63416EF-BH7GC3NMUEFHZOKW-G3K3RI3MVKBE-QL5TCHXJSKIB-6QHOM3RTNRMC-FQGWM5QYM5VX-6KT3DU23NNZM-GKKMRS-TYZZR2VKSO2NUA-DEPLOYMENT.TRIAL-NB3FQ3.TRIAL.EXPIRES.23.OCT.2024";
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
                Application.Run(new frmPrincipal());
            }
        }
    
}
