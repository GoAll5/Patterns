using System;

namespace Adapter
{   
    class JsonObject
    {

    }

    interface IJsonService
    {
        JsonObject GetData(JsonObject queryData);
    }

    class JsonService : IJsonService
    {
        public JsonObject GetData(JsonObject queryData)
        {
            return queryData;
        }
    }

    class Client
    {
        public void DoWork(IJsonService service)
        {
            var q = new JsonObject();
            var response = service.GetData(q);
            // work with repsonse
        }
    }

    class XmlObject { }

    interface IXmlService
    {
        XmlObject GetParams(XmlObject obj);
    }

    class XmlService : IXmlService
    {
        public XmlObject GetParams(XmlObject obj)
        {
            return obj;
        }
    }
    class XmlToJsonAdapter : IJsonService
    {
        protected IXmlService _service;
        public XmlToJsonAdapter(IXmlService s)
        {
            _service = s;
        }
        public JsonObject XmlToJson(XmlObject obj)
        {
            return new JsonObject();
        }
        public XmlObject JsonToXml(JsonObject obj)
        {
            return new XmlObject();
        }
        public JsonObject GetData(JsonObject queryData)
        {
            var xml = JsonToXml(queryData);
            var responseXml = _service.GetParams(xml);
            return XmlToJson(responseXml);
        }
    }
    class Adapter
    {
        static void Main(string[] args)
        {
            Client cli = new Client();
            var s = new JsonService();
            cli.DoWork(s);

            var xml = new XmlService();
            var adapter = new XmlToJsonAdapter(xml);
            cli.DoWork(adapter);
        }
    }
}
