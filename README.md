### Bitexen API .Net Client Library

This client library is built for .net framework to connect Bitexen Trading API. All the public and private methods included that is accessible on [bitexen api documentation](https://docs.bitexen.com).

#### Public Methods

Public methods don't require authorization so client can be initialized without parameters.

```c#
using BitexenNet;
var client = new Client();
```

```c#
var markets = client.GetMarkets();
var market = client.GetMarket(marketCode: "market_code");
var tickers = client.GetTickers(marketCode: );
var ticker = client.GetTicker(marketCode: "market_code");
var orderBook = client.getOrderBook(marketCode: "market_code");
```

#### Private Methods

Private methods requires authorization parameters while initializing client.

```c#
using BitexenNet;
var client = new Client(apiKey: "api_key", userName: "user_name", passphrase: "passphrase", secretKey: "secret_key");
```

```c#
var balance = client.GetBalance(accountName: "account_name");
var orders = client.GetOrders(accountName: "account_name", orderStatus: "open_closed_all", marketCode: "market_code", pageNumber = 1);
var order = client.GetOrder(orderId: "order_id");
var order = client.CreateOrder(orderType: "limit_market", marketCode: "market_code", volume: "volume", orderSide: "buy_sell", price: "price", clientId: 0, postOnly: false, accountName: "Main");
var message = client.CancelOrder(orderId: "order_id");
var message = client.CreateWithdrawRequest(currencyCode: "currency_code", amount: "amount", alias: "alias");
```
