using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using ClinicaVivaEstetica.WebApp.Utils.Json;
using Newtonsoft.Json;

namespace ClinicaVivaEstetica.WebApp.Utils.RestIntegration
{
    public static class RestIntegration
    {
        public static TResponse Post<TRequest, TResponse>(string end_point, string url, TRequest model, string authorizationToken = null, IDictionary<string, string> customHeaders = null)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            end_point = end_point.Substring(end_point.Length - 1) == "/"
                ? end_point.Substring(0, end_point.Length - 1)
                : end_point;

            string fullUrl = $"{end_point}{url}";

            using (var handler = new HttpClientHandler())
            {

                handler.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

                using (var client = new HttpClient(handler))
                {

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("Accept", "application/json");

                    var jsonRequest = JsonConvert.SerializeObject(model);
                    var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                    if (!string.IsNullOrEmpty(authorizationToken))
                    {
                        client.DefaultRequestHeaders.Add("Authorization", authorizationToken);
                    }

                    if (customHeaders != null && customHeaders.Any())
                    {
                        foreach (var customHeader in customHeaders)
                        {
                            client.DefaultRequestHeaders.Add(customHeader.Key, customHeader.Value);
                        }
                    }

                    var response = client.PostAsync(fullUrl, content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var strResult = response.Content.ReadAsStringAsync().Result;

                        return JsonConvert.DeserializeObject<TResponse>(strResult);
                    }
                    else
                    {
                        throw new Exception(
                            "Erro ao acessar o serviço " + fullUrl + " StatusCode = " + response.StatusCode +
                            "\\r\\n Mensagem de Retorno:" + response.Content.ReadAsStringAsync().Result);
                    }
                }
            }
        }

        public static TResponse Get<TResponse>(string end_point, string url, string authorizationToken = null, IDictionary<string, string> customHeaders = null)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            end_point = end_point.Substring(end_point.Length - 1) == "/"
                ? end_point.Substring(0, end_point.Length - 1)
                : end_point;

            string fullUrl = $"{end_point}{url}";

            using (var handler = new HttpClientHandler())
            {

                handler.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

                using (var client = new HttpClient(handler))
                {

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("Accept", "application/json");

                    if (!string.IsNullOrEmpty(authorizationToken))
                    {
                        client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authorizationToken);
                    }

                    if (customHeaders != null && customHeaders.Any())
                    {
                        foreach (var customHeader in customHeaders)
                        {
                            client.DefaultRequestHeaders.Add(customHeader.Key, customHeader.Value);
                        }
                    }

                    var response = client.GetAsync(fullUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var strResult = response.Content.ReadAsStringAsync().Result;

                        return JsonConverterUtility.DeserializeObject<TResponse>(strResult);
                    }
                    else
                    {
                        throw new Exception(
                            "Erro ao acessar o serviço " + fullUrl + " StatusCode = " + response.StatusCode +
                            "\\r\\n Mensagem de Retorno:" + response.Content.ReadAsStringAsync().Result);
                    }
                }
            }
        }

        public static TResponse Put<TRequest, TResponse>(string end_point, string url, TRequest model, string authorizationToken = null, IDictionary<string, string> customHeaders = null)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            end_point = end_point.Substring(end_point.Length - 1) == "/"
                ? end_point.Substring(0, end_point.Length - 1)
                : end_point;

            string fullUrl = $"{end_point}{url}";

            using (var handler = new HttpClientHandler())
            {

                handler.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

                using (var client = new HttpClient(handler))
                {

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("Accept", "application/json");

                    var jsonRequest = JsonConvert.SerializeObject(model);
                    var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                    if (!string.IsNullOrEmpty(authorizationToken))
                    {
                        client.DefaultRequestHeaders.Add("Authorization", authorizationToken);
                    }

                    if (customHeaders != null && customHeaders.Any())
                    {
                        foreach (var customHeader in customHeaders)
                        {
                            client.DefaultRequestHeaders.Add(customHeader.Key, customHeader.Value);
                        }
                    }

                    var response = client.PutAsync(fullUrl, content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var strResult = response.Content.ReadAsStringAsync().Result;

                        return JsonConvert.DeserializeObject<TResponse>(strResult);
                    }
                    else
                    {
                        throw new Exception(
                            "Erro ao acessar o serviço " + fullUrl + " StatusCode = " + response.StatusCode +
                            "\\r\\n Mensagem de Retorno:" + response.Content.ReadAsStringAsync().Result);
                    }
                }
            }
        }

        public static Boolean Delete(string end_point, string url, string authorizationToken = null, IDictionary<string, string> customHeaders = null)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            end_point = end_point.Substring(end_point.Length - 1) == "/"
                ? end_point.Substring(0, end_point.Length - 1)
                : end_point;

            string fullUrl = $"{end_point}{url}";

            using (var handler = new HttpClientHandler())
            {

                handler.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

                using (var client = new HttpClient(handler))
                {

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("Accept", "application/json");

                    if (!string.IsNullOrEmpty(authorizationToken))
                    {
                        client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authorizationToken);
                    }

                    if (customHeaders != null && customHeaders.Any())
                    {
                        foreach (var customHeader in customHeaders)
                        {
                            client.DefaultRequestHeaders.Add(customHeader.Key, customHeader.Value);
                        }
                    }

                    var response = client.DeleteAsync(fullUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var strResult = response.Content.ReadAsStringAsync().Result;
                        return true;
                    }
                    else
                    {
                        throw new Exception(
                            "Erro ao acessar o serviço " + fullUrl + " StatusCode = " + response.StatusCode +
                            "\\r\\n Mensagem de Retorno:" + response.Content.ReadAsStringAsync().Result);
                    }
                }
            }
        }

    }
}
