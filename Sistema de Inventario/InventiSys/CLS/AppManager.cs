using InventiSys.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventiSys.CLS
{
    internal class AppManager : ApplicationContext
    {
        private void SplashScreen()
        {
            try
            {
                GUI.Splash f = new GUI.Splash();
                f.ShowDialog();
            }
            catch (Exception)
            {
            }
        }
        public Boolean LoginScreen()
        {
            Boolean Resultado = false;
            try
            {
                GUI.Login f = new GUI.Login();
                f.ShowDialog();
                Resultado = f.Autorizado;
            }
            catch (Exception)
            {
                Resultado = false;
            }
            return Resultado;

        }
        public AppManager()
        {
            SplashScreen();
            if (LoginScreen())
            {
                Principal f = new Principal();
                f.Show();
            }
        }
    }
}
