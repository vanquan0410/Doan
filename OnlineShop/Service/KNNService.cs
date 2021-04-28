using Repository.DBContext;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuanShop.Service
{
    public class KNNService
    {
        public KNNService()
        {
           
        }

        public  string getLabaleKnn()
        {
            var client = new RestClient("http://localhost:4000/api/knn/20000000");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            var res = response.Content;
            return res.ToString();
        }
    }
}
