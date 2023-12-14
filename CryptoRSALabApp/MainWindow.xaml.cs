using System.Windows;

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

        private void firstReceiveAndDecryptButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void firstEncryptAndSendButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void secondEncryptAndSendButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void secondReceiveAndDecryptButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}