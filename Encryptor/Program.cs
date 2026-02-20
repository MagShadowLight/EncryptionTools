using Encryptor.Utils;
using EncryptorTools;

namespace Encryptor
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Encryption tool");
            Thread.Sleep(1000);
            ConsoleChanges.Colors(ConsoleColor.Blue, ConsoleColor.White);
            RunMainMenu();
            ConsoleChanges.Colors(ConsoleColor.Black, ConsoleColor.Gray);
            Console.WriteLine($"Exited encryption tool at {DateTime.Now}");
        }

        private static void RunMainMenu()
        {
            int input = -1;
            while (input != 0) {
                Console.WriteLine("""
                Which tools to use?
                1. Encryption
                2. Decryption
                0. quit
                """);
                int.TryParse(Console.ReadLine(), out input);
                Console.Clear();
                switch (input)
                {
                    case 1:
                        RunEncryptionMenu();
                        break;
                    case 2:
                        RunDecryptionMenu();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Invalid input. choose the right input as number");
                        break;
                }
            }
        }

        private static void RunDecryptionMenu()
        {
            string message = string.Empty;
            Console.WriteLine("Enter the file name with a .txt to decrypt");
            string path = Console.ReadLine()!;
            Console.WriteLine($"Decrypting the file: {path}");
            try
            {
                message = Encrypter.Decrypt(path);
            }
            catch (Exception ex)
            {
                ConsoleChanges.Colors(ConsoleColor.DarkRed, ConsoleColor.White);
                Console.WriteLine($"Decryption failed.\nmessage: {ex.Message}");
                Console.WriteLine($"Press any key to try again");
                Console.ReadKey();
                ConsoleChanges.Colors(ConsoleColor.Blue, ConsoleColor.White);
                return;
            }
            ConsoleChanges.Colors(ConsoleColor.Green, ConsoleColor.Black);
            Console.WriteLine("File decrypted successfully");
            Console.WriteLine($"Message: {message}");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            ConsoleChanges.Colors(ConsoleColor.Blue, ConsoleColor.White);
        }

        private static void RunEncryptionMenu()
        {
            Console.WriteLine("Enter the text to encrypt");
            string text = Console.ReadLine()!;
            Console.WriteLine("Enter the file name with a .txt");
            string path = Console.ReadLine()!;
            Console.WriteLine($"Encrypting the text: {text}");
            try
            {
                Encrypter.Encrypt(text, path);
            } catch (Exception ex)
            {
                ConsoleChanges.Colors(ConsoleColor.DarkRed, ConsoleColor.White);
                Console.WriteLine($"Encryption failed.\nmessage: {ex.Message}");
                Console.WriteLine($"Press any key to try again");
                Console.ReadKey();
                ConsoleChanges.Colors(ConsoleColor.Blue, ConsoleColor.White);
                return;
            }
            ConsoleChanges.Colors(ConsoleColor.Green, ConsoleColor.Black);
            Console.WriteLine("Text encrypted successfully");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            ConsoleChanges.Colors(ConsoleColor.Blue, ConsoleColor.White);
        }
    }
}
