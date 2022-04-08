using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace QAChallenge.XMLModel
{
	[XmlRoot(ElementName = "tCountryCodeAndName", Namespace = "http://www.oorsprong.org/websamples.countryinfo")]
	public class TCountryCodeAndName
	{
		[XmlElement(ElementName = "sISOCode", Namespace = "http://www.oorsprong.org/websamples.countryinfo")]
		public string SISOCode { get; set; }
		[XmlElement(ElementName = "sName", Namespace = "http://www.oorsprong.org/websamples.countryinfo")]
		public string SName { get; set; }
	}

	[XmlRoot(ElementName = "ListOfCountryNamesByNameResult", Namespace = "http://www.oorsprong.org/websamples.countryinfo")]
	public class ListOfCountryNamesByNameResult
	{
		[XmlElement(ElementName = "tCountryCodeAndName", Namespace = "http://www.oorsprong.org/websamples.countryinfo")]
		public List<TCountryCodeAndName> TCountryCodeAndName { get; set; }
	}

	[XmlRoot(ElementName = "ListOfCountryNamesByNameResponse", Namespace = "http://www.oorsprong.org/websamples.countryinfo")]
	public class ListOfCountryNamesByNameResponse
	{
		[XmlElement(ElementName = "ListOfCountryNamesByNameResult", Namespace = "http://www.oorsprong.org/websamples.countryinfo")]
		public ListOfCountryNamesByNameResult ListOfCountryNamesByNameResult { get; set; }
	}

	[XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
	public class Body
	{
		[XmlElement(ElementName = "ListOfCountryNamesByNameResponse", Namespace = "http://www.oorsprong.org/websamples.countryinfo")]
		public ListOfCountryNamesByNameResponse ListOfCountryNamesByNameResponse { get; set; }

		[XmlElement(ElementName = "CountryIntPhoneCodeResponse", Namespace = "http://www.oorsprong.org/websamples.countryinfo")]
		public CountryIntPhoneCodeResponse CountryIntPhoneCodeResponse { get; set; }
	}

	[XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
	public class Envelope
	{
		[XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
		public Body Body { get; set; }
		[XmlAttribute(AttributeName = "soap", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Soap { get; set; }
	}

	[XmlRoot(ElementName = "CountryIntPhoneCodeResponse", Namespace = "http://www.oorsprong.org/websamples.countryinfo")]
	public class CountryIntPhoneCodeResponse
	{
		[XmlElement(ElementName = "CountryIntPhoneCodeResult", Namespace = "http://www.oorsprong.org/websamples.countryinfo")]
		public string CountryIntPhoneCodeResult { get; set; }
	}
}
