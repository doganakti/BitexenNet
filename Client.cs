namespace BitexenNet;
using BitexenNet.Models;
using System.Text.Json;
using System;
using BitexenNet.Helpers;
using BitexenNet.Extensions;
using BitexenNet.Services;

public class Client
{

    HttpService httpService;
    PrivateHttpService privateHttpService;

    const string BaseUrl = "https://www.bitexen.com/api/v1";

    public Client()
    {
        httpService = new HttpService(credentials: null);
        privateHttpService = new PrivateHttpService(credentials: null);
    }

    public Client(string apiKey, string userName, string passphrase, string secretKey)
    {
        var credentials = new Credentials(apiKey, userName, passphrase, secretKey);
        httpService = new HttpService(credentials: null);
        privateHttpService = new PrivateHttpService(credentials);
    }

    public List<Market>? GetMarkets()
    {
        var url = $"{BaseUrl}/market_info/";
        var result = httpService.Get<MarketsData>(url);
        return result!.Data!.Markets;
    }

    public Market GetMarket(string marketCode)
    {
        var url = $"{BaseUrl}/market_info/{marketCode}/";
        var result = httpService.Get<MarketData>(url);
        return result!.Data!.Market!;
    }

    public List<Ticker>? GetTickers()
    {
        var url = $"{BaseUrl}/ticker/";
        var result = httpService.Get<TickersData>(url);
        return result!.Data!.Tickers;
    }

    public Ticker GetTicker(string marketCode)
    {
        var url = $"{BaseUrl}/ticker/{marketCode}/";
        var result = httpService.Get<TickerData>(url);
        return result!.Data!.Ticker!;
    }

    public OrderBookData GetOrderBook(string marketCode)
    {
        var url = $"{BaseUrl}/order_book/{marketCode}/";
        var result = httpService.Get<OrderBookData>(url);
        return result!.Data!;
    }

    public Dictionary<string, TokenBalance>? GetBalance(string accountName = "")
    {
        var url = $"{BaseUrl}/balance/{accountName}";
        var result = privateHttpService.Get<BalancesData>(url);
        return result!.Data!.Balances;
    }

    public List<Order>? GetOrders(string accountName = "Main", OrderStatus orderStatus = OrderStatus.All, string marketCode = "", int? pageNumber = null)
    {
        var url = $"{BaseUrl}/orders/{accountName}/{orderStatus.DisplayName()}/{marketCode}/{pageNumber}";
        var result = privateHttpService.Get<OrdersData>(url);
        return result!.Data!.Orders;
    }

    public Order? GetOrder(string orderId)
    {
        var url = $"{BaseUrl}/order_status/{orderId}/";
        var result = privateHttpService.Get<OrderData>(url);
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
        var result = privateHttpService.Post<OrderData>(url, data: data);
        return result!.Data!.Order!;
    }

    public string CancelOrder(string orderId)
    {
        var url = $"{BaseUrl}/cancel_order/{orderId}/";
        var result = privateHttpService.Post<MessageData>(url, null);
        return result!.Data!.Message!;
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
        var result = privateHttpService.Post<MessageData>(url, data: data);
        return result!.Data!.Message!;
    }


}