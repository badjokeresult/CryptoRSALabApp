using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptoRSALabApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private KeyPair? _firstKeyPair;
        private KeyPair? _secondKeyPair;

        private readonly RSAKeyGenerator _keyGenerator;
        private readonly RSATextEncryptor _textEncryptor;

        public MainWindow()
        {
            InitializeComponent();
            _keyGenerator = new RSAKeyGenerator();
            _textEncryptor = new RSATextEncryptor();
        }

        private void firstKeysGeneratingButton_Click(object sender, RoutedEventArgs e)
        {
            _firstKeyPair = _keyGenerator.GenerateKeyPair();

            firstPublicKeyTextBox.Text = _firstKeyPair.PublicKey.ToString();
            firstPrivateKeyTextBox.Text = _firstKeyPair.PrivateKey.ToString();

            secondCompanionPublicKeyTextBox.Text = _firstKeyPair.PublicKey.ToString();
        }

        private void secondKeysGeneratingButton_Click(object sender, RoutedEventArgs e)
        {
            _secondKeyPair = _keyGenerator.GenerateKeyPair();

            secondPublicKeyTextBox.Text = _secondKeyPair.PublicKey.ToString();
            secondPrivateKeyTextBox.Text= _secondKeyPair.PrivateKey.ToString();

            firstCompanionPublicKeyTextBox.Text = _secondKeyPair.PublicKey.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (firstSourceMessageTextBox.Text.Length > 0)
            {
            }
        }

        private void firstReceiveAndDecryptButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}