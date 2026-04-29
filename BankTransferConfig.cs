using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

public class BankTransferConfig
{
    [JsonIgnore]
    private string _filepath = Path.Combine(Environment.CurrentDirectory, "bank_transfer_config.json");

    public class Transfer
    {
        [JsonPropertyName("lang")]
        public string Language { get; set; }
        [JsonPropertyName("transfer")]
        public TransferThreshold TransferThrs { get; set; }
        [JsonPropertyName("methods")]
        public string[] Methods { get; set; }
        [JsonPropertyName("confirmation")]
        public ConfirmationMessage ConfirmationMessage { get; set; }
    }

    public class TransferThreshold
    {
        [JsonPropertyName("threshold")]
        public int ThresholdLimit { get; set; }
        [JsonPropertyName("low_fee")]
        public int low_fee { get; set; }
        [JsonPropertyName("high_fee")]
        public int high_fee { get; set; }
    }

    public class ConfirmationMessage
    {
        [JsonPropertyName("en")]
        public string English { get; set; }
        [JsonPropertyName("id")]
        public string Indonesian { get; set; }
    }

    public Transfer transferObj { get; set; }

    public void LoadConfig()
    {
        if (File.Exists(_filepath))
        {
            string jsonString = File.ReadAllText(_filepath);
            var config = JsonSerializer.Deserialize<Transfer>(jsonString);
            this.transferObj = config;
        }
        else
        {
            Console.WriteLine("Configuration file not found.");
            transferObj = new Transfer
            {
                Language = "en",
                TransferThrs = new TransferThreshold { ThresholdLimit = 1000000, low_fee = 5000, high_fee = 10000 },
                Methods = ["RTO (real-time)", "SKN", "RTGS", "BI FAST"],
                ConfirmationMessage = new ConfirmationMessage { English = "Are you sure you want to transfer?", Indonesian = "Apakah Anda yakin ingin mentransfer?" }
            };
        }

    }
}
