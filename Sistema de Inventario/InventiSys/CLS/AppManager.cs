using InventiSys.GUI;
using System;
using System.Windows.Forms;

namespace InventiSys.CLS
{
    internal class AppManager : ApplicationContext
    {
        private void SplashScreen()
        {
            try
            {
                Splash f = new Splash();
                f.ShowDialog();
            }
            catch (Exception)
            {
                // Manejar la excepción si es necesario
            }
        }

        public Boolean LoginScreen()
        {
            Boolean Resultado = false;
            try
            {
                Login f = new Login();
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
                f.FormClosed += (sender, e) => { ExitThread(); }; // Salir del contexto de la aplicación cuando se cierre la ventana principal
                f.Show();
            }
            else
            {
                ExitThread(); // Salir del contexto de la aplicación si no se autoriza el login
            }
        }
    }
}
