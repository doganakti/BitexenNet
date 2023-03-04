namespace BitexenNet;
using BitexenNet.Models;
using System.Text.Json;
using System;
using BitexenNet.Helpers;
using BitexenNet.Extensions;

public class Client
{

    HttpHelper httpHelper;

    const string BaseUrl = "https://www.bitexen.com/api/v1";

    public Client()
    {
        httpHelper = new HttpHelper(credentials: null);
    }

    public Client(string apiKey, string userName, string passphrase, string secretKey)
    {
        var credentials = new Credentials(apiKey, userName, passphrase, secretKey);
        httpHelper = new HttpHelper(credentials: credentials);
    }

    public Dictionary<string, TokenBalance>? GetBalance(string accountName = "")
    {
        var url = $"{BaseUrl}/balance/{accountName}";
        var result = httpHelper.Get<Result>(url);
        return result!.Data!.Balances;
    }

    public List<Order>? GetOrders(string accountName = "Main", OrderStatus orderStatus = OrderStatus.All, string marketCode = "", int? pageNumber = null)
    {
        var url = $"{BaseUrl}/orders/{accountName}/{orderStatus.DisplayName()}/{marketCode}/{pageNumber}";
        var result = httpHelper.Get<Result>(url);
        return result!.Data!.Orders;
    }

    public Order? GetOrder(string orderId)
    {
        var url = $"{BaseUrl}/order_status/{orderId}/";
        var result = httpHelper.Get<Result>(url);
        return result!.Data!.Order;
    }

    public Order CreateOrder(OrderType orderType, string marketCode, string volume, OrderSide orderSide, string price, long clientId = 0, bool postOnly = false, string accountName = "Main")
    {
        var url = $"{BaseUrl}/orders/";
        var data = new Dictionary<string, string>
        {
            { "order_type", orderType.DisplayName() },
            { "market_code", marketCode },
            { "volume", volume },
            { "buy_sell", orderSide.DisplayName() },
            { "price", price },
            { "client_id", clientId.ToString() },
            { "post_only", postOnly.ToString() },
            { "account_name", accountName }
        };
        var result = httpHelper.Post<Result>(url, data: data);
        return result!.Data!.Order!;
    }

    public Order CancelOrder(string orderId)
    {
        var url = $"{BaseUrl}/cancel_order/{orderId}/";
        var result = httpHelper.Post<Result>(url, null);
        return result!.Data!.Order!;
    }

    public string CreateWithdrawRequest(string currencyCode, string amount, string alias)
    {
        var url = $"{BaseUrl}/withdrawal/request/";
        var data = new Dictionary<string, string>
        {
            { "currency_code", currencyCode },
            { "amount", amount },
            { "alias", alias }
        };
        var result = httpHelper.Post<Result>(url, data: data);
        return result!.Data!.Message!;
    }


}