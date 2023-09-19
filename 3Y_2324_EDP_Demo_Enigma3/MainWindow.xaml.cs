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

namespace _3Y_2324_EDP_Demo_Enigma3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool caps = false;
        bool initialState = true;
        string defaultMessage = "Just type whatever...";
        private Dictionary<string, char> numbers = new Dictionary<string, char>()
        {
            {"D1",'1'}, {"D2",'2'}, {"D3",'3'}, {"D4",'4'}, {"D5",'5'}, {"D6",'6'},
            {"D8",'8'}, {"D9",'9'}, {"D0",'0'}
        };
        private Dictionary<string, char> specialChar = new Dictionary<string, char>()
        {
            {"D1",'!'}, {"D2",'@'}, {"D3",'#'}, {"D4",'$'}, {"D5",'%'},  {"D6",'^'},
            {"D7",'&'}, {"D8",'*'}, {"D9",'('}, {"D0",')'}
        };

        public MainWindow()
        {
            InitializeComponent();

            if(initialState)
                lblInput.Content = defaultMessage;
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (initialState) 
            {
                initialState = false;
                lblInput.Content = KeyManager(e.Key);
            }
            else
                lblInput.Content += KeyManager(e.Key) + "";
            lblDebug.Content = e.Key.ToString();
        }

        private char KeyManager(Key input)
        {
            char retVal = '\b';
            switch (input)
            {
                case Key.Space:
                    retVal = ' ';
                    break;
                case Key.LeftShift:
                case Key.RightShift:
                    caps = false;
                    break;
                case Key.Back:
                    break;
                case Key.D1:
                    if(!caps)
                        retVal = '1';
                    else
                        retVal = '!';
                    break;
                case Key.D2:
                    if(!caps)
                        retVal = '2';
                    else
                        retVal = '@';
                    break;
                case Key.D3:
                    if(!caps)
                        retVal = '3';
                    else
                        retVal = '#';
                    break;
                case Key.D4:
                    if(!caps)
                        retVal = '4';
                    else
                        retVal = '$';
                    break;
                case Key.D5:
                    if(!caps)
                        retVal = '5';
                    else
                        retVal = '%';
                    break;
                case Key.D6:
                    if(!caps)
                        retVal = '6';
                    else
                        retVal = '^';
                    break;
                case Key.D7:
                    if(!caps)
                        retVal = '7';
                    else
                        retVal = '&';
                    break;
                case Key.D8:
                    if(!caps)
                        retVal = '8';
                    else
                        retVal = '*';
                    break;
                case Key.D9:
                    if(!caps)
                        retVal = '9';
                    else
                        retVal = '(';
                    break;
                case Key.D0:
                    if(!caps)
                        retVal = '0';
                    else
                        retVal = ')';
                    break;
                default:
                    if(!caps)
                        retVal = input.ToString().ToLower()[0];
                    else
                        retVal = input.ToString()[0];
                    break;
            }
            return retVal;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.LeftShift:
                case Key.RightShift:
                    caps = true;
                    break;
            }
        }
    }
}
