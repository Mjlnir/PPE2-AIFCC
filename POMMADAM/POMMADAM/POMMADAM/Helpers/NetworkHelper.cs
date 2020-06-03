using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using POMMADAM.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SaisieProdSite.Helpers
{
    public class NetworkHelper
    {
        HttpClient _httpClient;

        public NetworkHelper()
        {
            _httpClient = new HttpClient();
            _httpClient.MaxResponseContentBufferSize = 256000;
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> PostResponse<T>(string _sUrl, JObject _jsonContent) where T : class
        {
            _httpClient = new HttpClient();

            try
            {
                HttpClient _httpClient = new HttpClient();

                HttpContent _httpContent = new StringContent(_jsonContent.ToString(), Encoding.UTF8, "application/json");
                HttpResponseMessage _httpResponseConn = new HttpResponseMessage();

                _httpResponseConn = await _httpClient.PostAsync(_sUrl, _httpContent);

                if (_httpResponseConn.IsSuccessStatusCode)
                {
                    string _tContentJson = await _httpResponseConn.Content.ReadAsStringAsync();
                    ResultsAdapter _rAdap = JsonConvert.DeserializeObject<ResultsAdapter>(_tContentJson);

                    if (_rAdap.success)
                    {
                        return JsonConvert.DeserializeObject<T>(_rAdap.results);
                    }
                    else
                    {
                        return default(T);
                    }
                }
                else
                {
                    return default(T);
                }
            }
            catch (HttpRequestException ex)
            {
                return default(T);
            }
            catch (JsonException ex)
            {
                string e = ex.Message;
                return default(T);
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                return default(T);
            }
        }

        public async Task<T> PostResponseWithDate<T>(string _sUrl, JObject _jsonContent) where T : class
        {
            _httpClient = new HttpClient();

            try
            {
                HttpClient _httpClient = new HttpClient();

                HttpContent _httpContent = new StringContent(_jsonContent.ToString(), Encoding.UTF8, "application/json");
                HttpResponseMessage _httpResponseConn = new HttpResponseMessage();

                _httpResponseConn = await _httpClient.PostAsync(_sUrl, _httpContent);

                if (_httpResponseConn.IsSuccessStatusCode)
                {
                    string _tContentJson = await _httpResponseConn.Content.ReadAsStringAsync();
                    ResultsAdapter _rAdap = JsonConvert.DeserializeObject<ResultsAdapter>(_tContentJson);

                    if (_rAdap.success)
                    {
                        return JsonConvert.DeserializeObject<T>(_rAdap.results,
                            new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
                    }
                    else
                    {
                        return default(T);
                    }
                }
                else
                {
                    return default(T);
                }
            }
            catch (HttpRequestException ex)
            {
                return default(T);
            }
            catch (JsonException ex)
            {
                string e = ex.Message;
                return default(T);
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                return default(T);
            }
        }

        public async Task<T> GetResponse<T>(string _sUrl) where T : class
        {
            _httpClient = new HttpClient();

            try
            {
                HttpClient _httpClient = new HttpClient();

                HttpResponseMessage _httpResponseConn = await _httpClient.GetAsync(_sUrl);

                if (_httpResponseConn.IsSuccessStatusCode)
                {
                    string _tContentJson = await _httpResponseConn.Content.ReadAsStringAsync();
                    ResultsAdapter _rAdap = JsonConvert.DeserializeObject<ResultsAdapter>(_tContentJson);

                    if (_rAdap.success)
                    {
                        return JsonConvert.DeserializeObject<T>(_rAdap.results);
                    }
                    else
                    {
                        return default(T);
                    }
                }
                else
                {
                    return default(T);
                }
            }
            catch (HttpRequestException ex)
            {
                return default(T);
            }
            catch (System.Exception ex)
            {
                return default(T);
            }
        }
    }
}