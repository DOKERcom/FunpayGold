using System.Net;
using Leaf.xNet;

namespace FunpayGold.WorkerCommon.Handlers;

public class WebOperator
{

    public HttpRequest CreateReq()
    {
        var req = new HttpRequest();
        
        return req;
    }

    public HttpResponse GetRequest(HttpRequest req, string href)
    {
        var response = req.Get(href);

        return response;
    }

    public HttpResponse PostRequest(HttpRequest req, string href, string? str = null, string? contentType = null)
    {
        var response = req.Post(href, str, contentType);

        return response;
    }

    private HttpRequest SetProxy(HttpRequest req, string proxy)
    {
        var proxyInfo = proxy.Split(':');

        req.Proxy = new HttpProxyClient(proxyInfo[0], Convert.ToInt32(proxyInfo[1]), proxyInfo[2], proxyInfo[3]);

        return req;
    }
}