using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DBTools
{
    [Serializable]
    public class Servers
    {
        private static int _lastId = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public bool ConnectionStatus { get; set; }
        
        private static string filePath = "obj.dat";
        public Servers() { }
        public Servers(int id) { if (id >= _lastId) { _lastId = id + 1; } }

        public Servers(string name, string ip, string port, string user, string password)
        {
            Id          = _lastId;
            Name        = name;
            Ip          = ip;
            Port        = port;
            User        = user;
            Password    = password;
            _lastId++;
        }
        private string ConnectionString
        {
            get
            {
                string server = string.IsNullOrEmpty(Port) ? Ip : $"{Ip},{Port}";
                return $"Server={server};Database=master;User Id={User};Password={Password};";
            }
        }
        public static void Save(List<Servers> servers)
        {
            string encryptionKey = "your-32-character-long-encryption-key";
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                using (Aes aes = Aes.Create())
                {
                    byte[] key = Encoding.UTF8.GetBytes(encryptionKey);
                    aes.Key = key.Take(aes.KeySize / 8).ToArray(); // Adjust key size
                    aes.IV = new byte[aes.BlockSize / 8]; // Use a zero IV for simplicity

                    using (CryptoStream cryptoStream = new CryptoStream(fileStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(cryptoStream, servers);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving servers: {ex.Message}");
            }
        }
        public static List<Servers> LoadServers()
        {
            List<Servers> servers = new List<Servers>();
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                using (Aes aes = Aes.Create())
                {
                    byte[] key = Encoding.UTF8.GetBytes("your-32-character-long-encryption-key");
                    aes.Key = key.Take(aes.KeySize / 8).ToArray(); // Adjust key size
                    aes.IV = new byte[aes.BlockSize / 8]; // Use a zero IV for simplicity

                    using (CryptoStream cryptoStream = new CryptoStream(fileStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        servers = (List<Servers>)formatter.Deserialize(cryptoStream);
                    }
                }

                //using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                //{
                //    BinaryFormatter formatter = new BinaryFormatter();
                //    servers = (List<Servers>)formatter.Deserialize(fileStream);
                //}
            }
            catch (Exception ex)
            {
            }
            return servers;
        }
        public static async Task<(bool status, string msj)> TestConnection(Servers settings, int timeoutSeconds = 2, int maxAttempts = 1)
        {
            bool statusBool = false;
            string msj = "";
            int attempts = 0;

            while (attempts < maxAttempts)
            {
                using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    connection.ConnectionString += $"Connection Timeout={timeoutSeconds};";

                    try
                    {
                        await connection.OpenAsync();
                        statusBool = true;
                        break;
                    }
                    catch (SqlException ex)
                    {
                        statusBool = false;
                        msj = ex.Message;
                        attempts++;
                        if (attempts >= maxAttempts)
                        {
                            break;
                        }
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }
                }
            }

            return (statusBool, msj);
        }

    }
}
