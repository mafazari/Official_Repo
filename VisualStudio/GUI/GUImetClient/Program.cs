using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using DYMO.Label.Framework;
using System.Timers;
using GUImetClient;
using GUI_Project_periode_3;
using System.Net;
using Newtonsoft.Json;
using System.Runtime.Serialization;

//using JSON.Net;
//using System.Web.Script.Serialization.JavaScriptSerializer;

namespace GUI_Project_periode_3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Hash hash = new Hash();
            //Error.show(hash.makeHash(11248649, 1234));
            
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Beginscherm());
        }
    }
}

                                                                        //HAS TO BE UP TO DATE WITH WEBAPI
    public class Rekening
    {
        public int RekeningID { get; set; }
        public int Balans { get; set; }
        public String Hash { get; set; }
    }
    public class Transactie
    {
        public int RekeningID { get; set; }
        public double Bedrag { get; set; }
        public string Locatie { get; set; }
    }
    public class Pas
    {
        public String PasID { get; set; }
        public int RekeningID { get; set; }
        public int KlantID { get; set; }
        public int Actief { get; set; }
        public int FalsePin { get; set; }
}
    public class Klant
    {
        public int KlantID { get; set; }
        public String voornaam { get; set; }
        public String achternaam { get; set; }
        public String email { get; set; }
    }

    public class ArduinoClass
    {
        static SerialPort Arduino = new SerialPort();
        static String portName = "COM6";
        public bool makePort(String s)
        {
            portName = s;
            bool status = false;
            Arduino.BaudRate = 9600;
            Arduino.PortName = portName;
            // Arduino.DataReceived

            try
            {
                Arduino.Open();
                status = true;
            }
            catch (System.IO.IOException)
            {
                Error.show("Poort niet gevonden", "Error");
                // Console.WriteLine(e.Message);
            }
            catch (System.UnauthorizedAccessException)
            {
                Error.show("Toegang tot de compoort is geweigerd", "Error");
                // Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                Error.show("No port selected", "Error");
                // Console.WriteLine(exc.Message);   
            }
            return status;
        }
        public void closePort(String s)
        {
            Arduino.Close();
        }
        public static SerialPort getPort()
        {
            return Arduino;
        }

        public static string strInput()
        {
            string str = "";

            while (str.Equals(""))
            {
                str = Arduino.ReadLine().ToString().Trim();
            }

            return str;
        }

    }
    public static class Error
    {
        public static void show(String s, String x)
        {
            MessageBox.Show(s, x,
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void show(String s)
        {
            MessageBox.Show(s, s,
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
}
    public class HTTPget
    {
        public bool getActiefStand(String pasID)
        {
            Pas temp = getActiefStandData(pasID).Result;
            if (temp.Actief == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Pas getPinclass(String s)
        {
            Pas tmp = getPinData(s).Result;
            return tmp;
        }
        public int getFalsePinnr(String s)
        {
            Pas tmp = getPinData(s).Result;
            int falsepi = tmp.FalsePin;
            return falsepi;
        }
        public Klant getKlant(string s)
        {
            Klant result = GetKlantData(s).Result;
            return result;

        }
        public String getKlantID(string s)
        {
            String location = String.Concat("api/pass/", s);
            return getKlantIDthrougPasID(location).Result;
        }
        public Rekening getRekening(string s)
        {
            //Error.show("S: " +s);
            String loc = String.Concat("api/rekenings/", s);
            Rekening result = getRekeningData(loc).Result;
            //result = JsonConvert.DeserializeObject<Rekening>(loc);
            int Balans = result.Balans;

            return result;
        
        //double testbalans = result.Balans;
        //string hash = result.Hash;
            
        } 
        public String getHash(String RekeningID)
        {
            String loc = String.Concat("api/rekenings/", RekeningID);
            Rekening result = getRekeningData(loc).Result;
        //Error.show(result.Hash);
            return result.Hash;
        }
        static async Task<String> getKlantIDthrougPasID(String s)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            using (var client = new HttpClient(new HttpClientHandler { UseProxy = false, ClientCertificateOptions = ClientCertificateOption.Automatic }))
            {
                
                client.BaseAddress = new Uri("https://hrsqlapp.tk/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET THE KLANT ID
                HttpResponseMessage response = await client.GetAsync(s).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    Pas tmppas = await response.Content.ReadAsAsync<Pas>();
                    String result = tmppas.KlantID.ToString();
                    return result;
                }
                else
                {
                    String result = "0000";
                    return result;
                }
            }
        }
        static async Task<Klant> GetKlantData(String s)
        {
            String location = s;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            using (var client = new HttpClient(new HttpClientHandler { UseProxy = false, ClientCertificateOptions = ClientCertificateOption.Automatic }))
            {
                
                client.BaseAddress = new Uri("https://hrsqlapp.tk/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // HTTP GET
                HttpResponseMessage response = await client.GetAsync(location).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    Klant klant = await response.Content.ReadAsAsync<Klant>();
                    return klant;
                }
                else
                {
                    Klant a = new Klant();
                    return a;
                    //CONNECTION FAILED
                    //RETRY CLAUSE? or cut the program?
                }
            }
        }
        static async Task<Rekening> getRekeningData(string s)
        {
            String location = s;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            using (var client = new HttpClient(new HttpClientHandler { UseProxy = false, ClientCertificateOptions = ClientCertificateOption.Automatic }))
            {
                
                client.BaseAddress = new Uri("https://hrsqlapp.tk/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // HTTP GET
                HttpResponseMessage response = await client.GetAsync(location).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    Rekening rekening = await response.Content.ReadAsAsync<Rekening>();
                    return rekening;
                }
                else
                {
                    Rekening reject = new Rekening();
                    return reject;
                }

            }
        }
        static async Task<Pas> getPasData(string s)
        {
            String location = s;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            using (var client = new HttpClient(new HttpClientHandler { UseProxy = false, ClientCertificateOptions = ClientCertificateOption.Automatic }))
            {
                
                client.BaseAddress = new Uri("https://hrsqlapp.tk/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // HTTP GET
                HttpResponseMessage response = await client.GetAsync(location).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    Pas pas = await response.Content.ReadAsAsync<Pas>();
                    return pas;
                }
                else
                {
                    Pas reject = new Pas();
                    return reject;
                }

            }
        }
        static async Task<Pas> getPinData(string ID)
        {
            String location = string.Concat("api/Pass/", ID);
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            using (var client = new HttpClient(new HttpClientHandler { UseProxy = false, ClientCertificateOptions = ClientCertificateOption.Automatic }))
            {
                client.BaseAddress = new Uri("https://hrsqlapp.tk/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // HTTP GET
                HttpResponseMessage response = await client.GetAsync(location).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    Pas FalsePin = await response.Content.ReadAsAsync<Pas>();
                    return FalsePin;
                }
                else
                {
                    Pas reject = new Pas();
                    return reject;
                }

            }
        }
        static async Task<Pas> getActiefStandData(string ID)
        {
            String location = string.Concat("api/Pass/", ID);
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            using (var client = new HttpClient(new HttpClientHandler { UseProxy = false, ClientCertificateOptions = ClientCertificateOption.Automatic }))
                {
                    client.BaseAddress = new Uri("https://hrsqlapp.tk/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    // HTTP GET
                    HttpResponseMessage response = await client.GetAsync(location).ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        Pas Actief = await response.Content.ReadAsAsync<Pas>();
                        return Actief;
                    }
                    else
                    {
                        Pas reject = new Pas();
                        return reject;
                    }

            }
        }
    }
public class HTTPpost
{
    public void transaction(string PasID, String RekeningID, int Balans)
    {
        Transactie(PasID, RekeningID, Balans).Wait();
    }
    public void resetfalsepin(String PasID)
    {
        HTTPget tmp = new HTTPget();
        Pas resetdata = tmp.getPinclass(PasID);
        incrementFalsePin(PasID, resetdata, 0).Wait();
    }
    public void Incrementfalsepin(String PasID)
    {
        HTTPget tmp = new HTTPget();
        int nrfalsepin = tmp.getFalsePinnr(PasID);
        Pas uploaddata = tmp.getPinclass(PasID);
        nrfalsepin++;
        if (nrfalsepin >= 3)
        {
            BlockScreen a = new BlockScreen();
            BlockCard(PasID, uploaddata).Wait();
        }
        if (nrfalsepin < 3)
        {
            incrementFalsePin(PasID, uploaddata, nrfalsepin).Wait();
        }
    }
    public void UpdateBalans(int RekeningID, int balans)
    {
        NieuwBalans(RekeningID, balans).Wait();
    }
    static async Task Transactie(string PasID, String RekeningID, int balans)
    {
        int RekeningIDint;
        string locatie = "HollandBank-Locatie21";
        Int32.TryParse(RekeningID, out RekeningIDint);
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
        using (var client = new HttpClient(new HttpClientHandler { UseProxy = false, ClientCertificateOptions = ClientCertificateOption.Automatic }))
        {
            client.BaseAddress = new Uri("https://hrsqlapp.tk/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HTTPpost part
            var trans = new Transactie() { Bedrag = balans, Locatie = locatie, RekeningID = RekeningIDint };
            HttpResponseMessage response = await client.PostAsJsonAsync("api/transacties", trans).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                //Error.show("TRANSACTIE SUCCEED");
            }
            else
            {
                Error.show("TRANSACTIE FAILED");
            }
        }
    }
    static async Task NieuwBalans(int RekeningID, int balans)
    {
        string rekStr = Convert.ToString(RekeningID);
        string balansStr = Convert.ToString(balans);
        //Error.show("Rekening nr: " + rekStr + "\nBalans :" + balansStr);
        String location = string.Concat("api/rekenings/", RekeningID.ToString());
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
        using (var client = new HttpClient(new HttpClientHandler { UseProxy = false, ClientCertificateOptions = ClientCertificateOption.Automatic }))
        { 
            client.BaseAddress = new Uri("https://hrsqlapp.tk/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HTTPpost part
            HTTPget tmp = new HTTPget();
            Rekening trans = tmp.getRekening(RekeningID.ToString());
            trans.Balans = balans;

            HttpResponseMessage response = await client.PutAsJsonAsync(location, trans).ConfigureAwait(false);
            //Error.show(location, balans.ToString());
            if (response.IsSuccessStatusCode)
            {
                //Error.show("Succeeded", "Succeeded");
            }
            else
            {
                Error.show("NIEUW BALANS FAILED");
            }
        }
    }
    static async Task incrementFalsePin(String PasID, Pas data, int falsepinnr)
    {
        String location = string.Concat("api/pass/", PasID.ToString());
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
        using (var client = new HttpClient(new HttpClientHandler { UseProxy = false, ClientCertificateOptions = ClientCertificateOption.Automatic }))
        {
            client.BaseAddress = new Uri("https://hrsqlapp.tk/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HTTPpost part
            Pas incrementFalsePin = new Pas() { Actief = data.Actief, FalsePin = falsepinnr, KlantID = data.KlantID, PasID = PasID, RekeningID = data.RekeningID };
            HttpResponseMessage response = await client.PutAsJsonAsync(location, incrementFalsePin).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                //Error.show("INCREMENTING SUCCED", "INCREMENT Succeeded");
            }
            else
            {
                Error.show("INCR FAILED", "INCR FAILED");
            }
        }
    }
    static async Task BlockCard(String PasID, Pas data)
    {
        String location = string.Concat("api/pass/", PasID.ToString());
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
        using (var client = new HttpClient(new HttpClientHandler { UseProxy = false, ClientCertificateOptions = ClientCertificateOption.Automatic }))
        {
            client.BaseAddress = new Uri("https://hrsqlapp.tk/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HTTPpost part
            Pas incrementFalsePin = new Pas() { Actief = 0, FalsePin = data.FalsePin, KlantID = data.KlantID, PasID = PasID, RekeningID = data.RekeningID };
            HttpResponseMessage response = await client.PutAsJsonAsync(location, incrementFalsePin).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                //Error.show("INCREMENTING SUCCED", "INCREMENT Succeeded");
            }
            else
            {
                Error.show("BLOCKING FAILED", "BLOCKING FAILED");
            }
        }
    }
}

public class Executer
{
    private string rekeningID;
    private String userName;
    private string pasID;
    private ArduinoData arduino;
    private HTTPget downloadConnection = new HTTPget();
    private HTTPpost uploadConnection = new HTTPpost();
    private Rekening rekening;
    private Boolean endOfSession = true;
    public int saldo;

    public Executer(string r, string u, ArduinoData a, string p)
    {
        this.rekeningID = r;
        this.userName = u;
        this.arduino = a;
        this.pasID = p;
        //Error.show(rekeningID);
        this.rekening = downloadConnection.getRekening(rekeningID);
        this.saldo = rekening.Balans;
    }

    public Boolean getEndOfSession()
    {
        return this.endOfSession;
    }

    public void executeChoice(int choice)
    {
        switch (choice)
        {
            case 1:
                pin();
                break;
            case 2:
                checkSaldo();
                break;
            case 3:
                ///quickPin();
                break;
            case 4:
                break;
        }
    }

    private void pin()
    {
        Opnemen opnemen = new Opnemen();
        Boolean printTicket = false;
        Boolean cancelled = false;
        Boolean goBack = true;
        int amount = 0;
        String input;

        while (goBack == true)
        {
            opnemen.Show();
            while (true)
            {
                input = arduino.getString();
                if (input.Contains("1"))
                {
                    amount = 10;
                    break;
                }
                else if (input.Contains("2"))
                {
                    amount = 20;
                    break;
                }
                else if (input.Contains("3"))
                {
                    amount = 50;
                    break;
                }
                else if (input.Contains("#"))
                {
                    cancelled = true;
                    break;
                }
                else if (input.Contains("C"))
                {
                    cancelled = true;
                    endOfSession = false;
                    break;
                }

            }
            if (amount > saldo && amount != 0)
            {
                //PinError pinError = new PinError();
                cancelled = true;
            }
            if (cancelled == true)
            {
                opnemen.Hide();
                break;
            }
            else
            {
                uploadConnection.UpdateBalans(Int32.Parse(rekeningID), (saldo - amount));
                uploadConnection.transaction(pasID, rekeningID, saldo - amount);
                //Error.show(amount.ToString());
            }
            Bon asker = new Bon();
            asker.Show();
            while (true)
            {
                input = arduino.getString();
                if (input.Contains("*"))
                {
                    printTicket = true;
                    goBack = false;
                    break;
                }
                else if (input.Contains("#"))
                {
                    //Error.show("Geen Bon", "bon");
                    goBack = false;
                    break;
                }
            }
            asker.Hide();
            if (printTicket == true)
            {
                //Printer bonPrinter = new Printer(userName, amount);
                //bonPrinter.printTicket();
            }
            if (goBack != false)
            {
                DankU goAway = new DankU();
                goAway.Show();
                System.Threading.Thread.Sleep(5000);
                goAway.Hide();
                opnemen.Hide();
            }
        }
    }

    public void checkSaldo()
    {
        Saldo saldoDisplay = new Saldo(saldo);
        //saldoDisplay.Show();
        //saldoDisplay.Refresh();
        while (true)
        {
            String input = arduino.getString();
            if (input.Contains("*"))
            {
                saldoDisplay.Hide();
                pin();
                break;
            }
            else if (input.Contains("#"))
            {
                DankU goAway = new DankU();
                endOfSession = true;
                saldoDisplay.Close();
                break;
            }
        }
    }

   /* private void quickPin()
    {
        //Printer bonPrinter = new Printer(userName, 70);
        bonPrinter.printTicket();
        DankU quickBye = new DankU();
        System.Threading.Thread.Sleep(5000);
        endOfSession = true;
        quickBye.Hide();
    }*/
}

public class Printer
{
    private String userName;
    private int amount;

    public Printer(int b)
    {
        //this.userName = s;
        this.amount = b;
    }

    public void printTicket()
    {
        String bedrag = amount.ToString();
        ILabel _label;
        _label = Framework.Open(@"C:\Program Files (x86)\DYMO\bonPrint.label");
        //_label.SetObjectText("Klantnaam", userName);
        _label.SetObjectText("bedrag", bedrag + "€");
        _label.SetObjectText("DATUM-TIJD", "");
        IPrinter printer = Framework.GetPrinters().First();
        if (printer is ILabelWriterPrinter)
        {
            ILabelWriterPrintParams printParams = null;
            ILabelWriterPrinter labelWriterPrinter = printer as ILabelWriterPrinter;
            if (labelWriterPrinter.IsTwinTurbo)
            {
                printParams = new LabelWriterPrintParams();
                printParams.RollSelection = (RollSelection)Enum.Parse(typeof(RollSelection), "koekje");
            }

            _label.Print(printer, printParams);
        }
        else
            _label.Print(printer); // print with default params
    }
}

public class Hash
{
    public bool checkHash(string RekeningID, String pincode)
    {
        int RekeningIDcv;
        int pincodecv;
        Int32.TryParse(RekeningID, out RekeningIDcv);
        Int32.TryParse(pincode, out pincodecv);
        bool status = false;
        HTTPget temporary = new HTTPget();
        string Hash = makeHash(RekeningIDcv, pincodecv);
        if (Hash == temporary.getHash(RekeningID))
        {
            status = true;
        }
        
        return status;

    }
    public String makeHash(int RekeningID, int pincode)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Concat(RekeningID, pincode)));
    }
    public void blockCard(String PasID)
    {

    }
}
public class ArduinoData
{
    SerialPort startPort = ArduinoClass.getPort();
    private String inputString;

    public String getFirstString()
    {
        inputString = startPort.ReadTo("\r\n");
        return inputString;
    }

    public String getString()
    {
        inputString = startPort.ReadTo("\r\n");
        startPort.DiscardInBuffer();
        return inputString;
    }

    public string getPin()
    {
        String pin = "0000";
        return pin;
    }

    public int getChoice()
    {
        int choice = 0;
        string choiceString = this.getString();
        if (choiceString == "AKEY") { choice = 1; }
        if (choiceString == "BKEY") { choice = 2; }
        if (choiceString == "CKEY") { choice = 3; }
        if (choiceString == "#KEY") { choice = 4; }
        return choice;
    }

    public int getUser()
    {
        int userID = 0;
        return userID;
    }
}