using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lazuli
{
    internal class Encryption
    {
        string TextFolderPath = @"C:\\Users\\JoãoPedroTorres\\source\\repos\\Lazuli\\Lazuli\\Texts\";


        public void Encrypt(string message, string password,string entryTitle)
        {
            byte[] encryptedBytes;

            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())  //AesCryptoServiceProvide é utilizado para realizar a criptografia
            {
                byte[] key = new byte[32];
                byte[] initVector = new byte[16];   // valor aleatório usado em conjunto com a chave para inicializar o algoritmo

                // criando a password com password passada e o vetor de inicialização
                using (PasswordDeriveBytes passwordBytes = new PasswordDeriveBytes(password, null))     //PasswordDeriveBytes é uma implementação do algoritmo de derivação de chave baseado em senha PKCS #5
                {                                                                                              // usado pra transformar senha numa chave
                    key = passwordBytes.GetBytes(32);   // chave com 32 bytes
                    initVector = passwordBytes.GetBytes(16);    // initVector com 16 bytes
                }

                // criar um objeto de criptografia para realiza a criptografia
                using (ICryptoTransform encryptor = aes.CreateEncryptor(key, initVector))   // ICrpytoTransform é o transformador de criptografia
                {
                    using (MemoryStream memoryStream = new MemoryStream())   // criar um stream de memória para escrever os dados criptografados
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))    // cryptoStream é responsável por criptografar os dados no memoryStream
                        {
                            using (StreamWriter streamWriter = new StreamWriter(cryptoStream))    // a mensagem passada é escrita no streamWriter, e a medida que são escritos
                            {                                                                     // são automaticamente criptografados e escritos no MemoryStream através do CryptoStream
                                streamWriter.Write(message);
                            }
                            encryptedBytes = memoryStream.ToArray();    // converte o MemoryStream num array de bytes
                        }
                    }
                }

            }

            try
            {
                // Grava o conteúdo no arquivo
                string fullPath = Path.Combine(TextFolderPath, entryTitle+".txt");
                File.WriteAllText(fullPath, Convert.ToBase64String(encryptedBytes));
                Console.WriteLine("Arquivo salvo com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao salvar o arquivo: " + ex.Message);
            }

        }

        public string Decrypt(string encryptedMessage, string password)
        {
            string decryptedString;
            byte[] encryptedBytes = Convert.FromBase64String(encryptedMessage);

            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())   //AesCryptoService é criado para realizar a criptografia
            {
                byte[] key = new byte[32];
                byte[] initVector = new byte[16];

                // derivar key e initVector aa partir da password
                using (PasswordDeriveBytes passwordBytes = new PasswordDeriveBytes(password, null))
                {
                    key = passwordBytes.GetBytes(32);
                    initVector = passwordBytes.GetBytes(16);
                }

                using (ICryptoTransform decryptor = aes.CreateDecryptor(key, initVector))
                {
                    using (MemoryStream memoryStream = new MemoryStream(encryptedBytes))
                    {
                        using (CryptoStream cryptoStreamDecrypt = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader(cryptoStreamDecrypt))
                                decryptedString = streamReader.ReadToEnd();

                        }
                    }
                }

            }

            return decryptedString;
        }
    }
}
