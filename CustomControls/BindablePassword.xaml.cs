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

namespace TasksProject.CustomControls
{
    
    public partial class BindablePassword : UserControl
    {
        private bool _isPasswordChanging;
        
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(BindablePassword), new PropertyMetadata(string.Empty, PasswordPropertyCHanged));

        private static void PasswordPropertyCHanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is BindablePassword passwordBox)
            {

                passwordBox.UpdatePassword();
            }
        }

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }


        public BindablePassword()
        {
            InitializeComponent();
        }

        private void TxtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _isPasswordChanging = true;
            Password = txtPassword.Password;
            _isPasswordChanging = false;
        }
        private void UpdatePassword()
        {
            if (!_isPasswordChanging)
            {
                txtPassword.Password = Password;
            }

        }
    }
}
