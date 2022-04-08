using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using log4net;
using NUnit.Framework;
using QAChallenge.Helpers;
using QAChallenge.XMLModel;

namespace QAChallenge.Test
{
    public class SOAPTest
    {
        

        
        private string URL = "http://webservices.oorsprong.org/websamples.countryinfo/CountryInfoService.wso";

        private string CountryISOXml = @"<?xml version=""1.0"" encoding=""utf-8""?>
        <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
            <soap:Body>
            <ListOfCountryNamesByName xmlns=""http://www.oorsprong.org/websamples.countryinfo""/>         
            </soap:Body>
        </soap:Envelope>";

        private ArrayList newfinal;
        public string finalcode;

        

        [Test]
        public void PostCountry()
        { 

            
        ReportHelper.Extenttest = ReportHelper.AddTestCaseName("PostCountry", "Description");

            ReportHelper.Extenttest.Info("Create HTTP request to get country code with POST Method");
            Task<HttpResponseMessage> postResponse = HttpClientHelper.CreateHttpRequestMessage(URL, CountryISOXml, Encoding.UTF8, "text/xml");

            ReportHelper.Extenttest.Info("Get the status code in the response");
            HttpStatusCode statuscode = postResponse.Result.StatusCode;
            ReportHelper.Extenttest.Info("Verify country code response and Status Code should be 200");
            Assert.AreEqual(200, (int)statuscode);


            ReportHelper.Extenttest.Info("Get Content of the response");
            HttpContent responsecontent = postResponse.Result.Content;
            Task<string> responseData = responsecontent.ReadAsStringAsync();
            string data = responseData.Result;
            ReportHelper.Extenttest.Pass("Country ISO code response" + data);
            Console.WriteLine(data);

            ReportHelper.Extenttest.Info("Deserlize Country code response");
            XmlSerializer xmlserializer = new XmlSerializer(typeof(Envelope));
            TextReader textReader = new StringReader(responseData.Result);
            Envelope xmldata = (Envelope)xmlserializer.Deserialize(textReader);
            //Console.WriteLine(xmldata.ToString());



            int NumberOfCountryCodes = xmldata.Body.ListOfCountryNamesByNameResponse.ListOfCountryNamesByNameResult.TCountryCodeAndName.Count;

            var arlist = new ArrayList();

            for (int i = 0; i < NumberOfCountryCodes; i++)
            {
                String code = xmldata.Body.ListOfCountryNamesByNameResponse.ListOfCountryNamesByNameResult.TCountryCodeAndName[i].SISOCode;
                ReportHelper.Extenttest.Pass("Country ISO Code is : " + code);
                Console.WriteLine(code);
                arlist.Add(code);

            }


            for (int j = 0; j < arlist.Count; j++)
            {
                //Console.WriteLine(arlist[j]);
                ReportHelper.Extenttest.Info("Pass country code value to phone code xml");
                string PhoneCodeXml = @"<?xml version=""1.0"" encoding=""utf-8""?>
                    <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                    <soap:Body>
                    <CountryIntPhoneCode xmlns=""http://www.oorsprong.org/websamples.countryinfo"">
                    <sCountryISOCode>" + arlist[j] + @"</sCountryISOCode>
                    </CountryIntPhoneCode>
                    </soap:Body>
                    </soap:Envelope>";
                ReportHelper.Extenttest.Info("Create HTTP request to get country code with POST Method");
                HttpClient httpclient1 = new HttpClient();
                HttpContent contentnew = new StringContent(PhoneCodeXml, Encoding.UTF8, "text/xml");
                Task<HttpResponseMessage> postResponses = httpclient1.PostAsync(URL, contentnew);
                HttpStatusCode statuscodes = postResponses.Result.StatusCode;
                ReportHelper.Extenttest.Info("Verify phone code response and Status Code should be 200");
                Assert.AreEqual(200, (int)statuscodes);


                HttpContent responsecontents = postResponses.Result.Content;

                Task<string> responseDatas = responsecontents.ReadAsStringAsync();
                string datas = responseDatas.Result;
               // ReportHelper.Extenttest.Pass("Country ISO code response" + data);
               // Console.WriteLine(datas);

                ReportHelper.Extenttest.Info("Deserlize phone code response");
                XmlSerializer xmlserializers = new XmlSerializer(typeof(Envelope));
                TextReader textReaders = new StringReader(responseDatas.Result);
                Envelope xmldatas = (Envelope)xmlserializers.Deserialize(textReaders);
                // Console.WriteLine(xmldatas.ToString());

                finalcode = xmldatas.Body.CountryIntPhoneCodeResponse.CountryIntPhoneCodeResult;
                ReportHelper.Extenttest.Info("country phone code is " + finalcode);
                 Console.WriteLine("country phone code is " +finalcode);

                newfinal = new ArrayList();

               newfinal.Add(finalcode);
                foreach (var item in newfinal)
                {
                    Console.WriteLine("arrat code" + item);
                }
                
                
            }

            Assert.That(newfinal, Is.Unique);
            
           












        }

        

    }
}

