using Moq;
using Romarinho.Domain.Model;
using Romarinho.Infra;

namespace Romarinho.Testes;

public class ApiServiceTestes
{
    [Fact]
    public async System.Threading.Tasks.Task PostAsyncTeste()
    {
        try
        {
            var mock = new Mock<IApiService>();
            var objeto = new Ordem { Quantidade = 1, Valor = 1 };
            var url = "http://localhost:3001/ordem";
            var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };
            mock.Setup(m => m.PostAsync<Ordem>(objeto, url, headers)).Returns(Task.FromResult(new RespostaServico<Ordem> { Sucesso = true }));

            var apiClient = mock.Object;
            var response = await apiClient.PostAsync<Ordem>(objeto, url, headers);

            if (response.Sucesso)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }
        catch (Exception ex)
        {
            Assert.True(false);
        }
    }

    [Fact]
    public async System.Threading.Tasks.Task GetAsyncTeste()
    {
        try
        {
            var mock = new Mock<IApiService>();
            var url = "http://localhost:3001/ordem/1";
            var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };
            mock.Setup(m => m.GetAsync<Ordem>(url, headers)).Returns(Task.FromResult(new RespostaServico<Ordem> { Sucesso = true }));

            var apiClient = mock.Object;
            
            var response = await apiClient.GetAsync<Ordem>(url, headers);

            if (response.Sucesso)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }
        catch (Exception ex)
        {
            Assert.True(false);
        }
    }

    [Fact]
    public async System.Threading.Tasks.Task PutAsyncTeste()
    {
        try
        {
            var mock = new Mock<IApiService>();
            var objeto = new Ordem { Quantidade = 1, Valor = 1 };
            var url = "http://localhost:3001/ordem";
            var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

            mock.Setup(m => m.PutAsync<Ordem>(objeto, url, headers)).Returns(Task.FromResult(new RespostaServico<Ordem> { Sucesso = true }));

            var apiClient = mock.Object;
            var response = await apiClient.PutAsync<Ordem>(objeto, url, headers);

            if (response.Sucesso)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }
        catch (Exception ex)
        {
            Assert.True(false);
        }
    }

    [Fact]
    public async System.Threading.Tasks.Task DeleteAsyncTeste()
    {
        try
        {
            var mock = new Mock<IApiService>();
            var url = "http://localhost:3001/ordem/1";
            var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

            mock.Setup(m => m.DeleteAsync<Ordem>(url, headers)).Returns(Task.FromResult(new RespostaServico<Ordem> { Sucesso = true }));

            var apiClient = mock.Object;
            var response = await apiClient.DeleteAsync<Ordem>(url, headers);

            if (response.Sucesso)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }
        catch (Exception ex)
        {
            Assert.True(false);
        }
    }

    [Fact]
    public async System.Threading.Tasks.Task SuccessPostAsyncTeste()
    {
        try
        {
            var apiClient = new ApiService();
            var objeto = new { StatusCodeEsperadoConsiderandoUsuarioLogado = "200" };
            var url = "http://localhost:3001/ordem";
            var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

            var response = await apiClient.PostAsync<Ordem>(objeto, url, headers);

            if (response.Sucesso)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }
        catch (Exception ex)
        {
            Assert.True(false);
        }
    }

    [Fact]
    public async System.Threading.Tasks.Task SuccessGetAsyncTeste()
    {
        try
        {
            var apiClient = new ApiService();
            var url = "http://localhost:3001/ordem?StatusCodeEsperadoConsiderandoUsuarioLogado=200";
            var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

            var response = await apiClient.GetAsync<Ordem>(url, headers);

            if (response.Sucesso)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }
        catch (Exception ex)
        {
            Assert.True(false);
        }
    }

    [Fact]
    public async System.Threading.Tasks.Task SuccessPutAsyncTeste()
    {
        try
        {
            var apiClient = new ApiService();
            var objeto = new { StatusCodeEsperadoConsiderandoUsuarioLogado = "200" };
            var url = "http://localhost:3001/ordem";
            var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

            var response = await apiClient.PutAsync<Ordem>(objeto, url, headers);

            if (response.Sucesso)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }
        catch (Exception ex)
        {
            Assert.True(false);
        }
    }

    [Fact]
    public async System.Threading.Tasks.Task SuccessDeleteAsyncTeste()
    {
        try
        {
            var apiClient = new ApiService();
            var url = "http://localhost:3001/ordem?StatusCodeEsperadoConsiderandoUsuarioLogado=200";
            var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

            var response = await apiClient.DeleteAsync<Ordem>(url, headers);

            if (response.Sucesso)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }
        catch (Exception ex)
        {
            Assert.True(false);
        }
    }

    [Fact]
    public async System.Threading.Tasks.Task UnauthorizedPostAsyncTeste()
    {
        try
        {
            var apiClient = new ApiService();
            var objeto = new { StatusCodeEsperadoConsiderandoUsuarioLogado = "401" };
            var url = "http://localhost:3001/ordem";
            var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

            var response = await apiClient.PostAsync<Ordem>(objeto, url, headers);

            if (response.HttpStatus == "Unauthorized")
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }
        catch (Exception ex)
        {
            Assert.True(false);
        }
    }

    [Fact]
    public async System.Threading.Tasks.Task UnauthorizedGetAsyncTeste()
    {
        try
        {
            var apiClient = new ApiService();
            var url = "http://localhost:3001/ordem?StatusCodeEsperadoConsiderandoUsuarioLogado=401";
            var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

            var response = await apiClient.GetAsync<Ordem>(url, headers);

            if (response.HttpStatus == "Unauthorized")
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }
        catch (Exception ex)
        {
            Assert.True(false);
        }
    }

    [Fact]
    public async System.Threading.Tasks.Task UnauthorizedPutAsyncTeste()
    {
        try
        {
            var apiClient = new ApiService();
            var objeto = new { StatusCodeEsperadoConsiderandoUsuarioLogado = "401" };
            var url = "http://localhost:3001/ordem";
            var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

            var response = await apiClient.PutAsync<Ordem>(objeto, url, headers);

            if (response.HttpStatus == "Unauthorized")
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }
        catch (Exception ex)
        {
            Assert.True(false);
        }
    }

    [Fact]
    public async System.Threading.Tasks.Task UnauthorizedDeleteAsyncTeste()
    {
        try
        {
            var apiClient = new ApiService();
            var url = "http://localhost:3001/ordem?StatusCodeEsperadoConsiderandoUsuarioLogado=401";
            var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

            var response = await apiClient.DeleteAsync<Ordem>(url, headers);

            if (response.HttpStatus == "Unauthorized")
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }
        catch (Exception ex)
        {
            Assert.True(false);
        }
    }

    [Fact]
    public async System.Threading.Tasks.Task NotFoundMockPostAsyncTeste()
    {
        try
        {
            var apiClient = new ApiService();
            var objeto = new { StatusCodeEsperadoConsiderandoUsuarioLogado = "404" };
            var url = "http://localhost:3001/ordem";
            var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

            var response = await apiClient.PostAsync<Ordem>(objeto, url, headers);

            if (response.HttpStatus == "NotFound")
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }
        catch (Exception ex)
        {
            Assert.True(false);
        }
    }

    [Fact]
    public async System.Threading.Tasks.Task NotFoundMockGetAsyncTeste()
    {
        try
        {
            var apiClient = new ApiService();
            var url = "http://localhost:3001/ordem?StatusCodeEsperadoConsiderandoUsuarioLogado=404";
            var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

            var response = await apiClient.GetAsync<Ordem>(url, headers);

            if (response.HttpStatus == "NotFound")
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }
        catch (Exception ex)
        {
            Assert.True(false);
        }
    }

    [Fact]
    public async System.Threading.Tasks.Task NotFoundMockPutAsyncTeste()
    {
        try
        {
            var apiClient = new ApiService();
            var objeto = new { StatusCodeEsperadoConsiderandoUsuarioLogado = "404" };
            var url = "http://localhost:3001/ordem";
            var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

            var response = await apiClient.PutAsync<Ordem>(objeto, url, headers);

            if (response.HttpStatus == "NotFound")
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }
        catch (Exception ex)
        {
            Assert.True(false);
        }
    }

    [Fact]
    public async System.Threading.Tasks.Task NotFoundMockDeleteAsyncTeste()
    {
        try
        {
            var apiClient = new ApiService();
            var url = "http://localhost:3001/ordem?StatusCodeEsperadoConsiderandoUsuarioLogado=404";
            var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

            var response = await apiClient.DeleteAsync<Ordem>(url, headers);

            if (response.HttpStatus == "NotFound")
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }
        catch (Exception ex)
        {
            Assert.True(false);
        }
    }

    [Fact]
    public async System.Threading.Tasks.Task InternalServerErrorPostAsyncTeste()
    {
        try
        {
            var apiClient = new ApiService();
            var objeto = new { StatusCodeEsperadoConsiderandoUsuarioLogado = "500" };
            var url = "http://localhost:3001/ordem";
            var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

            var response = await apiClient.PostAsync<Ordem>(objeto, url, headers);

            if (response.HttpStatus == "InternalServerError")
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }
        catch (Exception ex)
        {
            Assert.True(false);
        }
    }

    [Fact]
    public async System.Threading.Tasks.Task InternalServerErrorGetAsyncTeste()
    {
        try
        {
            var apiClient = new ApiService();
            var url = "http://localhost:3001/ordem?StatusCodeEsperadoConsiderandoUsuarioLogado=500";
            var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

            var response = await apiClient.GetAsync<Ordem>(url, headers);

            if (response.HttpStatus == "InternalServerError")
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }
        catch (Exception ex)
        {
            Assert.True(false);
        }
    }

    [Fact]
    public async System.Threading.Tasks.Task InternalServerErrorPutAsyncTeste()
    {
        try
        {
            var apiClient = new ApiService();
            var objeto = new { StatusCodeEsperadoConsiderandoUsuarioLogado = "500" };
            var url = "http://localhost:3001/ordem";
            var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

            var response = await apiClient.PutAsync<Ordem>(objeto, url, headers);

            if (response.HttpStatus == "InternalServerError")
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }
        catch (Exception ex)
        {
            Assert.True(false);
        }
    }

    [Fact]
    public async System.Threading.Tasks.Task InternalServerErrorDeleteAsyncTeste()
    {
        try
        {
            var apiClient = new ApiService();
            var url = "http://localhost:3001/ordem?StatusCodeEsperadoConsiderandoUsuarioLogado=500";
            var headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", "token")
                };

            var response = await apiClient.DeleteAsync<Ordem>(url, headers);

            if (response.HttpStatus == "InternalServerError")
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }
        catch (Exception ex)
        {
            Assert.True(false);
        }
    }
}