using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using FunpayGold.WorkerCommon.Handlers;
using Zennolab.CapMonsterCloud;
using Zennolab.CapMonsterCloud.Requests;

namespace FunpayGold.WorkerApplication;

public class Startup
{

    private readonly string Login = "rbwrghewwg";

    private readonly string Password = "D!w$R8B@dhV#@+-";

    private WebOperator webHanlder = new WebOperator();
    public void StartWorker()
    {

        TestXnet();
    }

    public void TestXnet()
    {
        var clientOptions = new ClientOptions
        {
            ClientKey = "8bef49a3d936364c3a808aee14339658"
        };

        // var bots = new List<ThreadBotModel>();

        var href = "https://funpay.com/account/login";

        var url = "https://funpay.com/";

        var req = webHanlder.CreateReq();

        req.AcceptEncoding = "gzip, deflate";

        req.Referer = url;

        req.UserAgent = "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/105.0.0.0 Mobile Safari/537.36";

        req.AddHeader("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");

        var response = webHanlder.GetRequest(req, href);

        var csrfToken = Regex.Match(response.ToString(), "csrf-token&quot;:&quot;(.*?)&quot;").Groups[1].Value;

        var login = "rbwrghewwg";

        var password = "2288227";

        var captchaSiteKey = Regex.Match(response.ToString(), "g-recaptcha\" data-sitekey=\"(.*?)\"").Groups[1].Value;

        var cmCloudClient = CapMonsterCloudClientFactory.Create(clientOptions);

        // solve RecaptchaV2 (without proxy)
        var recaptchaV2Request = new RecaptchaV2ProxylessRequest
        {
            WebsiteUrl = href,
            WebsiteKey = captchaSiteKey,
        };
        var recaptchaV2Result = cmCloudClient.SolveAsync(recaptchaV2Request, CancellationToken.None).Result;

        var postProf =
            $"csrf_token={csrfToken}&login={login}&password={password}&g-recaptcha-response={recaptchaV2Result.Solution.Value}";

        var responseLog = webHanlder.PostRequest(req, href, postProf, "application/x-www-form-urlencoded");

       // response = webHanlder.GetRequest(req, url);
    }

    private void RegisterWorker()
    {

    }

    private void GetNewBot()
    {

    }

    private void GetAllMyBots()
    {

    }
}