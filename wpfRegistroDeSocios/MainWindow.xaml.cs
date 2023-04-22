using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpfRegistroDeSocios
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String strEdad;
        int edad, contadorSociosFem = 0, contadorSociosMasc = 0, contadorSocios = 0;
        double valorInscripcion = 45000, valorTenis = 250000, valorFutbol = 120000, porcentajeSubvencion = 0.85, promedioEdades = 0, sumaTotalAPagar = 45000, sumatoriaEdades = 0,
            totalPagarFuncionarios = 0, totalPagarEmpresa=0;
        bool socioFem, socioMasc;

        private void checkTenis_Checked(object sender, RoutedEventArgs e)
        {
            this.checkTenis.IsChecked = true;
            sumaTotalAPagar = sumaTotalAPagar + valorTenis;
            
        }

        private void checkFutbol_Checked(object sender, RoutedEventArgs e)
        {
            this.checkFutbol.IsChecked = true;
            sumaTotalAPagar = sumaTotalAPagar + valorFutbol;
        }        

        private void rbtnFem_Checked(object sender, RoutedEventArgs e)
        {
            socioFem = true;
            socioMasc = false;
        }
        private void rbtnMasc_Checked(object sender, RoutedEventArgs e)
        {
            socioMasc = true;
            socioFem = false;
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            this.txtRut.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtEdad.Text = string.Empty;

            this.lblSociosFem.Content = string.Empty;
            this.lblSociosMasc.Content = string.Empty;
            this.lblTotalSocios.Content = string.Empty;
            this.lblTotalAPagar.Content = string.Empty;
            this.lblPagoFuncionario.Content = string.Empty;
            this.lblPromedioEdad.Content = string.Empty;
            this.lblPagoEmpresa.Content = string.Empty;
            this.lblTotalAPagar.Content = string.Empty;

            socioFem = true;
            socioMasc = false;
            checkTenis.IsChecked = false;
            checkFutbol.IsChecked = false;
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            strEdad = this.txtEdad.Text;
            int.TryParse(strEdad, out edad);
            sumaTotalAPagar = valorInscripcion;

            if(socioFem == true)
            {
                contadorSociosFem++;
            }
            if(socioMasc == true)
            {
                contadorSociosMasc++;
            }
            if(checkTenis.IsChecked == true)
            {
                sumaTotalAPagar = sumaTotalAPagar + valorTenis;
            }
            if (checkFutbol.IsChecked == true)
            {
                sumaTotalAPagar = sumaTotalAPagar + valorFutbol;
            }          

            totalPagarEmpresa = sumaTotalAPagar * porcentajeSubvencion;

            totalPagarFuncionarios = sumaTotalAPagar - totalPagarEmpresa;

            contadorSocios++;

            sumatoriaEdades = sumatoriaEdades + edad;

            promedioEdades = sumatoriaEdades / contadorSocios;

            this.lblSociosFem.Content = contadorSociosFem;
            this.lblSociosMasc.Content = contadorSociosMasc;
            this.lblPromedioEdad.Content = promedioEdades;
            this.lblTotalSocios.Content = contadorSocios;

            this.lblTotalAPagar.Content = sumaTotalAPagar;
            this.lblPagoEmpresa.Content = totalPagarEmpresa;
            this.lblPagoFuncionario.Content = totalPagarFuncionarios;
        }
    }
}
