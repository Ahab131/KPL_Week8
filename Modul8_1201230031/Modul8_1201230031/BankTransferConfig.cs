using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

public class BankTransferConfig
{
    public string Lang { get; set; }
    public Transfer Transfer { get; set; }
    public List<string> Methods { get; set; }
    public Confirmation Confirmation { get; set; }

    private const string ConfigFileName = "bank_transfer_config.json";

    public BankTransferConfig()
    {
        if (File.Exists(ConfigFileName))
        {
            string json = File.ReadAllText(ConfigFileName);
            var config = JsonConvert.DeserializeObject<BankTransferConfig>(json);
            Lang = config.Lang;
            Transfer = config.Transfer;
            Methods = config.Methods;
            Confirmation = config.Confirmation;
        }
        else
        {
            // Nilai default
            Lang = "en";
            Transfer = new Transfer
            {
                Threshold = 25000000,
                LowFee = 6500,
                HighFee = 15000
            };
            Methods = new List<string> { "RTO (real-time)", "SKN", "RTGS", "BI FAST" };
            Confirmation = new Confirmation
            {
                en = "yes",
                id = "ya"
            };

            SaveConfig();
        }
    }

    public void SaveConfig()
    {
        string json = JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(ConfigFileName, json);
    }
}

public class Transfer
{
    public int Threshold { get; set; }
    public int LowFee { get; set; }
    public int HighFee { get; set; }
}

public class Confirmation
{
    public string en { get; set; }
    public string id { get; set; }
}
