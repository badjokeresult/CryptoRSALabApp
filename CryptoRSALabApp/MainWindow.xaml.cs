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
            firstReceivedEncryptedMessageTextBox.Text = secondEncryptedMessageTextBox.Text;
            var encryptedMessage = firstReceivedEncryptedMessageTextBox.Text;

            var decryptedMessage = _textEncryptor.Decrypt(encryptedMessage, _firstKeyPair.PrivateKey.Item1, _firstKeyPair.PrivateKey.Item2);

            firstReceivedDecryptedMessageTextBox.Text = decryptedMessage;
        }

        private void firstEncryptAndSendButton_Click(object sender, RoutedEventArgs e)
        {
            var message = firstSourceMessageTextBox.Text;

            var encrypted = _textEncryptor.Encrypt(message, _secondKeyPair.PublicKey.Item1, _secondKeyPair.PublicKey.Item2);

            firstEncryptedMessageTextBox.Text = encrypted;
        }

        private void secondEncryptAndSendButton_Click(object sender, RoutedEventArgs e)
        {
            var message = secondSourceMessageTextBox.Text;

            var encrypted = _textEncryptor.Encrypt(message, _firstKeyPair.PublicKey.Item1, _firstKeyPair.PublicKey.Item2);

            secondEncryptedMessageTextBox.Text = encrypted;
        }

        private void secondReceiveAndDecryptButton_Click(object sender, RoutedEventArgs e)
        {
            secondReceivedEncryptedMessageTextBox.Text = firstEncryptedMessageTextBox.Text;
            var encryptedMessage = secondReceivedEncryptedMessageTextBox.Text;

            var decryptedMessage = _textEncryptor.Decrypt(encryptedMessage, _secondKeyPair.PrivateKey.Item1, _secondKeyPair.PrivateKey.Item2);

            secondReceivedDecryptedMessageTextBox.Text = decryptedMessage;
        }

        // Методы-заглушки, нужны, т.к. элементы интерфейса требуют реакции на их изменения
        // В данном случае никакой реакции не нужно
        private void firstPublicKeyTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void firstCompanionPublicKeyTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void secondPublicKeyTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void secondPrivateKeyTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void secondCompanionPublicKeyTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void firstSourceMessageTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void firstEncryptedMessageTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void secondSourceMessageTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void secondEncryptedMessageTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void firstReceivedEncryptedMessageTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void firstReceivedDecryptedMessageTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void secondReceivedDecryptedMessageTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}