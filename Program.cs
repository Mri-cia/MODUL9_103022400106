var transferConfig = new BankTransferConfig();

transferConfig.LoadConfig();

var config = transferConfig.transferObj;

if (config.Language == "en")
{
    Console.WriteLine("Please insert the amount of money to transfer:");
}
else if (config.Language == "id")
{
    Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
}
else
{
    Console.WriteLine("Unsupported language.");
    return ;
}

int amount = int.Parse(Console.ReadLine());
int transferFee;
var threshold = config.TransferThrs;

Console.WriteLine($"");

if (amount <= threshold.ThresholdLimit)
{
    if (config.Language == "en")
    {
        Console.WriteLine($"Transfer fee: {threshold.low_fee}");
    }
    else if (config.Language == "id")
    {
        Console.WriteLine($"Biaya transfer: {threshold.low_fee}");
    }

    transferFee = threshold.low_fee;
}
else
{
    if (config.Language == "en")
    {
        Console.WriteLine($"Transfer fee: {threshold.high_fee}");
    }
    else if (config.Language == "id")
    {
        Console.WriteLine($"Biaya transfer: {threshold.high_fee}");
    }

    transferFee = threshold.high_fee;
}

Console.WriteLine($"");

if (config.Language == "en")
{
    Console.WriteLine("Select Transfer Method: ");
}
else if (config.Language == "id")
{
    Console.WriteLine("Pilih Metode Transfer");
}

for (int i = 0; i < config.Methods.Length; i++)
{
    Console.WriteLine($"{i + 1}. {config.Methods[i]}");
}

Console.WriteLine($"");

if (config.Language == "en")
{
    Console.WriteLine("Input type:");
}
else if (config.Language == "id")
{
    Console.WriteLine("Ketik input:");
}

int methodChoice = int.Parse(Console.ReadLine());

Console.WriteLine($"");

if(config.Language == "en")
{
    Console.WriteLine($"Please type {config.ConfirmationMessage.English} to confirm transaction:");
}
else if (config.Language == "id")
{
    Console.WriteLine($"Ketik {config.ConfirmationMessage.Indonesian} untuk mengkonfirmasi transaksi:");
}

string confirmation = Console.ReadLine();

if (config.Language == "en")
{
    if (confirmation == config.ConfirmationMessage.English)
    {
        Console.WriteLine($"The transfer is completed using {config.Methods[methodChoice-1]}");
    }
    else
    {
        Console.WriteLine("Transfer is cancelled.");
    }
}
else if (config.Language == "id")
{
    if (confirmation == config.ConfirmationMessage.Indonesian)
    {
        Console.WriteLine($"Proses transfer berhasil menggunakan {config.Methods[methodChoice-1]}");
    }
    else
    {
        Console.WriteLine("Transfer dibatalkan.");
    }
}