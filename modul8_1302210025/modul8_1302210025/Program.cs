using modul8_1302210025;
using System.Text.Json;

internal class Program
{
   
    private static void Main(string[] args)
    {
        BankTransferConfig config= new BankTransferConfig();
        config = JsonSerializer.Deserialize<BankTransferConfig>(File.ReadAllText("../../../bank_transfer_config.json"));
        if (config.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer : ");
        }
        else
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer : ");
        }
        var tf = Convert.ToInt64(Console.ReadLine());
        if(tf <= config.transfer.threshold)
        {
            if (config.lang == "en")
            {
                Console.WriteLine("Transfer fee =  "+config.transfer.low_fee);
                Console.WriteLine("Total amount fee =  "+(config.transfer.low_fee+tf));
            }
            else
            {
                Console.WriteLine("Biaya transfer =  " + config.transfer.low_fee);
                Console.WriteLine("Total biaya =  " + (config.transfer.low_fee + tf));
            }
        }
        else
        {
            if (config.lang == "en")
            {
                Console.WriteLine("Transfer fee =  " + config.transfer.high_fee);
                Console.WriteLine("Total amount fee =  " + (config.transfer.high_fee + tf));
            }
            else
            {
                Console.WriteLine("Biaya transfer =  " + config.transfer.high_fee);
                Console.WriteLine("Total biaya =  " + (config.transfer.high_fee + tf));
            }

        }
        if (config.lang == "en")
        {
            Console.WriteLine("Select transfer method : ");
        }
        else
        {
            Console.WriteLine("Pilih metode transfer : ");
        }
        var i = 1;
        foreach (var item in config.methods)
        {
            Console.WriteLine($"{i++}. {item}");
        }
        var idx = Convert.ToInt16(Console.ReadLine());

        if (config.lang == "en")
        {
            Console.WriteLine("Please type "+config.confirmation.en+" to confirm the transaction");
            var confirm = Console.ReadLine();
            if (confirm.Equals(config.confirmation.en))
            {
                Console.WriteLine("The transfer is completed");
            }
            else
            {
                Console.WriteLine("Transfer is cancelled");
            }
        }
        else
        {
            Console.WriteLine("Ketik " + config.confirmation.id + " untuk mengkonfirmasi transaksi");
            var confirm = Console.ReadLine();
            if (confirm.Equals(config.confirmation.id))
            {
                Console.WriteLine("Proses transfer berhasil");
            }
            else
            {
                Console.WriteLine("Transfer dibatalkan");
            }

        }
    }
}