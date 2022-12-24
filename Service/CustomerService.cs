using EntityModel;
using System;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Service
{

    public class CustomerService
    {
        public static string fileName = "Customer.json";
        public IEnumerable<Customer> GetCustomers(int noOfCustomers, int invPerCustomer, int servicesPerInvoice)
        {

            for (var i = 0; i < noOfCustomers; i++)
            {
                yield return new(1, $"Customer{i}", $"Address{i}", GetInvoices());
            }

            List<CustomerInvoice>? GetInvoices()
                => Enumerable.Repeat<CustomerInvoice>(new(8, $"Invoice2022", false, GetInvServices()), invPerCustomer).ToList();

            List<CustomerPerService>? GetInvServices()
                => Enumerable.Repeat<CustomerPerService>(new(4, $"Oil_10K", false), servicesPerInvoice).ToList();
        }

        public Customer GetCustomer()
        {

            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                var result = JsonSerializer.Deserialize<Customer>(json);
                return result;
            }

        }

        public List<Customer> GetCustomers()
        {

            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                var result = JsonSerializer.Deserialize<List<Customer>>(json);
                return result;
            }

        }

        public bool Add(Customer customer)
        {
            try
            {
                var jsonObj = new JsonObject
                {
                    ["Id"] = customer.Id,
                    ["Name"] = customer.Name,
                    ["Address"] = customer.Address,
                };
                JsonFileUtils.WriteDynamicJsonObject(jsonObj, fileName);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool Edit(Customer customer)
        {
            try
            {
                var jsonObj = new JsonObject
                {
                    ["Id"] = customer.Id,
                    ["Name"] = customer.Name,
                    ["Address"] = customer.Address,
                };
                JsonFileUtils.WriteDynamicJsonObject(jsonObj, fileName);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //public bool Delete(int id)
        //{
        //    try
        //    {
        //        var jObject = JObject.Parse(json);
        //        JArray experiencesArrary = (JArray)jObject["experiences"];

        //        var companyToDeleted = Customer.FirstOrDefault(obj => obj["companyid"].Value<int>() == companyId);

        //        experiencesArrary.Remove(companyToDeleted);

        //        return true;
        //    }
        //    catch ( Exception ex)
        //    {
        //        return false;
        //    }

        //}

    }




}
