# Currency-Converter
Practical project for my college where we had to build a currency converter 

## Overview
The app populates 2x drop down lists from an API. Select your 2 currencies and then hit the convert button to see the result

## Technology used

C#

## Featured Code
Consuming the exchange rate API
```C#
public Dictionary<string, double> GetCurrencyCollection()
        {
            // init a new webclient
            WebClient client = new WebClient();
            // download the Json from the Exchange API

            reply = client.DownloadString(
                "https://openexchangerates.org/api/latest.json?app_id=c7f171d1499e4a71a4d358c9ed877c59");
            // init the Root class and deserialize the Json
            MyDeserializedClass = JsonConvert.DeserializeObject<Root>(reply);

            // return the rates as a dictionary
            var currencyCollection = MyDeserializedClass.rates
                .GetType()
                .GetProperties()
                .ToDictionary(
                    x => x.Name,
                    x => (double)x.GetValue(MyDeserializedClass.rates));  //possible null exception here but it's caught in the try catch onForm Load

            return currencyCollection;

        }

```
