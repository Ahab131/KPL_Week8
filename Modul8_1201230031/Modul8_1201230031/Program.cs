using System;

class Program
{
    static void Main()
    {
        var config = new BankTransferConfig();

        // D-i
        if (config.Lang == "en")
        {
            Console.Write("Please insert the amount of money to transfer: ");
        }
        else
        {
            Console.Write("Masukkan jumlah uang yang akan di-transfer: ");
        }

        int amount = int.Parse(Console.ReadLine());

        // D-ii
        int fee = amount <= config.Transfer.Threshold ? config.Transfer.LowFee : config.Transfer.HighFee;
        int total = amount + fee;

        if (config.Lang == "en")
        {
            Console.WriteLine($"Transfer fee = {fee}");
            Console.WriteLine($"Total amount = {total}");
        }
        else
        {
            Console.WriteLine($"Biaya transfer = {fee}");
            Console.WriteLine($"Total biaya = {total}");
        }

        // D-iii
        if (config.Lang == "en")
        {
            Console.WriteLine("Select transfer method:");
        }
        else
        {
            Console.WriteLine("Pilih metode transfer:");
        }

        // D-iv
        for (int i = 0; i < config.Methods.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {config.Methods[i]}");
        }

        Console.Write("Your choice (number): ");
        Console.ReadLine(); // input nomor metode, tidak diproses lebih lanjut

        // D-v
        if (config.Lang == "en")
        {
            Console.Write($"Please type \"{config.Confirmation.en}\" to confirm the transaction: ");
            string confirm = Console.ReadLine();
            if (confirm.ToLower() == config.Confirmation.en.ToLower())
                Console.WriteLine("The transfer is completed");
            else
                Console.WriteLine("Transfer is cancelled");
        }
        else
        {
            Console.Write($"Ketik \"{config.Confirmation.id}\" untuk mengkonfirmasi transaksi: ");
            string confirm = Console.ReadLine();
            if (confirm.ToLower() == config.Confirmation.id.ToLower())
                Console.WriteLine("Proses transfer berhasil");
            else
                Console.WriteLine("Transfer dibatalkan");
        }
    }
}
