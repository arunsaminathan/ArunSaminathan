using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using System.Net;
using RegisterationAPI.Models;
using RegisterationAPI.Controllers;
using System.Net.Http;
using System.IO;
using System.Web.Http;

namespace RegisterTest
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test1()
        {
            Assert.That(1 == 1);
        }

        [Test]
        public void PoseRegisterTest()
        {

            byte[] XMLbyte = ImageToBinary(@"F:\FSE_Document\CredentialExpired.png");
            var controller = new RegisterationsController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            var user = new Registeration
            {
                FirstName = "Anand",
                LastName = "Saminathan",
                Email = "andnd@gmail.com",
                City = "chennai",
                MobileNumber = "7827487382",
                Bill = XMLbyte
            };
            var actionResult = controller.PostRegisteration(user);
            Assert.AreEqual("OK", actionResult.ReasonPhrase);
        }

        public static byte[] ImageToBinary(string _path)
        {
            FileStream fS = new FileStream(_path, FileMode.Open, FileAccess.Read);
            byte[] b = new byte[fS.Length];
            fS.Read(b, 0, (int)fS.Length);
            fS.Close();
            return b;
        }

    }
}
