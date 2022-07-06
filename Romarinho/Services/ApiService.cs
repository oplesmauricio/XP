using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Romarinho.App.Model;
using Romarinho.App.Services.Interfaces;

namespace Romarinho.App.Services
{
    
    public class ApiService : IApiService
    {

#if DEBUG
        readonly string _urlAPIRaiz = "https://10.0.2.2:5001/api/";
#else
        readonly string _urlAPIRaiz = "http://ec2-52-91-69-122.compute-1.amazonaws.com:8181/api/";
#endif

        /// <summary>
        /// Metodo para requisicoes via Post
        /// </summary>
        /// <typeparam name="T">Tipo generico que deve ser passado para que esta classe construa um objeto deste vindo da API</typeparam>
        /// <param name="item">Objeto a ser enviado para a API</param>
        /// <param name="url">Endereco completo da API</param>
        /// <param name="headers">Cabeçalhos a serem utilizados no formato "string" "string"</param>
        /// <returns>Objeto do tipo RespostaServico contendo uma propriedade chamada "resposta" do tipo T passado na chamada do metodo</returns>
        public async Task<RespostaServico<T>> PostAsync<T>(object item, string url, List<KeyValuePair<string, string>> headers)
        {
            try
            {
                var json = JsonSerializer.Serialize(item);
                var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

                var _handler = new HttpClientHandler();
                _handler.ServerCertificateCustomValidationCallback =
                    (message, certificate, chain, sslPolicyErrors) => true;

                using (var client = new HttpClient(_handler))
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }

                    using (var response = await client.PostAsync(_urlAPIRaiz + url, conteudo))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                            var objeto = JsonSerializer.Deserialize<T>(ProdutoJsonString);
                            return new RespostaServico<T>
                            {
                                Resposta = objeto,
                                HttpStatus = response.StatusCode.ToString(),
                                Sucesso = true,
                                Mensagem = ""
                            };
                        }
                        else
                        {
                            return new RespostaServico<T>
                            {
                                HttpStatus = response.StatusCode.ToString(),
                                Sucesso = false,
                                Mensagem = response.ReasonPhrase
                            };
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return new RespostaServico<T>
                {
                    HttpStatus = ex.StatusCode.ToString(),
                    Sucesso = false,
                    Mensagem = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new RespostaServico<T>
                {
                    HttpStatus = "400",
                    Sucesso = false,
                    Mensagem = ex.Message
                };
            }
        }

        /// <summary>
        /// Metodo para requisicoes via Get
        /// </summary>
        /// <typeparam name="T">Tipo generico que deve ser passado para que esta classe construa um objeto deste vindo da API</typeparam>
        /// <param name="url">Endereco completo da API</param>
        /// <param name="headers">Cabeçalhos a serem utilizados no formato "string" "string"</param>
        /// <returns>Objeto do tipo RespostaServico contendo uma propriedade chamada "resposta" do tipo T passado na chamada do metodo</returns>
        public async Task<RespostaServico<T>> GetAsync<T>(string url, List<KeyValuePair<string, string>> headers)
        {
            try
            {
                var _handler = new HttpClientHandler();
                _handler.ServerCertificateCustomValidationCallback =
                    (message, certificate, chain, sslPolicyErrors) => true;

                using (var client = new HttpClient(_handler))
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }

                    using (var response = await client.GetAsync(_urlAPIRaiz + url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                            var objeto = JsonSerializer.Deserialize<T>(ProdutoJsonString, new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } });
                            return new RespostaServico<T>
                            {
                                Resposta = objeto,
                                HttpStatus = response.StatusCode.ToString(),
                                Sucesso = true,
                                Mensagem = ""
                            };
                        }
                        else
                        {
                            return new RespostaServico<T>
                            {
                                HttpStatus = response.StatusCode.ToString(),
                                Sucesso = false,
                                Mensagem = response.ReasonPhrase
                            };
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return new RespostaServico<T>
                {
                    HttpStatus = ex.StatusCode.ToString(),
                    Sucesso = false,
                    Mensagem = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new RespostaServico<T>
                {
                    HttpStatus = "400",
                    Sucesso = false,
                    Mensagem = ex.Message
                };
            }
        }

        /// <summary>
        /// Metodo para requisicoes via Put
        /// </summary>
        /// <typeparam name="T">Tipo generico que deve ser passado para que esta classe construa um objeto deste vindo da API</typeparam>
        /// <param name="item">Objeto a ser enviado para a API</param>
        /// <param name="url">Endereco completo da API</param>
        /// <param name="headers">Cabeçalhos a serem utilizados no formato "string" "string"</param>
        /// <returns>Objeto do tipo RespostaServico contendo uma propriedade chamada "resposta" do tipo T passado na chamada do metodo</returns>
        public async Task<RespostaServico<T>> PutAsync<T>(object item, string url, List<KeyValuePair<string, string>> headers)
        {
            try
            {
                var json = JsonSerializer.Serialize(item);
                var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

                var _handler = new HttpClientHandler();
                _handler.ServerCertificateCustomValidationCallback =
                    (message, certificate, chain, sslPolicyErrors) => true;

                using (var client = new HttpClient(_handler))
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }

                    using (var response = await client.PutAsync(_urlAPIRaiz + url, conteudo))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                            var objeto = JsonSerializer.Deserialize<T>(ProdutoJsonString);
                            return new RespostaServico<T>
                            {
                                Resposta = objeto,
                                HttpStatus = response.StatusCode.ToString(),
                                Sucesso = true,
                                Mensagem = ""
                            };
                        }
                        else
                        {
                            return new RespostaServico<T>
                            {
                                HttpStatus = response.StatusCode.ToString(),
                                Sucesso = false,
                                Mensagem = response.ReasonPhrase
                            };
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return new RespostaServico<T>
                {
                    HttpStatus = ex.StatusCode.ToString(),
                    Sucesso = false,
                    Mensagem = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new RespostaServico<T>
                {
                    HttpStatus = "400",
                    Sucesso = false,
                    Mensagem = ex.Message
                };
            }
        }

        /// <summary>
        /// Metodo para requisicoes via Delete
        /// </summary>
        /// <typeparam name="T">Tipo generico que deve ser passado para que esta classe construa um objeto deste vindo da API</typeparam>
        /// <param name="item">Objeto a ser enviado para a API</param>
        /// <param name="url">Endereco completo da API</param>
        /// <param name="headers">Cabeçalhos a serem utilizados no formato "string" "string"</param>
        /// <returns>Objeto do tipo RespostaServico contendo uma propriedade chamada "resposta" do tipo T passado na chamada do metodo</returns>
        public async Task<RespostaServico<T>> DeleteAsync<T>(object item, string url, List<KeyValuePair<string, string>> headers)
        {
            try
            {
                var json = JsonSerializer.Serialize(item);
                var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

                var _handler = new HttpClientHandler();
                _handler.ServerCertificateCustomValidationCallback =
                    (message, certificate, chain, sslPolicyErrors) => true;

                using (var client = new HttpClient(_handler))
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }

                    var request = new HttpRequestMessage
                    {
                        Content = conteudo,
                        Method = HttpMethod.Delete,
                        RequestUri = new Uri(_urlAPIRaiz + url)
                    };

                    using (var response = await client.SendAsync(request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                            var objeto = JsonSerializer.Deserialize<T>(ProdutoJsonString);
                            return new RespostaServico<T>
                            {
                                Resposta = objeto,
                                HttpStatus = response.StatusCode.ToString(),
                                Sucesso = true,
                                Mensagem = ""
                            };
                        }
                        else
                        {
                            return new RespostaServico<T>
                            {
                                HttpStatus = response.StatusCode.ToString(),
                                Sucesso = false,
                                Mensagem = response.ReasonPhrase
                            };
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return new RespostaServico<T>
                {
                    HttpStatus = ex.StatusCode.ToString(),
                    Sucesso = false,
                    Mensagem = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new RespostaServico<T>
                {
                    HttpStatus = "400",
                    Sucesso = false,
                    Mensagem = ex.Message
                };
            }
        }

        public async Task<RespostaServico<T>> PostAnonymousAsync<T>(object item, string url)
        {
            var json = JsonSerializer.Serialize(item);
            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

            var _handler = new HttpClientHandler();
            _handler.ServerCertificateCustomValidationCallback =
                (message, certificate, chain, sslPolicyErrors) => true;

            using (var client = new HttpClient(_handler))
            {
                using (var response = await client.PostAsync(_urlAPIRaiz + url, conteudo))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                        var objeto = JsonSerializer.Deserialize<T>(ProdutoJsonString);
                        return new RespostaServico<T>
                        {
                            Resposta = objeto,
                            HttpStatus = response.StatusCode.ToString(),
                            Sucesso = true,
                            Mensagem = ""
                        };
                    }
                    else
                    {
                        return new RespostaServico<T>
                        {
                            HttpStatus = response.StatusCode.ToString(),
                            Sucesso = false,
                            Mensagem = response.ReasonPhrase
                        };
                    }
                }
            }
        }
    }
}

