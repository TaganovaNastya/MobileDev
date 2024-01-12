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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            txtUsernamePlaceholder.Visibility = string.IsNullOrWhiteSpace(txtUsername.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            txtUsernamePlaceholder.Visibility = string.IsNullOrWhiteSpace(txtUsername.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPasswordPlaceholder.Visibility = string.IsNullOrWhiteSpace(txtPassword.Password) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            txtPasswordPlaceholder.Visibility = string.IsNullOrWhiteSpace(txtPassword.Password) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtUsernamePlaceholder.Visibility = string.IsNullOrWhiteSpace(txtUsername.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtPasswordPlaceholder.Visibility = string.IsNullOrWhiteSpace(txtPassword.Password) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password.Trim();

            if (!IsValidEmail(username))
            {
                MessageBox.Show("Логин введён не верно", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (password.Length < 5)
            {
                MessageBox.Show("Пароль должен быть длинее 5 символов", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
            MessageBox.Show($"Вошли!\nUsername: {username}\nPassword: {password}", "Login Successful", MessageBoxButton.OK, MessageBoxImage.Information);// Добавьте код для обработки авторизации здесь
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnAuthorize_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show("Регистрация!");
            
        }
    }
}
